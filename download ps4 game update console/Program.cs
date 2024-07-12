using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace DownloadPS4GameUpdateConsole
{
    class Program
    {
        static string urlKey = "";
        static string titleId = "";

        static void Main(string[] args)
        {
            if (args.Length < 4 || args[0] != "-key" || args[2] != "-title")
            {
                ShowHelp();
                return;
            }

            urlKey = args[1];
            titleId = args[3];

            if (urlKey.Length != 64)
            {
                Console.WriteLine($"HMAC_SHA256_Patch_Pkg_URL_Key invalid\nMust contain 64 characters!");
                return;
            }

            if (titleId.Length != 9)
            {
                Console.WriteLine($"Title ID: {titleId} invalid\nMust contain 9 characters!\nCorrect example: CUSA00001");
                return;
            }

            try
            {
                string xmlUrl = $"http://gs-sec.ww.np.dl.playstation.net/plo/np/{titleId}/{GetHash(titleId)}/{titleId}-ver.xml";

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

                Console.WriteLine($"Title: {title}");
                Console.WriteLine($"Version: {version}");
                Console.WriteLine($"Required Firmware: {system_ver_formatted}");
                Console.WriteLine($"PKG Size: {(sizeMB > 1024 ? $"{sizeMB / 1024:0.##} GB" : $"{sizeMB:0.##} MB")}");

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

                        Console.WriteLine(packageUrl);

                        urlStartIndex = json.IndexOf("\"url\":\"", urlEndIndex);
                    }
                }

                //Console.WriteLine($"\r\nxmlUrl: {xmlUrl}");
                //Console.WriteLine($"manifestUrl: {manifestNode.Value}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading and parsing XML: {ex.Message}");
            }
        }

        private static void ShowHelp()
        {
#if WINDOWS
            Console.WriteLine("Usage: ps4_pkg_update_console.exe -key <HMAC_SHA256_Patch_Pkg_URL_Key> -title <TitleId>");
#else
            Console.WriteLine("Usage: ./ps4_pkg_update_console -key <HMAC_SHA256_Patch_Pkg_URL_Key> -title <TitleId>");
#endif
        }


        private static string GetHash(string gameID)
        {
            byte[] byteKey = StringToByteArray(urlKey);
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
    }
}
