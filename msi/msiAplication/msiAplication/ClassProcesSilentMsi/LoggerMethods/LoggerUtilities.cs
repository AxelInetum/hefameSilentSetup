﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace msiAplication.ClassProcesSilentMsi.LoggerMethods
{
    public class LoggerUtilities
    {

        public LoggerUtilities()
        {

        }

        private bool ExistFolderLogger(string path)
        {
            return Directory.Exists(path);
        }

        public void CreateFolderLogger(string path)
        {
            if (!this.ExistFolderLogger(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public bool ExistFileLogger(string path)
        {
            return File.Exists(path);
        }

        public void WriteFileMethodLogger(string path, string exception)
        {
            using (var tw = new StreamWriter(path, true))
            {
                this.AddDatasFile(tw, exception);
            }
        }

        public void CreateFileMethodLogger(string path,  string exception)
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                this.AddDatasFile(sw, exception);
            }
        }

        private void AddDatasFile(StreamWriter tw, string exception)
        {
            tw.WriteLine("El programa no ha podido realizar la actualización con la siguiente excepción: ");
            tw.WriteLine(exception);
            tw.WriteLine("Con fecha y hora :" + DateTime.Now.ToString());
        }  
        
    }
}