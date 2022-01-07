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
        public string httpRemotServer = "";
        private WebClient client;

        public HttpsMethods(string url )
        {
            httpRemotServer = url;
            client = new WebClient();
        }

        public void HttpsDownloadNewVersionMsi(string completeUrl,string newMsiVersion)
        {
           client.DownloadFile(completeUrl, @"C:\Users\x40369pi\Desktop\LastVersion\" + newMsiVersion +".msi");
        }
        public bool HttpsCorrectDownloafileNewVersionMsi(string newMsiVersion)
        {
            return File.Exists(@"C:\Users\x40369pi\Desktop\LastVersion\" + newMsiVersion + ".msi");
        }
    }
}
