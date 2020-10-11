using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
	+1) Создать заданный в варианте класс. Определить в классе необходимые методы, конструкторы, индексаторы и заданные перегруженные
	операции. Написать программу тестирования, в которой проверяется использование перегруженных операций.
	+	Класс - стек Stack. Дополнительно перегрузить следующие операции: + - добавить элемент в стек; -- - извлечь элемент из
	стека; true - проверка, пустой ли стек; > - копирование одного стека в другой с сортировкой в возрастающем порядке.

	+?2) Добавьте в свой класс вложенный объект Owner, который содержит Id, имя и организацию создателя. Проинициализируйте его

	+3) Добавьте в свой класс вложенный класс Date (дата создания). Проинициализируйте.

	+4) Создайте статический класс StatisticOperation, содержащий 3 метода для работы с вашим классом.

	+5) Добавьте к классу StatisticOperation методы расширения для типа string и вашего типа из задания№1.
		Методы расширения:
		+1) Подсчет количества предложений
		+2) Определение среднего элемента стека
 */
namespace lab4
{

	class Stack
	{
		public int currentsize;
		public int[] arrayData;
		public int maxSize = 10;
		public int value { get; set; }

		private class Owner 
		{
			long id = 1235786554688;
			string name = "Rykhlionak A.";
			string organization = "Oooooo";
		}

		private class Date
		{
			double date = 11.10;
		}

		public Stack ()
		{
			currentsize = 0;
			arrayData = new int[maxSize];
		}

		public static int operator +(int value, Stack myStack)
		{
			return myStack.arrayData[myStack.currentsize++] = value;
		}

		public static Stack operator --(Stack myStack)
		{
			myStack.currentsize--;
			myStack.arrayData[myStack.currentsize] = 0;
			return myStack;
		}

		public static bool operator true(Stack myStack)
		{
			return myStack.currentsize == 0;
		}

		public static bool operator false(Stack myStack)
		{
			return myStack.currentsize != 0;
		}

		public static Stack operator >(Stack myStack, Stack secondStack)
		{
			for (int i = 0; i < myStack.currentsize; i++)
			{
				secondStack.arrayData[secondStack.currentsize] = myStack.arrayData[i];
				for (int j = secondStack.currentsize; j - 1 >= 0; j--)
				{

					if (secondStack.arrayData[j] < secondStack.arrayData[j - 1])
					{
						int temp = secondStack.arrayData[j];
						secondStack.arrayData[j] = secondStack.arrayData[j - 1];
						secondStack.arrayData[j - 1] = temp;
					}
				}
				secondStack.currentsize++;
			}
			return secondStack;
		}

		public static Stack operator <(Stack myStack, Stack secondStack)
		{
			Console.WriteLine("someBODY ONCE TOLD ME-");
			return secondStack;
		}

		public void Show()
		{
			for (int i = 0; i < this.currentsize; i++)
			{
				Console.Write(this.arrayData[i].ToString() + '\t');
				Console.WriteLine(' ');
			}
		}
	}

	static class StatisticOperation
	{
		public static int Sum(Stack myStack)
		{
			return myStack.arrayData.Sum();
		}

		public static int Length(Stack myStack)
		{
			return myStack.arrayData.Length;
		}

		public static int Dif(Stack myStack)
		{
			return myStack.arrayData.Max() - myStack.arrayData.Min();
		}

		public static string Count(this string s)
		{
			// int count = 0; count.ToString()
			string[] count_string = s.Split('.');
			return count_string.Length.ToString();
		}
		public static double MidElem(this Stack myStack)
		{
			return myStack.arrayData.Sum()/myStack.currentsize;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Stack myStack = new Stack();
			Console.WriteLine("Добавление:");
			Console.WriteLine(4 + myStack);
			Console.WriteLine(7 + myStack);
			Console.WriteLine(0 + myStack);
			Console.WriteLine(9 + myStack);
			Console.WriteLine(15 + myStack);
			myStack.Show();

			Console.WriteLine("Дикремент и тру:");
			myStack--;
			myStack.Show();
			Console.WriteLine(myStack);//true??????

			Console.WriteLine("Второй стек:");
			Stack secondStack = new Stack();
			Console.WriteLine(myStack > secondStack);
			secondStack.Show();

			Console.WriteLine("Методы (сумма, длина, max-min) и два расширенных (строки и среднее):");
			Console.WriteLine(StatisticOperation.Sum(myStack));
			Console.WriteLine(StatisticOperation.Length(myStack)); 
			Console.WriteLine(StatisticOperation.Dif(myStack));
			Console.WriteLine(StatisticOperation.Count("I.DONT.WANNA.BE.ME"));
			Console.WriteLine(StatisticOperation.MidElem(myStack));
			Console.ReadKey();
		}
	}
}