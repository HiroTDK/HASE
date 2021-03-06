﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HASE
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            MdiClient mdi = null;
            int ExStyle;
            foreach (Control ctl in Controls)
            {
                if (ctl is MdiClient)
                {
                    mdi = (MdiClient)ctl;
                    mdi.BackColor = Color.FromArgb(95, 95, 95);
                    ExStyle = GetWindowLong(mdi.Handle, GWL_EXSTYLE);
                    ExStyle ^= WS_EX_CLIENTEDGE;
                    SetWindowLong(mdi.Handle, GWL_EXSTYLE, ExStyle);
                    SetWindowPos(mdi.Handle, IntPtr.Zero, 0, 0, 0, 0, SWP_NOMOVE |
                    SWP_NOSIZE | SWP_NOZORDER | SWP_FRAMECHANGED);
                }
            }
            ToolStripSystemRenderer TSSR = new MenuRenderer();
            menuMain.Renderer = TSSR;
            statusMain.Renderer = TSSR;
            UnpackWindow u = new UnpackWindow();
            u.Show();
        }
    }
}

