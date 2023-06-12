using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Modles
{
	public abstract class CommonClass
	{
		public int Is_Active { get; set; }
		public int OrgId { get; set; }
		public string Remarks { get; set; }
		public Int32 Createdby { get; set; }
		public string CreatedOn { get; set; }
		public Int32 ModifiedBy { get; set; }
		public string ModifiedOn { get; set; }
	}
	public class Result
	{
		public int Status { get; set; }
		public string message { get; set; }
	}
}
