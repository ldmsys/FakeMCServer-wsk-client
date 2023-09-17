using System.Diagnostics;
using System.Net.Http;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Collections;

namespace FakeMCServer_wsk_client
{

    public partial class Form1 : Form
    {
        public const string driverB64 = "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bmcAAHAARGJnUHJpbnQAAM0ES2VJbml0aWFsaXplRXZlbnQAWQVLZVNldEV2ZW50AACZBEtlRGVsYXlFeGVjdXRpb25UaHJlYWQAAIUFS2VXYWl0Rm9yU2luZ2xlT2JqZWN0AMEARXhBbGxvY2F0ZVBvb2xXaXRoVGFnAO4ARXhGcmVlUG9vbFdpdGhUYWcABQZNbVByb2JlQW5kTG9ja1BhZ2VzABwGTW1VbmxvY2tQYWdlcwA+B1BzQ3JlYXRlU3lzdGVtVGhyZWFkAAD0AklvQWxsb2NhdGVJcnAA9gJJb0FsbG9jYXRlTWRsAE8ESW9mQ29tcGxldGVSZXF1ZXN0AAAjA0lvQ3JlYXRlRGV2aWNlAAAvA0lvQ3JlYXRlU3ltYm9saWNMaW5rAAA8A0lvRGVsZXRlRGV2aWNlAAA+A0lvRGVsZXRlU3ltYm9saWNMaW5rAABTA0lvRnJlZUlycABWA0lvRnJlZU1kbADsA0lvUmV1c2VJcnAAABcLWndDbG9zZQBpC1p3T3BlbktleQCoC1p3UXVlcnlWYWx1ZUtleQBudG9za3JubC5leGUAACwCV3NrUmVnaXN0ZXIAKQJXc2tDYXB0dXJlUHJvdmlkZXJOUEkALQJXc2tSZWxlYXNlUHJvdmlkZXJOUEkAKgJXc2tEZXJlZ2lzdGVyAE5FVElPLlNZUwBMCFJ0bENvcHlVbmljb2RlU3RyaW5nAABxAERiZ1ByaW50RXgAAAYAV2RmVmVyc2lvbkJpbmQAAAMAV2RmTGRyUXVlcnlJbnRlcmZhY2UAAAgAV2RmVmVyc2lvblVuYmluZAAABwBXZGZWZXJzaW9uQmluZENsYXNzAAkAV2RmVmVyc2lvblVuYmluZENsYXNzAFdERkxEUi5TWVMAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAAAAkAAAAMKE4oUChSKFQobih6KUApgimEKaoprCmuKbApgBQAAAUAAAAAKAIoFigcKCYoAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";

