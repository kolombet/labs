using System;
using System.Collections;

namespace kke {
	class Program {
		static void Main() {
			Student vasya = new Student("Василий");
			vasya.setSemester(1);
			Console.WriteLine(vasya.getAllInfo());
			
			Student masha = new Student("Маша");
			masha.setSemester(2);
			Console.WriteLine(masha.getAllInfo());
		}
		
		static string sep() {
			return "\n-------------------------------\n";
		}
	}

	abstract class Course {
		public string name;

		//Информация о зачете
		private bool _credit;

		//Информация о оценке
		private byte _grade;

		public Course(string name) {
			this.name = name;
		}

		public bool credit {
			get {return _credit;}
			set {_credit = value;}
		}

		public byte grade {
			get {return _grade;}
			set {
				if (value <= 5) {
					this._grade = value;
					if (value >= 3) {
						this.credit = true;
					}
				} else {
					Console.WriteLine("Попытка присвоить неправильное значение оценки");
					this._grade = 0;
				}
			}
		}
	}

	//Курс оканчивающийся экзаменом
	class GradeCourse:Course {
		public GradeCourse(string name, byte grade):base(name) {
			this.grade = grade;
		}
	}

	//Курс оканчивающийся зачетом
	class CreditCourse:Course {
		public CreditCourse(string name, bool credit = false):base(name) {
			this.credit = credit;
		}
	}
	
	class Semester {
		public ArrayList courses;
		public int semesterNumber;

		public Semester(int semesterNum) {
			this.semesterNumber = semesterNum;
			courses = new ArrayList();

			if (semesterNum == 1) {
				courses.Add(new CreditCourse("Физкультура", true));
				courses.Add(new CreditCourse("Пение", true));
				courses.Add(new CreditCourse("Свистение", true));
				courses.Add(new CreditCourse("Фортепиано", true));
				courses.Add(new CreditCourse("Основы православия", true));
				courses.Add(new CreditCourse("Культура речи", true));
				courses.Add(new GradeCourse("Математический анализ", 3));
				courses.Add(new GradeCourse("Линейная алгебра", 4));
				courses.Add(new GradeCourse("Аналитическая геометрия", 5));
				courses.Add(new GradeCourse("Компьютерные алгоритмы", 4));
				courses.Add(new GradeCourse("Машинная логика", 3));
			} else if (semesterNum == 2) {
				courses.Add(new CreditCourse("Безопасность жизнедеятельности", true));
				courses.Add(new CreditCourse("История руси", true));
				courses.Add(new CreditCourse("Поиск актуальной информации", true));
				courses.Add(new CreditCourse("Текстовые редакторы", true));
				courses.Add(new CreditCourse("Генетические алгоритмы", true));
				courses.Add(new CreditCourse("Устройство операционных систем", true));
				courses.Add(new GradeCourse("Высшая математика", 2));
				courses.Add(new GradeCourse("Теория вероятностей", 3));
				courses.Add(new GradeCourse("Теория игр", 5));
				courses.Add(new GradeCourse("Машинная графика", 4));
			}
		}

		public string getCourseInfo() {
			string coursesString = "";
			foreach (Course c in courses) {
				string s = (c.credit) ? "сдал" : "не сдал";
				coursesString += "Курс: " + c.name + ". Результат: " + s + "\n";
			}
			return coursesString;
		}

		public bool getCourseCompletitionInfo() {
			bool courseCompleted = true;
			foreach (Course c in courses) {
				if (!c.credit) {
					courseCompleted = false;
				}
			}

			return courseCompleted;
		}
	}
	
	class Student {
		//Информация о текущем семестре
		public Semester currentSemester;

		//Имя студента
		public string _name;

		public Student(string name) {
			this._name = name;	
		}

		public string name {
			get {return this._name;}
		}

		public void setSemester(int semesterNum) {
			currentSemester = new Semester(semesterNum);
		}

		//Возвращает информацию о списке предметов в текущем курсе
		public string getCurrentCourseInfo() {
			return currentSemester.getCourseInfo();
		}

		//Возвращает информацию о сдаче курса
		public string getCourseCompletitionInfo() {
			bool i = currentSemester.getCourseCompletitionInfo();
			return (i) ? "cдал" : "не сдал";
		}

		public string getAllInfo() {
			string resultString = "";
			resultString += "Имя студента " + _name + "\n";
			//resultString += "Учится на курсе" + Math.Ceiling((double)this.currentSemester.semesterNumber) + "\n"; 
			resultString += "На " + this.currentSemester.semesterNumber + " семестре \n";
			resultString += "Список предметов: \n";
			resultString += getCurrentCourseInfo();
			resultString += "Результат заверешения курса: " + getCourseCompletitionInfo() + "\n";

			return resultString;
		}
	}
}