using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _2lab
{
	class Program
	{
		static void Main(string[] args)
		{
			//1a Определите переменные всех возможных примитивных типов
			//С# и проинициализируйте их. 
			sbyte a = -1;
			short b = 2;
			int c = 3;
			long d = 123456;
			byte e = 4;
			ushort f = 5;
			uint g = 6;
			ulong h = 456789;
			char i = 'i';
			bool j = true;
			float k = 7.5f;
			double l = 8.569;
			decimal m = 9.1235M;
			string n = "mmmm";
			object o = 5;

			//1b Выполните 5 операций явного и 5 неявного приведения.
			long c2 = c;
			ulong g2 = g;
			double k2 = k;
			int f2 = f;
			short e2 = e;

			int c3 = (int)c2;
			float k3 = (float)k2;
			long f3 = (long)f2;
			int g3 = (int)g;
			short g4 = (short)g3;


			//1c Выполните упаковку и распаковку значимых типов.
			object p = c;
			int s = (int)p;

			//1d Продемонстрируйте работу с неявно типизированной переменной
						var t = 2.36;
			Console.WriteLine("t type: {0}", t.GetType());

			//1e Продемонстрируйте пример работы с Nullable переменной
			int? u = null;
			Nullable<double> v = null;

			//2a Объявите строковые литералы. Сравните их
			string str1 = "a";
			string str2 = "aa";
			string str3 = "aa";
			Console.WriteLine(str2 == str3);
			Console.WriteLine(str1 != str3);

			//2b Создайте три строки на основе String. Выполните: сцепление,
			//копирование, выделение подстроки, разделение строки на слова,
			//вставки подстроки в заданную позицию, удаление заданной подстроки.
			string s1 = "aaaa1aaaa a";
			string s2 = "bbbbb2bbb";
			string s3 = "ccccc3ccc";


			Console.WriteLine(String.Concat(s1,s2));
			Console.WriteLine(String.Copy(s1));
			Console.WriteLine(s1.Substring(2, 4));
			Console.WriteLine(s1.Split(' ')); //??????????
			Console.WriteLine(s2.Insert(4, "lol"));
			Console.WriteLine(s3.Remove(6));

			//2c Создайте пустую и null строку. Продемонстрируйте что можно выполнить
			//с такими строками
			string s4 = ""; // методы
			string s5 = null; //объед. и сравнение

			Console.WriteLine(s4.Insert(0, "lol"));
			Console.WriteLine(s3 == s1);

			//2d
			/*Создайте строку на основе StringBuilder. Удалите определенные
			позиции и добавьте новые символы в начало и конец строки*/
			StringBuilder sb = new StringBuilder("lol", 40);
			sb.AppendFormat(" OMG");
			sb.Insert(0, "WOW ");
			sb.Remove(3, 1);
			Console.WriteLine(sb.ToString());

			//3a Создайте целый двумерный массив и выведите его на консоль в
			//отформатированном виде(матрица).
			int[,] arr = { { 1, 2, 3 }, { 4, 5, 6 } };

			foreach (var x in arr)
				Console.Write(x + "\t");

			//3b Создайте одномерный массив строк. Выведите на консоль его
			//содержимое, длину массива. Поменяйте произвольный элемент
			//(пользователь определяет позицию и значение).
			string[] arr_str = { "first", "second", "third" };
			Console.WriteLine(arr_str.Length);
			foreach (var x in arr_str)
				Console.WriteLine(x + "\t");

			string inp;
			int pos;
			Console.WriteLine("Input numper of element[0-2]:");
			pos = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Input string:");
			inp = Console.ReadLine();
			arr_str[pos] = inp;

			foreach (var x in arr_str)
				Console.WriteLine(x + "\t");


			//3c Создайте ступечатый (не выровненный) массив вещественных
			//чисел с 3 - мя строками, в каждой из которых 2, 3 и 4 столбцов
			//соответственно.Значения массива введите с консоли.
			string[][] jag_arr = { new string[2], new string[3], new string[4] };
			for (int x = 0; x < 3; x++)
			{
				for (int x2 = 0; x2 < jag_arr[x].Length; x2++)
				{
					jag_arr[x][x2] = Console.ReadLine();
				}
			}

			foreach (var x in jag_arr)
			{
				foreach (var x2 in x)
					Console.WriteLine(x2 + "\t");
				Console.WriteLine();
			}


			//3d Создайте неявно типизированные переменные для хранения массива и строки.
			var string_keeper = "This is string";
			var array_keeper = new int[5];

			//4a Задайте кортеж из 5 элементов с типами int, string, char, string, ulong
			ValueTuple<int, string, char, string, ulong> tuple = (3, "aaa", 's', "pop", 4567);

			//4b Выведите кортеж на консоль целиком и выборочно ( например 1, 3, 4 элементы)
			Console.WriteLine($"{tuple}");
			Console.WriteLine(tuple.Item2 + " " + tuple.Item5);

			//4c Выполните распаковку кортежа в переменные
			ValueTuple<char, int, string> tuple2 = ('a', 5, "ROHAN");
			var (one, two, three) = tuple2;

			//4d Сравните два кортежа

			Console.WriteLine(tuple2.Item3 == tuple.Item4);

			//5 Создайте локальную функцию в main и вызовите ее. Формальные
			//параметры функции – массив целых и строка. Функция должна вернуть
			//кортеж, содержащий: максимальный и минимальный элементы массива,
			//сумму элементов массива и первую букву строки.

			int[] arr5 = { 1, 0, 5, 70, -5 };
			string str5 = "ddd";

			(int, int, int, char) LocalFunc(int[] array, string strr)
			{
				return (array.Min(), array.Max(), array.Sum(), strr.First());
			}

			Console.WriteLine(LocalFunc(arr5, str5));
		}
	}
}