        // Reference: https://gist.github.com/FusRoDah061/d04dc0bbed890ba0e93166da2b62451e
        [DllImport("advapi32.dll", EntryPoint = "OpenSCManagerW", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern IntPtr OpenSCManager(string? machineName, string? databaseName, ScmAccessRights dwDesiredAccess);
        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern IntPtr CreateService(IntPtr SC_HANDLE, string lpSvcName, string lpDisplayName,
ServiceAccessRights dwDesiredAccess, int dwServiceType, int dwStartType, int dwErrorControl, string lpPathName,
string? lpLoadOrderGroup, IntPtr lpdwTagId, string? lpDependencies, string? lpServiceStartName, string? lpPassword);

        [DllImport("advapi32.dll", SetLastError = true)]
        static extern IntPtr OpenService(IntPtr hSCManager, string lpServiceName, ServiceAccessRights dwDesiredAccess);

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern int StartService(IntPtr hService, int dwNumServiceArgs, int lpServiceArgVectors);

        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseServiceHandle(IntPtr hSCObject);

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern int ControlService(IntPtr hService, int dwControl, IntPtr lpServiceStatus);

        //////////////////
        [DllImport("kernel32.dll", EntryPoint = "CreateFileW", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr CreateFile
        (
            string lpFileName,
            uint dwDesiredAccess,
            uint dwShareMode,
            IntPtr lpSecurityAttributes,
            uint dwCreationDisposition,
            uint dwFlagsAndAttributes,
            uint hTemplateFile
        );

        [DllImport("kernel32.dll")]
        public static extern bool DeviceIoControl
        (
            IntPtr deviceHandle,
            uint ioControlCode,
            IntPtr inBuffer,
            uint inBufferSize,
            IntPtr outBuffer,
            uint outBufferSize,
            IntPtr byteCountReturned,
            IntPtr? overlappedHandle
        );

        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr hHandle);

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

            MotdJSON = MotdJSON.Replace("\\r\\n", "\\n");
            KickJSON = KickJSON.Replace("\\r\\n", "\\n");
            MotdJSONBin = Encoding.UTF8.GetBytes(MotdJSON);
            KickJSONBin = Encoding.UTF8.GetBytes(KickJSON);
            if (MotdJSONBin == null || KickJSONBin == null) return;

            RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\fakemcserver");
            key.SetValue("Port", port, RegistryValueKind.DWord);
            key.SetValue("MotdJSON", MotdJSONBin, RegistryValueKind.Binary);
            key.SetValue("KickJSON", KickJSONBin, RegistryValueKind.Binary);
            key.Close();
            try
            {
                IntPtr handle = CreateFile("\\\\.\\MCServer", 0x80000000 | 0x40000000, 0xF, (IntPtr)0, 3, 0, 0);
                if (handle == (IntPtr)(-1))
                {
                    //MessageBox.Show(new Win32Exception(Marshal.GetLastWin32Error()).Message);
                    //throw new Win32Exception(Marshal.GetLastWin32Error());
                    throw new Exception();
                }

                GCHandle pinnedArray = GCHandle.Alloc(MotdJSONBin, GCHandleType.Pinned);
                IntPtr ptr = pinnedArray.AddrOfPinnedObject();
                IntPtr dummy = Marshal.AllocHGlobal(8);
                DeviceIoControl(handle, 0x220F07, ptr, (uint)MotdJSON.Length, dummy, 8, IntPtr.Zero, IntPtr.Zero);
                pinnedArray.Free();
                pinnedArray = GCHandle.Alloc(KickJSONBin, GCHandleType.Pinned);
                ptr = pinnedArray.AddrOfPinnedObject();
                DeviceIoControl(handle, 0x220F0B, ptr, (uint)MotdJSON.Length, dummy, 8, IntPtr.Zero, IntPtr.Zero);
                pinnedArray.Free();
                Marshal.FreeHGlobal(dummy);
                CloseHandle(handle);

                MessageBox.Show("Thy amendments were reflected (live).");
            }
            catch (Exception _e)
            {
                MessageBox.Show("Thy amendments were reflected (offline).");
                MessageBox.Show(new Win32Exception(Marshal.GetLastWin32Error()).Message);
                MessageBox.Show(_e.Message);
            }

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
            byte[] DriverBytes = Convert.FromBase64String(driverB64);
            try
            {
                using var stream = File.Create(Environment.ExpandEnvironmentVariables("%SystemRoot%\\system32\\drivers\\fakemcserver.sys"));
                stream.Write(DriverBytes);
                stream.Close();
            }
            catch (Exception _e)
            {
                //Debug.WriteLine(_e.ToString());
                MessageBox.Show("Writing driver failed");
                return;
            }
            IntPtr scm = OpenSCManager(null, null, ScmAccessRights.AllAccess);
            if (scm != IntPtr.Zero)
            {
                IntPtr svc = OpenService(scm, "fakemcserver", ServiceAccessRights.AllAccess);
                if (svc == IntPtr.Zero)
                {
                    svc = CreateService(scm, "fakemcserver", "fakemcserver", ServiceAccessRights.AllAccess, 1, 3, 1, @"\SystemRoot\System32\drivers\fakemcserver.sys", null, IntPtr.Zero, null, null, null);
                }
                if (svc == IntPtr.Zero)
                {
                    MessageBox.Show("CreateService() failed");
                    return;
                }


                CloseServiceHandle(scm);

                if (StartService(svc, 0, 0) == 0)
                {
                    MessageBox.Show(new Win32Exception(Marshal.GetLastWin32Error()).Message);
                }
                else
                {
                    MessageBox.Show("Driver started!");
                }
                CloseServiceHandle(svc);
            }
            else
            {
                MessageBox.Show("OpenSCManager() failed");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IntPtr scm = OpenSCManager(null, null, ScmAccessRights.AllAccess);
            if (scm != IntPtr.Zero)
            {
                IntPtr svc = OpenService(scm, "fakemcserver", ServiceAccessRights.AllAccess);
                if (svc == IntPtr.Zero)
                {
                    MessageBox.Show("The driver has been never installed.");
                    return;
                }

                CloseServiceHandle(scm);

                IntPtr dummy = Marshal.AllocHGlobal(28);
                if (ControlService(svc, 1, dummy) == 0)
                {
                    MessageBox.Show(new Win32Exception(Marshal.GetLastWin32Error()).Message);
                }
                else
                {
                    MessageBox.Show("Driver stopped!");
                }
                Marshal.FreeHGlobal(dummy);
                CloseServiceHandle(svc);
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