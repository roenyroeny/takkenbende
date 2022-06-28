﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Windows.Forms;

namespace plot
{
	public partial class Form1 : Form
	{
		public const int selectDistance = 15;
		public List<node> nodes = new List<node>();
		public List<edge> edges = new List<edge>();

		int mouseX, mouseY;
		node selectedNode, dragNode;
		edge selectedEdge;

		Font font;
		Font fontB;

		Matrix view = new Matrix();



		bool LoadPlot()
		{
			nodes.Clear();
			edges.Clear();
			try
			{
				XElement e = XElement.Load("plot.xml");
				foreach (var n in e.Elements("node"))
				{
					var x = double.Parse(n.Attribute("x").Value);
					var y = double.Parse(n.Attribute("y").Value);
					var c = double.Parse(n.Attribute("c").Value);
					var name = n.Attribute("n").Value;
					var locked = bool.Parse(n.Attribute("l").Value);
					var info = n.Attribute("i").Value;
					var nn = new node { X = x, Y = y, Circumference = c, name = name, locked = locked, info = info };
					nodes.Add(nn);
				}

				foreach (var n in e.Elements("edge_n"))
				{
					var a = int.Parse(n.Attribute("a").Value);
					var b = int.Parse(n.Attribute("b").Value);
					var d = double.Parse(n.Attribute("d").Value);
					var info = n.Attribute("i").Value;
					var edge = new edgeNodes { nodes = new node[] { nodes[a], nodes[b] }, Distance = d, info = info };

					edges.Add(edge);
				}

				foreach (var n in e.Elements("edge_e"))
				{
					var a = int.Parse(n.Attribute("a").Value);
					var b = int.Parse(n.Attribute("b").Value);
					var d = double.Parse(n.Attribute("d").Value);
					var info = n.Attribute("i").Value;
					var edge = new edgeNodeEdge { Node = nodes[a], Edge = edges[b], Distance = d, info = info };

					edges.Add(edge);
				}
				return true;
			}
			catch { }
			return false;
		}

		bool SavePlot()
		{
			XElement file = new XElement("plot");
			foreach (var n in nodes)
			{
				XElement e = new XElement("node");
				e.SetAttributeValue("x", n.X);
				e.SetAttributeValue("y", n.Y);
				e.SetAttributeValue("c", n.Circumference);
				e.SetAttributeValue("n", n.name);
				e.SetAttributeValue("l", n.locked);
				e.SetAttributeValue("i", n.info);
				file.Add(e);
			}
			foreach (var edge in edges)
			{
				var edg = edge as edgeNodes;
				if (edg != null)
				{
					XElement e = new XElement("edge_n");
					e.SetAttributeValue("a", nodes.IndexOf(edg.Nodes[0]));
					e.SetAttributeValue("b", nodes.IndexOf(edg.Nodes[1]));
					e.SetAttributeValue("d", edg.Distance);
					e.SetAttributeValue("i", edg.info);
					file.Add(e);
				}
				else
				{
					var edg_e = edge as edgeNodeEdge;
					XElement e = new XElement("edge_e");
					e.SetAttributeValue("a", nodes.IndexOf(edg_e.Node));
					e.SetAttributeValue("b", edges.IndexOf(edg_e.Edge));
					e.SetAttributeValue("d", edg_e.Distance);
					e.SetAttributeValue("i", edg_e.info);
					file.Add(e);
				}
			}
			file.Save("plot.xml");
			return true;
		}

		void removeNode(node node)
		{
			if (node == selectedNode)
				selectNode(null);
			if (node == dragNode)
				dragNode = null;

			edges = edges.Where(e => !e.Nodes.Contains(node)).ToList();

			nodes.Remove(node);
		}

		void removeEdge(edge edge)
		{
			edges = edges.Where(e => !e.Edges.Contains(edge)).ToList();
			edges.Remove(edge);
		}

		void selectNode(node n)
		{
			selectedNode = n;
			if (selectedEdge != null && selectedNode != null)
				selectEdge(null);

			if (selectedNode != null)
			{
				t_circ.Text = $"{(int)(n.Circumference)}";
				t_X.Text = $"{(int)(n.X)}";
				t_Y.Text = $"{(int)(n.Y)}";
				t_name.Text = n.name;
				t_info.Text = n.info;
				c_locked.Checked = n.locked;
			}
			g_edge.Enabled = selectedEdge != null;
			g_node.Enabled = selectedNode != null;
			g_edge.Visible = selectedEdge != null;
			g_node.Visible = selectedNode != null;
		}

