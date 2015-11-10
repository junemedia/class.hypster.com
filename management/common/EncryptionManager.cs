using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Collections;
using System.IO;
using System.Security.Cryptography;

namespace hypster_tv_DAL
{
    public class EncryptionManager
    {

        public EncryptionManager()
        {
        }



        public static string DecryptString(string Message, string Passphrase)
        {
            string _retString = "";
            byte[] Results = null;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            try
            {

                // Step 1. We hash the passphrase using MD5 
                // We use the MD5 hash generator as the result is a 128 bit byte array 
                // which is a valid length for the TripleDES encoder we use below 
                MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
                byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));
                // Step 2. Create a new TripleDESCryptoServiceProvider object 
                TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
                // Step 3. Setup the decoder 
                TDESAlgorithm.Key = TDESKey;
                TDESAlgorithm.Mode = CipherMode.ECB;
                TDESAlgorithm.Padding = PaddingMode.PKCS7;

                try
                {
                    // Step 4. Convert the input string to a byte[] 
                    byte[] DataToDecrypt = Convert.FromBase64String(Message);

                    // Step 5. Attempt to decrypt the string 
                    ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                    Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);

                }
                finally
                {
                    // Clear the TripleDes and Hashprovider services of any sensitive information 
                    TDESAlgorithm.Clear();
                    HashProvider.Clear();
                }

                _retString = UTF8.GetString(Results);
            }
            catch (Exception ex)
            {
                string PARAMS = "";
                try
                {
                    PARAMS = Message.ToString();
                }
                catch (Exception exp)
                {
                    PARAMS = exp.Message.ToString();
                }
                //Error.Write_To_Txtlog("Helper:DecryptString", ex.Message.ToString(), PARAMS);
            }
            finally
            {
            }

            // Step 6. Return the decrypted string in UTF8 format 
            return _retString;
        }


        public static string EncryptString(string Message, string Passphrase)
        {
            byte[] Results = null;

            try
            {
                System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

                // Step 1. We hash the passphrase using MD5 
                // We use the MD5 hash generator as the result is a 128 bit byte array 
                // which is a valid length for the TripleDES encoder we use below 
                MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();

                byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

                // Step 2. Create a new TripleDESCryptoServiceProvider object 
                TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

                // Step 3. Setup the encoder 
                TDESAlgorithm.Key = TDESKey;

                TDESAlgorithm.Mode = CipherMode.ECB;
                TDESAlgorithm.Padding = PaddingMode.PKCS7;

                // Step 4. Convert the input string to a byte[] 
                byte[] DataToEncrypt = UTF8.GetBytes(Message);


                // Step 5. Attempt to encrypt the string 
                try
                {
                    ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                    Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
                }
                finally
                {
                    // Clear the TripleDes and Hashprovider services of any sensitive information 
                    TDESAlgorithm.Clear();
                    HashProvider.Clear();
                }

            }
            catch (Exception ex)
            {
                string PARAMS = "";

                try
                {
                }
                catch (Exception exp)
                {
                    PARAMS = exp.Message.ToString();
                }
                //Error.Write_To_Txtlog("Helper:EncryptString", ex.Message.ToString(), PARAMS);
            }
            finally
            { }


            // Step 6. Return the encrypted string as a base64 encoded string 
            return Convert.ToBase64String(Results);
        }



    }
}
