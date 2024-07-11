namespace download_ps4_game_update
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1_TitleId = new System.Windows.Forms.TextBox();
            this.label_TitleID = new System.Windows.Forms.Label();
            this.textBox1_Result = new System.Windows.Forms.TextBox();
            this.button_check_updates = new System.Windows.Forms.Button();
            this.label_HMAC_SHA256_Patch_Pkg_URL_Key = new System.Windows.Forms.Label();
            this.textBox_HMAC_SHA256_Patch_Pkg_URL_Key = new System.Windows.Forms.TextBox();
            this.linkLabel_github = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1_TitleId
            // 
            this.textBox1_TitleId.Location = new System.Drawing.Point(201, 31);
            this.textBox1_TitleId.Name = "textBox1_TitleId";
            this.textBox1_TitleId.Size = new System.Drawing.Size(70, 20);
            this.textBox1_TitleId.TabIndex = 0;
            // 
            // label_TitleID
            // 
            this.label_TitleID.AutoSize = true;
            this.label_TitleID.Location = new System.Drawing.Point(21, 34);
            this.label_TitleID.Name = "label_TitleID";
            this.label_TitleID.Size = new System.Drawing.Size(174, 13);
            this.label_TitleID.TabIndex = 3;
            this.label_TitleID.Text = "Title ID (in this format CUSA00001):";
            // 
            // textBox1_Result
            // 
            this.textBox1_Result.Location = new System.Drawing.Point(12, 57);
            this.textBox1_Result.Multiline = true;
            this.textBox1_Result.Name = "textBox1_Result";
            this.textBox1_Result.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1_Result.Size = new System.Drawing.Size(1166, 263);
            this.textBox1_Result.TabIndex = 5;
            // 
            // button_check_updates
            // 
            this.button_check_updates.Location = new System.Drawing.Point(277, 29);
            this.button_check_updates.Name = "button_check_updates";
            this.button_check_updates.Size = new System.Drawing.Size(106, 23);
            this.button_check_updates.TabIndex = 7;
            this.button_check_updates.Text = "Check Updates";
            this.button_check_updates.UseVisualStyleBackColor = true;
            this.button_check_updates.Click += new System.EventHandler(this.button2_Check_Updates);
            // 
            // label_HMAC_SHA256_Patch_Pkg_URL_Key
            // 
            this.label_HMAC_SHA256_Patch_Pkg_URL_Key.AutoSize = true;
            this.label_HMAC_SHA256_Patch_Pkg_URL_Key.Location = new System.Drawing.Point(12, 9);
            this.label_HMAC_SHA256_Patch_Pkg_URL_Key.Name = "label_HMAC_SHA256_Patch_Pkg_URL_Key";
            this.label_HMAC_SHA256_Patch_Pkg_URL_Key.Size = new System.Drawing.Size(183, 13);
            this.label_HMAC_SHA256_Patch_Pkg_URL_Key.TabIndex = 9;
            this.label_HMAC_SHA256_Patch_Pkg_URL_Key.Text = "HMAC-SHA256 Patch Pkg URL Key:";
            // 
            // textBox_HMAC_SHA256_Patch_Pkg_URL_Key
            // 
            this.textBox_HMAC_SHA256_Patch_Pkg_URL_Key.Location = new System.Drawing.Point(201, 6);
            this.textBox_HMAC_SHA256_Patch_Pkg_URL_Key.Name = "textBox_HMAC_SHA256_Patch_Pkg_URL_Key";
            this.textBox_HMAC_SHA256_Patch_Pkg_URL_Key.Size = new System.Drawing.Size(424, 20);
            this.textBox_HMAC_SHA256_Patch_Pkg_URL_Key.TabIndex = 8;
            // 
            // linkLabel_github
            // 
            this.linkLabel_github.AutoSize = true;
            this.linkLabel_github.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.linkLabel_github.Location = new System.Drawing.Point(1087, 9);
            this.linkLabel_github.Name = "linkLabel_github";
            this.linkLabel_github.Size = new System.Drawing.Size(89, 13);
            this.linkLabel_github.TabIndex = 61;
            this.linkLabel_github.TabStop = true;
            this.linkLabel_github.Text = "Access on github";
            this.linkLabel_github.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_github_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1113, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "Version: 2.0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 332);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabel_github);
            this.Controls.Add(this.label_HMAC_SHA256_Patch_Pkg_URL_Key);
            this.Controls.Add(this.textBox_HMAC_SHA256_Patch_Pkg_URL_Key);
            this.Controls.Add(this.button_check_updates);
            this.Controls.Add(this.textBox1_Result);
            this.Controls.Add(this.label_TitleID);
            this.Controls.Add(this.textBox1_TitleId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Download PS4 Game Update";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1_TitleId;
        private System.Windows.Forms.Label label_TitleID;
        private System.Windows.Forms.TextBox textBox1_Result;
        private System.Windows.Forms.Button button_check_updates;
        private System.Windows.Forms.Label label_HMAC_SHA256_Patch_Pkg_URL_Key;
        private System.Windows.Forms.TextBox textBox_HMAC_SHA256_Patch_Pkg_URL_Key;
        private System.Windows.Forms.LinkLabel linkLabel_github;
        private System.Windows.Forms.Label label1;
    }
}

