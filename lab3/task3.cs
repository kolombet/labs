using System;

namespace kke {
	class Program {
		static void Main() {
			Console.WriteLine("Задание 3: Описание трехмерных фигур Параллелепипед и Куб с помощью ООП" + sep());
			Figure3D fig1 = new Figure3D();
			Console.WriteLine(fig1.getInfo() + sep());

			Parallelepiped fig2 = new Parallelepiped(5, 6, 7);
			Console.WriteLine(fig2.getInfo() + sep());

			Console.WriteLine(sep() + "Изменим характеристики фигур и попробуем снова вычислить объем" + sep());
			fig2.width = 1;
			fig2.height = 2;
			fig2.length = 3;
			Console.WriteLine(fig2.getInfo() + sep());

			Cube fig3 = new Cube(5);
			Console.WriteLine(fig3.getInfo() + sep());

			Console.ReadLine();
		}
		
		static string sep() {
			return "\n-------------------------------\n";
		}
	}
	
	interface IFigure3D {
		string name {
			get;
		}

		float calculateCapacity();
		string getInfo();
	}

	class Figure3D : IFigure3D {
		public string _name = "Figure3D";
		
		public Figure3D() {
			
		}
		
		public virtual string name {
			get {return _name;}
		}

		public virtual float calculateCapacity() {
			return 0;
		}

		public virtual float calculateSideArea() {
			return 0;
		}
		
		public virtual string getInfo() {
			return "Название фигуры: " + this.name;
		}
	}

	class Parallelepiped:Figure3D {
		public float width;
		public float height;
		public float length;

		public Parallelepiped(float length, float width, float height) {
			this._name = "Параллелепипед";
			this.length = length;
			this.width = width;
			this.height = height;
		}

		public override float calculateCapacity() {
			return this.width * this.height * this.length;
		}

		public override float calculateSideArea() {
			return (this.width * this.height + this.width * this.length + this.height * this.length) * 2;
		}

		public override string getInfo() {
			return base.getInfo() + "\nДлина: " + this.length + "\nШирина " + this.width +
					"\nВысота " + this.height + "\nОбъем: " + this.calculateCapacity() +
					"\nПлощадь поверхности: " + this.calculateSideArea();
		}
	}

	class Cube:Parallelepiped {
		public Cube(float side):base(side, side, side) {
			this._name = "Куб";
		}
	}
}


//C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\csc.exe