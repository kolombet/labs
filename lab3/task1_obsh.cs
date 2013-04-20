using System;
using System.Collections;
using System.Collections.Generic;

namespace kke {
	class Program {
		static void Main() {
			Figure2D<int> fig = new Figure2D<int>(5, 10);
			Console.WriteLine(fig.getInfo());
			separator();
			
			Rectangle<int> rec = new Rectangle<int>(15, 20, 100, 200);
			Console.WriteLine(rec.getInfo());
			separator();
			
			Square<int> sq = new Square<int>(20, 20, 50);
			Console.WriteLine(sq.getInfo());

			Console.ReadLine();
		}
		
		static void separator() {
			Console.WriteLine("\n-------------------------------\n");
		}
	}

	class Figure2D<T>{
		private T _x, _y;
		public string _name = "Figure2D";
		
		public Figure2D(T x, T y) {
			this._x = x;
			this._y = y;
		}
		
		public T x { 
			get {return this._x;}
			set {this._x = value;}
		}
		
		public T y { 
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
	
	class Rectangle<T>:Figure2D<T> {
		private T _width, _height;
		
		public Rectangle(T x, T y, T width, T height):base(x, y) {
			this._width = width;
			this._height = height;
			this._name = "Rectangle";
		}
		
		public T width { 
			get {return this._width;}
			set {this._width = value;}
		}
		
		public T height { 
			get {return this._height;}
			set {this._height = value;}
		}
		
		public T calculateArea() {
			return this._width * this._height;
		}
		
		public T calculatePerimeter() {
			return 2 * (this._width + this._height);
		}
		
		public override string getInfo() {
			return base.getInfo() + "\nШирина: " + width + " Высота: " + height + 
				"\nПлощадь: " + this.calculateArea() + "\nПериметр: " + this.calculatePerimeter();
		}
	}
	
	class Square<T>:Rectangle<T> {
		public Square(T x, T y, T side):base(x, y, side, side) {
			this._name = "Square";
		}
	}
}


//C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\csc.exe