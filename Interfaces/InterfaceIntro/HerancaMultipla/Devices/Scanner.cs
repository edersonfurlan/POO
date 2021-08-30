using System;

namespace HerancaMultipla.Devices
{
    class Scanner : Device, IScanner
    {
        public string Scan()
        {
            return "Scanner can result";
        }
        
        public override void ProcessDoc(string document)
        {
            Console.WriteLine("Scanner processing: " + document);
        }
    }
}
