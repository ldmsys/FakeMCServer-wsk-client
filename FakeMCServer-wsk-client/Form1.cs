using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FakeMCServer_wsk_client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            int protocol = 340;
            String JSONData;
            PingData pingData = new PingData();
            pingData.version = new PingData.Version();
            pingData.players = new PingData.Players();
            pingData.description = new PingData.Description();

            pingData.version.name = "";
            pingData.version.protocol = protocol;



            
            // 이야 vb6.0 생각난다

        }


        public void UpdateCombo()
        {
            comboBox1.Items.Clear();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

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
        public string? MinecraftVersion { get; set; } // I changed the property name to avoid naming conflict with the class name.
        public long Version { get; set; }
        public int DataVersion { get; set; }
        public bool UsesNetty { get; set; }
        public string? MajorVersion { get; set; }
        public string? ReleaseType { get; set; }
    }
}