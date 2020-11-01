using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

/*
+	Создать иерархию классов исключений (собственных) – 3 типа и более.
+	Сделать наследование пользовательских типов исключений от стандартных
классов .Net (например, Exception, IndexOutofRange).
+	Сгенерировать и обработать как минимум пять различных исключительных
ситуаций на основе своих и стандартных исключений. Например, не позволять при
инициализации объектов передавать неверные данные, обрабатывать ошибки при
работе с памятью и ошибки работы с файлами, деление на ноль, неверный индекс,
нулевой указатель и т. д.
+	В конце поставить универсальный обработчик catch.
+	Обработку исключений вынести в main. При обработке выводить
специфическую информацию о месте, диагностику и причине исключения.
+	Последним должен быть блок, который отлавливает все исключения (finally).
+	Добавьте код в одной из функций макрос Assert. Объясните что он проверяет, как
будет выполняться программа в случае не выполнения условия. Объясните
назначение Assert. 

Assert - это специальная конструкция, позволяющая проверять предположения о значениях 
произвольных данных в произвольном месте программы. Эта конструкция может автоматически 
сигнализировать при обнаружении некорректных данных, что обычно приводит к аварийному 
завершению программы с указанием места обнаружения некорректных данных.
*/

namespace lab7
{
	class SeaExeption : Exception
	{
		public SeaExeption(string message) : base(message)
		{	}
	}

	class PlanetAddExeption : NullReferenceException
	{
		public PlanetAddExeption(string message) : base(message)
		{ }
	}

	class PlanetDeleteExeption : Exception
	{
		public PlanetDeleteExeption(string message) : base(message)
		{ }
	}

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
		public string _name;
		public string SeaName
		{
			get { return _name; }
			set
			{
				if (String.Compare(value, " ") == 0 || value == null)
				{
					throw new SeaExeption("U didn't write sea name");
				}
				else
				{
					_name = value;
				}
			}
		}
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
//			Debug.Assert(state.Count() == 0); //ASSERT
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
			if (landList.Count == 0)
			{
				throw new PlanetDeleteExeption("There are no land elements");
			}
			else
			{
				landList.Remove(element);
			}
		}
		public void Add(Water element)
		{
			seaList.Add(element);
			seacount++;
		}
		public void Delete(Water element)
		{
			if (seacount == 0)
			{
				throw new PlanetDeleteExeption("There are no water elements");
			}
			else
			{
				seaList.Remove(element);
				seacount--;
			}
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
				else
				{
					throw new SeaExeption("What is it then?");
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
			try
			{
				Continent first_cont = new Continent("Europe");
				Continent second_cont = new Continent("South America");
				Continent third_cont = new Continent("Asia");

				Sea first_sea = new Sea("Athlantic sea");
				Sea second_sea = new Sea("Baltic sea");
				Sea third_sea = new Sea("White sea");
				Sea fourth_sea = new Sea("Black sea");
//				Sea fifth_sea = new Sea(null);

				State china = new State("China");
				State japan = new State("Japan");
				State belarus = new State("Belarus");
				State india = new State("India");

				Island[] islands = new Island[4];
				islands[0] = new Island("Jeju");
				islands[1] = new Island("Hokkaido");
				islands[2] = new Island("Hawaii");
				islands[3] = new Island("Singapore");
//				islands[4] = new Island("Neverland");

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
			}

			catch (SeaExeption message)
			{
				Console.WriteLine($"\nA seaException {message.Message} {message.InnerException} found in {message.StackTrace}. Need help? Look there: {message.HelpLink}!");
			}
			catch (IndexOutOfRangeException message)
			{
				Console.WriteLine($"\nAn exception index out of range {message.Message} {message.InnerException} found in {message.StackTrace}. Need help? Look there: {message.HelpLink}!");
			}
			catch (Exception message)
			{
				Console.WriteLine($"\nSomething wrong: {message.Message} {message.InnerException} found in {message.StackTrace}.");
			}
			finally
			{
				Console.WriteLine("\nIt's over");
			}

			Console.ReadKey();
		}
	}
}