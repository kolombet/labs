using System;

namespace kke {
	class Program {
		static void Main() {
			Figure2D fig = new Figure2D(5, 10);
			Console.WriteLine(fig.getInfo() + sep());
			
			Rectangle rec = new Rectangle(15, 20, 100, 200);
			Console.WriteLine(rec.getInfo() + sep());
			
			Square sq = new Square(20, 20, 50);
			Console.WriteLine(sq.getInfo() + sep());

			Console.WriteLine("Теперь попробуем поменять одну сторону квадрата:" + sep());

			sq.width = 30;
			Console.WriteLine(sq.getInfo());

			Console.WriteLine("Автоматически изменяются обе");
			Console.ReadLine();
		}
		
		static string sep() {
			return "\n-------------------------------\n";
		}
	}
	
	interface IFigure2D {
		float x {
			get;
			set;
		}

		float y {
			get;
			set;
		}

		string name {
			get;
		}

		float calculateArea();
		float calculatePerimeter();
		string getInfo();
	}
	
	class Figure2D : IFigure2D {
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

		public virtual float calculateArea() {
			return 0;
		}

		public virtual float calculatePerimeter() {
			return 0;
		}
		
		public virtual string getInfo() {
			return "Название фигуры: " + this.name + "\nКоордината X: " + x + "\nКоордината Y: " + y ;
		}
	}
	
	class Rectangle:Figure2D {
		protected float _width, _height;
		
		public Rectangle(float x, float y, float width, float height):base(x, y) {
			this._width = width;
			this._height = height;
			this._name = "Rectangle";
		}
		
		public virtual float width { 
			get {return this._width;}
			set {this._width = value;}
		}
		
		public virtual float height { 
			get {return this._height;}
			set {this._height = value;}
		}
		
		public override float calculateArea() {
			return this._width * this._height;
		}
		
		public override float calculatePerimeter() {
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

		public override float width {
			get {
				return this._width;
			}
			set {
				base.width = value;
				base.height = value;
			}
		} 

		public override float height {
			get {
				return this._height;
			}
			set {
				base.width = value;
				base.height = value;
			}
		}
	}
}



//	class Square:Rectangle {

//	}


//C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\csc.exe