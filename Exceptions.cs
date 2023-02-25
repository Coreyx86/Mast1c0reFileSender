using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mast1c0reFileLoader
{
    public class PayloadInfoValidationException : Exception
    {
        public PayloadInfoValidationException() : base()
        {

        }

        public PayloadInfoValidationException(string a_errorMessage) : base(a_errorMessage)
        {

        }
    }

    public class IpSettingsValidationException : Exception
    {
        public IpSettingsValidationException() : base()
        {

        }

        public IpSettingsValidationException(string a_errorMessage) : base(a_errorMessage)
        {

        }
    }
}
