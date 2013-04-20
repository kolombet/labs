using System;
using System.Collections;

class Program {
	static void Main() {
		ArrayList cr = new ArrayList();
		Field fi = new Field();
		
		cr.Add(new Creature("Дед", "Дедку", 3, Creature.MALE));
		cr.Add(new Creature("Бабка", "Бабку", 5, Creature.FEMALE));
		cr.Add(new Creature("Внучка", "Внучку", 4, Creature.FEMALE));
		cr.Add(new Creature("Жучка", "Жучку", 3, Creature.FEMALE));
		cr.Add(new Creature("Кошка", "Кошку", 2, Creature.FEMALE));
		cr.Add(new Creature("Мышка", "Мышку", 1, Creature.FEMALE));
		cr.Add(new Creature("Петя", "Петю", 1, Creature.MALE));
		cr.Add(new Creature("Вася", "Васю", 1, Creature.MALE));
		cr.Add(new Creature("Надя", "Надю", 1, Creature.MALE));
		cr.Add(new Creature("Миша", "Мишу", 1, Creature.MALE));
		cr.Add(new Creature("Монстр", "Монстра", 100, Creature.MALE));

		foreach (Creature c in cr) {		
			fi.addCreature(c);
			fi.startWork();
		}

		Console.ReadLine();
	}
}

class Field {
	public Repka repka = new Repka();
	public ArrayList creatures = new ArrayList();
	
	public Field() {
		
	}
	
	public void addCreature(Creature cr) {
		creatures.Add(cr);
		if (creatures.Count > 1) {
			Creature caller = (creatures[creatures.Count-2] as Creature);
			string callVerb;
			if (caller.gender == Creature.MALE) {
				callVerb = "позвал";
			} else {
				callVerb = "позвала";
			}
			Console.WriteLine(caller.name + " " + callVerb + " " + (creatures[creatures.Count-1] as Creature).genitiveName);
		} 
	}
	
	public void startWork() {
		Console.WriteLine("Начали они тянуть репку");
		repka.tryToGet(creatures);
	}
}

class Creature {
	public string name;
	public string genitiveName;
	public int power;
	public string gender;

	public const string MALE = "male";
	public const string FEMALE = "female";
	
	public Creature(string name, string genitiveName, int power, string gender) {
		this.name = name;
		this.power = power;
		this.genitiveName = genitiveName;
		this.gender = gender;
	}
}

class Repka {
	public int heaviness = 20;
	public bool inEarth = true;
	
	public void tryToGet(ArrayList cr) {
		int pow = 0;
		
		for(int i = 0; i < cr.Count; i++) {
			pow += (cr[i] as Creature).power;
			
			if (i == 0) {
				Console.WriteLine((cr[0] as Creature).name + " за репку");
			} else {
				Console.WriteLine((cr[i] as Creature).name + " за " + (cr[i - 1] as Creature).genitiveName);
			}
		}
		
		if (pow > heaviness) {
			Console.WriteLine("Тянут-потянут — и вытянули репку.\n");
			this.inEarth = false;
		} else {
			Console.WriteLine("Тянут-потянут, вытянуть не могут.\n");
		}
	}
}

//Вопрос - может вместо пола использовать Boolean?