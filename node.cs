using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml.Linq;

namespace plot
{
	public class graph
	{
		public List<node> nodes = new List<node>();
		public List<edge> edges = new List<edge>();

		public static graph FromXML(XElement e)
		{
			graph g = new graph();
			g.nodes.Clear();
			g.edges.Clear();
			try
			{
				foreach (var n in e.Elements("node"))
				{
					var x = double.Parse(n.Attribute("x").Value);
					var y = double.Parse(n.Attribute("y").Value);
					var c = double.Parse(n.Attribute("c").Value);
					var name = n.Attribute("n").Value;
					var locked = bool.Parse(n.Attribute("l").Value);
					var info = n.Attribute("i").Value;
					var nn = new node { X = x, Y = y, Circumference = c, name = name, locked = locked, info = info };
					g.nodes.Add(nn);
				}

				foreach (var n in e.Elements("edge_n"))
				{
					var a = int.Parse(n.Attribute("a").Value);
					var b = int.Parse(n.Attribute("b").Value);
					var d = double.Parse(n.Attribute("d").Value);
					var info = n.Attribute("i").Value;
					var edge = new edgeNodes { nodes = new node[] { g.nodes[a], g.nodes[b] }, Distance = d, info = info };

					g.edges.Add(edge);
				}

				foreach (var n in e.Elements("edge_e"))
				{
					var a = int.Parse(n.Attribute("a").Value);
					var b = int.Parse(n.Attribute("b").Value);
					var d = double.Parse(n.Attribute("d").Value);
					var info = n.Attribute("i").Value;
					var edge = new edgeNodeEdge { Node = g.nodes[a], Edge = g.edges[b], Distance = d, info = info };

					g.edges.Add(edge);
				}
				return g;
			}
			catch { }
			return null;
		}

		public XElement XML
		{
			get
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
				return file;
			}
		}

		public string OBJ
		{
			get
			{
				ObjBuilder builder = new ObjBuilder();

				foreach (node n in nodes)
				{
					builder.addCircleAsFace((float)n.X, (float)n.Y, (float)n.Radius);
				}

				foreach (edge e in edges)
				{
					if (!e.Nodes.All(a => a.locked))
						continue;
					var v = e.Vertices;
					builder.AddLine(v[0].X, v[0].Y, v[1].X, v[1].Y);
				}

				return builder.emit();
			}
		}

		public void removeNode(node node)
		{
			edges = edges.Where(e => !e.Nodes.Contains(node)).ToList();

			nodes.Remove(node);
		}

