using System;
using GeometryLib;

namespace Check
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			bool res = Geometry.Equilateral (0, 2, 4, 0, 3, 0);
			if (res) {
				Console.WriteLine ("Triangle is equilateral");
			} 
			else 
			{
				Console.WriteLine ("Triangle is not equilateral");
			}
		}
	}
}
