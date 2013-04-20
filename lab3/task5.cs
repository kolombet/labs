using System;
using System.Collections;

class Program {
	static void Main() {
		ArrayList cr = new ArrayList();
		Field fi = new Field();
		
		cr.Add(new Creature("Дед", 5));
		cr.Add(new Creature("Бабка", 5));
		cr.Add(new Creature("Внучка", 4));
		cr.Add(new Creature("Жучка", 3));
		cr.Add(new Creature("Кошка", 2));
		cr.Add(new Creature("Мышка", 1));
		cr.Add(new Creature("anded", 50));
		
		foreach (Creature c in cr) {		
			fi.addCreature(c);
			fi.startWork();
		}
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
			Console.WriteLine((creatures[creatures.Count-2] as Creature).name + " позвал " + (creatures[creatures.Count-1] as Creature).name + "\n");
		} 
	}
	
	public void startWork() {
		Console.WriteLine("Начали они тянуть репку\n");
		repka.tryToGet(creatures);
	}
}

class Creature {
	public string name;
	public int power;
	
	public Creature(string name, int power) {
		this.name = name;
		this.power = power;
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
				Console.WriteLine((cr[0] as Creature).name + " за репку\n");
			} else {
				Console.WriteLine((cr[i] as Creature).name + " за " + (cr[i - 1] as Creature).name + "\n");
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