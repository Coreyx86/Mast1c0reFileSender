using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mast1c0reFileLoader
{
    public static class DataHelper
    {
        public static byte[] ConvertToLittleEndian(uint a_value)
        {
            byte[] buffer = BitConverter.GetBytes(a_value);

            if(!BitConverter.IsLittleEndian)
            {
                Array.Reverse(buffer);
            }

            return buffer;
        }

        public static byte[] ConvertToLittleEndian(ulong a_value)
        {
            byte[] buffer = BitConverter.GetBytes(a_value);

            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(buffer);
            }

            return buffer;
        }
    }
}
