using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mast1c0reFileLoader
{
    public class IpSettings
    {
        public string Ip { get; set; } = string.Empty;
        public short Port { get; set; }
        public string LastPayloadPath { get; set; } = string.Empty;
    }
}