		void selectEdge(edge e)
		{
			selectedEdge = e;
			if (selectedEdge != null && selectedNode != null)
				selectNode(null);

			if (selectedEdge != null)
			{
				t_dist.Text = $"{(int)(e.Distance)}";
			}
			g_edge.Enabled = selectedEdge != null;
			g_node.Enabled = selectedNode != null;
			g_edge.Visible = selectedEdge != null;
			g_node.Visible = selectedNode != null;
		}


		public Form1()
		{
			InitializeComponent();
			DoubleBuffered = true;

			view.Reset();
			view.Translate(20, 20);
			view.Scale(0.2f, 0.2f);

			font = Font;
			FontFamily fontFamily = new FontFamily("Arial");
			fontB = new Font(
			   fontFamily,
			   16,
			   FontStyle.Bold,
			   GraphicsUnit.Pixel);


			p_view.GetType().GetMethod("SetStyle",
				System.Reflection.BindingFlags.Instance |
				System.Reflection.BindingFlags.NonPublic).Invoke(p_view,
			new object[]
			{
				System.Windows.Forms.ControlStyles.UserPaint |
				System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
				System.Windows.Forms.ControlStyles.DoubleBuffer, true
			});


			p_view.MouseWheel += new MouseEventHandler(this.panel1_MouseWheel);

			(p_view as Control).KeyDown += Form1_KeyDown;
			(p_view as Control).KeyUp += Form1_KeyUp;
			selectNode(null);
		}



		private void Form1_Load(object sender, EventArgs e)
		{
			if (!LoadPlot())
			{
				var A = new node { name = "A", X = 0, Y = 0, Circumference = 0, locked = true };
				var B = new node { name = "B", X = 4700, Y = 0, Circumference = 0, locked = true };
				var C = new node { name = "C", X = 4700, Y = 3900, Circumference = 0, locked = true };
				var D = new node { name = "D", X = 1860, Y = 3850, Circumference = 0, locked = true };
				var E = new node { name = "E", X = 855, Y = 5343, Circumference = 0, locked = true };
				var F = new node { name = "F", X = 0, Y = 5935, Circumference = 0, locked = true };

				nodes.AddRange(new node[] { A, B, C, D, E, F });

				edges.Add(new edgeNodes { nodes = new node[] { A, B } });
				edges.Add(new edgeNodes { nodes = new node[] { B, C } });
				edges.Add(new edgeNodes { nodes = new node[] { C, D } });
				edges.Add(new edgeNodes { nodes = new node[] { D, E } });
				edges.Add(new edgeNodes { nodes = new node[] { E, F } });
				edges.Add(new edgeNodes { nodes = new node[] { F, A } });
			}
		}

		void simulate()
		{
			foreach (node n in nodes)
			{
				if (n.Circumference < 0)
					n.Circumference = 0;
			}

			foreach (edge e in edges)
			{
				if (e.Distance < 0)
					e.Distance = 0;

				if (e.Distance == 0)
					continue;

				var v = e.Vertices;

				var cx = (v[0].X + v[1].X) * 0.5;
				var cy = (v[0].Y + v[1].Y) * 0.5;

				var dx = (v[0].X - v[1].X) * 0.5;
				var dy = (v[0].Y - v[1].Y) * 0.5;

				var l = Math.Sqrt(dx * dx + dy * dy);

				// normalize
				dx /= l;
				dy /= l;

				var dist = e.Distance;


				dx *= l - (dist * 0.5);
				dy *= l - (dist * 0.5);

				dx *= 0.4f; // smooth
				dy *= 0.4f; // smooth

				var en = e as edgeNodes;
				if (en != null)
				{
					if (!en.nodes[0].locked)
					{
						en.nodes[0].X -= dx;
						en.nodes[0].Y -= dy;
					}
					if (!en.nodes[1].locked)
					{
						en.nodes[1].X += dx;
						en.nodes[1].Y += dy;
					}
				}

				var ee = e as edgeNodeEdge;
				if (ee != null)
				{
					if (!ee.Node.locked)
					{
						ee.Node.X -= dx;
						ee.Node.Y -= dy;
					}
				}
			}
		}

