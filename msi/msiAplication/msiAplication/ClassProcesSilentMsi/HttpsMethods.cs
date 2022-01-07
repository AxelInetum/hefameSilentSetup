using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace msiAplication.ClassProcesSilentMsi
{
    public class HttpsMethods
    {
        private string httpRemotServer = "";
        private WebClient client;
        private CertificateWebClient certificateWebClient;
        private string localPathNewVersionMsi;
        private string newMsiVersion;

        public HttpsMethods(string url , string newVersionMsi)
        {
            httpRemotServer = url;
            newMsiVersion = newVersionMsi;
            X509Certificate2 cert = new X509Certificate2();
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);
            certificateWebClient = new CertificateWebClient(cert);
            client = new WebClient();
            localPathNewVersionMsi = @"C:\\proyectos\\ControlSetup\\SilentMsi\\hefameSilentSetup\\msi\\msiAplication\\NewVersionMsi\\" + newMsiVersion + ".msi";
        }

        public void HttpsDownloadNewVersionMsi()
        {
            using (certificateWebClient)
            {
                client.DownloadFile(httpRemotServer, localPathNewVersionMsi);
            }
        }
        public bool HttpsCorrectDownloafileNewVersionMsi()
        {
            return File.Exists(localPathNewVersionMsi);
        }

        public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}