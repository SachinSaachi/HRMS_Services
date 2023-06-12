using Common.Modles;
using Common.Modles.DependentDetail;
using HRMS_Core.BussinessLogic.Dependent;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_WebService.Areas.DependentDetail
{
	[ApiController]
	public class Dependent : ControllerBase
	{
		private IBLDependent _bLDependent;
		public Dependent(IBLDependent bLDependent)
		{
			_bLDependent = bLDependent;
		}
		[HttpPost]
		[Route("api/Dependent/Save")]
		public Result InsertUpdate_DependentDetails(Dependent_Modle dependent_Modle)
		{

			Result resultinfo = null;
			try
			{
				resultinfo = _bLDependent.InsertUpdate_DependentDetails(dependent_Modle);
			}
			catch (Exception ex)
			{
				throw;
			}
			return resultinfo;
		}


	}
}
