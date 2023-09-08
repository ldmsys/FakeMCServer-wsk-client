namespace FakeMCServer_wsk_client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            comboBox1 = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            label5 = new Label();
            textBox2 = new TextBox();
            button3 = new Button();
            label6 = new Label();
            textBox3 = new TextBox();
            label7 = new Label();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            label8 = new Label();
            label9 = new Label();
            textBox6 = new TextBox();
            button4 = new Button();
            checkBox1 = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 415);
            label1.Name = "label1";
            label1.Size = new Size(221, 15);
            label1.TabIndex = 0;
            label1.Text = "You should enable test mode before use.";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 363);
            button1.Name = "button1";
            button1.Size = new Size(152, 43);
            button1.TabIndex = 1;
            button1.Text = "Start Driver";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(170, 363);
            button2.Name = "button2";
            button2.Size = new Size(152, 43);
            button2.TabIndex = 2;
            button2.Text = "Stop Driver";
            button2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 15);
            label2.Name = "label2";
            label2.Size = new Size(137, 15);
            label2.TabIndex = 3;
            label2.Text = "Target Minecraft Version:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(176, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(146, 23);
            comboBox1.TabIndex = 4;
            comboBox1.Text = "1.12.2 (340)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 44);
            label3.Name = "label3";
            label3.Size = new Size(137, 15);
            label3.TabIndex = 5;
            label3.Text = "Displayed Server Version:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(157, 51);
            label4.Name = "label4";
            label4.Size = new Size(0, 15);
            label4.TabIndex = 6;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(155, 41);
            textBox1.MaxLength = 25;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "ldmsys-wsk 1.12.2";
            textBox1.Size = new Size(167, 23);
            textBox1.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(82, 73);
            label5.Name = "label5";
            label5.Size = new Size(67, 15);
            label5.TabIndex = 8;
            label5.Text = "Server Port:";
            label5.Click += label5_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(155, 69);
            textBox2.MaxLength = 5;
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "25565";
            textBox2.Size = new Size(167, 23);
            textBox2.TabIndex = 9;
            // 
            // button3
            // 
            button3.Location = new Point(12, 314);
            button3.Name = "button3";
            button3.Size = new Size(310, 43);
            button3.TabIndex = 10;
            button3.Text = "Apply Configuration";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 228);
            label6.Name = "label6";
            label6.Size = new Size(81, 15);
            label6.TabIndex = 11;
            label6.Text = "Kick Message:";
            label6.Click += label6_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(15, 246);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "You are not white-listed on this server!";
            textBox3.Size = new Size(307, 62);
            textBox3.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(50, 101);
            label7.Name = "label7";
            label7.Size = new Size(99, 15);
            label7.TabIndex = 13;
            label7.Text = "Connected Users:";
            label7.Click += label7_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(155, 98);
            textBox4.MaxLength = 5;
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "0";
            textBox4.Size = new Size(69, 23);
            textBox4.TabIndex = 14;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(253, 98);
            textBox5.MaxLength = 5;
            textBox5.Name = "textBox5";
            textBox5.PlaceholderText = "99999";
            textBox5.Size = new Size(69, 23);
            textBox5.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(230, 101);
            label8.Name = "label8";
            label8.Size = new Size(12, 15);
            label8.TabIndex = 16;
            label8.Text = "/";
            label8.Click += label8_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(15, 145);
            label9.Name = "label9";
            label9.Size = new Size(43, 15);
            label9.TabIndex = 17;
            label9.Text = "MOTD:";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(15, 163);
            textBox6.Multiline = true;
            textBox6.Name = "textBox6";
            textBox6.PlaceholderText = "§b§lFakeMCServer Test";
            textBox6.Size = new Size(307, 62);
            textBox6.TabIndex = 18;
            // 
            // button4
            // 
            button4.Location = new Point(155, 127);
            button4.Name = "button4";
            button4.Size = new Size(167, 30);
            button4.TabIndex = 19;
            button4.Text = "Minecraft Color Code help";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(155, 16);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 20;
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 441);
            Controls.Add(checkBox1);
            Controls.Add(button4);
            Controls.Add(textBox6);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(label7);
            Controls.Add(textBox3);
            Controls.Add(label6);
            Controls.Add(button3);
            Controls.Add(textBox2);
            Controls.Add(label5);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "Form1";
            Text = "FakeMCServer-Wsk Config";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Label label2;
        private ComboBox comboBox1;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private Label label5;
        private TextBox textBox2;
        private Button button3;
        private Label label6;
        private TextBox textBox3;
        private Label label7;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label8;
        private Label label9;
        private TextBox textBox6;
        private Button button4;
        private CheckBox checkBox1;
    }
}