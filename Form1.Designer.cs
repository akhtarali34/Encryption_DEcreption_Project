namespace CryptoGraphy
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            filepath = new TextBox();
            browseFile = new Button();
            decryptFile = new Button();
            Encryptfile = new Button();
            SuspendLayout();
            // 
            // filepath
            // 
            filepath.Location = new Point(148, 96);
            filepath.Name = "filepath";
            filepath.Size = new Size(294, 31);
            filepath.TabIndex = 0;
           // filepath.TextChanged += filepath_TextChanged;
            // 
            // browseFile
            // 
            browseFile.Location = new Point(473, 97);
            browseFile.Name = "browseFile";
            browseFile.Size = new Size(112, 34);
            browseFile.TabIndex = 1;
            browseFile.Text = "...";
            browseFile.UseVisualStyleBackColor = true;
            browseFile.Click += browseFile_Click;
            // 
            // decryptFile
            // 
            decryptFile.Location = new Point(344, 208);
            decryptFile.Name = "decryptFile";
            decryptFile.Size = new Size(112, 34);
            decryptFile.TabIndex = 2;
            decryptFile.Text = "DECRYPT";
            decryptFile.UseVisualStyleBackColor = true;
            decryptFile.Click += decryptFile_Click;
            // 
            // Encryptfile
            // 
            Encryptfile.Location = new Point(198, 208);
            Encryptfile.Name = "Encryptfile";
            Encryptfile.Size = new Size(112, 34);
            Encryptfile.TabIndex = 3;
            Encryptfile.Text = "ENCRYPT";
            Encryptfile.UseVisualStyleBackColor = true;
            Encryptfile.Click += Encryptfile_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Encryptfile);
            Controls.Add(decryptFile);
            Controls.Add(browseFile);
            Controls.Add(filepath);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox filepath;
        private Button browseFile;
        private Button decryptFile;
        private Button Encryptfile;
    }
}
