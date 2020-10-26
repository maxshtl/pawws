using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

/*
+	1) Определить иерархию и композицию классов (в соответствии с вариантом),
реализовать классы. Если необходимо расширьте по своему усмотрению
иерархию для выполнения всех пунктов л.р.
Каждый класс должен иметь отражающее смысл название и
информативный состав. При кодировании должны быть использованы
соглашения об оформлении кода code convention.
+	В одном из классов переопределите все методы, унаследованные от
Object.
	Море, Континент, Государство, Остров, Суша, Вода;

+	2) В проекте должны быть интерфейсы и абстрактный класс(ы).
Использовать виртуальные методы и переопределение.

+	3) Сделайте один из классов герметизированным (бесплодным).

+	4) Добавьте в интерфейсы (интерфейс) и абстрактный класс одноименные
методы. Дайте в наследуемом классе им разную реализацию и вызовите эти методы.

+	5) Написать демонстрационную программу, в которой создаются объекты
различных классов. Поработать с объектами через ссылки на абстрактные
классы и интерфейсы. В этом случае для идентификации типов объектов
использовать операторы is или as.

+	6) Во всех классах (иерархии) переопределить метод ToString(), который
выводит информацию о типе объекта и его текущих значениях.

+?	7) Создайте дополнительный класс Printer c полиморфным методом
IAmPrinting( SomeAbstractClassorInterface someobj). Формальным
параметром метода должна быть ссылка на абстрактный класс или наиболее
общий интерфейс в вашей иерархии классов. В методе iIAmPrinting
определите тип объекта и вызовите ToString(). В демонстрационной
программе создайте массив, содержащий ссылки на разнотипные объекты
ваших классов по иерархии, а также объект класса Printer и последовательно
вызовите его метод IAmPrinting со всеми ссылками в качестве аргументов.
 */

namespace lab5
{
	interface Iis_Land
	{
		void is_land();
	}

	abstract public class Water : Iis_Land
	{
		public abstract void is_land();
	}

	class Sea : Water
	{
		public string SeaName { get; set; }
		public Sea(string name)
		{
			SeaName = name;
		}
		public override void is_land()
		{
			Console.WriteLine("Это море.");
		}
		public void ToString()
		{
			Console.WriteLine($"Название моря: {this.SeaName}");
		}
		public bool Equals(Sea seaName)
		{
			if (seaName == null)
			{
				return false;
			}
			else
			{
				return this.SeaName == seaName.SeaName;
			}
		}
		public void GetType()
		{
			Console.WriteLine($"Тип моря: {this.SeaName.GetType()}");
		}
		public void GetHashCode()
		{
			Console.WriteLine($"Хэш-код моря: {this.SeaName.GetHashCode()}");
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
			Console.WriteLine("Это остров.");
		}
		new public void ToString()
		{
			Console.WriteLine($"Название острова: {this.IslandName}");
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
			Console.WriteLine("Это континент.");
		}
		public virtual void ToString()
		{
			Console.WriteLine($"Название континента: {ContinentName}");
		}
	}

	sealed class State : Continent
	{
		public string StateName { get; set; }
		public State(string name):base(name)
		{
			StateName = name;
		}

		public override void ToString()
		{
			Console.WriteLine($"Название государства: {StateName}");
		}
	}

	public class Printer
	{
		public void IAmPrinting(Object elem)
		{
			Console.WriteLine(elem.GetType());
			elem.ToString();
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Моря:");
			Sea first_sea = new Sea("Black Sea");
			Sea second_sea = new Sea("Baltic Sea");
			first_sea.is_land();
			Console.WriteLine(first_sea.Equals(second_sea));
			second_sea.ToString();
			first_sea.GetHashCode();
			second_sea.GetType();
			
			Console.WriteLine("Остров:");
			Island island = new Island("Гонконг");
			island.is_land();
			island.ToString();

			Console.WriteLine("Континент:");
			Continent continent = new Continent("Антарктида");
			continent.is_land();
			continent.ToString();

			Console.WriteLine("Государство:");
			State state = new State("Япония");
			state.is_land();
			state.ToString();

			/*
			Island isl = state as Island;
			if (isl == null)
			{
				Console.WriteLine("Преобразование state as Island недопустимо");
			}
			else
			{
				Console.WriteLine(isl.IslandName);
			}
			*/

			Console.Write("State is Continent: ");
			Console.WriteLine(state is Continent);

			Printer printer = new Printer();
			Object[] arr = new Object[] { first_sea, second_sea, island, continent, state, printer };
			for (int i = 0; i < arr.Length; i++)
			{
				printer.IAmPrinting(arr[i]);
			}
			
			Console.ReadKey();

		}
	}
}