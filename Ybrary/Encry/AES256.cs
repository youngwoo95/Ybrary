using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Ybrary.Encry
{
    /// <summary>
    /// AES256 Encry & Decry
    /// </summary>
    public class AES256
    {
        /// <summary>
        /// AES256 - 암호화
        /// </summary>
        /// <param name="plain"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Encrypt(string plain, string key)
        {
            try
            {
                // 바이트로 변환
                byte[] plainBytes = Encoding.UTF8.GetBytes(plain);

                // 레인달 알고리즘
                RijndaelManaged rm = new RijndaelManaged();

                rm.Mode = CipherMode.CBC;
                rm.Padding = PaddingMode.PKCS7;
                rm.KeySize = 256;

                // 메모리스트림 생성
                MemoryStream memoryStream = new MemoryStream();

                // key, iv값 정의
                ICryptoTransform encryptor= rm.CreateEncryptor(Encoding.UTF8.GetBytes(key.Substring(0, 256 / 8)), Encoding.UTF8.GetBytes(key.Substring(0, 128 / 8)));
                // 크립토스트림을 키와 iv값으로 메모리스트림을 이용하여 생성
                CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

                // 크립토스트림에 바이트배열을 쓰고 플러시
                cryptoStream.Write(plainBytes, 0, plainBytes.Length);
                cryptoStream.FlushFinalBlock();

                // 메모리스트림에 담겨있는 암호화된 바이트배열을 담음
                byte[] encryptBytes = memoryStream.ToArray();

                // 베이스64로 변환
                string encryptString = Convert.ToBase64String(encryptBytes);

                // 스트림 닫기.
                cryptoStream.Close();
                memoryStream.Close();

                return encryptString;
            }
            catch(Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex.Message);
#endif
                return null;
            }
        }

        /// <summary>
        /// AES256 - 복호화
        /// </summary>
        /// <param name="plain"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Decrypt(string plain, string key)
        {
            try
            {
                // base64를 바이트로 변환
                byte[] encryptBytes = Convert.FromBase64String(plain);

                // 레인달 알고리즘
                RijndaelManaged rm = new RijndaelManaged();

                rm.Mode = CipherMode.CBC;
                rm.Padding = PaddingMode.PKCS7;
                rm.KeySize = 256;

                // 메모리스트림 생성
                MemoryStream memoryStream = new MemoryStream(encryptBytes);

                // key, iv값 정의
                ICryptoTransform decryptor = rm.CreateDecryptor(Encoding.UTF8.GetBytes(key.Substring(0, 256 / 8)), Encoding.UTF8.GetBytes(key.Substring(0, 128 / 8)));
                // 크립토스트림을 key 와 iv값으로 메모리스트림을 이용하여 생성
                CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

                // 복호화된 데이터를 담을 바이트 배열을 선언한다.
                byte[] plainBytes = new byte[encryptBytes.Length];

                int plainCount = cryptoStream.Read(plainBytes, 0, plainBytes.Length);

                // 복호화된 바이트 배열을 string으로 변환
                string plainString = Encoding.UTF8.GetString(plainBytes, 0, plainCount);

                // 스트림 닫기
                cryptoStream.Close();
                memoryStream.Close();

                return plainString;
            }
            catch(Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex.Message);
#endif
                return null;
            }
        }
    }
}
