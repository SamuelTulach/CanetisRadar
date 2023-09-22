using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;
using NAudio.CoreAudioApi;

namespace CanetisRadar
{
	// Token: 0x02000003 RID: 3
	public partial class Overlay : Form
	{
		// Token: 0x06000008 RID: 8
		[DllImport("user32.dll")]
		private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

		// Token: 0x06000009 RID: 9
		[DllImport("user32.dll")]
		private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

		// Token: 0x0600000A RID: 10 RVA: 0x0000277A File Offset: 0x0000097A

		private DateTime[] lastHighlightedTimestamps = new DateTime[12];

		public Overlay()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000027BC File Offset: 0x000009BC
		private void Overlay_Load(object sender, EventArgs e)
		{
			base.TransparencyKey = Color.Turquoise;
			this.BackColor = Color.Turquoise;
			int initialStyle = Overlay.GetWindowLong(base.Handle, -20);
			Overlay.SetWindowLong(base.Handle, -20, initialStyle | 524288 | 32);
			base.WindowState = FormWindowState.Maximized;
			base.TopMost = true;
			base.Opacity = 0.7;
			FileIniDataParser parser = new FileIniDataParser();
			IniData data = parser.ReadFile(AppDomain.CurrentDomain.BaseDirectory + "settings.ini");
			this._multiplier = int.Parse(data["basic"]["multiplier"]);
			this._updateRate = int.Parse(data["basic"]["updateRate"]);
			this._delay = int.Parse(data["basic"]["delay"]);
			this._sectionAmount = int.Parse(data["sectionHighlights"]["sectionAmount"]);
			this._highlightDurationSeconds = int.Parse(data["sectionHighlights"]["highlightDurationSeconds"]);
			this._highlightSoundThreshold = int.Parse(data["sectionHighlights"]["highlightSoundThreshold"]);
			Thread t = new Thread(new ThreadStart(this.Loop));
			t.Start();
		}

