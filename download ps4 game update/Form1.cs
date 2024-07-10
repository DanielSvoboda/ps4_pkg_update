using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace download_ps4_game_update
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Check_Updates(object sender, EventArgs e)
        {
            if (textBox_HMAC_SHA256_Patch_Pkg_URL_Key.Text.Length != 64)
            {
                MessageBox.Show($"HMAC_SHA256_Patch_Pkg_URL_Key invalid\nMust contain 64 characters!");
                return;
            }

            string TitleId = textBox1_TitleId.Text;
            if (TitleId.Length != 9)
            {
                MessageBox.Show($"Title ID: {TitleId} invalid\nMust contain 9 characters!\nCorrect example: CUSA00001");
                return;
            }

            string xmlUrl = $"https://gs-sec.ww.np.dl.playstation.net/plo/np/{TitleId}/{GetHash(TitleId)}/{TitleId}-ver.xml";

            try
            {
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlUrl);

                XmlNode titleNode = xmlDoc.SelectSingleNode("/titlepatch/tag/package[@version]");
                string title = titleNode.SelectSingleNode("paramsfo/title").InnerText;
                string version = titleNode.Attributes["version"].Value;

                double sizeBytes = Convert.ToDouble(titleNode.Attributes["size"].Value);
                double sizeMB = sizeBytes / (1024 * 1024);

                XmlNode system_ver = xmlDoc.SelectSingleNode("/titlepatch/tag/package/@system_ver");
                string hexadecimal = int.Parse(system_ver.Value).ToString("X8");
                string system_ver_formatted = $"{hexadecimal.Substring(0, 2)}.{hexadecimal.Substring(2, 2)}";

                textBox1_Result.Text = "";
                textBox1_Result.Text += $"Title: {title}\r\n";
                textBox1_Result.Text += $"Version: {version}\r\n";
                textBox1_Result.Text += $"Required Firmware: {system_ver_formatted}\r\n";

                Action<double> displaySize = size =>
                    textBox1_Result.Text += $"PKG Size: {(size > 1024 ? $"{size / 1024:0.##} GB" : $"{size:0.##} MB")}\r\n\r\n";
                displaySize(sizeMB);

                XmlNode manifestNode = xmlDoc.SelectSingleNode("/titlepatch/tag/package/@manifest_url");
                if (manifestNode == null)
                {
                    throw new Exception("Manifest URL not found in XML.");
                }

                using (var client = new WebClient())
                {
                    string json = client.DownloadString(manifestNode.Value);

                    int index = json.IndexOf("\"pieces\":");
                    if (index < 0)
                    {
                        throw new Exception("Expected JSON format not found.");
                    }
                    json = json.Substring(index + "\"pieces\":".Length);

                    int urlStartIndex = json.IndexOf("\"url\":\"");
                    while (urlStartIndex >= 0)
                    {
                        urlStartIndex += "\"url\":\"".Length;
                        int urlEndIndex = json.IndexOf("\"", urlStartIndex);
                        string packageUrl = json.Substring(urlStartIndex, urlEndIndex - urlStartIndex);

                        textBox1_Result.Text += $"{packageUrl}\r\n";

                        urlStartIndex = json.IndexOf("\"url\":\"", urlEndIndex);
                    }
                }
                //textBox1_Result.Text += $"\r\nxmlUrl: {xmlUrl}\r\n";
                //textBox1_Result.Text += $"manifestUrl: {manifestUrl}\r\n";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading and parsing XML: {ex.Message}");
            }
            finally
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = null;
            }
        }

        private string GetHash(string gameID)
        {
            byte[] byteKey = StringToByteArray(textBox_HMAC_SHA256_Patch_Pkg_URL_Key.Text);
            byte[] dataBytes = Encoding.UTF8.GetBytes($"np_{gameID}");

            using (var hmacsha256 = new HMACSHA256(byteKey))
            {
                byte[] hashBytes = hmacsha256.ComputeHash(dataBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        public static byte[] StringToByteArray(string hex)
        {
            int numberChars = hex.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }

        private void linkLabel_github_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/DanielSvoboda/download_ps4_game_update");
        }
    }
}
