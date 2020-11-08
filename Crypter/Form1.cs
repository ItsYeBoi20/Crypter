using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crypter
{
    public partial class Form1 : Form
    {
        public static int KeyCount;
        public static int IVCount;

        public Form1()
        {
            InitializeComponent();     
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            KeyCount = 0;
            foreach (char c in textBox3.Text)
            {
                KeyCount++;
            }
            label3.Text = "Key - Characters : " + KeyCount;

            IVCount = 0;
            foreach (char c in textBox4.Text)
            {
                IVCount++;
            }
            label4.Text = "IV - Characters : " + IVCount;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            KeyCount = 0;
            foreach (char c in textBox3.Text)
            {
                KeyCount++;
            }
            label3.Text = "Password - Characters : " + KeyCount;

            IVCount = 0;
            foreach (char c in textBox4.Text)
            {
                IVCount++;
            }
            label4.Text = "Salt - Characters : " + IVCount;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "AES 256")
            {
                timer2.Stop();
                timer1.Start();
                label3.Text = "Key - Characters : 0";
                label4.Text = "IV - Characters : 0";
                button2.Enabled = true;
                label3.Font = new Font(label3.Font, FontStyle.Regular);
                label4.Font = new Font(label4.Font, FontStyle.Regular);
                textBox4.Enabled = true;
                textBox3.Enabled = true;

                if (textBox3.TextLength > 32)
                {
                    int tB3Chars = 0;
                    int Characters = 0;
                    string Futuretb3 = textBox3.Text;

                    foreach (char c in textBox3.Text)
                    {
                        tB3Chars++;
                    }

                    while (tB3Chars > 32)
                    {
                        tB3Chars--;
                        Characters++;
                    }

                    textBox3.Text = textBox3.Text.Substring(0, textBox3.Text.Length - Characters);
                    textBox3.MaxLength = 32;
                }
                else
                {
                    textBox3.MaxLength = 32;
                }

                if (textBox4.TextLength > 16)
                {
                    int tB3Chars = 0;
                    int Characters = 0;
                    string Futuretb3 = textBox4.Text;

                    foreach (char c in textBox4.Text)
                    {
                        tB3Chars++;
                    }

                    while (tB3Chars > 16)
                    {
                        tB3Chars--;
                        Characters++;
                    }

                    textBox4.Text = textBox4.Text.Substring(0, textBox4.Text.Length - Characters);
                    textBox4.MaxLength = 16;
                }
                else
                {
                    textBox4.MaxLength = 16;
                }
            }
            else if (comboBox1.SelectedItem == "BASE 64")
            {
                timer1.Stop();
                timer2.Stop();
                label3.Text = "Key - Characters : 0";
                label4.Text = "IV - Characters : 0";
                button2.Enabled = true;
                label3.Font = new Font(label3.Font, FontStyle.Strikeout);
                label4.Font = new Font(label4.Font, FontStyle.Strikeout);
                textBox4.Enabled = false;
                textBox3.Enabled = false;
            }
            else if (comboBox1.SelectedItem == "MD5")
            {
                timer1.Stop();
                timer2.Stop();
                label3.Text = "Key - Characters : 0";
                label4.Text = "IV - Characters : 0";
                button2.Enabled = false;
                label3.Font = new Font(label3.Font, FontStyle.Strikeout);
                label4.Font = new Font(label4.Font, FontStyle.Strikeout);
                textBox4.Enabled = false;
                textBox3.Enabled = false;
            }
            else if (comboBox1.SelectedItem == "SHA1")
            {
                timer1.Stop();
                timer2.Stop();
                label3.Text = "Key - Characters : 0";
                label4.Text = "IV - Characters : 0";
                button2.Enabled = false;
                label3.Font = new Font(label3.Font, FontStyle.Strikeout);
                label4.Font = new Font(label4.Font, FontStyle.Strikeout);
                textBox4.Enabled = false;
                textBox3.Enabled = false;
            }
            else if (comboBox1.SelectedItem == "SHA256")
            {
                timer1.Stop();
                timer2.Stop();
                label3.Text = "Key - Characters : 0";
                label4.Text = "IV - Characters : 0";
                button2.Enabled = false;
                label3.Font = new Font(label3.Font, FontStyle.Strikeout);
                label4.Font = new Font(label4.Font, FontStyle.Strikeout);
                textBox4.Enabled = false;
                textBox3.Enabled = false;
            }
            else if (comboBox1.SelectedItem == "SHA512")
            {
                timer1.Stop();
                timer2.Stop();
                label3.Text = "Key - Characters : 0";
                label4.Text = "IV - Characters : 0";
                button2.Enabled = false;
                label3.Font = new Font(label3.Font, FontStyle.Strikeout);
                label4.Font = new Font(label4.Font, FontStyle.Strikeout);
                textBox4.Enabled = false;
                textBox3.Enabled = false;
            }
            else if (comboBox1.SelectedItem == "BINARY")
            {
                timer1.Stop();
                timer2.Stop();
                label3.Text = "Key - Characters : 0";
                label4.Text = "IV - Characters : 0";
                button2.Enabled = true;
                label3.Font = new Font(label3.Font, FontStyle.Strikeout);
                label4.Font = new Font(label4.Font, FontStyle.Strikeout);
                textBox4.Enabled = false;
                textBox3.Enabled = false;
            }
            else if (comboBox1.SelectedItem == "TRIPLE DES")
            {
                timer1.Stop();
                timer2.Start();
                button2.Enabled = true;
                label3.Font = new Font(label3.Font, FontStyle.Regular);
                label4.Font = new Font(label4.Font, FontStyle.Regular);
                label3.Text = "Password - Characters : 0";
                label4.Text = "Salt - Characters : 0";
                textBox4.Enabled = true;
                textBox3.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "AES 256")
            {
                if (textBox3.TextLength == 32 && textBox4.TextLength == 16)
                {
                    try
                    {
                        Methods.Aes256.Key = textBox3.Text;
                        textBox2.Text =  Methods.Aes256.Encrypt(textBox1.Text);
                    }
                    catch
                    {
                        MessageBox.Show("An Error Occured!");
                    }
                }
                else
                {
                    MessageBox.Show("Key need 32 Chars + IV needs 16 Chars");
                }
            }
            else if (comboBox1.SelectedItem == "BASE 64")
            {
                try
                {
                    textBox2.Text = Methods.Base64.Base64Encode(textBox1.Text);
                }
                catch
                {
                    MessageBox.Show("An Error Occured!");
                }
            }
            else if (comboBox1.SelectedItem == "MD5")
            {
                try
                {
                    textBox2.Text = Methods.MD5.CreateMD5(textBox1.Text);
                }
                catch
                {
                    MessageBox.Show("An Error Occured!");
                }
            }
            else if (comboBox1.SelectedItem == "SHA1")
            {
                try
                {
                    textBox2.Text = Methods.SHA1.Hash(textBox1.Text);
                }
                catch
                {
                    MessageBox.Show("An Error Occured!");
                }
            }
            else if (comboBox1.SelectedItem == "SHA256")
            {
                try
                {
                    textBox2.Text = Methods.SHA256.Hash(textBox1.Text);
                }
                catch
                {
                    MessageBox.Show("An Error Occured!");
                }
            }
            else if (comboBox1.SelectedItem == "SHA512")
            {
                try
                {
                    textBox2.Text = Methods.SHA512.Hash(textBox1.Text);
                }
                catch
                {
                    MessageBox.Show("An Error Occured!");
                }
            }
            else if (comboBox1.SelectedItem == "BINARY")
            {
                try
                {
                    textBox2.Text = Methods.BINARY.StringToBinary(textBox1.Text);
                }
                catch
                {
                    MessageBox.Show("An Error Occured!");
                }
            }
            else if (comboBox1.SelectedItem == "TRIPLE DES")
            {
                try
                {
                    if (textBox4.TextLength < 4)
                    {
                        MessageBox.Show("Salt has to be bigger than 4 Characters!");
                    }
                    else
                    {
                        textBox2.Text = Methods.Triple_DES.Encrypt(textBox1.Text, textBox3.Text, textBox4.Text);
                    }
                }
                catch
                {
                    MessageBox.Show("An Error Occured!");
                }
            }
            else
            {
                MessageBox.Show("Please Choose a Valid Method First!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "AES 256")
            {
                if (textBox3.TextLength == 32 && textBox4.TextLength == 16)
                {
                    try
                    {
                        Methods.Aes256.Key = textBox3.Text;
                        textBox2.Text = Methods.Aes256.Decrypt(textBox1.Text);
                    }
                    catch
                    {
                        MessageBox.Show("An Error Occured!");
                    }
                }
                else
                {
                    MessageBox.Show("Key need 32 Chars + IV needs 16 Chars");
                }
            }
            else if (comboBox1.SelectedItem == "BASE 64")
            {
                try
                {
                    textBox2.Text = Methods.Base64.Base64Decode(textBox1.Text);
                }
                catch
                {
                    MessageBox.Show("An Error Occured!");
                }
            }
            else if (comboBox1.SelectedItem == "BINARY")
            {
                try
                {
                    textBox2.Text = Methods.BINARY.BinaryToString(textBox1.Text);
                }
                catch
                {
                    MessageBox.Show("An Error Occured!");
                }
            }
            else if (comboBox1.SelectedItem == "TRIPLE DES")
            {
                try
                {
                    if (textBox4.TextLength < 4)
                    {
                        MessageBox.Show("Salt has to be bigger than 4 Characters!");
                    }
                    else
                    {
                        textBox2.Text = Methods.Triple_DES.Decrypt(textBox1.Text, textBox3.Text, textBox4.Text);
                    }
                }
                catch
                {
                    MessageBox.Show("An Error Occured!");
                }
            }
            else
            {
                MessageBox.Show("Please Choose a Valid Method First!");
            }
        }        
    }
}