		// Token: 0x0600000C RID: 12 RVA: 0x0000289C File Offset: 0x00000A9C
		private void Loop()
		{
			this._enumerator = new MMDeviceEnumerator();
			this._device = this._enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
			bool flag = this._device.AudioMeterInformation.PeakValues.Count < 8;
			if (flag)
			{
				MessageBox.Show("You are not using 7.1 audio device! Please look again at setup guide.", "No 7.1 audio detected!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				Environment.Exit(-1);
			}

			const int history = 100;
			float[] leftTop = new float[history];
			float[] rightTop = new float[history];
			float[] leftBottom = new float[history];
			float[] rightBottom = new float[history];
			float[] left = new float[history];
			float[] right = new float[history];

			int idx = 0;

			Graphics grp = Graphics.FromImage(this._radar);
			grp.FillRectangle(Brushes.Black, 0, 0, this._radar.Width, this._radar.Height);

			for (;;)
			{
				leftTop[idx] = this._device.AudioMeterInformation.PeakValues[0];
				rightTop[idx] = this._device.AudioMeterInformation.PeakValues[1];
				leftBottom[idx] = this._device.AudioMeterInformation.PeakValues[4];
				rightBottom[idx] = this._device.AudioMeterInformation.PeakValues[5];
				left[idx] = this._device.AudioMeterInformation.PeakValues[6];
				right[idx] = this._device.AudioMeterInformation.PeakValues[7];
				idx = (idx + 1) % 100;


				float tempOne = leftTop[(idx + (history - this._delay)) % history] * (float)this._multiplier;
				float tempTwo = rightTop[(idx + (history - this._delay)) % history] * (float)this._multiplier;
				float tempThree = leftBottom[(idx + (history - this._delay)) % history] * (float)this._multiplier;
				float tempFour = rightBottom[(idx + (history - this._delay)) % history] * (float)this._multiplier;
				float tempFive = left[(idx + (history - this._delay)) % history] * (float)this._multiplier;
				float tempSix = right[(idx + (history - this._delay)) % history] * (float)this._multiplier;


				float x = 75f - tempOne + tempTwo - tempFive + tempSix;
				float y = 75f - tempOne - tempTwo;
				x = x - tempThree + tempFour;
				y = y + tempThree + tempFour;
				bool flag2 = y < 10f;
				if (flag2)
				{
					y = 10f;
				}
				bool flag3 = x < 10f;
				if (flag3)
				{
					x = 10f;
				}
				bool flag4 = y > 140f;
				if (flag4)
				{
					y = 140f;
				}
				bool flag5 = x > 140f;
				if (flag5)
				{
					x = 140f;
				}
				//this.CreateRadar((int)x, (int)y, (int)idx);
				this.CreateRadarTriangle((int)x, (int)y, (int)idx);
				Thread.Sleep(this._updateRate);
			}
		}


		// Token: 0x0600000D RID: 13 RVA: 0x00002A90 File Offset: 0x00000C90
		private void CreateRadar(int x, int y, int idx)
		{
			Graphics grp = Graphics.FromImage(this._radar);
			if((idx % 50) == 0) { grp.FillRectangle(Brushes.Black, 0, 0, this._radar.Width, this._radar.Height); };
			grp.FillRectangle(Brushes.Red, x - 5, y - 5, 10, 10);
			this.RadarBox.Invoke(new MethodInvoker(delegate()
			{
				this.RadarBox.Image = this._radar;
			}));
		}

		private void CreateRadarTriangle(int x, int y, int idx)
		{

			Graphics grp = Graphics.FromImage(this._radar);

			// Define the vertices of the this._sectionAmount triangular sections
			Point[][] triangles = new Point[this._sectionAmount][];
			Point center = new Point(75, 75);
			double angleStep = 360.0 / this._sectionAmount;
			double overlapAngle = 0; // Adjust this value to increase or decrease the overlap

			for (int i = 0; i < this._sectionAmount; i++)
			{
				double angle1 = Math.PI / 180 * ((i * angleStep) - overlapAngle);
				double angle2 = Math.PI / 180 * (((i + 1) * angleStep) + overlapAngle);

				Point vertex1 = new Point(center.X + (int)(150 * Math.Cos(angle1)), center.Y + (int)(150 * Math.Sin(angle1)));
				Point vertex2 = new Point(center.X + (int)(150 * Math.Cos(angle2)), center.Y + (int)(150 * Math.Sin(angle2))) ;

				triangles[i] = new Point[] { center, GetIntersectionPoint(center, vertex1), GetIntersectionPoint(center, vertex2) };
			}

			for (int i = 0; i < this._sectionAmount; i++)
			{// Draw only the inner borders of the sections
			 // Highlight the section if it was highlighted within the last 3 seconds
				if ((DateTime.Now - lastHighlightedTimestamps[i]).TotalSeconds > this._highlightDurationSeconds)
				{
					grp.FillPolygon(Brushes.Black, triangles[i]); // Fill the highlighted section
				}
				grp.DrawLine(Pens.MintCream, triangles[i][0], triangles[i][1]);
				grp.DrawLine(Pens.MintCream, triangles[i][0], triangles[i][2]);
			}

			// Determine in which triangular section the red dot falls
			int section = -1;
			for (int i = 0; i < this._sectionAmount; i++)
			{
				if (IsPointInTriangle(new Point(x, y), triangles[i][0], triangles[i][1], triangles[i][2]))
				{
					section = i;
					break;
				}
			}

			// Highlight the section where the red dot if threshold is met (radius)
			double normalized_x = (75f - x) % 75;
			double normalized_y = (75f - y) % 75;
			double magnitude = Math.Sqrt((normalized_x * normalized_x) + (normalized_y * normalized_y));
			if (section != -1 && magnitude >= this._highlightSoundThreshold)  
			{
				grp.FillPolygon(Brushes.Green, triangles[section]); // Fill the highlighted section
				lastHighlightedTimestamps[section] = DateTime.Now; // Save time of last highlighting

			}

			// Draw the red dot
			grp.FillRectangle(Brushes.Red, x - 5, y - 5, 10, 10);

			this.RadarBox.Invoke(new MethodInvoker(delegate ()
			{
				this.RadarBox.Image = this._radar;
			}));
		}
		private Point GetIntersectionPoint(Point p1, Point p2)
		{
			float t;
			if (p2.X - p1.X != 0)
			{
				t = Math.Min(Math.Max((-150 - p1.X) / (float)(p2.X - p1.X), (300 - p1.X) / (float)(p2.X - p1.X)), 1);
			}
			else
			{
				t = Math.Min(Math.Max((-150 - p1.Y) / (float)(p2.Y - p1.Y), (300 - p1.Y) / (float)(p2.Y - p1.Y)), 1);
			}

			return new Point((int)(p1.X + t * (p2.X - p1.X)), (int)(p1.Y + t * (p2.Y - p1.Y)));
		}

		// Method to check if a point is inside a triangle
		private bool IsPointInTriangle(Point pt, Point v1, Point v2, Point v3)
		{
			float d1, d2, d3;
			bool has_neg, has_pos;

			d1 = Sign(pt, v1, v2);
			d2 = Sign(pt, v2, v3);
			d3 = Sign(pt, v3, v1);

			has_neg = (d1 < 0) || (d2 < 0) || (d3 < 0);
			has_pos = (d1 > 0) || (d2 > 0) || (d3 > 0);

			return !(has_neg && has_pos);
		}

		private float Sign(Point p1, Point p2, Point p3)
		{
			return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
		}
		// Token: 0x0400000B RID: 11
		private MMDeviceEnumerator _enumerator;

		// Token: 0x0400000C RID: 12
		private MMDevice _device;

		// Token: 0x0400000D RID: 13
		private int _multiplier = 500;

		// Token: 0x0400000E RID: 14
		private int _updateRate = 50;

		// Amount of Triangle Slices
		private int _sectionAmount = 12;

		// Highlighting Duration in Seconds
		private int _highlightDurationSeconds = 3;

		// Highlighting SoundThreshold
		private int _highlightSoundThreshold = 50;

		//Delay Time for visuals
		private int _delay = 5;

		// Token: 0x0400000F RID: 15
		private readonly Bitmap _radar = new Bitmap(150, 150);

		// Token: 0x04000010 RID: 16
		public IntPtr ParentHandle;
	}
}
