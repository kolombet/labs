using System;

namespace kke {
	class Program {
	static void Main() {
			Triangle tr2 = new Triangle(1, 2, 3);
			Console.WriteLine(tr2.getInfo());

			IsoscelesTriangle tr3 = new IsoscelesTriangle(3, 5);
			Console.WriteLine(tr3.getInfo());

			EquilateralTriangle tr4 = new EquilateralTriangle(5);
			Console.WriteLine(tr4.getInfo());

			RightAngledTriangle tr5 = new RightAngledTriangle(3, 4, 5);
			Console.WriteLine(tr5.getInfo());

			tr2.setSides(40, 30, 65);
			Console.WriteLine(tr2.getInfo());

			Console.ReadLine();
		}
	}

	interface ITrinagle {

	}

	class Triangle {
		private bool exist = false;
		private float _sideA, _sideB, _sideC;

		public Triangle(float a, float b, float c) {
			this.setSides(a, b, c);
		}

		public Triangle() {}

		public virtual string name {
			get {
				return "Triangle";
			}
		}

		//устанавливает значения сторон с проверкой условия их существования
		//возвращает false если треугольника с такими сторонами не существует
		public virtual bool setSides(float a, float b, float c) {
			if (true == (a+b>c) && (a+c>b) && (b+c>a)) {
				this._sideA = a;
				this._sideB = b;
				this._sideC = c;
				this.exist = true;
				return true;
			} else {
				this.exist = false;
				Console.WriteLine("Попытка присвоить треугольнику невозможные стороны");
				return false;
			}	
		}

		public float sideA {
			get {
				return _sideA;
			}
			set {
				this.setSides(value, this._sideB, this._sideC);
			}
		}

		public float sideB {
			get {
				return _sideB;
			}
			set {
				this.setSides(this._sideA, value, this._sideC);
			}
		}

		public float sideC {
			get {
				return _sideC;
			}
			set {
				this.setSides(this._sideA, this._sideB, value);
			}
		}

		public virtual float calculateArea() {
			return calculateAreaWithHeronFormula();
		}

		public float calculateAreaWithHeronFormula() {
			float s = calculateSemiPerimeter();
			float area = (float)Math.Sqrt(s * (s - sideA) * (s - sideB) * (s - sideC));
			return area;
		}

		public float calculatePerimeter() {
			return this.sideA + this.sideB + this.sideC;
		}

		public float calculateSemiPerimeter() {
			return this.calculatePerimeter() / (float)2;
		}

		public string getInfo() {
			string infoString = "";
			infoString += "Тип: " + this.name;
			if (this.exist == true) {
				infoString += "\nСторона 1: " + this.sideA + "\nСторона2: " + this.sideB +
					"\nСторона 3: " + this.sideC + "\nПериметр: " + this.calculatePerimeter() + 
					"\nПлощадь: " + this.calculateArea();
			} else {
				infoString += "\nУ треугольника присвоены неправильные стороны";
			}
			return infoString;
		}
	}

	//Равносторонний треугольник
	class EquilateralTriangle:Triangle {
		public EquilateralTriangle(float side):base(side, side, side) {
			
		}

		public EquilateralTriangle(float a, float b, float c):base(a, b, c) {
			
		}

		public EquilateralTriangle():base() {
			
		}

		override public float calculateArea() {
			return (float)(Math.Pow(sideA, 2) * (Math.Sqrt(3) / 4));
		}

		override public string name {
			get {
				return "EquilateralTriangle";
			}
		}
	}

	//Равнобедренный треугольник
	class IsoscelesTriangle:Triangle {
		public IsoscelesTriangle(float side, float floor):base(side, side, floor) {
			
		}

		public IsoscelesTriangle(float a, float b, float c):base(a, b, c) {
			
		}

		public IsoscelesTriangle():base() {
			
		}

		public override string name {
			get {
				return "IsoscelesTriangle";
			}
		}
	}

	//Прямоугольный треуегольник
	class RightAngledTriangle:Triangle {
		public RightAngledTriangle(float a, float b, float c):base(a, b, c) {
			
		}

		public RightAngledTriangle():base() {
			
		}

		public override string name {
			get {
				return "RightAngledTriangle";
			}
		}

		public override bool setSides(float a, float b, float c) {
			if (pythCheck(a,b,c) || pythCheck(c, a, b) || pythCheck(c, b, a)) {
				
				return base.setSides(a, b, c);
			} else {
				Console.WriteLine("Wrong sides of RightAngledTriangle"); 
				return false;
			}
		}

		private bool pythCheck(float catet1, float catet2, float hypotenuse) {
			if (Math.Pow(catet1, 2) + Math.Pow(catet2, 2) - Math.Pow(hypotenuse, 2) == 0)
				return true;
			else 
				return false;
		}
	}
}

//Сколько конструкторов надо сделать чтобы учесть все типы данных
