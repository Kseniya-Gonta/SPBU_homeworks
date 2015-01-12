using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GeometryLib
{
	public class Geometry
	{

		public static bool Equilateral(int Coordinate1X, 
			int Coordinate2X,
			int Coordinate3X,
			int Coordinate1Y,
			int Coordinate2Y,
			int Coordinate3Y)
		{
			Double sumption = 0.0001;
			Double a = Math.Sqrt(Math.Pow((Coordinate1Y - Coordinate2Y), 2) + Math.Pow((Coordinate1X- Coordinate2X), 2));
			Double b = Math.Sqrt(Math.Pow((Coordinate3Y - Coordinate2Y), 2) + Math.Pow((Coordinate3X - Coordinate2X), 2));
			Double c = Math.Sqrt(Math.Pow((Coordinate1Y - Coordinate3Y), 2) + Math.Pow((Coordinate1X - Coordinate3X), 2));

			if ((Math.Abs(a - b) < sumption) && (Math.Abs(b - c) < sumption) && (Math.Abs(a - c) < sumption))          
				return true;
			else            
				return false;
		}
	}
}