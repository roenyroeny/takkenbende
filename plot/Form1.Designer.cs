
namespace plot
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.panel1 = new System.Windows.Forms.Panel();
			this.g_node = new System.Windows.Forms.GroupBox();
			this.t_info = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.c_locked = new System.Windows.Forms.CheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.t_Y = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.t_X = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.t_circ = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.t_name = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.g_edge = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.t_dist = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.p_view = new System.Windows.Forms.Panel();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveOBJToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.c_crossed = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.g_node.SuspendLayout();
			this.g_edge.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.g_node);
			this.panel1.Controls.Add(this.g_edge);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 39);
			this.panel1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(533, 2091);
			this.panel1.TabIndex = 0;
			// 
			// g_node
			// 
			this.g_node.Controls.Add(this.t_info);
			this.g_node.Controls.Add(this.label5);
			this.g_node.Controls.Add(this.c_crossed);
			this.g_node.Controls.Add(this.label7);
			this.g_node.Controls.Add(this.c_locked);
			this.g_node.Controls.Add(this.label6);
			this.g_node.Controls.Add(this.t_Y);
			this.g_node.Controls.Add(this.label10);
			this.g_node.Controls.Add(this.t_X);
			this.g_node.Controls.Add(this.label4);
			this.g_node.Controls.Add(this.t_circ);
			this.g_node.Controls.Add(this.label3);
			this.g_node.Controls.Add(this.t_name);
			this.g_node.Controls.Add(this.label2);
			this.g_node.Dock = System.Windows.Forms.DockStyle.Top;
			this.g_node.Location = new System.Drawing.Point(0, 422);
			this.g_node.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.g_node.Name = "g_node";
			this.g_node.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.g_node.Size = new System.Drawing.Size(533, 820);
			this.g_node.TabIndex = 0;
			this.g_node.TabStop = false;
			this.g_node.Text = "node";
			// 
			// t_info
			// 
			this.t_info.Dock = System.Windows.Forms.DockStyle.Fill;
			this.t_info.Location = new System.Drawing.Point(8, 449);
			this.t_info.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.t_info.Multiline = true;
			this.t_info.Name = "t_info";
			this.t_info.Size = new System.Drawing.Size(517, 364);
			this.t_info.TabIndex = 0;
			this.t_info.KeyDown += new System.Windows.Forms.KeyEventHandler(this.t_info_KeyDown);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Dock = System.Windows.Forms.DockStyle.Top;
			this.label5.Location = new System.Drawing.Point(8, 418);
			this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(58, 31);
			this.label5.TabIndex = 8;
			this.label5.Text = "info";
			// 
			// c_locked
			// 
			this.c_locked.AutoSize = true;
			this.c_locked.Dock = System.Windows.Forms.DockStyle.Top;
			this.c_locked.Location = new System.Drawing.Point(8, 345);
			this.c_locked.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.c_locked.Name = "c_locked";
			this.c_locked.Size = new System.Drawing.Size(517, 21);
			this.c_locked.TabIndex = 0;
			this.c_locked.UseVisualStyleBackColor = true;
			this.c_locked.CheckedChanged += new System.EventHandler(this.c_locked_CheckedChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Dock = System.Windows.Forms.DockStyle.Top;
			this.label6.Location = new System.Drawing.Point(8, 314);
			this.label6.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(93, 31);
			this.label6.TabIndex = 9;
			this.label6.Text = "locked";
			// 
			// t_Y
			// 
			this.t_Y.Dock = System.Windows.Forms.DockStyle.Top;
			this.t_Y.Location = new System.Drawing.Point(8, 276);
			this.t_Y.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.t_Y.Name = "t_Y";
			this.t_Y.Size = new System.Drawing.Size(517, 38);
			this.t_Y.TabIndex = 7;
			this.t_Y.KeyDown += new System.Windows.Forms.KeyEventHandler(this.t_Y_KeyDown);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Dock = System.Windows.Forms.DockStyle.Top;
			this.label10.Location = new System.Drawing.Point(8, 245);
			this.label10.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(32, 31);
			this.label10.TabIndex = 6;
			this.label10.Text = "Y";
			// 
			// t_X
			// 
			this.t_X.Dock = System.Windows.Forms.DockStyle.Top;
			this.t_X.Location = new System.Drawing.Point(8, 207);
			this.t_X.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.t_X.Name = "t_X";
			this.t_X.Size = new System.Drawing.Size(517, 38);
			this.t_X.TabIndex = 5;
			this.t_X.KeyDown += new System.Windows.Forms.KeyEventHandler(this.t_X_KeyDown);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Dock = System.Windows.Forms.DockStyle.Top;
			this.label4.Location = new System.Drawing.Point(8, 176);
			this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(32, 31);
			this.label4.TabIndex = 4;
			this.label4.Text = "X";
			// 
			// t_circ
			// 
			this.t_circ.Dock = System.Windows.Forms.DockStyle.Top;
			this.t_circ.Location = new System.Drawing.Point(8, 138);
			this.t_circ.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.t_circ.Name = "t_circ";
			this.t_circ.Size = new System.Drawing.Size(517, 38);
			this.t_circ.TabIndex = 2;
			this.t_circ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.t_circ_KeyDown);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Dock = System.Windows.Forms.DockStyle.Top;
			this.label3.Location = new System.Drawing.Point(8, 107);
			this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(185, 31);
			this.label3.TabIndex = 3;
			this.label3.Text = "circumference";
			// 
			// t_name
			// 
			this.t_name.Dock = System.Windows.Forms.DockStyle.Top;
			this.t_name.Location = new System.Drawing.Point(8, 69);
			this.t_name.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.t_name.Name = "t_name";
			this.t_name.Size = new System.Drawing.Size(517, 38);
			this.t_name.TabIndex = 1;
			this.t_name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.t_name_KeyDown);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Dock = System.Windows.Forms.DockStyle.Top;
			this.label2.Location = new System.Drawing.Point(8, 38);
			this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(81, 31);
			this.label2.TabIndex = 1;
			this.label2.Text = "name";
			// 
			// g_edge
			// 
			this.g_edge.Controls.Add(this.button1);
			this.g_edge.Controls.Add(this.t_dist);
			this.g_edge.Controls.Add(this.label1);
			this.g_edge.Dock = System.Windows.Forms.DockStyle.Top;
			this.g_edge.Location = new System.Drawing.Point(0, 184);
			this.g_edge.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.g_edge.Name = "g_edge";
			this.g_edge.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.g_edge.Size = new System.Drawing.Size(533, 238);
			this.g_edge.TabIndex = 0;
			this.g_edge.TabStop = false;
			this.g_edge.Text = "edge";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 131);
			this.button1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(144, 52);
			this.button1.TabIndex = 0;
			this.button1.Text = "snap";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// t_dist
			// 
			this.t_dist.Dock = System.Windows.Forms.DockStyle.Top;
			this.t_dist.Location = new System.Drawing.Point(8, 69);
			this.t_dist.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.t_dist.Name = "t_dist";
			this.t_dist.Size = new System.Drawing.Size(517, 38);
			this.t_dist.TabIndex = 0;
			this.t_dist.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(8, 38);
			this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(116, 31);
			this.label1.TabIndex = 0;
			this.label1.Text = "distance";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.groupBox1.Size = new System.Drawing.Size(533, 184);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "search";
			// 
			// textBox1
			// 
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.textBox1.Location = new System.Drawing.Point(8, 38);
			this.textBox1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(517, 38);
			this.textBox1.TabIndex = 0;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.checkBox2);
			this.groupBox2.Controls.Add(this.checkBox1);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox2.Location = new System.Drawing.Point(0, 1922);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.groupBox2.Size = new System.Drawing.Size(533, 169);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "filter";
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Checked = true;
			this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.checkBox2.Location = new System.Drawing.Point(8, 73);
			this.checkBox2.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(517, 35);
			this.checkBox2.TabIndex = 1;
			this.checkBox2.Text = "labels";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.checkBox1.Location = new System.Drawing.Point(8, 38);
			this.checkBox1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(517, 35);
			this.checkBox1.TabIndex = 0;
			this.checkBox1.Text = "edges";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(533, 39);
			this.splitter1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(8, 2091);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			// 
			// p_view
			// 
			this.p_view.Dock = System.Windows.Forms.DockStyle.Fill;
			this.p_view.Location = new System.Drawing.Point(541, 39);
			this.p_view.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.p_view.Name = "p_view";
			this.p_view.Size = new System.Drawing.Size(3303, 2091);
			this.p_view.TabIndex = 2;
			this.p_view.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
			this.p_view.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDoubleClick);
			this.p_view.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
			this.p_view.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
			this.p_view.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 33;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(135, 36);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(134, 32);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
			// 
			// contextMenuStrip2
			// 
			this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.contextMenuStrip2.Name = "contextMenuStrip2";
			this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
			this.contextMenuStrip2.Text = "Add";
			// 
			// printDocument1
			// 
			this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
			// 
			// menuStrip1
			// 
			this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(16, 5, 0, 5);
			this.menuStrip1.Size = new System.Drawing.Size(3844, 39);
			this.menuStrip1.TabIndex = 3;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printToolStripMenuItem,
            this.saveOBJToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// printToolStripMenuItem
			// 
			this.printToolStripMenuItem.Name = "printToolStripMenuItem";
			this.printToolStripMenuItem.Size = new System.Drawing.Size(200, 34);
			this.printToolStripMenuItem.Text = "Print";
			this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
			// 
			// saveOBJToolStripMenuItem
			// 
			this.saveOBJToolStripMenuItem.Name = "saveOBJToolStripMenuItem";
			this.saveOBJToolStripMenuItem.Size = new System.Drawing.Size(200, 34);
			this.saveOBJToolStripMenuItem.Text = "Export OBJ";
			this.saveOBJToolStripMenuItem.Click += new System.EventHandler(this.saveOBJToolStripMenuItem_Click);
			// 
			// c_crossed
			// 
			this.c_crossed.AutoSize = true;
			this.c_crossed.Dock = System.Windows.Forms.DockStyle.Top;
			this.c_crossed.Location = new System.Drawing.Point(8, 397);
			this.c_crossed.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.c_crossed.Name = "c_crossed";
			this.c_crossed.Size = new System.Drawing.Size(517, 21);
			this.c_crossed.TabIndex = 10;
			this.c_crossed.UseVisualStyleBackColor = true;
			this.c_crossed.CheckedChanged += new System.EventHandler(this.c_crossed_CheckedChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Dock = System.Windows.Forms.DockStyle.Top;
			this.label7.Location = new System.Drawing.Point(8, 366);
			this.label7.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(110, 31);
			this.label7.TabIndex = 11;
			this.label7.Text = "crossed";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(3844, 2130);
			this.Controls.Add(this.p_view);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.Name = "Form1";
			this.Text = "Takkenbende";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.panel1.ResumeLayout(false);
			this.g_node.ResumeLayout(false);
			this.g_node.PerformLayout();
			this.g_edge.ResumeLayout(false);
			this.g_edge.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel p_view;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
		private System.Windows.Forms.GroupBox g_edge;
		private System.Windows.Forms.TextBox t_dist;
		private System.Windows.Forms.GroupBox g_node;
		private System.Windows.Forms.TextBox t_name;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox t_circ;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox t_Y;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox t_X;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox t_info;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.CheckBox c_locked;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Drawing.Printing.PrintDocument printDocument1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.ToolStripMenuItem saveOBJToolStripMenuItem;
		private System.Windows.Forms.CheckBox c_crossed;
		private System.Windows.Forms.Label label7;
	}
}

