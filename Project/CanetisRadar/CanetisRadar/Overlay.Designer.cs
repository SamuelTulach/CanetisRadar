namespace CanetisRadar
{
	// Token: 0x02000003 RID: 3
	public partial class Overlay : global::System.Windows.Forms.Form
	{
		// Token: 0x0600000E RID: 14 RVA: 0x00002AFC File Offset: 0x00000CFC
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002B34 File Offset: 0x00000D34
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::CanetisRadar.Overlay));
			this.RadarBox = new global::System.Windows.Forms.PictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.RadarBox).BeginInit();
			base.SuspendLayout();
			int yPosRadar = 50;
			this.RadarBox.Location = new global::System.Drawing.Point(12, yPosRadar);
			this.RadarBox.Name = "RadarBox";
			this.RadarBox.Size = new global::System.Drawing.Size(150, 150);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(512, 512);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Overlay";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			base.Location = new global::System.Drawing.Point(150, 150);
			this.Text = "CanetisRadar Overlay";
			base.TopMost = true;
			base.Controls.Add(this.RadarBox);
			base.Load += new global::System.EventHandler(this.Overlay_Load);
			((global::System.ComponentModel.ISupportInitialize)this.RadarBox).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000011 RID: 17
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000012 RID: 18
		private global::System.Windows.Forms.PictureBox RadarBox;
	}
}
