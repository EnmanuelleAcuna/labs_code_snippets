using System;

namespace ToDoAPI.Models
{
	// The Singleton class defines the `GetInstance` method that serves as an alternative to constructor and 
	// lets clients access the same instance of this class over and over.

	// The Singleton should always be a 'sealed' class to prevent class inheritance through external classes and 
	// also through nested classes.
	public sealed class SingletonST
	{
		// The constructor should always be private to prevent direct construction calls with the `new` operator.
		private SingletonST() { }

		public static SingletonST _instance;

		public static SingletonST GetInstance()
		{
			if (_instance == null)
			{
				_instance = new SingletonST();
			}

			return _instance;
		}
	}

	class ProgramST
	{
		static void MainST(string[] args)
		{
			// Both are the same in memory
			SingletonST s1 = SingletonST.GetInstance();
			SingletonST s2 = SingletonST.GetInstance();

			if (s1 == s2)
			{
				Console.WriteLine("Singleton works! Both variables contain the same instance");
			}
			else
			{
				Console.WriteLine("Singleton failed! Variables contain different instances");
			}
		}
	}

	// This Singleton implementation is called "double check lock". It is safe in multithreaded environment and 
	// provides lazy initialization for the Singleton object.
	public sealed class SingletonMT
	{
		private SingletonMT() { }

		private static SingletonMT _instance;

		// Lock object will be used to synchronize threads during first access to the Singleton.
		private static readonly object _lock = new Object();

		public static SingletonMT GetInstance(string value)
		{
			// This conditional is needed to prevent threads stumbling over the lock once the instance is ready.
			if (_instance == null)
			{
				// Now, imagine that the program has just been launched. Since there's no Singleton instance yet, 
				// multiple threads can simultaneously pass the previous conditional and reach this point almost at 
				// the same time. The first of them will acquire lock and will proceed further, while the rest will wait here.
				lock (_lock)
				{
					// The first thread to acquire the lock, reaches this conditional, goes inside and creates the 
					// Singleton instance. Once it leaves the lock block, a thread that might have been waiting for the 
					// lock release may then enter this section. But since the Singleton field is already initialized, 
					// the thread won't create a new object.
					if (_instance == null)
					{
						_instance = new SingletonMT();
						_instance.Value = value;
					}
				}
			}

			return _instance;
		}

		// Use this property to prove that the Singleton really works.
		public string Value { get; set; }
	}

	class ProgramMT
	{
		static void MainMT(string[] args)
		{
			Console.WriteLine();

			Thread process1 = new Thread(() =>
			{
				TestSingleton("Ema");
			});

			Thread process2 = new Thread(() =>
			{
				TestSingleton("Ame");
			});

			process1.Start();
			process2.Start();

			process1.Join();
			process2.Join();
		}

		public static void TestSingleton(string value)
		{
			SingletonMT singleton = SingletonMT.GetInstance(value);
			Console.WriteLine(singleton.Value);
		}
	}
}