		PointF ToView(PointF p)
		{
			var ps = new PointF[] { p };
			view.TransformPoints(ps);
			return ps[0];
		}

		PointF ToView(double x, double y)
		{
			var ps = new PointF[] { new PointF((float)x, (float)y) };
			view.TransformPoints(ps);
			return ps[0];
		}

		PointF FromView(PointF p)
		{
			var v = view.Clone();
			v.Invert();
			var ps = new PointF[] { p };
			v.TransformPoints(ps);
			return ps[0];
		}

		private void panel2_Paint(object sender, PaintEventArgs e)
		{
			StringFormat textFormat = new StringFormat();
			textFormat.Alignment = StringAlignment.Center;
			// textFormat. = StringAlignment.Center;
			var g = e.Graphics;
			g.Clear(Color.White);


			{
				var tl = FromView(new PointF());
				var br = FromView(new PointF(p_view.Width, p_view.Height));

				var gridSize = 100; // cm

				var x1 = (int)Math.Floor(tl.X / gridSize) * gridSize;
				var x2 = (int)Math.Ceiling(br.X / gridSize) * gridSize;
				var y1 = (int)Math.Floor(tl.Y / gridSize) * gridSize;
				var y2 = (int)Math.Ceiling(br.Y / gridSize) * gridSize;

				for (int x = x1; x < x2; x += gridSize)
				{
					var p = ToView(x, 0);
					g.DrawLine(Pens.LightGray, p.X, 0, p.X, p_view.Height);
				}
				for (int y = y1; y < y2; y += gridSize)
				{
					var p = ToView(0, y);
					g.DrawLine(Pens.LightGray, 0, p.Y, p_view.Width, p.Y);
				}
			}


			foreach (var n in nodes)
			{
				float t = n.locked ? 2.0f : 1.0f; // thickness
				var pen = selectedNode == n ?
					new Pen(new SolidBrush(Color.Red), t) :
					new Pen(new SolidBrush(Color.Black), t);

				var brush = Brushes.Black;
				if (!n.visible)
				{
					pen = new Pen(new SolidBrush(Color.LightGray), t);
					brush = Brushes.LightGray;
				}

				var p = ToView(new PointF((float)n.X, (float)n.Y));
				if (n.Circumference == 0.0)
				{
					var size = 20;

					g.DrawLine(pen,
						(float)(p.X - size / 2.0), (float)(p.Y - size / 2.0),
						(float)(p.X + size / 2.0), (float)(p.Y + size / 2.0));
					g.DrawLine(pen,
						(float)(p.X + size / 2.0), (float)(p.Y - size / 2.0),
						(float)(p.X - size / 2.0), (float)(p.Y + size / 2.0));
				}
				else
				{
					var p1 = ToView(new PointF((float)(n.X - n.Radius), (float)(n.Y - n.Radius)));
					var p2 = ToView(new PointF((float)(n.X + n.Radius), (float)(n.Y + n.Radius)));
					g.DrawEllipse(pen, new RectangleF(new PointF(p1.X, p1.Y), new SizeF(p2.X - p1.X, p2.Y - p1.Y)));
				}

				if (n.Circumference != 0)
				{
					g.DrawString(n.name, fontB, brush, p.X, p.Y - 10, textFormat);
				}
			}

			foreach (var n in edges)
			{
				float t = n.Nodes[0].locked && n.Nodes[1].locked ? 2.0f : 1.0f; // thickness
				var pen = selectedEdge == n ?
					new Pen(new SolidBrush(Color.Red), t) :
					new Pen(new SolidBrush(Color.Black), t);

				var brush = Brushes.Black;

				if (!n.Nodes.All(a => a.visible))
				{
					pen = new Pen(new SolidBrush(Color.LightGray), t);
					brush = Brushes.LightGray;
				}

				var p1 = ToView(n.Vertices[0]);
				var p2 = ToView(n.Vertices[1]);

				g.DrawLine(pen, p1, p2);

				var v = n.Vertices;
				var cx = (v[0].X + v[1].X) * 0.5;
				var cy = (v[0].Y + v[1].Y) * 0.5;

				var p = ToView(cx, cy);
				var str = "";
				if (n.Distance != 0)
				{
					str = $"{(int)(n.Distance)}cm";
				}
				else
				{
					str = $"({(int)(n.length)}cm)";
				}
				g.DrawString(str, font, brush, p);
			}

			if (dragNode != null)
			{
				var p1 = ToView(new PointF((float)dragNode.X, (float)dragNode.Y));
				var p2 = (new PointF((float)mouseX, (float)mouseY));

				var p = new Pen(Color.Black);
				float[] dashValues = { 8, 8 };
				p.DashPattern = dashValues;
				g.DrawLine(p, p1, p2);
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (ModifierKeys != Keys.Control)
			{
				simulate();
			}
			p_view.Invalidate();
		}

		private void panel2_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (selectedNode != null || selectedEdge != null)
				return;
			var p = PointToScreen(new Point(e.Location.X + p_view.Location.X, e.Location.Y + p_view.Location.Y));
			var pf = FromView(new PointF(e.Location.X, e.Location.Y));
			nodes.Add(new node { X = pf.X, Y = pf.Y, Circumference = 0, locked = false, name = $"{nodes.Count}" });
		}

