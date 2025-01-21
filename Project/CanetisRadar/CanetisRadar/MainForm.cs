using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace CanetisRadar
{
	// Token: 0x02000002 RID: 2
	public partial class MainForm : Form
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public MainForm()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002068 File Offset: 0x00000268
		private void Button1_Click(object sender, EventArgs e)
		{
			Overlay o = new Overlay
			{
				ParentHandle = base.Handle
			};
			o.Show();
			base.Hide();
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002096 File Offset: 0x00000296
		private void Button3_Click(object sender, EventArgs e)
		{
			MessageBox.Show("CanetisRadarv3\nCopyright (c) 2023 Samuel Tulach, Philipp Ensinger\n\nThis program is free software: you can redistribute it and/or modify\nit under the terms of the GNU General Public License as published by\nthe Free Software Foundation, either version 3 of the License, or\n(at your option) any later version.\n\nThis program is distributed in the hope that it will be useful,\nbut WITHOUT ANY WARRANTY; without even the implied warranty of\nMERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the\nGNU General Public License for more details.\n\nYou should have received a copy of the GNU General Public License\nalong with this program.  If not, see <https://www.gnu.org/licenses/>.", "About this program", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000020AC File Offset: 0x000002AC
		private void MainForm_Load(object sender, EventArgs e)
		{
			this.toolStripStatusLabel1.Text = string.Format("Version: {0}", Assembly.GetExecutingAssembly().GetName().Version);
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020D4 File Offset: 0x000002D4
		private void Button2_Click(object sender, EventArgs e)
		{
			Process.Start(AppDomain.CurrentDomain.BaseDirectory + "settings.ini");
		}
	}
}
