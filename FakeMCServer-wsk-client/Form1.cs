using System.Diagnostics;
using System.Net.Http;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace FakeMCServer_wsk_client
{

    public partial class Form1 : Form
    {
        [DllImport("advapi32.dll", EntryPoint = "OpenSCManagerW", CharSet = CharSet.Unicode)]
        public static extern IntPtr OpenSCManager(string lpMachineName, string lpSCDB, int scParameter);

        [DllImport("Advapi32.dll")]
        public static extern IntPtr CreateService(IntPtr SC_HANDLE, string lpSvcName, string lpDisplayName,
int dwDesiredAccess, int dwServiceType, int dwStartType, int dwErrorControl, string lpPathName,
string lpLoadOrderGroup, int lpdwTagId, string lpDependencies, string lpServiceStartName, string lpPassword);

        [DllImport("advapi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseServiceHandle(IntPtr hSCObject);

        public Form1()
        {
            InitializeComponent();
            UpdateCombo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process myProcess = new System.Diagnostics.Process();
            myProcess.StartInfo.UseShellExecute = true;
            myProcess.StartInfo.FileName = "https://htmlcolorcodes.com/minecraft-color-codes";
            myProcess.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string MotdJSON, KickJSON;
            byte[] MotdJSONBin, KickJSONBin;
            PingData.Description KickMessage = new PingData.Description();
            if (numericUpDown3.Value != 25565)
            {
                MessageBox.Show("Updating port-number dosen't reflect in live.\nYou should restart driver manually.");
            }

            PingData pingData = new PingData();
            pingData.version = new PingData.Version();
            pingData.players = new PingData.Players();
            pingData.description = new PingData.Description();

            int port = (int)numericUpDown3.Value;
            int protocol = 340;

            try
            {
                string tmp = comboBox1.Text;
                string pattern = @"^[^\ ]*\ \(([0-9]*)\)";
                Match match = Regex.Match(tmp, pattern);
                if (match.Success)
                {
                    protocol = Int32.Parse(match.Groups[1].Value);
                }
                else throw new Exception("no match");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid value in Server Version.");
                return;
            }

            pingData.version.name = textBox1.Text == "" ? textBox1.PlaceholderText : textBox1.Text;
            pingData.version.protocol = protocol;

            pingData.players.online = (int)numericUpDown1.Value;
            pingData.players.max = (int)numericUpDown2.Value;
            pingData.players.sample = new string[] { };

            pingData.description.text = textBox6.Text == "" ? textBox6.PlaceholderText : textBox6.Text;

            MotdJSON = JsonSerializer.Serialize(pingData, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            });

            KickMessage.text = textBox3.Text == "" ? textBox3.PlaceholderText : textBox3.Text;

            KickJSON = JsonSerializer.Serialize(KickMessage, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            });


            if (MotdJSON == null || KickJSON == null)
            {
                MessageBox.Show("Invalid JSON.");
                return;
            }

            MotdJSONBin = Encoding.UTF8.GetBytes(MotdJSON);
            KickJSONBin = Encoding.UTF8.GetBytes(KickJSON);

            RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\fakemcserver");
            key.SetValue("Port", port, RegistryValueKind.DWord);
            key.SetValue("MotdJSON", MotdJSONBin, RegistryValueKind.Binary);
            key.SetValue("KickJSON", KickJSONBin, RegistryValueKind.Binary);
            key.Close();
            MessageBox.Show("Thy amendments were reflected.");

        }


        public async void UpdateCombo()
        {
            comboBox1.Items.Clear();

            using var httpClient = new HttpClient();

            try
            {
                string Url = "https://raw.githubusercontent.com/PrismarineJS/minecraft-data/master/data/pc/common/protocolVersions.json";
                var response = await httpClient.GetStringAsync(Url);
                var versions = JsonSerializer.Deserialize<MCVersionContent[]>(response);
                if (versions == null) return;

                // Example: print the version values
                foreach (var version in versions)
                {
                    if (version.usesNetty && version.minecraftVersion != null)
                    {
                        if (checkBox1.Checked || (!(version.minecraftVersion[2] == 'w') && !version.minecraftVersion.Contains("-pre") && !version.minecraftVersion.Contains("-rc")))
                        {
                            comboBox1.Items.Add(version.minecraftVersion + " (" + version.version + ")");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Minecraft Version List not available at this moment");
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCombo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IntPtr hdr = OpenSCManager(null, null, ScmAccessRights.AllAccess);
        }
    }
    public class PingData
    {
        public Version? version { get; set; }
        public Players? players { get; set; }
        public Description? description { get; set; }
        public class Version
        {
            public string? name { get; set; }
            public int protocol { get; set; }
        }
        public class Players
        {
            public int max { get; set; }
            public int online { get; set; }
            public string[]? sample { get; set; }
        }
        public class Description
        {
            public string? text { get; set; }
        }
    }
    public class MCVersionContent
    {
        public string? minecraftVersion { get; set; }
        public long version { get; set; }
        public int dataVersion { get; set; }
        public bool usesNetty { get; set; }
        public string? majorVersion { get; set; }
        public string? releaseType { get; set; }
    }
}