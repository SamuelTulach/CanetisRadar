namespace CanetisRadar
{
	// Token: 0x02000002 RID: 2
	public partial class MainForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000006 RID: 6 RVA: 0x000020F4 File Offset: 0x000002F4
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x0000212C File Offset: 0x0000032C
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::CanetisRadar.MainForm));
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.richTextBox1 = new global::System.Windows.Forms.RichTextBox();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.button4 = new global::System.Windows.Forms.Button();
			this.button3 = new global::System.Windows.Forms.Button();
			this.button2 = new global::System.Windows.Forms.Button();
			this.button1 = new global::System.Windows.Forms.Button();
			this.statusStrip1 = new global::System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			base.SuspendLayout();
			this.groupBox1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.groupBox1.Controls.Add(this.richTextBox1);
			this.groupBox1.Location = new global::System.Drawing.Point(15, 15);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(487, 115);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Welcome";
			this.richTextBox1.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.richTextBox1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.richTextBox1.Location = new global::System.Drawing.Point(3, 19);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new global::System.Drawing.Size(481, 93);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
			this.groupBox3.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.groupBox3.Controls.Add(this.button4);
			this.groupBox3.Controls.Add(this.button3);
			this.groupBox3.Controls.Add(this.button2);
			this.groupBox3.Controls.Add(this.button1);
			this.groupBox3.Location = new global::System.Drawing.Point(15, 137);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(487, 63);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Let´s do it!";
			this.button4.Location = new global::System.Drawing.Point(390, 22);
			this.button4.Name = "button4";
			this.button4.Size = new global::System.Drawing.Size(87, 27);
			this.button4.TabIndex = 3;
			this.button4.Text = "GitHub";
			this.button4.UseVisualStyleBackColor = true;
			this.button3.Location = new global::System.Drawing.Point(196, 22);
			this.button3.Name = "button3";
			this.button3.Size = new global::System.Drawing.Size(87, 27);
			this.button3.TabIndex = 2;
			this.button3.Text = "About";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new global::System.EventHandler(this.Button3_Click);
			this.button2.Location = new global::System.Drawing.Point(101, 22);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(87, 27);
			this.button2.TabIndex = 1;
			this.button2.Text = "Settings";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new global::System.EventHandler(this.Button2_Click);
			this.button1.Location = new global::System.Drawing.Point(7, 22);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(87, 27);
			this.button1.TabIndex = 0;
			this.button1.Text = "Start overlay";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.Button1_Click);
			this.statusStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.toolStripStatusLabel1
			});
			this.statusStrip1.Location = new global::System.Drawing.Point(0, 216);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Padding = new global::System.Windows.Forms.Padding(1, 0, 16, 0);
			this.statusStrip1.Size = new global::System.Drawing.Size(520, 22);
			this.statusStrip1.TabIndex = 3;
			this.statusStrip1.Text = "statusStrip1";
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new global::System.Drawing.Size(106, 17);
			this.toolStripStatusLabel1.Text = "Nothing here now.";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(520, 238);
			base.Controls.Add(this.statusStrip1);
			base.Controls.Add(this.groupBox3);
			base.Controls.Add(this.groupBox1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "MainForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "CanetisRadar (by Samuel Tulach, Philipp Ensinger)";
			base.Load += new global::System.EventHandler(this.MainForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000001 RID: 1
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000002 RID: 2
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000003 RID: 3
		private global::System.Windows.Forms.RichTextBox richTextBox1;

		// Token: 0x04000004 RID: 4
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x04000005 RID: 5
		private global::System.Windows.Forms.Button button4;

		// Token: 0x04000006 RID: 6
		private global::System.Windows.Forms.Button button3;

		// Token: 0x04000007 RID: 7
		private global::System.Windows.Forms.Button button2;

		// Token: 0x04000008 RID: 8
		private global::System.Windows.Forms.Button button1;

		// Token: 0x04000009 RID: 9
		private global::System.Windows.Forms.StatusStrip statusStrip1;

		// Token: 0x0400000A RID: 10
		private global::System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
	}
}
