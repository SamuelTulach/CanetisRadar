using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.CoreAudioApi;
using IniParser;
using IniParser.Model;

namespace CanetisRadar
{
    public partial class Overlay : Form
    {
        // -------------------------------------------------------
        // Variables
        // -------------------------------------------------------
        MMDeviceEnumerator enumerator;
        MMDevice device;

        int multiplier = 100;

        // -------------------------------------------------------
        // Dll Imports
        // -------------------------------------------------------
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        public Overlay()
        {
            InitializeComponent();
        }

        private void Overlay_Load(object sender, EventArgs e)
        {
            this.TransparencyKey = Color.Turquoise;
            this.BackColor = Color.Turquoise;

            int initialStyle = GetWindowLong(this.Handle, -20);
            SetWindowLong(this.Handle, -20, initialStyle | 0x80000 | 0x20);

            this.WindowState = FormWindowState.Maximized;
            this.Opacity = 0.5;

            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(AppDomain.CurrentDomain.BaseDirectory + "settings.ini");
            string m = data["basic"]["multiplier"];
            multiplier = Int32.Parse(m);

            Thread t = new Thread(Loop);
            t.Start();
        }

        // -------------------------------------------------------
        // Main Loop
        // -------------------------------------------------------
        public void Loop()
        {
            enumerator = new MMDeviceEnumerator();
            device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);

            if (device.AudioMeterInformation.PeakValues.Count < 8)
            {
                MessageBox.Show("You are not using 7.1 audio device! Please look again at setup guide.", "No 7.1 audio detected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }

            while (true)
            {
                float lefttop = device.AudioMeterInformation.PeakValues[0];
                float righttop = device.AudioMeterInformation.PeakValues[1];
                float leftbottom = device.AudioMeterInformation.PeakValues[4];
                float rightbottom = device.AudioMeterInformation.PeakValues[5];

                var tempone = lefttop * multiplier;
                var temptwo = righttop * multiplier;

                var tempthree = leftbottom * multiplier;
                var tempfour = rightbottom * multiplier;

                var x = 75 - tempone + temptwo;
                var y = 75 - tempone - temptwo;

                x = x - tempthree + tempfour;
                y = y + tempthree + tempfour;

                if (y < 10)
                {
                    y = 10;
                }
                if (x < 10)
                {
                    x = 10;
                }

                if (y > 140)
                {
                    y = 140;
                }
                if (x > 140)
                {
                    x = 140;
                }

                string infotext = "";
                for (int i = 0; i < device.AudioMeterInformation.PeakValues.Count; i++)
                {
                    infotext += i + " -> " + device.AudioMeterInformation.PeakValues[i] + "\n";
                }
                label2.Invoke((MethodInvoker)delegate {
                    label2.Text = infotext;
                });

                CreateRadar((int)x, (int)y);

                Thread.Sleep(10);
            }
        }

        public void CreateRadar(int x, int y)
        {
            Bitmap radar = new Bitmap(150, 150);
            Graphics grp = Graphics.FromImage(radar);
            grp.FillRectangle(Brushes.Black, 0, 0, radar.Width, radar.Height);

            grp.FillRectangle(Brushes.Red, x - 5, y - 5, 10, 10);

            pictureBox1.Invoke((MethodInvoker)delegate {
                pictureBox1.Image = radar;
            });
        }
    }
}
