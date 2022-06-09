using System;

// Primitive gypes
byte myBite = 120; //unsigned, range is from 0 to 255
short myShort = 32000; // 16 bit version of int, -32 768 to 32 767
int myInt = 0; // 32bits, can hold numbers from -2 147 483 648 to 2 147 483 648
long myLong = 465; // 64 bit version of int,  range from -9.2X10^18 to 9.2X10^18

// unsigned versions of int
//ushort, uint, ulong
ushort myUShort = 11232;
uint myUInt = 12232;
ulong myULong = 1232323;

// signed version of byte
sbyte mySByte = -120; // rangre from -128 to 127

float myFloat = 2.563452f; // 32 bits, can hold -3.4X10^38 to 3.4X10^38, has to end with f, has 6 decimal units
double myDouble = 2.234234; // 64 bits, has 15 to 16 decimal units.
char myChar = 'a'; // can hold one value at a time, letter o symbol.
bool isTrue = true;

// Complex types
DateTime dateTime = DateTime.Now;

DateOnly dateOnly; // .Net 6
dateOnly = DateOnly.FromDateTime(DateTime.Now);

TimeOnly timeOnly; // .Net 6
timeOnly = TimeOnly.FromDateTime(DateTime.Now);

// Type conversion
// There is implicit and explicit conversion

// Implicit conversions
float float_a = 2.3f;
double double_1 = float_a; // no loss of data because double can hold more data than float

sbyte sByte_1 = 12;
int int_1 = sByte_1;
short short_1 = int_1; // not allowed because of data loss

// Explicit conversions
// There is posible loss of data ans required syntax (castings)
short short_2 = (short)int_1;

double double_2 = 2.44324324;
float float_b = (float)double_2; // lose 2 decimal units

// Conversions between non-compatible types
char char_a = 'a'; // use ASCII table, a is 97 in the ASCII table.
int int_2 = char_a; // converts to 97

// Using Convert class
// string is an array of characters
string myString = "12000";
int myInt_2 = Convert.ToInt32(myString);
long myLong_2 = Convert.ToInt64(myString);

// Abstract classes
public abstract class MyClass_A
{
	public string name;
	public int myNumber;

	public abstract void print(); // must be modified in derived classes or inherited

	public int TestFunction()
	{
		return 1 + 1;
	}
}

// Virtual classes
public virtual class MyClass_V { }

// Inheritance and implementation on an abstract class
public class MyClass : MyClass_A
{
	public MyClass()
	{
		name = "Ema";
		myNumber = 1;
	}

	// implement abstract class we must use override
	public override void print()
	{
		Console.WriteLine(name);
	}

	public override int TestFunction()
	{
		return 1 + 2;
	}
}

// Structures
// Similar to classes, they can have public an private data mebers and functions/methods
public struct MyStruct
{
	public int MyNumber;
	public string Name;

	public MyStruct(int myNumber, string name)
	{
		MyNumber = myNumber;
		Name = name;
	}

	public void MyFunc()
	{
		Console.WriteLine(Name);
	}
}

// Ejecutar descarga de página y devolver las veces que .Net aparece 
private readonly HttpClient _httpClient = new HttpClient();

[HttpGet]
[Route("DotNetCount")]
public async Task<int> GetDotNetCountAsync()
{
	// Suspends GetDotNetCountAsync() to allow the caller (the web server) 
	// to accept another request, rather than blocking on this one. 
	var html = await _httpClient.GetStringAsync("https://dotnetfoundation.org");
	return Regex.Matches(html, @"\.NET").Count;
}

// Buscar una Claim dentro de un ClaimIdentity por su nombre 

ClaimIdentity.FindFirst("NombreClaim");
Return Claim.Value;

using (DBModels dbModel = new DbModels())
{
	Return view(dbmodel.customers.tolist);
}

Using(dbmodels dbmodel = new dbmodels())
{
	Return view(dbmodel.customer.where(x => x.id == id));
}

[httppost]
public ActionResult edit(int id, customer customer)
{
	try
	{
		using (DBModels dbModel = new DbModels())
		{
			dbmodel.entry(customer).state = entitystate.modified;
			Dbmodel.savechanges();
		}

		Reirect to action index
	}
	catch { }
}

// Singleton
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
