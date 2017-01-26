using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HASE
{
    /// <summary>
    /// This is going to be our custom message box. Here we 
    /// can display messages and errors in our own style.
    /// </summary>
    internal partial class MessageBox : Form
    {
        public MessageBox()                                                     // Required for designer support.
        {
            InitializeComponent();
        }

        public MessageBox(
                string title,                                                   // Text shown on title bar.
                string message,                                                 // Message for the user.
                string description,                                             // Descriptive text explaining the message.
                int width,                                                      // Width and height of the window. Elements are
                int height,                                                     // automatically arranged to make use of the space.
                List<string> buttons,                                           // Text shown on buttons. No limit but space on buttons.
                List<DialogResult> results)                                     // Results of button presses, tied to indexes.
        {
            InitializeComponent();

            this.DialogResult = DialogResult.Cancel;
            this.Results = results;

            this.Text = title;
            this.labelMessage.Text = message;
            this.labelDescription.Text = description;
            this.Width = width;
            this.Height = height;
    
            foreach (string s in buttons)
            {
                if (s.Length < 1)
                {
                    buttons.Remove(s);
                    //results.RemoveAt(buttons.IndexOf(s));
                }
            }
            
            if(buttons.Count() > 1)
            {
                List<Button> buttonList = new List<Button>();
                int i = 1;
                int bw = 0;
                int bh = 0;

                foreach (string s in buttons)
                {
                    Button b = newButton("button" + i, s);
                    this.Controls.Add(b);
                    b.BringToFront();

                    buttonList.Add(b);
                    b.TabIndex = i;
                    bw += b.Width;
                    bh = Math.Max(bh, b.Height);
                    i++;
                }

                int w = this.ClientSize.Width - bw;
                if (w > 0)
                {
                    w /= i;
                }

                i = 1;
                bw = 0;
                foreach (Button b in buttonList)
                {
                    b.Location = new System.Drawing.Point(
                        (( w * i) + bw),
                        (this.ClientSize.Height - bh - 20));
                    
                    i++;
                    bw += b.Width;
                }
            }

            else
            {
                Button b;

                if (buttons.Count() > 0)
                {
                    b = newButton("button1", buttons[0]);
                }
                else
                {
                    b = newButton("button1", "Close");
                }

                this.Controls.Add(b);
                b.BringToFront();
                b.TabIndex = 1;

                b.Location = new System.Drawing.Point(
                    (this.ClientSize.Width - b.Width) / 2,
                    (this.ClientSize.Height - b.Height - 20) );
            }
        }

        private Button newButton(string name, string text)
        {
            System.Windows.Forms.Button b = new System.Windows.Forms.Button();

            b.ForeColor = System.Drawing.Color.White;
            b.BackColor = System.Drawing.Color.FromArgb(95, 95, 95);
            b.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(31, 31, 31);
            b.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(62, 62, 62);
            b.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(127, 127, 127);
            b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            b.UseVisualStyleBackColor = false;

            b.Font = new System.Drawing.Font(
                "Microsoft Sans Serif",
                9.25F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point,
                0);

            b.Anchor = System.Windows.Forms.AnchorStyles.None;
            b.TabIndex = 1;

            b.AutoSize = true;
            b.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            b.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            b.Margin = new System.Windows.Forms.Padding(0);

            b.Name = name;
            b.Text = text;

            b.Invalidate();
            b.Update();
            b.Click += new System.EventHandler(this.button_click);
            return b;
        }

        private List<DialogResult> Results;

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int t = b.TabIndex - 1;
            if(t >= 0 && Results.Count() >= b.TabIndex)
            {
                this.DialogResult = Results[t];
            }
            this.Close();
        }
    }

    /// <summary>
    /// Your custom message box helper. This wrapper allows
    /// easy creating of the message box as well as proper
    /// destruction when usage is finished. The using
    /// construct is what allows the resources to be freed
    /// when the form is closed.
    /// </summary>
    public static class CustomMessageBox
    {
        public static DialogResult Show(string title, string message, string description, int width, int height, List<string> buttons, List<DialogResult> results)
        {
            using (var form = new MessageBox(title, message, description, width, height, buttons, results))
            {                                                                   // New form creating our custom message box.
                DialogResult d = form.ShowDialog();                             // Shows the customized message box to the user.
                return d;
            }
        }
    }
}