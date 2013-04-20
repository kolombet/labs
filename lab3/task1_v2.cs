using System;

namespace ConsoleApplication32 
{
	public class Figure2D<T>
	{
		public T width;
		public T height;
		public string name;
	}

	public class Square<T>:Figure2D<T> 
	{
		public int Area(int width)
		{
			return width*width;
		}

		public double Area(double width)
		{
			return width*width;
		}

		public override string ToString() 
		{
			string result = "Тип: " + name + "\n" + "Ширина: " + width.ToString() + "\n";
			return result;
		}
	}

	public class Generator<V>
	{
		public void Show(V val) {
			Console.WriteLine("{0}\n", val.ToString());
		}
	}

	public class Rectangle<T>:Figure2D<T>
	{
		public int Area(int width, int height)
		{
			return width * height;
		}

		public double Area(double width, double height)
		{
			return width * height;
		}

		public override string ToString() 
		{
			string result = "Тип: " + name + "\n" + 
							"Ширина: " + width.ToString() + "\n" +
							"Высота: " + height.ToString() + "\n";
			return result;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Square<double> myFigure = new Square<double>();
			myFigure.width = 20.32;
			myFigure.name = "Square";

			Generator<Square<double>> exoSquare = new Generator<Square<double>>();
			exoSquare.Show(myFigure);
			Console.WriteLine("Площадь {0} \n", myFigure.Area(myFigure.width));
			Console.ReadLine();

			Rectangle<double> myFigure1 = new Rectangle<double>();
			myFigure1.width = 20.2;
			myFigure1.height = 10.5;
			myFigure1.name = "Rectangle";

			Generator<Rectangle<double>> exoSquare1 = new Generator<Rectangle<double>>();
			exoSquare1.Show(myFigure1);
			Console.WriteLine("Площадь {0} \n", myFigure1.Area(myFigure1.width, myFigure1.height));
			Console.ReadLine();

			Square<int> myFigure2 = new Square<int>();
			myFigure2.width = 20;
			myFigure2.name = "Square";

			Generator<Square<int>> exoSquare2 = new Generator<Square<int>>();
			exoSquare2.Show(myFigure2);
			Console.WriteLine("Площадь {0} \n", myFigure2.Area(myFigure.width));
			Console.ReadLine();

		}
	}
}