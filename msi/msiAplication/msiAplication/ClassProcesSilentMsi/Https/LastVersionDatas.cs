using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace msiAplication.ClassProcesSilentMsi
{
    public class LastVersionDatas
    {
        public string url;
        public string ThelastVersion;

        public LastVersionDatas()
        {
            url = "https://localhost:443/HefameSetup.msi";
            ThelastVersion = "1.1.2";
        }
    }

}


