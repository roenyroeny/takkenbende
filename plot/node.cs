using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace plot
{
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
