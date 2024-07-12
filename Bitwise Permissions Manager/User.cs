using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitwise_Permissions_Manager
{
	public class User
	{
		public enum enPermissions
		{
			Add = 1,
			Update = 2,
			Delete = 4,
			ViewReports = 8,
			ManageUsers = 16,
			ExportData = 32,
			ApproveRequests = 64,
			AdministerSystem = 128


		}
		public int Id { get; set; }
		public string Name { get; set; }

		public int Permissions {  get; set; }

	}

	
}
