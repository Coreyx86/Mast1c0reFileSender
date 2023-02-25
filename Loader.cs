using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Text.Json.Nodes;
using Newtonsoft.Json;

namespace Mast1c0reFileLoader
{
    internal class PayloadInfo
    {
        public string FilePath { get; set; }

        internal FileInfo FileInfo
        {
            get
            {
                if(!string.IsNullOrEmpty(FilePath))
                {
                    return new FileInfo(FilePath);
                }

                return null;
            }
        }

        public PayloadInfo(string a_filePath)
        {
            FilePath = a_filePath;
        }
    }

    internal class Loader
    {
        private const uint c_magic = 0x0000EA6E;
        private const short c_port = 9045;

        private IpSettings m_ipSettings;
        private PayloadInfo m_payloadInfo;
        private Socket m_socket;

        public static string SettingsFilePath = Application.StartupPath + "Mast1c0reFileLoader.settings.json";

        public Loader()
        {
            m_ipSettings = new();
            m_ipSettings.Port = c_port;
        }

        internal void SendPayload(string a_filePath)
        {
            PayloadInfo payloadInfo = new(a_filePath);

            ValidateIpSettings();
            ValidatePayloadInfo(payloadInfo);

            m_payloadInfo = payloadInfo;

            long fileSize = m_payloadInfo.FileInfo.Length;

            IPAddress ipAddr = IPAddress.Parse(m_ipSettings.Ip);

            using Socket socket = new(SocketType.Stream, ProtocolType.IP);
            socket.ReceiveTimeout = 3000;
            socket.Connect(ipAddr, m_ipSettings.Port);

            //Send little endian unsigned int of the MAGIC
            socket.Send(DataHelper.ConvertToLittleEndian(c_magic));

            //Send little endian ulong of the filesize
            socket.Send(DataHelper.ConvertToLittleEndian((ulong)fileSize));

            //Send the payload in 4096 byte chunks
            int chunkSize = 4096;
            long numOfBytesToRead = m_payloadInfo.FilePath.Length;
            using (FileStream fs = new(m_payloadInfo.FilePath, FileMode.Open, FileAccess.Read))
            {
                while(fileSize > 0)
                {
                    byte[] buffer = new byte[chunkSize];
                    int n = fs.Read(buffer, 0, chunkSize);

                    //EOF, break here
                    if(n == 0)
                    {
                        break;
                    }

                    socket.Send(buffer);
                    fileSize -= n;
                }
            }

            socket.Close();

            m_ipSettings.LastPayloadPath = a_filePath;
        }

        internal void UpdateIpSettings(IpSettings a_ipSettings)
        {
            ValidateIpSettings(a_ipSettings);

            m_ipSettings = a_ipSettings;

            if (File.Exists(SettingsFilePath))
            {
                File.Delete(SettingsFilePath);
            }

            string serializedSettings = JsonConvert.SerializeObject(m_ipSettings, Formatting.Indented);
            File.WriteAllText(SettingsFilePath, serializedSettings);
        }

        #region Validation
        internal void ValidatePayloadInfo(PayloadInfo a_payloadInfo)
        {
            if(string.IsNullOrEmpty(a_payloadInfo.FilePath))
            {
                throw new PayloadInfoValidationException("The payload's filepath is null or empty.");
            }

            if(a_payloadInfo.FileInfo == null)
            {
                throw new PayloadInfoValidationException($"Failed to get FileInfo of payload '{a_payloadInfo.FilePath}'.");
            }
        }

        internal void ValidatePayloadInfo()
        {
            ValidatePayloadInfo(m_payloadInfo);
        }

        internal void ValidateIpSettings(IpSettings a_ipSettings)
        {
            string ipRegex = @"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$";

            if(string.IsNullOrEmpty(a_ipSettings.Ip))
            {
                throw new IpSettingsValidationException("The configured IP address is empty or null.");
            }

            if(!Regex.IsMatch(a_ipSettings.Ip, ipRegex) || !IPAddress.TryParse(a_ipSettings.Ip, out IPAddress ipAddress))
            {
                throw new IpSettingsValidationException($"The configured IP address '{a_ipSettings.Ip}' is invalid.");
            }
        }
        internal void ValidateIpSettings()
        {
            ValidateIpSettings(m_ipSettings);
        }
        #endregion
    }
}
