using Common.Modles;
using Common.Modles.UserDetails;
using HRMS_Core.BussinessLogic.BLUserLogin;
using HRMS_Core.DataAccessLayer.DatabaseHelper.Datablase.DatabaseHelper;
using HRMS_Core.DataAccessLayer.DAUserLogin;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;

namespace HRMSWebService.Areas.UserDetails
{
    [ApiController]
	public class UserDetails : ControllerBase
	{
		private IBLUserLogin _iBLUserLogin;
		public UserDetails(IBLUserLogin BLUserLogin)
		{
			_iBLUserLogin = BLUserLogin;
		}

		[HttpGet]
		[Route("api/UserDetails/Login")]
		public UserLogin Login(int LCOID)
		{
			
			UserLogin resultinfo = null;
			try
			{
				resultinfo = _iBLUserLogin.Login(LCOID);
			}
			catch (Exception ex)
			{
				throw;
			}
			return resultinfo;
		}

		[HttpPost]
		[Route("api/UserDetails/Save")]
		public Result Usp_InsertUpdate_UserDetails(UserLogin userLogin)
		{

			Result resultinfo = null;
			try
			{
				resultinfo = _iBLUserLogin.InsertUpdate_UserDetails(userLogin);
			}
			catch (Exception ex)
			{
				throw;
			}
			return resultinfo;
		}
	}

}
