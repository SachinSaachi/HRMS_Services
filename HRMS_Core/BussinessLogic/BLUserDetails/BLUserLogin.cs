using Common.Modles;
using Common.Modles.UserDetails;
using HRMS_Core.DataAccessLayer.DAUserLogin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS_Core.BussinessLogic.BLUserLogin
{
    public interface IBLUserLogin
	{
		UserLogin Login(int LCOID);
		Result InsertUpdate_UserDetails(UserLogin objuserLogin);
	}
	public class BLUserLogin : IBLUserLogin
	{
		private IDAUserLogin _dAUserLogin;
		public BLUserLogin(IDAUserLogin dAUserLogin)
		{
			_dAUserLogin = dAUserLogin;
		}
		public UserLogin Login(int LCOID)
		{
			return _dAUserLogin.Login(LCOID);
				
		}
		public Result InsertUpdate_UserDetails(UserLogin objuserLogin)
		{
			return _dAUserLogin.InsertUpdate_UserDetails(objuserLogin);

		}
	}
}
