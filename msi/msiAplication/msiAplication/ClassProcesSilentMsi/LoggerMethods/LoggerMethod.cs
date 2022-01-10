using msiAplication.ClassProcesSilentMsi.Interfaces;
using msiAplication.ClassProcesSilentMsi.LoggerMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace msiAplication.ClassProcesSilentMsi.LoggerMethods
{
    public class LoggerMethod : Ilogger
    {
        public LoggerUtilities _loggerUtilities = new LoggerUtilities();

        private string _filename = "Methodlogs_" + DateTime.Now.Year.ToString() + "_" +
                                  DateTime.Now.Month.ToString() + "_" +
                                  DateTime.Now.Day.ToString();

        private string _pathString = "";
        public LoggerMethod()
        {

        }

        public void CreateLog(string exception)
        {
            //creamos el directorio de logs sino existe
            _loggerUtilities.CreateFolderLogger(@"C:\proyectos\ControlSetup\SilentMsi\hefameSilentSetup\msi\msiAplication\MethodLogs");
            //creamos la ruta completa
            this._pathString = System.IO.Path.Combine(@"C:\proyectos\ControlSetup\SilentMsi\hefameSilentSetup\msi\msiAplication\MethodLogs", this._filename);
            //si el fichelo existe por fecha y ruta grabamos en la siguiente linea 
            if (_loggerUtilities.ExistFileLogger(this._pathString))
            {
                _loggerUtilities.WriteFileMethodLogger(this._pathString, exception);
            }
            //si el fichero no existe lo creamos de nuevo
            else
            {
                _loggerUtilities.CreateFileMethodLogger(this._pathString, exception);
            }
        }
    }
}
