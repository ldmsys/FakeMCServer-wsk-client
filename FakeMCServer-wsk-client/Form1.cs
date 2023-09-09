using System.Diagnostics;
using System.Net.Http;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FakeMCServer_wsk_client
{
    public partial class Form1 : Form
    {
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
            string MotdJSON, kickJSON;
            PingData.Description kickMessage;

            PingData pingData = new PingData();
            pingData.version = new PingData.Version();
            pingData.players = new PingData.Players();
            pingData.description = new PingData.Description();

            int protocol = 25565;

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
            }

            pingData.version.name = textBox1.Text == "" ? textBox1.PlaceholderText : textBox1.Text;
            pingData.version.protocol = protocol;

            pingData.players.online = (int)numericUpDown1.Value;
            pingData.players.max = (int)numericUpDown2.Value;
            pingData.players.sample = new string[] { };

            pingData.description.text = textBox6.Text == "" ? textBox6.PlaceholderText : textBox6.Text;

            MotdJSON = JsonSerializer.Serialize(pingData);
            MessageBox.Show(MotdJSON);

            // 이야 vb6.0 생각난다

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