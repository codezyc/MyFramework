using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CommonLibary
{
    /// <summary>
    /// C#加密解密常用操作
    /// </summary>
    public static class CryptographicUtils
    {
        #region MD5加密相关
        /// <summary>
        /// 16位MD5加密
        /// </summary>
        /// <param name="str">待加密内容</param>
        /// <param name="charset">编码方式</param>
        /// <returns>加密后的字符串</returns>
        public static string MD5Encrypt16(string str, string charset)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(Encoding.GetEncoding(charset).GetBytes(str), 4, 8);
            string encrypt = Encoding.GetEncoding(charset).GetString(result);
            return encrypt.Replace("-", "");
        }

        /// <summary>
        /// 32位MD5加密
        /// </summary>
        /// <param name="str">待加密内容</param>
        /// <param name="charset">编码方式</param>
        /// <returns>加密后的字符串</returns>
        public static string Md5Encrypt32(string str, string charset)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(Encoding.GetEncoding(charset).GetBytes(str));
            string encrypt = Encoding.GetEncoding(charset).GetString(result);
            return encrypt.Replace("-", "");
        }

        /// <summary>
        /// MD5加盐加密
        /// </summary>
        /// <param name="str">待加密字符串</param>
        /// <param name="charset">编码方式</param>
        /// <param name="salt">盐值</param>
        /// <returns>加密后的字符串</returns>
        public static string MD5EncryptWithSalt(string str, string charset, string salt)
        {
            if (string.IsNullOrEmpty(salt)) return string.Empty;
            return Md5Encrypt32(str + salt, charset);
        }

        /// <summary>
        /// 计算文件的MD5值
        /// </summary>
        /// <param name="filepath">文件路径</param>
        /// <returns></returns>
        public static string GetFileMD5(string filepath)
        {
            if (File.Exists(filepath))
            {
                using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                    byte[] hash = md5.ComputeHash(fs);
                    string result = BitConverter.ToString(hash);
                    result.Replace("-", "");
                    return result;
                }
            }
            return string.Empty;
        }

        #endregion

        #region SHA1加密相关
        /// <summary>
        /// SHA1加密字符串
        /// </summary>
        /// <param name="str">待加密字符串</param>
        /// <param name="charset">编码方式</param>
        /// <returns>加密后的字符串</returns>
        public static string SHA1Encrypt(string str, string charset)
        {
            byte[] bytes = Encoding.GetEncoding(charset).GetBytes(str);
            HashAlgorithm hashalgorithm = new SHA1CryptoServiceProvider();
            bytes = hashalgorithm.ComputeHash(bytes);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                sb.AppendFormat("{0:x2}", b);
            }
            return sb.ToString();
        }

        #endregion

        #region DES加密解密相关
        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="str">待加密字符串</param>
        /// <param name="contentcharset">字符串编码方式</param>
        /// <param name="keycharset">密钥的编码方式</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        public static string DESEncrypt(string str, string contentcharset, string keycharset, string key)
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                byte[] inputbyte = Encoding.GetEncoding(contentcharset).GetBytes(str);
                des.Key = ASCIIEncoding.GetEncoding(keycharset).GetBytes(key);
                des.IV = ASCIIEncoding.GetEncoding(keycharset).GetBytes(key);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(inputbyte, 0, inputbyte.Length);
                        cs.FlushFinalBlock();
                    }
                    string encryptstr = Convert.ToBase64String(ms.ToArray());
                    return encryptstr;
                }
            }
        }

        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="str">待解密字符串</param>
        /// <param name="contentcharset">字符串编码方式</param>
        /// <param name="key">密钥</param>
        /// <param name="keycharset">密钥编码方式</param>
        /// <returns></returns>
        public static string DESDecrypt(string str, string contentcharset, string key, string keycharset)
        {
            byte[] inputbyte = Convert.FromBase64String(str);
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = ASCIIEncoding.GetEncoding(keycharset).GetBytes(key);
                des.IV = ASCIIEncoding.GetEncoding(keycharset).GetBytes(key);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(inputbyte, 0, inputbyte.Length);
                        cs.FlushFinalBlock();
                    }
                    string decryptstr = Encoding.GetEncoding(contentcharset).GetString(ms.ToArray());
                    return decryptstr;
                }
            }
        }
        #endregion

        #region TripleDES加密解密相关
        /// <summary>
        /// 3DES加密字符串
        /// </summary>
        /// <param name="str">待加密字符串</param>
        /// <param name="contentcharset">字符串编码方式</param>
        /// <param name="key">密钥</param>
        /// <param name="keycharset">密钥编码方式</param>
        /// <returns>加密后的字符串</returns>
        public static string TripleDESEncrypt(string str, string contentcharset, string key, string keycharset)
        {
            using (var tripledes = new TripleDESCryptoServiceProvider())
            {
                tripledes.Padding = PaddingMode.PKCS7;
                tripledes.Mode = CipherMode.CBC;
                byte[] contentbytes = Encoding.GetEncoding(contentcharset).GetBytes(str);
                byte[] keybytes = Encoding.GetEncoding(keycharset).GetBytes(key);
                byte[] ivbytes = Encoding.GetEncoding(keycharset).GetBytes(key);
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, tripledes.CreateEncryptor(keybytes, ivbytes), CryptoStreamMode.Write))
                    {
                        cs.Write(contentbytes, 0, contentbytes.Length);
                        cs.FlushFinalBlock();
                    }
                    string encryptstr = Convert.ToBase64String(ms.ToArray());
                    return encryptstr;
                }
            }
        }

        /// <summary>
        /// 3DES解密字符串
        /// </summary>
        /// <param name="str">待解密字符串</param>
        /// <param name="contentcharset">字符串编码方式</param>
        /// <param name="key">密钥</param>
        /// <param name="keycharset">密钥编码方式</param>
        /// <returns></returns>
        public static string TripleDESDecrypt(string str, string contentcharset, string key, string keycharset)
        {
            using (var tripledes = new TripleDESCryptoServiceProvider())
            {
                tripledes.Padding = PaddingMode.PKCS7;
                tripledes.Mode = CipherMode.CBC;
                byte[] contentbytes = Encoding.GetEncoding(contentcharset).GetBytes(str);
                byte[] keybytes = Encoding.GetEncoding(keycharset).GetBytes(key);
                byte[] ivbytes = Encoding.GetEncoding(keycharset).GetBytes(key);
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, tripledes.CreateDecryptor(keybytes, ivbytes), CryptoStreamMode.Write))
                    {
                        cs.Write(contentbytes, 0, contentbytes.Length);
                        cs.FlushFinalBlock();
                    }
                    string decryptstr = Encoding.GetEncoding(contentcharset).GetString(ms.ToArray());
                    return decryptstr;
                }
            }
        }

        #endregion

        #region AES加密解密
        /// <summary>
        /// AES加密字符串
        /// </summary>
        /// <param name="str">待加密字符串</param>
        /// <param name="contentcharset">字符串编码方式</param>
        /// <param name="key">密钥</param>
        /// <param name="keycharset">密钥的编码方式</param>
        /// <param name="iv">IV</param>
        /// <param name="ivcharset">IV的编码方式</param>
        /// <returns></returns>
        public static string AESEncrypt(string str, string contentcharset, string key, string keycharset, string iv,
            string ivcharset)
        {
            using (SymmetricAlgorithm symm = Rijndael.Create())
            {
                byte[] contentbytes = Encoding.GetEncoding(contentcharset).GetBytes(str);
                byte[] keybytes = Encoding.GetEncoding(keycharset).GetBytes(key);
                byte[] ivbytes = Encoding.GetEncoding(ivcharset).GetBytes(iv);
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, symm.CreateEncryptor(keybytes, ivbytes), CryptoStreamMode.Write))
                    {
                        cs.Write(contentbytes, 0, contentbytes.Length);
                        cs.FlushFinalBlock();
                    }
                    string encryptstr = Convert.ToBase64String(ms.ToArray());
                    return encryptstr;
                }
            }
        }

        /// <summary>
        /// AES解密字符串
        /// </summary>
        /// <param name="str">待解密字符串</param>
        /// <param name="contentcharset">字符串编码方式</param>
        /// <param name="key">密钥</param>
        /// <param name="keycharset">密钥的编码方式</param>
        /// <param name="iv">IV</param>
        /// <param name="ivcharset">IV的编码方式</param>
        /// <returns></returns>
        public static string AESDecrypt(string str, string contentcharset, string key, string keycharset, string iv,
            string ivcharset)
        {
            using (SymmetricAlgorithm symm = Rijndael.Create())
            {
                byte[] contentbytes = Encoding.GetEncoding(contentcharset).GetBytes(str);
                byte[] keybytes = Encoding.GetEncoding(keycharset).GetBytes(key);
                byte[] ivbytes = Encoding.GetEncoding(ivcharset).GetBytes(iv);
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, symm.CreateDecryptor(keybytes, ivbytes), CryptoStreamMode.Write))
                    {
                        cs.Write(contentbytes, 0, contentbytes.Length);
                        cs.FlushFinalBlock();
                    }
                    string encryptstr = Convert.ToBase64String(ms.ToArray());
                    return encryptstr;
                }
            }
        }

        #endregion
    }
}
