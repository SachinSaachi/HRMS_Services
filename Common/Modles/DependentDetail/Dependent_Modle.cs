using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Modles.DependentDetail
{
	public class Dependent_Modle:CommonClass
	{
public Int64 DependentDetailId { get; set; }	
public Int64 UserId { get; set; }	
public string DependentName { get; set; }	
public string Relation { get; set; }	
public string Gender { get; set; }	
public string DOB { get; set; }
public string BirthPlace { get; set; }	
public string BloodGroup { get; set; }
public string Occupation { get; set; }

	}
}
