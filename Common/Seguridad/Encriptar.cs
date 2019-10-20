using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Common.Seguridad
{
    public static class Encriptar
    {
                
        public static string llave = "gn2kgk2l30mkmksg";
        public static string encriptar3DES(string dato, string llave) {
            
            byte[] arrayLlave = Encoding.UTF8.GetBytes(llave);
            byte[] encriptar = Encoding.UTF8.GetBytes(dato);

            var tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = arrayLlave;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultado = cTransform.TransformFinalBlock(encriptar, 0, encriptar.Length);
            tdes.Clear();

            return Convert.ToBase64String(resultado, 0, resultado.Length);

        }

        public static string desencriptar3DES(string dato, string llave) {

            byte[] arrayLlave = Encoding.UTF8.GetBytes(llave);
            byte[] desencriptar = Convert.FromBase64String(dato);

            var tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = arrayLlave;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultado = cTransform.TransformFinalBlock(desencriptar, 0, desencriptar.Length);
            tdes.Clear();

            return Encoding.UTF8.GetString(resultado);
        
        }

        public static string encriptarMD5(string pass) {
           
            MD5 md5 = MD5.Create();
            byte[] encriptar = System.Text.Encoding.ASCII.GetBytes(pass);
            byte[] hash = md5.ComputeHash(encriptar);
            pass = BitConverter.ToString(hash).Replace("-", "");
            return pass;
        }
    }
}
