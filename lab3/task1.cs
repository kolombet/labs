using System;

namespace kke {
	class Program {
		static void Main() {
			Figure2D fig = new Figure2D(5, 10);
			Console.WriteLine(fig.getInfo());
			separator();
			
			Rectangle rec = new Rectangle(15, 20, 100, 200);
			Console.WriteLine(rec.getInfo());
			separator();
			
			Square sq = new Square(20, 20, 50);
			Console.WriteLine(sq.getInfo());

			Console.ReadLine();
		}
		
		static void separator() {
			Console.WriteLine("\n-------------------------------\n");
		}
	}

	class Figure2D {
		private float _x, _y;
		public string _name = "Figure2D";
		
		public Figure2D(float x, float y) {
			this._x = x;
			this._y = y;
		}
		
		public float x { 
			get {return this._x;}
			set {this._x = value;}
		}
		
		public float y { 
			get {return this._y;}
			set {this._y = value;}
		}
		
		public virtual string name {
			get {return _name;}
		}
		
		public virtual string getInfo() {
			return "Название фигуры: " + this.name + "\nКоордината X: " + x + "\nКоордината Y: " + y ;
		}
	}
	
	class Rectangle:Figure2D {
		private float _width, _height;
		
		public Rectangle(float x, float y, float width, float height):base(x, y) {
			this._width = width;
			this._height = height;
			this._name = "Rectangle";
		}
		
		public float width { 
			get {return this._width;}
			set {this._width = value;}
		}
		
		public float height { 
			get {return this._height;}
			set {this._height = value;}
		}
		
		public float calculateArea() {
			return this._width * this._height;
		}
		
		public float calculatePerimeter() {
			return 2 * (this._width + this._height);
		}
		
		public override string getInfo() {
			return base.getInfo() + "\nШирина: " + width + " Высота: " + height + 
				"\nПлощадь: " + this.calculateArea() + "\nПериметр: " + this.calculatePerimeter();
		}
	}
	
	class Square:Rectangle {
		public Square(float x, float y, float side):base(x, y, side, side) {
			this._name = "Square";
		}
	}
}


//C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\csc.exe