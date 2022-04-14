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

Public actionresult edit(int id, customer customer) 

{

	Try

{

		using (DBModels dbModel = new DbModels())

		{

			dbmodel.entry(customer).state = entitystate.modified;

			Dbmodel.savechanges();

		}

		Reirect to action index

}

	Catch

{

	}

}