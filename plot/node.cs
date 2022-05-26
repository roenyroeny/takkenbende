using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace plot
{
	public class node
	{
		public double X, Y;
		public double Circumference;
		public bool locked;
		public string name = "";
		public double Radius
		{
			get { return Circumference / (Math.PI * 2); }
		}
	}


	public class edge
	{
		public node[] Nodes = new node[2];
		public PointF[] Vertices
		{
			get
			{
				var dx = Nodes[0].X - Nodes[1].X;
				var dy = Nodes[0].Y - Nodes[1].Y;
				var l = Math.Sqrt(dx * dx + dy * dy);
				dx /= l;
				dy /= l;

				return new PointF[] {
				new PointF((float)(Nodes[0].X - dx * Nodes[0].Radius), (float)(Nodes[0].Y - dy * Nodes[0].Radius)),
				new PointF((float)(Nodes[1].X + dx * Nodes[1].Radius), (float)(Nodes[1].Y + dy * Nodes[1].Radius))};
			}
		}
		public double length
		{
			get
			{
				double dx = Nodes[0].X - Nodes[1].X;
				double dy = Nodes[0].Y - Nodes[1].Y;
				return Math.Sqrt(dx * dx + dy * dy);
			}
		}
		public double Distance = 0;
	}
}