		public void removeEdge(edge edge)
		{
			edges = edges.Where(e => !e.Edges.Contains(edge)).ToList();
			edges.Remove(edge);
		}


	}
	public class node
	{
		public bool visible = true;
		public double X, Y;
		public double Circumference;
		public bool locked;
		public string name = "";
		public string info = "";
		public double Radius
		{
			get { return Circumference / (Math.PI * 2); }
		}
		public bool MatchInfo(string key)
		{
			var infos = info.Split('\n');
			return info.Contains(key) || name.Contains(key);
		}
	}

	public abstract class edge
	{
		public abstract PointF[] Vertices { get; }
		public abstract PointF[] VerticesOnCenter { get; }
		public abstract double[] Radii { get; }
		public abstract bool Pure { get; }
		public abstract node[] Nodes { get; }
		public abstract edge[] Edges { get; }

		public float Stress
		{
			get
			{
				if (Distance == 0)
					return 0.0f;
				var v = Vertices;
				double dx = v[0].X - v[1].X;
				double dy = v[0].Y - v[1].Y;
				float l = (float)Math.Sqrt(dx * dx + dy * dy);

				float f;
				if (l < Distance)
				{
					f = l / (float)Distance;
				}
				else
				{
					f = (float)Distance / l;
				}

				return Math.Min((1.0f - f) * 10.0f, 1.0f);
			}
		}

		public double Distance = 0;
		public PointF NearestPoint(PointF p)
		{
			var v = Vertices;

			var d0x = p.X - v[0].X;
			var d0y = p.Y - v[0].Y;

			var d1x = v[1].X - v[0].X;
			var d1y = v[1].Y - v[0].Y;
			var d1l = (float)Math.Sqrt(d1x * d1x + d1y * d1y);
			d1x /= d1l;
			d1y /= d1l;

			float dot = d0x * d1x + d0y * d1y;
			if (dot < 0.0f)
				return v[0];
			if (dot > d1l)
				return v[1];
			d1x *= dot;
			d1y *= dot;

			d1x += v[0].X;
			d1y += v[0].Y;

			return new PointF(d1x, d1y);
		}

		public double length
		{
			get
			{
				double dx = Vertices[0].X - Vertices[1].X;
				double dy = Vertices[0].Y - Vertices[1].Y;
				return Math.Sqrt(dx * dx + dy * dy);
			}
		}

		public double lengthOnCenter
		{
			get
			{
				double dx = VerticesOnCenter[0].X - VerticesOnCenter[1].X;
				double dy = VerticesOnCenter[0].Y - VerticesOnCenter[1].Y;
				return Math.Sqrt(dx * dx + dy * dy);
			}
		}
	}

	// edge between nodes
	public class edgeNodes : edge
	{
		public string info = "";

		public node[] nodes = new node[2];
		public override node[] Nodes { get { return new node[] { nodes[0], nodes[1] }; } }
		public override edge[] Edges { get { return new edge[] { }; } }
		public override bool Pure { get { return true; } }

		public override PointF[] Vertices
		{
			get
			{
				var dx = nodes[0].X - nodes[1].X;
				var dy = nodes[0].Y - nodes[1].Y;
				var l = Math.Sqrt(dx * dx + dy * dy);
				dx /= l;
				dy /= l;

				return new PointF[] {
				new PointF((float)(nodes[0].X - dx * Radii[0]), (float)(nodes[0].Y - dy * Radii[0])),
				new PointF((float)(nodes[1].X + dx * Radii[1]), (float)(nodes[1].Y + dy * Radii[1]))};
			}
		}
		public override PointF[] VerticesOnCenter
		{
			get
			{
				return new PointF[] {
				new PointF((float)(nodes[0].X), (float)(nodes[0].Y)),
				new PointF((float)(nodes[1].X), (float)(nodes[1].Y))};
			}
		}

		public override double[] Radii
		{
			get
			{
				return new double[] { Nodes[0].Radius, Nodes[1].Radius };
			}
		}
	}
	// edge between a node and a (pure) edge
	public class edgeNodeEdge : edge
	{
		public string info = "";

		public node Node;
		public override node[] Nodes { get { return new node[] { Node }; } }
		public override edge[] Edges { get { return new edge[] { Edge }; } }
		public edge Edge;
		public override bool Pure { get { return false; } }

		public override PointF[] Vertices
		{
			get
			{
				var p = Edge.NearestPoint(new PointF((float)Node.X, (float)Node.Y));
				var dx = Node.X - p.X;
				var dy = Node.Y - p.Y;
				var l = Math.Sqrt(dx * dx + dy * dy);
				dx /= l;
				dy /= l;

				return new PointF[] {
				new PointF((float)(Node.X - dx * Radii[0]), (float)(Node.Y - dy * Radii[0])),
				new PointF((float)(p.X + dx * Radii[1]), (float)(p.Y + dy * Radii[1]))};
			}
		}
		public override PointF[] VerticesOnCenter
		{
			get
			{
				var p = Edge.NearestPoint(new PointF((float)Node.X, (float)Node.Y));

				return new PointF[] {
				new PointF((float)(Node.X), (float)(Node.Y )),
				new PointF((float)(p.X), (float)(p.Y))};
			}
		}

		public override double[] Radii
		{
			get
			{
				return new double[] { Node.Radius, 0 };
			}
		}
	}
}
