using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
+	1. Создайте обобщенный интерфейс с операциями добавить, удалить,
просмотреть.
+	2. Возьмите за основу лабораторную № 4 «Перегрузка операций» и
сделайте из нее обобщенный тип (класс) CollectionType<T>, в который
вложите обобщённую коллекцию. Наследуйте в обобщенном классе интерфейс
из п.1. Реализуйте необходимые методы. Добавьте обработку исключений c
finally. Наложите какое-либо ограничение на обобщение.
+	3. Проверьте использование обобщения для стандартных типов данных (в
качестве стандартных типов использовать целые, вещественные и т.д.).
Определить пользовательский класс, который будет использоваться в качестве
параметра обобщения. Для пользовательского типа взять класс из лабораторной
№5 «Наследование».
	Дополнительно:
Добавьте методы сохранения объекта (объектов) обобщённого типа
CollectionType<T> в файл и чтения из него. 
*/

namespace lab8
{
	internal interface IWork<T>
	{
		void Add(T value);
		void Delete();
		void Show();
	}

	class MyException : Exception
	{
		public MyException(string message) : base(message)
		{ }
	}

	public class CollectionType<T> : IWork<T> where T : new()
	{
		public int currentsize;
		Stack<T> stack;
		public int Value { get; set; }

		public CollectionType()
		{
			currentsize = 0;
			stack = new Stack<T>();
		}

		public void Add(T value)
		{
			if (value == null)
			{
				throw new MyException("U can't add null\n");
			}
			else
			{
				this.currentsize++;
				this.stack.Push(value);
			}
		}

		public void Delete()
		{
			if (this.currentsize == 0)
			{
				throw new MyException("There is no elements\n");
			}
			else
			{
				this.currentsize--;
				this.stack.Pop();
			}
		}
		public static bool operator true(CollectionType<T> myStack)
		{
			return myStack.currentsize == 0;
		}

		public static bool operator false(CollectionType<T> myStack)
		{
			return myStack.currentsize != 0;
		}

		public void Show()
		{
			T[] temp = this.stack.ToArray();
			for (int i = 0; i < temp.Length; i++)
			{
				if (temp[i] as Island != null)
				{
					Island island = temp[i] as Island;
					island.ToString();
				}
				else
				{
					Console.WriteLine($"{temp[i]}");
				}
			}
		}
	}

	class Island
	{
		public string IslandName { get; set; }
		public Island()
		{
			IslandName = "Some island";
		}
		public Island(string name)
		{
			IslandName = name;
		}
		new public void ToString()
		{
			Console.WriteLine($"Название острова: {this.IslandName}");
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Console.WriteLine("Collection of int before:");
				CollectionType<int?> collection_of_int = new CollectionType<int?>();
				collection_of_int.Add(1);
				collection_of_int.Add(2);
				collection_of_int.Add(3);
				collection_of_int.Add(4);
				collection_of_int.Show();
				Console.WriteLine("Collection of int after:");
				collection_of_int.Delete();
				collection_of_int.Show();
				Console.WriteLine();

				Console.WriteLine("Collection of double before:");
				CollectionType<double?> collection_of_double = new CollectionType<double?>();
				collection_of_double.Add(0.1);
//				collection_of_double.Add(null);
				collection_of_double.Add(0.2);
				collection_of_double.Add(0.3);
				collection_of_double.Add(0.4);
				collection_of_double.Show();
				Console.WriteLine("Collection of double after:");
				collection_of_double.Delete();
				collection_of_double.Show();
				Console.WriteLine();

				Console.WriteLine("Collection of Islands before:");
				CollectionType<Island> collection_of_Islands = new CollectionType<Island>();
				Island first_island = new Island("Jeju");
				Island second_island = new Island("Hokkaido");
				Island third_island = new Island("Hawaii");
				Island fouth_island = new Island("Singapore");
				Island neverland = new Island();
				collection_of_Islands.Add(first_island);
				collection_of_Islands.Add(second_island);
				collection_of_Islands.Add(third_island);
				collection_of_Islands.Add(fouth_island);
				collection_of_Islands.Add(neverland);
				collection_of_Islands.Show();
				Console.WriteLine("Collection of Islands after:");
				collection_of_Islands.Delete();
				collection_of_Islands.Show();
				Console.WriteLine();
			}
			catch (MyException message)
			{
				Console.WriteLine($"An exception {message.InnerException} found there: {message.StackTrace}.\n");
			}
			catch (Exception message)
			{
				Console.WriteLine($"An exception {message.InnerException} found there: {message.StackTrace}.\n");
			}
			finally
			{
				Console.WriteLine("It's over. Bye.");
			}
			Console.ReadKey();
		}
	}
}
