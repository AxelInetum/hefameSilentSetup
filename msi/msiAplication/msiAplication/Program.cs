using System;
using System.Diagnostics;
using System.Threading;
using msiAplication.ClassProcesSilentMsi;

namespace msiAplication
{
    class Program
    {
        static void Main(string[] args)
        {    
            //desde visual basic llamariamos a este metodo para incializar el proceso
            ProcessSilentMsi.InitProcessSilentMsi();        
        } 
    }
}
