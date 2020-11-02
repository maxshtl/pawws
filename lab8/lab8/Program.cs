using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
+	1. Создайте обобщенный интерфейс с операциями добавить, удалить,
просмотреть.
	2. Возьмите за основу лабораторную № 4 «Перегрузка операций» и
сделайте из нее обобщенный тип (класс) CollectionType<T>, в который
вложите обобщённую коллекцию. Наследуйте в обобщенном классе интерфейс
из п.1. Реализуйте необходимые методы. Добавьте обработку исключений c
finally. Наложите какое-либо ограничение на обобщение.
	3. Проверьте использование обобщения для стандартных типов данных (в
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
	internal interface IWork<T, V>
	{
		void Add(V value, T myStack);
		void Delete(T myStack);
		void Show();
	}

	public class CollectionType<T> : IWork<T, V>
	{
		public int currentsize;
		Stack<T> stack;
		public int value { get; set; }

		public CollectionType()
		{
			currentsize = 0;
			stack = new Stack<T>();
		}

		public void Add(T value, CollectionType<T> myStack)
		{
			myStack.currentsize++;
			myStack.stack.Push(value);
		}

		public void Delete(CollectionType<T> myStack)
		{
			myStack.currentsize--;
			myStack.stack.Pop();
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
				Console.Write($"{temp[i]}\t");
				Console.WriteLine(' ');
			}
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
		}
	}
}
