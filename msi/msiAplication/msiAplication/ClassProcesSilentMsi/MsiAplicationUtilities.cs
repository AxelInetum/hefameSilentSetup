using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace msiAplication.ClassProcesSilentMsi
{
    public class MsiAplicationUtilities
    {
        public MsiAplicationUtilities()
        {

        }

        public int CompareVersions(Version currentversion, Version theLastVersionHttps)
        {
            return currentversion.CompareTo(theLastVersionHttps);
        }

        public void MoveMsiOldErVersionFolder()
        {
            string origin = "C:\\proyectos\\ControlSetup\\SilentMsi\\hefameSilentSetup\\msi\\msiAplication\\NewVersionMsi\\HefameSetup.msi";
            string destiny = "C:\\proyectos\\ControlSetup\\SilentMsi\\hefameSilentSetup\\msi\\msiAplication\\OldVersionMsi\\HefameSetup.msi";
            File.Copy(origin, destiny, true);
        }
    }
}
