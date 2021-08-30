using System;

namespace HerancaMultipla.Devices
{
    class ComboDevice : Device, IScanner, IPrinter
    {
        public override void ProcessDoc(string document)
        {
            Console.WriteLine("ComboDevice processing " + document);
        }
                
        public string Scan()
        {
            return "Combodevice scan result";
        }

        public void Print(string document)
        {
            Console.WriteLine("ComboDevice print " + document);
        }
    }
}
