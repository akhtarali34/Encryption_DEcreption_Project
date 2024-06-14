using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace CryptoGraphy
{
    public partial class Form1 : Form
    {
        // Define your AES key and IV as byte arrays
        private byte[] aesKey = Convert.FromBase64String("F2VP3Rh00fnXOerCnr7v2VIGfHxv8eBTlHE09e9E5J0="); // Replace with your actual key
        private byte[] aesIV = Convert.FromBase64String("Z71kAlxh7ImS62/V5V1mSg=="); // Replace with your actual IV

        public Form1()
        {
            InitializeComponent();
        }

        private void browseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filepath.Text = openFileDialog.FileName;
            }
        }

        private void Encryptfile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filepath.Text))
            {
                MessageBox.Show("Please select a file to encrypt.");
                return;
            }

            try
            {
                EncryptFile(filepath.Text);
                MessageBox.Show("File encrypted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Encryption failed: " + ex.Message);
            }
        }

        private void decryptFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filepath.Text))
            {
                MessageBox.Show("Please select a file to decrypt.");
                return;
            }

            try
            {
                DecryptFile(filepath.Text);
                MessageBox.Show("File decrypted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Decryption failed: " + ex.Message);
            }
        }

        private void EncryptFile(string filePath)
        {
            byte[] plainBytes = File.ReadAllBytes(filePath);
            byte[] encryptedBytes;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = aesKey;
                aesAlg.IV = aesIV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(plainBytes, 0, plainBytes.Length);
                        csEncrypt.FlushFinalBlock();
                        encryptedBytes = msEncrypt.ToArray();
                    }
                }
            }

            // Save or use encryptedBytes as needed
            File.WriteAllBytes(filePath + ".encrypted", encryptedBytes);
        }

        private void DecryptFile(string filePath)
        {
            byte[] encryptedBytes = File.ReadAllBytes(filePath);
            byte[] decryptedBytes;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = aesKey;
                aesAlg.IV = aesIV;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(encryptedBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (MemoryStream msPlainText = new MemoryStream())
                        {
                            csDecrypt.CopyTo(msPlainText);
                            decryptedBytes = msPlainText.ToArray();
                        }
                    }
                }
            }

            // Save or use decryptedBytes as needed
            File.WriteAllBytes(filePath.Replace(".encrypted", ".decrypted"), decryptedBytes);
        }
    }
}
