using msiAplication.ClassProcesSilentMsi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using msiAplication.ClassProcesSilentMsi.LoggerMethods;

namespace msiAplication.ClassProcesSilentMsi
{
    public class ProcessSilentMsi
    {
        public static void InitProcessSilentMsi()
        {
            Ilogger _loggerMethodObject = new LoggerMethod();
            try
            {        
                //version actual del aplicativo 
                string currentVersion = "1.1";
                //objeto para obtener los metodos para instalar y desinstalar el msi de manera silenciosa 
                SilentMsiMethods ProcessSilentMsiMethods;
                //objeto para obtener los metodos para acceso al servidor https (descargar de la version nueva del msi)
                HttpsMethods HttpsMethods;
                //representa el web service que nos devolvera un objeto con la url del https y la ultima version guardada en base de datos
                LastVersionDatas lastVersionDatas = new LastVersionDatas();
                //utilidades que utilizara el aplicativo 
                MsiAplicationUtilities MsiAplicationUtilities = new MsiAplicationUtilities();
                //cojemos la version actual y la ultima version , pasamos los dos a objeto version
                Version currentversion = new Version(currentVersion);
                Version theLastVersionHttps = new Version(lastVersionDatas.ThelastVersion);
                //comparamos la version actual con la remota (si la version actual es inferior generamos el proceso)
                if (MsiAplicationUtilities.CompareVersions(currentversion,theLastVersionHttps) < 0)
                {
                    //creamos el objeto para llamar el metodo que descargar la nueva version del msi a nuestra maquina local 
                    HttpsMethods = new HttpsMethods(lastVersionDatas.url, "HefameSetup");
                    //bajamos la version del msi del https 
                    HttpsMethods.HttpsDownloadNewVersionMsi();
                    //comprobamos que se ha descargado correctamente comprobando que localmente existe el fichero 
                    if (HttpsMethods.HttpsCorrectDownloafileNewVersionMsi())
                    {
                        ProcessSilentMsiMethods = new SilentMsiMethods("HefameSetup");
                        ProcessSilentMsiMethods.DesinstallOldLocalAplicationMsi();
                        ProcessSilentMsiMethods.InstallNewLocalAplicationMsi();
                        MsiAplicationUtilities.MoveMsiOldErVersionFolder();
                        MsiAplicationUtilities.DeleteNewVersionMsi();
                        ProcessSilentMsiMethods.OpenNewApplicationMsi();
                        Environment.Exit(0);
                    }
                }
            }
            catch (Exception ex)
            {
                _loggerMethodObject.CreateLog(ex.Message.ToString());
            }
        }
    }
}
