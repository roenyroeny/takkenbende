using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plot
{
	// obj builder to use with sketchups universal importer
	// includes some flips to unupsidedown everything
	internal class ObjBuilder
	{
		List<string> vertices = new List<string>();
		List<string> geo = new List<string>();

		float scale = 1e-2f;

		public ObjBuilder()
		{

		}

		public int addVert(float x, float y)
		{
			vertices.Add($"v {x * scale} 0 {y * scale}");
			return vertices.Count; // no -1 needed, obj's are 1 based
		}

		public void addCircle(float x, float y, float r, int steps = 30)
		{
			var center = addVert(x, y);
			var prev = -1;
			for (int i = 0; i <= steps; i++)
			{
				float a = (float)i / (float)steps;
				a *= (float)Math.PI * 2.0f;

				float vx = x + (float)Math.Cos(a) * r;
				float vy = y + (float)Math.Sin(a) * r;

				var v = addVert(vx, vy);
				if (prev != -1)
				{
					geo.Add($"f {center}/1/1 {prev}/1/1 {v}/1/1");
				}
				prev = v;
			}
		}

		public void addCircleAsFace(float x, float y, float r, int steps = 30)
		{
			var str = "f ";
			for (int i = 0; i <= steps; i++)
			{
				float a = (float)i / (float)steps;
				a *= (float)Math.PI * 2.0f;

				float vx = x + (float)Math.Cos(a) * r;
				float vy = y + (float)Math.Sin(a) * r;

				var v = addVert(vx, vy);
				str += $" {v}/1/1 ";
			}
			geo.Add(str);
		}

		public void AddLine(float x1, float y1, float x2, float y2)
		{
			var v0 = addVert(x1, y1);
			var v1 = addVert(x2, y2);
			geo.Add($"l {v0} {v1}");
		}

		public string emit()
		{
			var str = "#plot obj file\n";

			str += "vn 0 0 1\n";
			str += "vt 0 0\n";

			foreach (string s in vertices)
				str += s + "\n";
			foreach (string s in geo)
				str += s + "\n";

			return str;
		}
	}
}
