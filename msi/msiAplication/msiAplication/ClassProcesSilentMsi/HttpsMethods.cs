using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace msiAplication.ClassProcesSilentMsi
{
    public class HttpsMethods
    {
        private string httpRemotServer = "";
        private WebClient client;
        private string localPathNewVersionMsi;
        private string newMsiVersion;

        public HttpsMethods(string url , string newVersionMsi)
        {
            httpRemotServer = url;
            newMsiVersion = newVersionMsi;
            client = new WebClient();
            localPathNewVersionMsi = @"C:\Users\x40369pi\Desktop\LastVersion\" + newMsiVersion + ".msi";
        }

        public void HttpsDownloadNewVersionMsi()
        {
           client.DownloadFile(httpRemotServer, localPathNewVersionMsi);




        }
        public bool HttpsCorrectDownloafileNewVersionMsi()
        {
            return File.Exists(localPathNewVersionMsi);
        }

        public static bool ValidateHttpsServerCertificate(object sender)
        {
            return true;
            /*
            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;
            else
            {
                if (System.Windows.Forms.MessageBox.Show("The server certificate is not valid.\nAccept?", "Certificate Validation", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    return true;
                else
                    return false;
            }
            */
        }
    }
}
