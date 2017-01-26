using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HASE
{
    public partial class UnpackWindow : Form
    {
        public UnpackWindow()
        {
            InitializeComponent();
        }

        private string fn;

        private void checkLabel_Click(object sender, EventArgs e)
        {
            Label l = (Label)sender;
            if (l == checkLabel1) { checkBox1.Focus(); checkBox1.Checked = !checkBox1.Checked; }
            else if (l == checkLabel2) { checkBox2.Focus(); checkBox2.Checked = !checkBox2.Checked; }
            else if (l == checkLabel3) { checkBox3.Focus(); checkBox3.Checked = !checkBox3.Checked; }
            else if (l == checkLabel4) { checkBox4.Focus(); checkBox4.Checked = !checkBox4.Checked; }
            else if (l == checkLabel5) { checkBox5.Focus(); checkBox5.Checked = !checkBox5.Checked; }
            else if (l == checkLabel6) { checkBox6.Focus(); checkBox6.Checked = !checkBox6.Checked; }
            else if (l == checkLabel7) { checkBox7.Focus(); checkBox7.Checked = !checkBox7.Checked; }
            else if (l == checkLabel8) { checkBox8.Focus(); checkBox8.Checked = !checkBox8.Checked; }
            else if (l == checkLabel9) { checkBox9.Focus(); checkBox9.Checked = !checkBox9.Checked; }
            else if (l == checkLabel10) { checkBox10.Focus(); checkBox10.Checked = !checkBox10.Checked; }
        }

        private void checkBox_GotFocus(object sender, EventArgs e)
        {
            CheckBox c = (CheckBox)sender;
            if (c == checkBox1) { checkLabel1.BackColor = Color.FromArgb(95, 95, 95); }
            else if (c == checkBox2) { checkLabel2.BackColor = Color.FromArgb(95, 95, 95); }
            else if (c == checkBox3) { checkLabel3.BackColor = Color.FromArgb(95, 95, 95); }
            else if (c == checkBox4) { checkLabel4.BackColor = Color.FromArgb(95, 95, 95); }
            else if (c == checkBox5) { checkLabel5.BackColor = Color.FromArgb(95, 95, 95); }
            else if (c == checkBox6) { checkLabel6.BackColor = Color.FromArgb(95, 95, 95); }
            else if (c == checkBox7) { checkLabel7.BackColor = Color.FromArgb(95, 95, 95); }
            else if (c == checkBox8) { checkLabel8.BackColor = Color.FromArgb(95, 95, 95); }
            else if (c == checkBox9) { checkLabel9.BackColor = Color.FromArgb(95, 95, 95); }
            else if (c == checkBox10) { checkLabel10.BackColor = Color.FromArgb(95, 95, 95); }
        }

        private void checkBox_LostFocus(object sender, EventArgs e)
        {
            CheckBox c = (CheckBox)sender;
            if (c == checkBox1) { checkLabel1.BackColor = Color.FromArgb(63, 63, 63); }
            else if (c == checkBox2) { checkLabel2.BackColor = Color.FromArgb(63, 63, 63); }
            else if (c == checkBox3) { checkLabel3.BackColor = Color.FromArgb(63, 63, 63); }
            else if (c == checkBox4) { checkLabel4.BackColor = Color.FromArgb(63, 63, 63); }
            else if (c == checkBox5) { checkLabel5.BackColor = Color.FromArgb(63, 63, 63); }
            else if (c == checkBox6) { checkLabel6.BackColor = Color.FromArgb(63, 63, 63); }
            else if (c == checkBox7) { checkLabel7.BackColor = Color.FromArgb(63, 63, 63); }
            else if (c == checkBox8) { checkLabel8.BackColor = Color.FromArgb(63, 63, 63); }
            else if (c == checkBox9) { checkLabel9.BackColor = Color.FromArgb(63, 63, 63); }
            else if (c == checkBox10) { checkLabel10.BackColor = Color.FromArgb(63, 63, 63); }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = (CheckBox)sender;
            if(c.Checked)
            {
                c.FlatAppearance.MouseOverBackColor = Color.White;
                if(c == checkBox1)
                {
                    checkBox2.Enabled = false;
                    checkBox2.FlatAppearance.CheckedBackColor = Color.FromArgb(127, 127, 127);
                    checkBox2.BackColor = Color.FromArgb(127, 127, 127);
                    checkLabel2.ForeColor = Color.FromArgb(127, 127, 127);

                    checkBox3.Enabled = false;
                    checkBox3.FlatAppearance.CheckedBackColor = Color.FromArgb(127, 127, 127);
                    checkBox3.BackColor = Color.FromArgb(127, 127, 127);
                    checkLabel3.ForeColor = Color.FromArgb(127, 127, 127);

                    checkBox4.Enabled = false;
                    checkBox4.FlatAppearance.CheckedBackColor = Color.FromArgb(127, 127, 127);
                    checkBox4.BackColor = Color.FromArgb(127, 127, 127);
                    checkLabel4.ForeColor = Color.FromArgb(127, 127, 127);

                    checkBox5.Enabled = false;
                    checkBox5.FlatAppearance.CheckedBackColor = Color.FromArgb(127, 127, 127);
                    checkBox5.BackColor = Color.FromArgb(127, 127, 127);
                    checkLabel5.ForeColor = Color.FromArgb(127, 127, 127);
                }
            }
            else
            {
                c.FlatAppearance.MouseOverBackColor = Color.FromArgb(127,127,127);
                if (c == checkBox1)
                {
                    checkBox2.Enabled = true;
                    checkBox2.FlatAppearance.CheckedBackColor = Color.White;
                    checkBox2.BackColor = Color.FromArgb(95, 95, 95);
                    checkLabel2.ForeColor = Color.White;

                    checkBox3.Enabled = true;
                    checkBox3.FlatAppearance.CheckedBackColor = Color.White;
                    checkBox3.BackColor = Color.FromArgb(95, 95, 95);
                    checkLabel3.ForeColor = Color.White;

                    checkBox4.Enabled = true;
                    checkBox4.FlatAppearance.CheckedBackColor = Color.White;
                    checkBox4.BackColor = Color.FromArgb(95, 95, 95);
                    checkLabel4.ForeColor = Color.White;

                    checkBox5.Enabled = true;
                    checkBox5.FlatAppearance.CheckedBackColor = Color.White;
                    checkBox5.BackColor = Color.FromArgb(95, 95, 95);
                    checkLabel5.ForeColor = Color.White;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Title = "Select a ROM to unpack.";
            o.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            o.RestoreDirectory = true;
            o.Filter = "NDS ROM (*.nds)|*.nds";
            o.ShowDialog();
            fn = o.FileName;
            label2.Text = o.SafeFileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.Description = "Select a location to unpack the ROM.";
            f.RootFolder = Environment.SpecialFolder.Desktop;
            f.ShowDialog();
            label4.Text = f.SelectedPath;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (fn == null || fn.Length == 0)
            {
                DialogResult result = CustomMessageBox.Show(
                    "No File",
                    "You haven't chosen a file.",
                    "Something can't come from nothing. This, unfortunately, is nothing. That's actually incorrect."
                    + " \"This is nothing\" doesn't make sense. You can't have nothing isn't."
                    + " If nothing wasn't, there'd be all kinds of stuff, like giant ants with top hats dancing around."
                    + " There's no room for all that.",
                    365, 235,
                    new List<string>(),
                    new List<DialogResult>());
                return;
            }
            
            if (!File.Exists(fn))
            {
                DialogResult result = CustomMessageBox.Show(
                    "File Error",
                    "This file doesn't exist.",
                    "The file that you've specified doesn't exist or has changed locations."
                    + " Please check the path and file name for any errors and try again.",
                    365, 200,
                    new List<string>(),
                    new List<DialogResult>());
                return;
            }

            ROM r = new ROM();
            r.pathROM = fn;
            r.ReadROM();
        }
    }
}
