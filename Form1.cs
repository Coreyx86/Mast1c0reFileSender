using Newtonsoft.Json;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Mast1c0reFileLoader
{
    public partial class Form1 : Form
    {
        private Loader m_loader = new();
        private const string c_fileStep0 = "Open a file to send";
        private const string c_fileStep1 = "Send payload!";
        private const string c_fileStepSending = "Sending please wait...";
        private const string c_fileStepSendError = "Failed to send";
        private const string c_fileStepSuccess = "Payload sent!";

        private string m_filePath = string.Empty;

        public Form1()
        {
            InitializeComponent();
            HandleCreated += Form1_HandleCreated;
        }

        #region Event Handlers
        private void Form1_HandleCreated(object a_sender, EventArgs a_e)
        {
            LoadSettings();
        }

        private void textBox_filePath_DoubleClick(object sender, EventArgs e)
        {
            //If there is a file loaded, open the folder
            if (!string.IsNullOrEmpty(m_filePath))
            {
                Process proc = new();
                proc.StartInfo.FileName = m_filePath;
                proc.StartInfo.UseShellExecute = true;
                proc.Start();
            }
        }

        private void button_clearFile_Click(object sender, EventArgs e)
        {
            //TODO: Clear the target file info here
            UpdateFilePathText("");
            SetFileButtonStatus(false);
            SetFileStepText(c_fileStep0);
        }

        private void button_sendFile_Click(object a_sender, EventArgs a_e)
        {
            try
            {
                SetFileStepText(c_fileStepSending);
                UpdateIpSettings();
                Task.Run(() =>
                {
                    m_loader.SendPayload(m_filePath);
                    Invoke(() => SetFileStepText(c_fileStepSuccess));
                });
            }
            catch (Exception e)
            {
                SetFileStepText(c_fileStepSendError);
                MessageBox.Show($"Failed to send payload to the targed.\n{e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //TODO: Log the exception details somewhere
            }
        }

        private void button_openFile_Click(object sender, EventArgs e)
        {
            //TODO: Open the file, do any validation if necessary, enable the other buttons
            OpenFileDialog ofd = new();
            ofd.Filter = "PS2 File (*.elf,*.iso)|*.elf;*.iso";
            ofd.Multiselect = false;
            ofd.Title = "Choose a payload";
            ofd.InitialDirectory = Application.StartupPath;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //Update the other controls now that we have a payload
                SetFileButtonStatus(true);
                UpdateFilePathText(ofd.FileName); //Updates m_filePath as well
                SetFileStepText(c_fileStep1);
                textBox_filePath.Enabled = true;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs a_e)
        {
            if (a_e.Data.GetData(DataFormats.FileDrop) is string[] data && data.Length > 0)
            {
                string filePath = data[0];
                if (filePath.EndsWith(".iso") || filePath.EndsWith(".bin") || filePath.EndsWith(".elf"))
                {
                    UpdateFilePathText(filePath);
                    SetFileButtonStatus(true);
                    textBox_filePath.Enabled = true;
                    SetFileStepText(c_fileStep1);
                }
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void button_saveSettings_Click(object a_sender, EventArgs a_e)
        {
            UpdateIpSettings();
        }
        #endregion



        /// <summary>
        /// Deserializes the settings file and updates the UI
        /// </summary>
        private void LoadSettings()
        {
            try
            {
                if (File.Exists(Loader.SettingsFilePath))
                {
                    string settingsData = File.ReadAllText(Loader.SettingsFilePath);
                    IpSettings ipSettings = JsonConvert.DeserializeObject<IpSettings>(settingsData);

                    textBox_ip.Text = ipSettings.Ip;
                    numericUpDown_port.Value = ipSettings.Port;

                    if(!string.IsNullOrEmpty(ipSettings.LastPayloadPath) && File.Exists(ipSettings.LastPayloadPath))
                    {
                        UpdateFilePathText(ipSettings.LastPayloadPath);
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show($"Failed to load the settings file.\n{e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Various helper functions
        private void UpdateFilePathText(string a_newText)
        {
            m_filePath = a_newText;
            textBox_filePath.Text = a_newText;
        }

        private void SetFileButtonStatus(bool a_enabled)
        {
            button_clearFile.Enabled = a_enabled;
            button_sendFile.Enabled = a_enabled;
        }

        private void SetFileStepText(string a_newText)
        {
            label_fileStep.Text = a_newText;
        }

        private void UpdateIpSettings()
        {
            try
            {
                m_loader.UpdateIpSettings(new()
                {
                    Ip = textBox_ip.Text,
                    Port = (short)numericUpDown_port.Value
                });
            }
            catch(Exception e)
            {
                MessageBox.Show($"Failed to save ip settings.\n{e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}