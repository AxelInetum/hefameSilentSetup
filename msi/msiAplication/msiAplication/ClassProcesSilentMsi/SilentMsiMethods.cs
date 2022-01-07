using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace msiAplication.ClassProcesSilentMsi
{
    public class SilentMsiMethods
    {
        public SilentMsiMethods()
        {

        }
        public void DesinstallOldLocalAplicationMsi(string VersionMsi)
        {
            //necesito el msi antiguo para desinstalarlo 
            Process process = new Process();
            process.StartInfo.FileName = "msiexec.exe";
            process.StartInfo.Arguments = "/qn /x C:\\proyectos\\ControlSetup\\SilentMsi\\hefameSilentSetup\\msi\\msiAplication\\OldVersionMsi\\" + VersionMsi +".msi";
            process.StartInfo.Verb = "runas";
            process.Start();
            process.WaitForExit();
        }

        public void InstallNewLocalAplicationMsi(string VersionMsi)
        {
            Process process = new Process();
            process.StartInfo.FileName = "msiexec.exe";
            process.StartInfo.Arguments = string.Format("/i {0} " + " /quiet /qn /log  {1}", @"C:\\proyectos\\ControlSetup\\SilentMsi\\hefameSilentSetup\\msi\\msiAplication\\NewVersionMsi\\" + VersionMsi + ".msi", @"C:\proyectos\ControlSetup\SilentMsi\hefameSilentSetup\msi\msiAplication\install.log");
            process.StartInfo.Verb = "runas";
            process.Start();
            process.WaitForExit();

        }

        public void OpenNewApplicationMsi()
        {
            Process p = new Process();
            p.StartInfo.FileName = @"C:\Program Files (x86)\Default Company Name\SilenceSetup\HefameApp\msiAplication.exe";
            p.Start();
        }
    }
}
