using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GreekKB
{
    public partial class Form1 : Form
    {
        //PLACEMENT
        Rectangle screenrect = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
        bool taskBarOnTopOrBottom = (Screen.PrimaryScreen.WorkingArea.Width == Screen.PrimaryScreen.Bounds.Width);
        int taskBarLocation = 0;
        const int size = 60; const int height = 5, width = 4;
        string[] s = new string[60];
        int opacityToggler = 0;
        Button[,] B = new Button[height, width];

        //FOR KEYS
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public Form1()
        {
            //LISTENERS
            InitializeComponent();
            RegisterHotKey(this.Handle, 2, 0x0002, (int)Keys.Subtract);
            RegisterHotKey(this.Handle, 3, 0x0002, (int)Keys.NumPad7);
            RegisterHotKey(this.Handle, 4, 0x0002, (int)Keys.NumPad8);
            RegisterHotKey(this.Handle, 5, 0x0002, (int)Keys.NumPad9);
            //RegisterHotKey(this.Handle, 6, 0x0002, (int)Keys.Add); //ZOOM PLUS
            RegisterHotKey(this.Handle, 7, 0x0002, (int)Keys.NumPad4);
            RegisterHotKey(this.Handle, 8, 0x0002, (int)Keys.NumPad5);
            RegisterHotKey(this.Handle, 9, 0x0002, (int)Keys.NumPad6);
            RegisterHotKey(this.Handle, 10, 0x0002, (int)Keys.NumPad1);
            RegisterHotKey(this.Handle, 11, 0x0002, (int)Keys.NumPad2);
            RegisterHotKey(this.Handle, 12, 0x0002, (int)Keys.NumPad3);
            RegisterHotKey(this.Handle, 13, 0x0002, (int)Keys.NumPad0);
            RegisterHotKey(this.Handle, 14, 0x0002, (int)Keys.Decimal);
            RegisterHotKey(this.Handle, 15, 0x0002, (int)Keys.Back);
            RegisterHotKey(this.Handle, 16, 0x0002, (int)Keys.Delete);

            RegisterHotKey(this.Handle, 22, 0x0008, (int)Keys.Subtract);
            RegisterHotKey(this.Handle, 23, 0x0008, (int)Keys.NumPad7);
            RegisterHotKey(this.Handle, 24, 0x0008, (int)Keys.NumPad8);
            RegisterHotKey(this.Handle, 25, 0x0008, (int)Keys.NumPad9);
            //RegisterHotKey(this.Handle, 26, 0x0008, (int)Keys.Add);//MAGNIFIER PLUS
            RegisterHotKey(this.Handle, 27, 0x0008, (int)Keys.NumPad4);
            RegisterHotKey(this.Handle, 28, 0x0008, (int)Keys.NumPad5);
            RegisterHotKey(this.Handle, 29, 0x0008, (int)Keys.NumPad6);
            RegisterHotKey(this.Handle, 30, 0x0008, (int)Keys.NumPad1);
            RegisterHotKey(this.Handle, 31, 0x0008, (int)Keys.NumPad2);
            RegisterHotKey(this.Handle, 32, 0x0008, (int)Keys.NumPad3);
            RegisterHotKey(this.Handle, 33, 0x0008, (int)Keys.NumPad0);
            RegisterHotKey(this.Handle, 34, 0x0008, (int)Keys.Decimal);
            RegisterHotKey(this.Handle, 35, 0x0008, (int)Keys.Back);
            RegisterHotKey(this.Handle, 36, 0x0008, (int)Keys.Delete);

            RegisterHotKey(this.Handle, 40, 0x0002 | 0x0008, (int)Keys.Divide);
            RegisterHotKey(this.Handle, 41, 0x0002 | 0x0008, (int)Keys.Multiply);
            RegisterHotKey(this.Handle, 42, 0x0002 | 0x0008, (int)Keys.Subtract);
            RegisterHotKey(this.Handle, 43, 0x0002 | 0x0008, (int)Keys.NumPad7);
            RegisterHotKey(this.Handle, 44, 0x0002 | 0x0008, (int)Keys.NumPad8);
            RegisterHotKey(this.Handle, 45, 0x0002 | 0x0008, (int)Keys.NumPad9);
            RegisterHotKey(this.Handle, 46, 0x0002 | 0x0008, (int)Keys.Add);
            RegisterHotKey(this.Handle, 47, 0x0002 | 0x0008, (int)Keys.NumPad4);
            RegisterHotKey(this.Handle, 48, 0x0002 | 0x0008, (int)Keys.NumPad5);
            RegisterHotKey(this.Handle, 49, 0x0002 | 0x0008, (int)Keys.NumPad6);
            RegisterHotKey(this.Handle, 50, 0x0002 | 0x0008, (int)Keys.NumPad1);
            RegisterHotKey(this.Handle, 51, 0x0002 | 0x0008, (int)Keys.NumPad2);
            RegisterHotKey(this.Handle, 52, 0x0002 | 0x0008, (int)Keys.NumPad3);
            RegisterHotKey(this.Handle, 53, 0x0002 | 0x0008, (int)Keys.NumPad0);
            RegisterHotKey(this.Handle, 54, 0x0002 | 0x0008, (int)Keys.Decimal);
            RegisterHotKey(this.Handle, 55, 0x0002 | 0x0008, (int)Keys.Back);
            RegisterHotKey(this.Handle, 56, 0x0002 | 0x0008, (int)Keys.Delete);


            //BUTTONS
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    B[i, j] = new Button();
                    B[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    B[i, j].Size = new Size(size, size);
                    B[i, j].Location = new Point(j * size, i * size);
                    B[i, j].BackColor = Color.Black;
                    B[i, j].ForeColor = Color.White;
                    B[i, j].Font = new Font(B[i, j].Font.FontFamily, 14);
                    this.Controls.Add(B[i, j]);
                }
            }
            
            //TEXT TO SEND
            s[2] = "₋";
            s[3] = Convert.ToString('\u2087'); //7
            s[4] = Convert.ToString('\u2088'); //8
            s[5] = Convert.ToString('\u2089'); //9
            //s[6] ZOOM PLUS
            s[7] = Convert.ToString('\u2084'); //4
            s[8] = Convert.ToString('\u2085'); //5
            s[9] = Convert.ToString('\u2086'); //6
            s[10] = Convert.ToString('\u2081'); //1
            s[11] = Convert.ToString('\u2082'); //2
            s[12] = Convert.ToString('\u2083'); //3
            s[13] = Convert.ToString('\u2080'); //0
            
            s[22] = "⁻";
            s[23] = Convert.ToString('\u2077'); //7
            s[24] = Convert.ToString('\u2078'); //8
            s[25] = Convert.ToString('\u2079'); //9
            //s[26] MAGNIFIER PLUS
            s[27] = Convert.ToString('\u2074'); //4
            s[28] = Convert.ToString('\u2075'); //5
            s[29] = Convert.ToString('\u2076'); //6
            s[30] = Convert.ToString('\u00B9'); //1
            s[31] = Convert.ToString('\u00B2'); //2
            s[32] = Convert.ToString('\u00B3'); //3
            s[33] = Convert.ToString('\u2070'); //0

            s[40] = "α";// /
            s[41] = "β";//*
            s[42] = "γ";//-
            s[43] = "ε";//7
            s[44] = "θ";//8
            s[45] = "λ";//9
            s[46] = "μ";//+
            s[47] = "π";//4
            s[48] = "ρ";//5
            s[49] = "σ";//6
            s[50] = "ω";//1
            s[51] = "ϕ";//2
            s[52] = "Ω";//3
            s[53] = "±";//0
            s[54] = "Σ";//.

            
            B[0, 0].Text = "Num" + '\n' + "Disabled";
            B[0, 1].Text = "/" + '\n' + s[40];
            B[0, 2].Text = "*" + '\n' + s[41];
            B[0, 3].Text = "-" +'\n' + s[42];
            B[1, 0].Text = "7" + '\n' + s[43];
            B[1, 1].Text = "8" + '\n' + s[44];
            B[1, 2].Text = "9" +'\n' + s[45];
            B[1, 3].Text = "+" + '\n' + s[46];
            B[2, 0].Text = "4" + '\n' + s[47];
            B[2, 1].Text = "5" + '\n' + s[48];
            B[2, 2].Text = "6" + '\n' + s[49];
            B[2, 3].Text = "+" + '\n' + s[46];
            B[3, 0].Text = "1" + '\n' + s[50];
            B[3, 1].Text = "2" + '\n' + s[51];
            B[3, 2].Text = "3" + '\n' + s[52];
            B[3, 3].Text = "Enter" + '\n' + "Disabled";
            B[4, 0].Text = "Rarrow" + '\n' + "Disabled";
            B[4, 1].Text = "0" + '\n' + s[53];
            B[4, 2].Text = "." + '\n' + s[54];
            B[4, 3].Text = "Enter" + '\n'  +"Disabled";

            B[0, 0].Enabled = false; //NUMLOCK
            B[4, 0].Enabled = false; //RIGHT ARROW
            B[3, 3].Enabled = false; //ENTER
            B[4, 3].Enabled = false; //ENTER
            
            //LOCATION ON SCREEN
            this.Size = new Size(width * size, height * size);
            taskBarOnTopOrBottom = (Screen.PrimaryScreen.WorkingArea.Width == Screen.PrimaryScreen.Bounds.Width);
            if (taskBarOnTopOrBottom)
            {
                if (Screen.PrimaryScreen.WorkingArea.Top > 0)
                { taskBarLocation = 1; } //TOP
                else
                { taskBarLocation = 0; } //BOTTOM
            }
            else
            {
                if (Screen.PrimaryScreen.WorkingArea.Left > 0)
                { taskBarLocation = 2; } //LEFT
                else
                { taskBarLocation = 3; } //RIGHT
            }
            switch (taskBarLocation)
            {
                case 0: this.Location = new Point(screenrect.Width - this.Size.Width-65, 40); break;
                case 1: this.Location = new Point(screenrect.Width - this.Size.Width-65, 90); break;
                case 2: this.Location = new Point(screenrect.Width - this.Size.Width-65, 40); break;
                case 3: this.Location = new Point(screenrect.Width - this.Size.Width-65, 40); break;
                default: this.Location = new Point(screenrect.Width - this.Size.Width-65, 40); break;
            }

            //MISC DISPLAY SETTINGS
            this.TopMost = true;
            this.Opacity = 0.5;
            //this.BackColor = Color.White;
            this.AllowTransparency = true;
            this.TransparencyKey = this.BackColor;
        }
        

        
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                if ((int)m.WParam == 16) this.Close(); //QUIT
                else if ((int)m.WParam == 15) //HIDE
                {
                    opacityToggler++; 
                    if (opacityToggler % 2 == 1)
                    {
                        this.Opacity = 0;
                    }
                    else
                    {
                        this.Opacity = 0.5;
                    }
                }
                else //PRESS
                {
                    SendKeys.Send(s[(int)m.WParam]);
                }
            }
            base.WndProc(ref m);
        }

        
    }
}
