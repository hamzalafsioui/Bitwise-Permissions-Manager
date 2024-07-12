namespace Bitwise_Permissions_Manager
{
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public byte Permissions { get; set; }
		public User(int id, string name, byte permissions)
		{
			Id = id;
			Name = name;
			Permissions = permissions;
		}

		public override string ToString()
		{
			return $"ID: {Id},  Name: {Name},  Permissions: {Permissions}";
		}

		public void RemovePermission(enPermissions permission)
		{
			Permissions &= (byte)~permission;
		}

		public bool AccessDenied(enPermissions permission)
		{
			return !((Permissions & (byte)permission) != 0);
		}
	}


}
