using System;
using System.Security.Cryptography;
using System.Text;

namespace Common.Core.Helper
{
    public class Encriptado
    {
        private const string KEY = "NRCTEg1Jpk";
        public static string Encriptar(string texto)
        {
            byte[] keyArray;
            byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(texto);

            //Se utilizan las clases de encriptación MD5
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(KEY));
            hashmd5.Clear();

            //Algoritmo TripleDES
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();

            byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);

            tdes.Clear();

            //se regresa el resultado en forma de una cadena
            texto = Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);
            return texto;
        }

        public static string Desencriptar(string textoEncriptado)
        {

            byte[] keyArray;
            byte[] Array_a_Descifrar = Convert.FromBase64String(textoEncriptado);

            //algoritmo MD5
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(KEY));

            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();

            byte[] resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);

            tdes.Clear();
            textoEncriptado = UTF8Encoding.UTF8.GetString(resultArray);
            return textoEncriptado;
        }
    }
}
