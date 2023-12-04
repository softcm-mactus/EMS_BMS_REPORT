using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportsSetup
{
    public class InstallInfo
    {
        public class WebInfo
        {
            public string name { get; set; }
            public string path { get; set; }
            public int port { get; set; }
        }
        public WebInfo webInfo = new WebInfo();
        public class AppInfo
        {
            public string path { get; set; }
            public string service { get; set; }
        }
        public AppInfo appInfo = new AppInfo();
        public class DBInfo
        {
            public string database { get; set; }
            public string server { get; set; }
            public string port { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public string type { get; set; }
            public string connectionString { get; set; }
        }
        public DBInfo dbInfo { get; set; }
        public DBInfo eboInfo { get; set; }
        public DateTime installDate { get; set; }
        public DateTime updateDate { get; set; }
        public InstallInfo() {

            appInfo = new AppInfo();
            dbInfo = new DBInfo();
            eboInfo = new DBInfo();
            installDate = DateTime.Now;
            updateDate = DateTime.Now;
            webInfo.name = "MactusReports";
            webInfo.path = "C:\\WebSites\\MactusReports";
            webInfo.port = 105;
            appInfo.path = "D:\\Mactus\\Reports";
            appInfo.service = "Mactus EMS Reports";

            dbInfo.database = "";
            dbInfo.server = "localhost";
            dbInfo.port = "";
            dbInfo.username = "Mactus";
            dbInfo.password = "Mactus@123";
            dbInfo.type = "SQLServer";
            dbInfo.connectionString = "";

            eboInfo.database = "";
            eboInfo.server = "localhost";
            eboInfo.port = "";
            eboInfo.type= "SQLServer";
            eboInfo.username = "Mactus";
            eboInfo.password = "Mactus@123";
            eboInfo.connectionString = "";
        }
        public void decryptPasswords()
        {
            eboInfo.password = decryptPassword(eboInfo.password);
            dbInfo.password= decryptPassword(dbInfo.password);
        }
        public void encryptPasswords()
        {
            eboInfo.password = encryptPassword(eboInfo.password);
            dbInfo.password = encryptPassword(dbInfo.password);
        }
        public string decryptPassword(string cipherString)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes("mactus33ddbsdsjdudssd@!24123"));
            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();

            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        public string encryptPassword(string toEncrypt)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes("mactus33ddbsdsjdudssd@!24123"));
            hashmd5.Clear();
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

    }
}
