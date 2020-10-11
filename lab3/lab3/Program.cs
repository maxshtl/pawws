using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*1) Определить класс, указанный в варианте, содержащий:
+		 Не менее трех конструкторов (с параметрами и без, а также с
параметрами по умолчанию );
+	   	статический конструктор (конструктор типа);
+		определите закрытый конструктор; предложите варианты его вызова;
+		 поле - только для чтения (например, для каждого экземпляра сделайте
поле только для чтения ID - равно некоторому уникальному номеру
(хэшу) вычисляемому автоматически на основе инициализаторов
объекта);
+		поле- константу;
+		свойства (get, set) – для всех полей класса (поля класса должны быть
закрытыми); Для одного из свойств ограничьте доступ по set
+		в одном из методов класса для работы с аргументами используйте ref -
и out-параметры.
+		создайте в классе статическое поле, хранящее количество созданных
объектов (инкрементируется в конструкторе) и статический
метод вывода информации о классе.
+		сделайте касс partial
+		переопределяете методы класса Object: Equals, для сравнения объектов,
GetHashCode; для алгоритма вычисления хэша руководствуйтесь
стандартными рекомендациями, ToString – вывода строки –
информации об объекте.
2)+		 Создайте несколько объектов вашего типа. Выполните вызов
конструкторов, свойств, методов, сравнение объекты, проверьте тип
созданного объекта и т.п.
3)+		Создайте массив объектов вашего типа. И выполните задание,
выделенное курсивом в таблице.
4)+		 Создайте и выведите анонимный тип (по образцу вашего класса).


	Создать класс Airline: Пункт назначения, Номер рейса,
Тип самолета, Время вылета, Дни недели. Свойства и
конструкторы должны обеспечивать проверку
корректности.
Создать массив объектов. Вывести:
a)+		список рейсов для заданного пункта назначения;
b)+		список рейсов для заданного дня недели;*/


namespace lab3
{
	public partial class Airline
	{
		public string destination, airplane_type, day;
		public int flight_number;
		public double time;
		public readonly int ID;
		internal const int max_seats = 60;
		public static int count;

		static Airline()
		{
			count = 0;
			Console.WriteLine("New post!");
		}

		private string Destination
		{
			get => destination;
			set => destination = value;
		}

		internal string Airplane_type
		{
			get => airplane_type;
			private set => airplane_type = value;
		}

		private string Day
		{
			get => day;
			set => day = value;
		}

		private int Flight_number
		{
			get => flight_number;
			set => flight_number = value;
		}

		private double Time
		{
			get => time;
			set => time = value;
		}

		public Airline()
		{
			destination = "LA";
			airplane_type = "business";
			day = "tus";
			flight_number = 1;
			time = 10.15;
			ID = flight_number.GetHashCode();
			count++;
		}

		public Airline(string Destination, string Airplane_type, string Day, int Flight_number, double Time)
		{
			destination = Destination;
			airplane_type = Airplane_type;
			day = Day;
			flight_number = Flight_number;
			time = Time;
			ID = flight_number.GetHashCode();
			count++;
		}

		private Airline(string Day, double Time)
		{
			destination = "Tokyo";
			airplane_type = "economy";
			day = Day;
			flight_number = 12;
			time = Time;
			ID = flight_number.GetHashCode();
			count++;
		}

		public static Airline createAirlineToTokyo(string Day, double Time)
		{
			return new Airline(Day, Time);
		}

		public void Show()
		{
			Console.WriteLine("\nПункт назначения: " + destination + "\nНомер рейса: " + flight_number + "\nДень: " + day + "\nВремя: " + time.ToString() + "\nТип самолета: " + airplane_type);
		}

		public void ShowDay()
		{
			Console.WriteLine("\nПункт назначения: " + destination + "\nНомер рейса: " + flight_number + "\nВремя: " + time + "\nТип самолета: " + airplane_type);
		}

		public void ShowDest ()
		{
			Console.WriteLine("\nНомер рейса: " + flight_number + "\nДень: " + day + "\nВремя: " + time + "\nТип самолета: " + airplane_type);
		}

		public static void OutFlight(out int flight_number, ref double time)
		{
			flight_number = 0;
			time = 0;
		}

	}

	class Program
	{
		static void Main(string[] args)
		{
			Airline first = new Airline();
			first.Show();

			Airline second = Airline.createAirlineToTokyo("mon", 12.15);
			second.Show();

			Airline third = new Airline("NY", "economy", "sun", 2, 16.30);
			third.Show();

			Airline fourth = Airline.createAirlineToTokyo("sun", 16.30);
			fourth.Show();

			Airline fifth = new Airline("LA", "business", "thu", 3, 15.45);
			fifth.Show();

			Console.WriteLine(fifth.airplane_type == first.airplane_type);
			Console.WriteLine(third.destination.GetType());

			Airline[] List = { first, second, third, fourth, first };

			string show_dest = "LA";
			string show_day = "sun";
			foreach (var x in List)
			{
				if (x.day == show_day)
				{
					Console.WriteLine("\nOn {0} we have: ", show_day);
					x.ShowDay();
				}
			}

			foreach (var x in List)
			{
				if (x.destination == show_dest)
				{
					Console.WriteLine("\nTo {0} flying: ", show_dest);
					x.ShowDest();
				}
			}

			var some_flight = new { destination = "LA", airplane_type = "business", day = "wed", flight_number = 5, time = 9 };
			Console.WriteLine($"{some_flight}");

			Console.ReadKey();
		}
	}
}