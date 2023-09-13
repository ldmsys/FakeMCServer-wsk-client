using System.Diagnostics;
using System.Net.Http;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.ServiceProcess;
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
        // Reference: https://gist.github.com/FusRoDah061/d04dc0bbed890ba0e93166da2b62451e
        [DllImport("advapi32.dll", EntryPoint = "OpenSCManagerW", CharSet = CharSet.Unicode)]
        static extern IntPtr OpenSCManager(string? machineName, string? databaseName, ScmAccessRights dwDesiredAccess);
        [DllImport("Advapi32.dll")]
        public static extern IntPtr CreateService(IntPtr SC_HANDLE, string lpSvcName, string lpDisplayName,
ServiceAccessRights dwDesiredAccess, int dwServiceType, int dwStartType, int dwErrorControl, string lpPathName,
string? lpLoadOrderGroup, IntPtr lpdwTagId, string? lpDependencies, string? lpServiceStartName, string? lpPassword);

        [DllImport("advapi32.dll")]
        static extern IntPtr OpenService(IntPtr hSCManager, string lpServiceName, ServiceAccessRights dwDesiredAccess);

        [DllImport("advapi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseServiceHandle(IntPtr hSCObject);

        public enum ScmAccessRights
        {
            Connect = 0x0001,
            CreateService = 0x0002,
            EnumerateService = 0x0004,
            Lock = 0x0008,
            QueryLockStatus = 0x0010,
            ModifyBootConfig = 0x0020,
            StandardRightsRequired = 0xF0000,
            AllAccess = (StandardRightsRequired | Connect | CreateService |
                         EnumerateService | Lock | QueryLockStatus | ModifyBootConfig)
        }
        public enum ServiceAccessRights
        {
            QueryConfig = 0x1,
            ChangeConfig = 0x2,
            QueryStatus = 0x4,
            EnumerateDependants = 0x8,
            Start = 0x10,
            Stop = 0x20,
            PauseContinue = 0x40,
            Interrogate = 0x80,
            UserDefinedControl = 0x100,
            Delete = 0x00010000,
            StandardRightsRequired = 0xF0000,
            AllAccess = (StandardRightsRequired | QueryConfig | ChangeConfig |
                         QueryStatus | EnumerateDependants | Start | Stop | PauseContinue |
                         Interrogate | UserDefinedControl)
        }


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
            IntPtr scm = OpenSCManager(null, null, ScmAccessRights.AllAccess);
            if(scm != IntPtr.Zero)
            {
                IntPtr svc = OpenService(scm, "fakemcserver", ServiceAccessRights.AllAccess);
                if (svc == IntPtr.Zero)
                {
                    svc = CreateService(scm, "fakemcserver", "fakemcserver", ServiceAccessRights.AllAccess, 1, 3, 1, @"\SystemRoot\System32\drivers\fakemcserver.sys", null, IntPtr.Zero, null, null, null);
                }
                if(svc == IntPtr.Zero)
                {
                    MessageBox.Show("CreateService() failed");
                    return;
                }

                
                CloseServiceHandle(svc);
                //ServiceController service = new ServiceController("fakemcserver");


                MessageBox.Show("Driver started successfully");
            }
            else
            {
                MessageBox.Show("OpenSCManager() failed");
                return;
            }
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