		node PickNode(PointF p, bool view = false)
		{
			foreach (node n in nodes)
			{
				if (!n.visible)
					continue;
				{
					var np = ToView(new PointF((float)n.X, (float)n.Y));
					var dx = np.X - p.X;
					var dy = np.Y - p.Y;
					var d = Math.Sqrt(dx * dx + dy * dy);
					if (d < selectDistance)
						return n;
				}

				{
					var np = FromView(p);
					var dx = np.X - n.X;
					var dy = np.Y - n.Y;
					var d = Math.Sqrt(dx * dx + dy * dy);
					if (d < n.Radius)
						return n;
				}
			}
			return null;
		}
		edge PickEdge(PointF p)
		{
			foreach (var e in edges)
			{
				if (!e.Nodes.All(a => a.visible))
					continue;
				var v0 = ToView(e.Vertices[0]);
				var v1 = ToView(e.Vertices[1]);


				var d0x = p.X - v0.X;
				var d0y = p.Y - v0.Y;

				var d1x = v1.X - v0.X;
				var d1y = v1.Y - v0.Y;
				var d1l = (float)Math.Sqrt(d1x * d1x + d1y * d1y);
				d1x /= d1l;
				d1y /= d1l;

				float dot = d0x * d1x + d0y * d1y;
				if (dot < 0.0f)
					continue;
				if (dot > d1l)
					continue;
				d1x *= dot;
				d1y *= dot;

				d1x -= d0x;
				d1y -= d0y;
				var dist = (float)Math.Sqrt(d1x * d1x + d1y * d1y);

				if (dist < selectDistance)
					return e;
			}
			return null;
		}

