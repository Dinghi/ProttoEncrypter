using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProttoEncrypter
{
    public partial class ProttoCrypter : Form
    {
        public class StringCipher
        {
            private const int Keysize = 256;

            private const int DerivationIterations = 1000;

            public string Encrypt(string plainText, string passPhrase)
            {
                var saltStringBytes = Generate256BitsOfRandomEntropy();
                var ivStringBytes = Generate256BitsOfRandomEntropy();
                var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
                {
                    var keyBytes = password.GetBytes(Keysize / 8);
                    using (var symmetricKey = new RijndaelManaged())
                    {
                        symmetricKey.BlockSize = 256;
                        symmetricKey.Mode = CipherMode.CBC;
                        symmetricKey.Padding = PaddingMode.PKCS7;
                        using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                                {
                                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                    cryptoStream.FlushFinalBlock();
                                    // Create the final bytes as a concatenation of the random salt bytes, the random iv bytes and the cipher bytes.
                                    var cipherTextBytes = saltStringBytes;
                                    cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
                                    cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                    memoryStream.Close();
                                    cryptoStream.Close();
                                    return Convert.ToBase64String(cipherTextBytes);
                                }
                            }
                        }
                    }
                }
            }

            public string Decrypt(string cipherText, string passPhrase)
            {
                var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
                var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
                var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
                var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();

                using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
                {
                    var keyBytes = password.GetBytes(Keysize / 8);
                    using (var symmetricKey = new RijndaelManaged())
                    {
                        symmetricKey.BlockSize = 256;
                        symmetricKey.Mode = CipherMode.CBC;
                        symmetricKey.Padding = PaddingMode.PKCS7;
                        using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
                        {
                            using (var memoryStream = new MemoryStream(cipherTextBytes))
                            {
                                using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                                {
                                    var plainTextBytes = new byte[cipherTextBytes.Length];
                                    var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                    memoryStream.Close();
                                    cryptoStream.Close();
                                    return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                                }
                            }
                        }
                    }
                }
            }

            private byte[] Generate256BitsOfRandomEntropy()
            {
                var randomBytes = new byte[32];
                using (var rngCsp = new RNGCryptoServiceProvider())
                {
                    rngCsp.GetBytes(randomBytes);
                }
                return randomBytes;
            }
        }
        public ProttoCrypter()
        {
            InitializeComponent();
        }

        private void CryptaButton_Click(object sender, EventArgs e)
        {
            var testoCifrato = CryptaTesto(NormalText.Text, PassphraseText.Text);
            NormalText.Text = "";
            EncrypterText.Text = testoCifrato;
        }

        public string CryptaTesto(string contenuto, string passphase)
        {
            string testoCryptato = "";
            StringCipher cifratore = new StringCipher();
            try
            {
                if (string.IsNullOrEmpty(contenuto)) throw new Exception("Testo da cryptare vuoto!");
                if (string.IsNullOrEmpty(passphase)) throw new Exception("Passphase vuota!");
                testoCryptato = cifratore.Encrypt(contenuto, passphase);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Errore Cryptazione", MessageBoxButtons.OK);
            }

            return testoCryptato;
        }
        public string DecryptaTesto(string contenuto, string passphase)
        {
            string testoDecryptato = "";
            StringCipher cifratore = new StringCipher();
            try
            {
                if (string.IsNullOrEmpty(contenuto)) throw new Exception("Testo da decrittare vuoto!");
                if (string.IsNullOrEmpty(passphase)) throw new Exception("Passphase vuota!");
                testoDecryptato = cifratore.Decrypt(contenuto, passphase);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Errore decrittazione", MessageBoxButtons.OK);
            }

            return testoDecryptato;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DecryptaButton_Click(object sender, EventArgs e)
        {
            var testoDecrittato = DecryptaTesto(EncrypterText.Text, PassphraseText.Text);
            EncrypterText.Text = "";
            NormalText.Text = testoDecrittato;
        }
    }
}
