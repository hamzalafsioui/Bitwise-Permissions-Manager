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

			Console.WriteLine("Enter UserID:");
			int UserID = -1;
			if (!int.TryParse(Console.ReadLine(), out UserID))
			{
				Console.WriteLine("Invalid input for UserID.");
				return;
			}

			Console.WriteLine("Enter UserName:");
			var UserName = Console.ReadLine();

			byte UserPermissions = 0;

			Console.WriteLine("\nPermissions Stage:");
			Console.WriteLine("Enter 'Y' if you want to add a permission, otherwise press any other key.");

			if (IsPermissionGranted("Add"))
				UserPermissions |= (byte)enPermissions.Add;

			if (IsPermissionGranted("Update"))
				UserPermissions |= (byte)enPermissions.Update;

			if (IsPermissionGranted("Delete"))
				UserPermissions |= (byte)enPermissions.Delete;

			if (IsPermissionGranted("ViewReports"))
				UserPermissions |= (byte)enPermissions.ViewReports;

			if (IsPermissionGranted("ManageUsers"))
				UserPermissions |= (byte)enPermissions.ManageUsers;

			if (IsPermissionGranted("ExportData"))
				UserPermissions |= (byte)enPermissions.ExportData;

			if (IsPermissionGranted("ApproveRequests"))
				UserPermissions |= (byte)enPermissions.ApproveRequests;

			if (IsPermissionGranted("AdministerSystem"))
				UserPermissions |= (byte)enPermissions.AdministerSystem;

			User user = new User(UserID, UserName, UserPermissions);
			Console.WriteLine("\nUser details:");
			Console.WriteLine(user);

			Console.WriteLine($"Is User Have a Permission Add: {(user.Permissions & (byte)enPermissions.Add) != 0}");
			Console.WriteLine($"Is User Have a Permission Update: {(user.Permissions & (byte)enPermissions.Update) != 0}");
			Console.WriteLine($"Is User Have a Permission Delete: {(user.Permissions & (byte)enPermissions.Delete) != 0}");
			Console.WriteLine($"Is User Have a Permission ViewReports: {(user.Permissions & (byte)enPermissions.ViewReports) != 0}");
			Console.WriteLine($"Is User Have a Permission ManageUsers: {(user.Permissions & (byte)enPermissions.ManageUsers) != 0}");
			Console.WriteLine($"Is User Have a Permission ExportData: {(user.Permissions & (byte)enPermissions.ExportData) != 0}");
			Console.WriteLine($"Is User Have a Permission ApproveRequests: {(user.Permissions & (byte)enPermissions.ApproveRequests) != 0}");
			Console.WriteLine($"Is User Have a Permission AdministerSystem: {(user.Permissions & (byte)enPermissions.AdministerSystem) != 0}");


			Console.WriteLine(user);
			user.RemovePermission(enPermissions.Add);
			Console.WriteLine("After Remove Permissions");
			Console.WriteLine(user);
			if (user.AccessDenied(enPermissions.Update))
			{
				Console.WriteLine($"You don't have the necessary permissions to access this resources {nameof(enPermissions.Update)}");
			}

			Console.ReadKey();
		}

		public static bool IsPermissionGranted(string permissionName)
		{
			Console.Write($"{permissionName}: ");
			char input = char.ToLower(Console.ReadKey().KeyChar);
			Console.WriteLine();
			return (input == 'y');
		}
	}

}
