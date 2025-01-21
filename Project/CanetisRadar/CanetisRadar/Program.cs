using System;
using System.Windows.Forms;

namespace CanetisRadar
{
	// Token: 0x02000004 RID: 4
	internal static class Program
	{
		// Token: 0x06000011 RID: 17 RVA: 0x00002CB1 File Offset: 0x00000EB1
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}
