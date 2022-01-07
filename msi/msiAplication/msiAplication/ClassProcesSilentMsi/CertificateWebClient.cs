using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace msiAplication.ClassProcesSilentMsi
{
    public class CertificateWebClient : WebClient
    {
        private readonly X509Certificate2 certificate;

        public CertificateWebClient(X509Certificate2 cert)
        {
            certificate = cert;
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);

            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (Object obj, X509Certificate X509certificate, X509Chain chain, System.Net.Security.SslPolicyErrors errors)
            {
                return true;
            };

            request.ClientCertificates.Add(certificate);
            return request;
        }
    }
}
