namespace Bitwise_Permissions_Manager
{
	internal class Program
	{
		static void Main(string[] args)
		{
			const byte FLAG_READ = 0x01;
			const byte FLAG_WRITE = 0x02;
			const byte FLAG_EXECUTE = 0x04;
			const byte FLAG_DELETE = 0x08;

			Byte Permissions = FLAG_READ | FLAG_WRITE;
			bool CanRead = (Permissions & FLAG_READ) != 0;
			bool CanWite = (Permissions & FLAG_WRITE) != 0;
			bool CanExecute = (Permissions & FLAG_EXECUTE) != 0;
			bool CanDelete = (Permissions & FLAG_DELETE) != 0;

			Console.WriteLine($"User can read: {CanRead}");      // True
			Console.WriteLine($"User can write: {CanWite}");    // True
			Console.WriteLine($"User can execute: {CanExecute}"); // False
			Console.WriteLine($"User can delete: {CanDelete}");    // False
			Console.WriteLine(Convert.ToString(Permissions, 2).PadLeft(8, '0'));

			Console.WriteLine("After Adding FLAG_DELETE ");
			Permissions |= FLAG_DELETE; // using | to add FLAG_DELETE
			Console.WriteLine(Convert.ToString(Permissions, 2).PadLeft(8, '0'));

			Console.WriteLine("After Removing FLAG_WRITE");
			Permissions = Convert.ToByte(Permissions & ~FLAG_WRITE); // using ~ to inverse byte (Ex: 1001 to 0110)
			Console.WriteLine(Convert.ToString(Permissions, 2).PadLeft(8, '0'));

			CanRead = (Permissions & FLAG_READ) != 0;
			CanWite = (Permissions & FLAG_WRITE) != 0;
			CanExecute = (Permissions & FLAG_EXECUTE) != 0;
			CanDelete = (Permissions & FLAG_DELETE) != 0;

			Console.WriteLine($"User can read: {CanRead}");        // True
			Console.WriteLine($"User can write: {CanWite}");       // False
			Console.WriteLine($"User can execute: {CanExecute}");  // False
			Console.WriteLine($"User can delete: {CanDelete}");    // True

            Console.WriteLine("\n\n Real Example class User\n");




            Console.ReadKey();
		}
	}
}
