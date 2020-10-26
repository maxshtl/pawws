using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

/*
+	1) К предыдущей лабораторной работе (л.р. 5) добавьте к существующим классам перечисление и структуру.

+	2) Один из классов сделайте partial и разместите его в разных файлах.

+?	3) Определить класс-Контейнер (Планету Земля) для хранения разных типов объектов (в пределах иерархии) в виде
списка или массива (использовать абстрактный тип данных). Класс-контейнер должен содержать методы get и set для управления
списком/массивом, методы для добавления и удаления объектов в список/массив, метод для вывода списка на консоль.
	
???	4) Определить управляющий класс-Контроллер, который управляет объектом-Контейнером и реализовать в нем запросы по 
варианту. При необходимости используйте стандартные интерфейсы (IComparable, ICloneable,….)
+?	Найти все государства на заданном континенте, 
+	подсчитать количество морей,
+?	вывести острова по алфавиту.
 */

namespace lab6
{
	interface Iis_Land
	{
		void is_land();
	}

	abstract public class Water : Iis_Land
	{
		public abstract void is_land();
	}

	partial class Sea : Water
	{
		public string SeaName { get; set; }
		public Sea(string name)
		{
			SeaName = name;
		}
		public override void is_land()
		{
			Console.WriteLine("It's sea.");
		}
		new public string ToString()
		{
			return $"Sea: {this.SeaName}";
		}
	}

	abstract public class Land : Iis_Land
	{
		public abstract void is_land();
    }

	class Island : Land
	{
		public string IslandName { get; set; }
		public Island(string name)
		{
			IslandName = name;
		}

		public override void is_land()
		{
			Console.WriteLine("It's island.");
		}
		new public string ToString()
		{
			return $"Island: {this.IslandName}";
		}
	}

	class Continent : Land
	{
		public string ContinentName { get; set; }
		public Continent(string name)
		{
			ContinentName = name;
		}
		public override void is_land()
		{
			Console.WriteLine("It's continent.");
		}
		new public virtual string ToString()
		{
			return $"Continent: {this.ContinentName}";
		}
	}

	enum Continents
	{
		Africa, Antarctica, Australia, Europe, NorthAmerica, SouthAmerica,
	}

	class State : Continent
	{
		public string StateName { get; set; }
		public State(string name) : base(name)
		{
			StateName = name;
		}
		public override string ToString()
		{
			return $"State {StateName}";
		}
	}

	struct CurrentContinent
	{
		public Continent continent;
		public List<State> state;

        public void DisplayInfo()
		{
			foreach (State x in state)
			{
				Console.WriteLine($"{x.ToString()} on {continent.ToString()}");
			}
		}
	}

	public class PlanetEarth
	{
		public object elem { get; set; }
		public List<Land> landList = new List<Land>();
		public List<Water> seaList = new List<Water>();
		internal static int seacount = 0;

		public void Add(Land element)
		{
			landList.Add(element);
		}
		public void Delete(Land element)
		{
			landList.Remove(element);
		}
		public void Add(Water element)
		{
			seaList.Add(element);
			seacount++;
		}
		public void Delete(Water element)
		{
			seaList.Remove(element);
			seacount--;
		}

		public void Print()
		{
            
			foreach (Land x in landList)
			{
				if (x as State != null)
				{
					State state = x as State;
					Console.WriteLine(state.ToString());
				}
				else if (x as Continent != null)
				{
					Continent continent = x as Continent;
					Console.WriteLine(continent.ToString());
				}
				else if (x as Island != null)
				{
					Island island = x as Island;
					Console.WriteLine(island.ToString());
				}
            }
			foreach (Water x in seaList)
			{
				if (x as Sea != null)
				{
					Sea sea = x as Sea;
					Console.WriteLine(sea.ToString());
				}
			}
		}
	}

	public class Control : PlanetEarth
	{
		internal void AllStates(CurrentContinent cont)
		{
			cont.DisplayInfo();
		}
		public void SeaEncouter()
		{
			Console.WriteLine($"Number of sea: {seacount}");
		}
		internal void SortIslands(Island[] islands)
		{
			var result = from island in islands
						 orderby island.IslandName
						 select island;
			foreach (Island isl in result)
				Console.WriteLine(isl.IslandName);
		}
	}


	class Program
	{
		static void Main(string[] args)
		{
			Continent first_cont = new Continent("Europe");
			Continent second_cont = new Continent("South America");
			Continent third_cont = new Continent("Asia");

			Sea first_sea = new Sea("Athlantic sea");
			Sea second_sea = new Sea("Baltic sea");
			Sea third_sea = new Sea("White sea");
			Sea fourth_sea = new Sea("Black sea");

			State china = new State("China");
			State japan = new State("Japan");
			State belarus = new State("Belarus");
			State india = new State("India");

			Island[] islands = new Island[4];
			islands[0] = new Island("Jeju");
			islands[1] = new Island("Hokkaido");
			islands[2] = new Island("Hawaii");
			islands[3] = new Island("Singapore");

			PlanetEarth earth = new PlanetEarth();
			Console.WriteLine("Before on Earth:");
			for (int i = 0; i < islands.Length; i++)
			{
				earth.Add(islands[i]);
			}

			earth.Add(first_cont);
			earth.Add(second_cont);
			earth.Add(third_cont);
			earth.Add(first_cont);

			earth.Add(china);
			earth.Add(japan);
			earth.Add(belarus);
			earth.Add(india);

			earth.Add(first_sea);
			earth.Add(second_sea);
			earth.Add(third_sea);
			earth.Add(fourth_sea);
			earth.Print();

			Console.WriteLine("\nAfter on Earth:");
			earth.Delete(second_cont);
			earth.Delete(third_sea);
			earth.Print();

			CurrentContinent asia = new CurrentContinent();
			asia.continent = third_cont;
            asia.state = new List<State>();
            asia.state.Add(china);
            asia.state.Add(japan);
            asia.state.Add(india);

            Console.WriteLine("\nControl:");
			Control control = new Control();
			control.AllStates(asia);
			control.SeaEncouter();
			control.SortIslands(islands);


			Console.ReadKey();
		}
	}
}