		private void panel2_MouseDown(object sender, MouseEventArgs e)
		{
			p_view.Focus();
			if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
			{
				var edge = PickEdge(new PointF(e.X, e.Y));
				selectEdge(edge);

				dragNode = PickNode(new PointF(e.X, e.Y));
				selectNode(dragNode);

				if (selectedNode != null || selectedEdge != null)
				{
					var p = PointToScreen(new Point(e.Location.X + p_view.Location.X, e.Location.Y + p_view.Location.Y));
					if (e.Button == MouseButtons.Right)
					{
						contextMenuStrip1.Show(p);
					}

					if (ModifierKeys != Keys.Control)
					{
						if (selectedEdge != null)
						{
							t_dist.Focus();
							t_dist.SelectAll();
						}

						if (selectedNode != null)
						{
							t_circ.Focus();
							t_circ.SelectAll();
						}
					}
				}
			}
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (selectedNode != null)
				removeNode(selectedNode);
			if (selectedEdge != null)
				removeEdge(selectedEdge);
		}

		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (selectedEdge != null)
				{
					double.TryParse(t_dist.Text, out selectedEdge.Distance);
				}
			}
		}

		private void panel2_MouseUp(object sender, MouseEventArgs e)
		{
			if (ModifierKeys != Keys.Control)
			{
				if (dragNode != null)
				{
					var other = PickNode(new PointF(e.X, e.Y));
					var othere = PickEdge(new PointF(e.X, e.Y));

					if (other == dragNode)
						other = null;
					if (othere == null || othere.Nodes.Contains(dragNode) || !othere.Pure)
						othere = null;

					if (other != null)
					{
						var newedge = new edgeNodes { nodes = new node[] { dragNode, other } };
						edges.Add(newedge);
						selectEdge(newedge);

					}
					else if (othere != null)
					{
						var newedge = new edgeNodeEdge { Node = dragNode, Edge = othere };
						edges.Add(newedge);
						selectEdge(newedge);
					}
				}
			}

			dragNode = null;
		}

		private void panel2_MouseMove(object sender, MouseEventArgs e)
		{
			var np = FromView(new PointF((float)e.X, (float)e.Y));
			if (ModifierKeys == Keys.Control)
			{
				if (dragNode != null && !dragNode.locked)
				{
					dragNode.X = np.X;
					dragNode.Y = np.Y;
					selectNode(null);
				}
			}
			else
			{
				if (selectedEdge == null && selectedNode == null)
				{
					// strafe
					if (e.Button == MouseButtons.Left)
					{
						var v2 = view.Clone();
						v2.Invert();
						var p = new PointF((float)(e.X - mouseX), (float)(e.Y - mouseY));
						var ps = new PointF[] { p };
						v2.TransformVectors(ps);
						view.Translate(ps[0].X, ps[0].Y);
					}
				}
			}
			mouseX = e.X;
			mouseY = e.Y;
		}
		private void panel1_MouseWheel(object sender, MouseEventArgs e)
		{
			if (ModifierKeys == Keys.Control)
			{
				if (selectedEdge != null)
				{
					selectedEdge.Distance -= e.Delta / 12;
					if (selectedEdge.Distance < 0)
						selectedEdge.Distance = 0;
				}
				if (selectedNode != null)
				{
					selectedNode.Circumference += e.Delta / 12;
					if (selectedNode.Circumference < 0)
						selectedNode.Circumference = 0;
				}
			}
			else
			{
				var p = FromView(new PointF(mouseX, mouseY));

				float s2 = view.Elements[0];
				view.Translate(p.X, p.Y);
				float t = -e.Delta / 120.0f;
				float s = 1.0f - t * 0.125f;

				view.Scale(s, s, MatrixOrder.Prepend);

				view.Translate(-p.X, -p.Y);
			}
		}


		private void t_circ_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (selectedNode != null)
				{
					double.TryParse(t_circ.Text, out selectedNode.Circumference);
				}
			}
		}

		private void t_name_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (selectedNode != null)
				{
					selectedNode.name = t_name.Text;
				}
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			SavePlot();
		}

		private void t_info_KeyDown(object sender, KeyEventArgs e)
		{
			if (selectedNode != null)
			{
				selectedNode.info = t_info.Text;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (selectedEdge != null)
			{
				selectedEdge.Distance = selectedEdge.lengthOnCenter - selectedEdge.Radii[0] - selectedEdge.Radii[1];
			}
		}

		private void c_locked_CheckedChanged(object sender, EventArgs e)
		{
			if (selectedNode != null)
			{
				selectedNode.locked = c_locked.Checked;
			}
		}

		private void t_X_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (selectedNode != null)
				{
					double.TryParse(t_Y.Text, out selectedNode.X);
				}
			}
		}

		private void t_Y_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (selectedNode != null)
				{
					double.TryParse(t_Y.Text, out selectedNode.Y);
				}
			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			foreach (node n in nodes)
			{
				n.visible = n.MatchInfo(textBox1.Text);
			}
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{

			if (ModifierKeys == Keys.Control && e.KeyCode == Keys.F)
			{
				textBox1.Focus();
				textBox1.SelectAll();
			}

			if (e.KeyCode == Keys.Home)
			{
				view.Reset();
				view.Scale(0.25f, 0.25f);
			}
		}
		private void Form1_KeyUp(object sender, KeyEventArgs e)
		{
		}
	}
}
