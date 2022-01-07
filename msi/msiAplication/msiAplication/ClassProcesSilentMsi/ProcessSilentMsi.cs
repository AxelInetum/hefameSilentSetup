using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace msiAplication.ClassProcesSilentMsi
{
    public class ProcessSilentMsi
    {
        public static void InitProcessSilentMsi()
        {
            //version actual del aplicativo 
            int currentVersion = 0;
            //objeto para obtener los metodos para instalar y desinstalar el msi de manera silenciosa 
            SilentMsiMethods ProcessSilentMsiMethods;
            //objeto para obtener los metodos para acceso al servidor https (descargar de la version nueva del msi)
            HttpsMethods HttpsMethods;
            //representa el web service que nos devolvera un objeto con la url del https y la ultima version guardada en base de datos
            LastVersionDatas LastVersionDatas = new LastVersionDatas();
            //comparamos la version actual con la remota (si la version actual es inferior generamos el proceso)
            if (currentVersion < LastVersionDatas.ThelastVersion)
            {
                //creamos el objeto para llamar el metodo que descargar la nueva version del msi a nuestra maquina local 
                HttpsMethods = new HttpsMethods(LastVersionDatas.url, LastVersionDatas.ThelastVersion.ToString());
                //bajamos la version del msi del https 
                HttpsMethods.HttpsDownloadNewVersionMsi();

                //comprobamos que se ha descargado correctamente comprobando que localmente existe el fichero 
                if (HttpsMethods.HttpsCorrectDownloafileNewVersionMsi())
                {
                    ProcessSilentMsiMethods = new SilentMsiMethods();
                    ProcessSilentMsiMethods.DesinstallOldLocalAplicationMsi(LastVersionDatas.ThelastVersion.ToString());
                    ProcessSilentMsiMethods.InstallNewLocalAplicationMsi(LastVersionDatas.ThelastVersion.ToString());
                    Environment.Exit(0);
                    /*ProcessSilentMsiMethods.OpenNewApplicationMsi();*/
                }
            }
        }
    }
}
