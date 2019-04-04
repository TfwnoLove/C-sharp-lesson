using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogMODBUS
{
    public class LogProperties
    {
        public string Number { get; set; }

        public string Time { get; set; }

        public string AppName { get; set; }
        public string IRP { get; set; }

        public string Serial0 { get; set; }

        public string ErrorType { get; set; }

        public string Length { get; set; }

        public string Adress  { get; set; }//FE

        public string Command { get; set; }//46

        public string Crc { get; set; }//46
    }
}
