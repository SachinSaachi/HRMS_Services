using Common.Modles;
using Common.Modles.UserDetails;
using HRMS_Core.DataAccessLayer.DatabaseHelper.Datablase.Common;
using HRMS_Core.DataAccessLayer.DatabaseHelper.Datablase.DatabaseHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS_Core.DataAccessLayer.DAUserLogin
{
    public interface IDAUserLogin
	{
		UserLogin Login(int LCOID);
		Result InsertUpdate_UserDetails(UserLogin objuserLogin);
	}
	public class DAUserLogin : IDAUserLogin
	{
		private IExecuteQuery _executeQuery;
		public DAUserLogin(IExecuteQuery executeQuery)
		{
			_executeQuery = executeQuery;
		}
		public UserLogin Login(int LCOID)
		{
			String SQL = String.Empty;
			UserLogin objUserLogin = new UserLogin();
			DataTableReader dr;
			ParameterList paramList = new ParameterList();
			try
			{
				SQL = "GetUserDetails";

				paramList.Add(new SQLParameter("@UserName", ""));
				paramList.Add(new SQLParameter("@Password", ""));

				dr = _executeQuery.ExecuteReader(SQL, paramList);
				//if (dr.HasRows)
				//{
				//	while (dr.Read())
				//	{

				//		objUserLogin.UserId = Convert.ToInt64(dr["UserId"]);
				//		objUserLogin.UserName = Convert.ToString(dr["UserName"]);
				//		objUserLogin.User_Type = Convert.ToString(dr["User_Type"]);
				//		objUserLogin.User_FName = Convert.ToString(dr["User_FName"]);
				//		objUserLogin.User_LName = Convert.ToString(dr["User_LName"]);
				//		objUserLogin.User_Gender = Convert.ToString(dr["user_Gender"]);
				//		objUserLogin.User_DOB = Convert.ToString(dr["User_DOB"]);
				//		objUserLogin.User_BloodGroup = Convert.ToString(dr["User_BloodGroup"]);
				//		objUserLogin.User_Religion = Convert.ToString(dr["User_Religion"]);
				//		objUserLogin.User_Cast = Convert.ToString(dr["User_Cast"]);
				//		objUserLogin.User_Citizenship = Convert.ToString(dr["User_Citizenship"]);
				//		objUserLogin.User_PrimaryEmail = Convert.ToString(dr["User_PrimaryEmail"]);
				//		objUserLogin.User_PrimaryMobile = Convert.ToString(dr["User_PrimaryMobile"]);
				//		objUserLogin.User_MaterialStatus = Convert.ToString(dr["User_MaterialStatus"]);
				//		objUserLogin.Is_AthorizedForLogin = Convert.ToInt32(dr["Is_AthorizedForLogin"]);
				//		objUserLogin.Is_Active = Convert.ToInt32(dr["Is_Active"]);
				//		objUserLogin.OrgId = Convert.ToInt32(dr["OrgId"]);
				//		objUserLogin.Remarks = Convert.ToString(dr["Remarks"]);



				//	}
				//}


				dr.Close();
			}

			catch (Exception ex)
			{
				#region Exception Handling
				if (Convert.ToInt32(ConfigurationManager.AppSettings["ExceptionFlag"]) == 1)
				{
					string InputParameters = "LCOID: " + LCOID;
					string Exception = Convert.ToString(ex.Message);
					int SMSId = 0;
					string VCNo = "";
					string STBNo = "";
					string Process = "Get LCO KYC Address Update Details and Satus";
					string AplicationName = "";
					string APIURL = "api/LCO/Details/GET_KYC_LCO_Details_Status";
					string LocationName = "";
					int _UserId = LCOID;
					//string _sp_name = SITI_API.Core.Common.Utility.SPNameWithParam("USP_GetLCOAddressUpdateRequestStatusAndDetails", paramList);

					//int res = SITI_API.Core.DataAccessLayer.ExceptionLog.ExceptionLog.InsertExceptionDetail(InputParameters, Exception, SMSId, VCNo, STBNo, Process, AplicationName, APIURL, LocationName, _UserId, _sp_name);

				}
				#endregion
				throw ex;
			}
			return objUserLogin;
		}

		public Result InsertUpdate_UserDetails(UserLogin objuserLogin)
		{
			var Createdby = "";
			var Modifiedby = "";
			String SQL = String.Empty;
			Result result= new Result();
			DataTableReader dr;
			ParameterList paramList = new ParameterList();
			try
			{
				SQL = "Usp_InsertUpdate_UserDetails";
				if (objuserLogin.UserId != 0)
				{
					Modifiedby = DateTime.Now.ToString();
				}
				else
				{
					Createdby = DateTime.Now.ToString();
				}

				paramList.Add(new SQLParameter("@UserId", objuserLogin.UserId));
				paramList.Add(new SQLParameter("@UserName", objuserLogin.UserName));
				paramList.Add(new SQLParameter("@SAP_Id", objuserLogin.SAP_Id));
				paramList.Add(new SQLParameter("@Password", objuserLogin.Password));
				paramList.Add(new SQLParameter("@LastLoginDate", objuserLogin.LastLoginDate));
				paramList.Add(new SQLParameter("@User_Type", objuserLogin.User_Type));
				paramList.Add(new SQLParameter("@User_FName", objuserLogin.User_FName));
				paramList.Add(new SQLParameter("@User_MName", objuserLogin.User_MName));
				paramList.Add(new SQLParameter("@User_LName", objuserLogin.User_LName));
				paramList.Add(new SQLParameter("@User_Gender", objuserLogin.User_Gender));
				paramList.Add(new SQLParameter("@User_DOB", objuserLogin.User_DOB));
				paramList.Add(new SQLParameter("@User_BloodGroup", objuserLogin.User_BloodGroup));
				paramList.Add(new SQLParameter("@User_Religion", objuserLogin.User_Religion));
				paramList.Add(new SQLParameter("@User_Cast", objuserLogin.User_Cast));
				paramList.Add(new SQLParameter("@User_Citizenship", objuserLogin.User_Citizenship));
				paramList.Add(new SQLParameter("@User_PrimaryEmail", objuserLogin.User_PrimaryEmail));
				paramList.Add(new SQLParameter("@User_PrimaryMobile", objuserLogin.User_PrimaryMobile));
				paramList.Add(new SQLParameter("@User_MaritalStatus", objuserLogin.User_MaritalStatus));
				paramList.Add(new SQLParameter("@Is_AthorizedForLogin", objuserLogin.Is_AthorizedForLogin));
				paramList.Add(new SQLParameter("@Is_Active", objuserLogin.Is_Active));
				paramList.Add(new SQLParameter("@OrgId", objuserLogin.OrgId));
				paramList.Add(new SQLParameter("@Remarks", objuserLogin.Remarks));
				paramList.Add(new SQLParameter("@Createdby", objuserLogin.Createdby));
				paramList.Add(new SQLParameter("@CreatedOn", Createdby));
				paramList.Add(new SQLParameter("@ModifiedBy", objuserLogin.ModifiedBy));
				paramList.Add(new SQLParameter("@ModifiedOn",Modifiedby));

				dr = _executeQuery.ExecuteReader(SQL, paramList);
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						result.Status = Convert.ToInt32(dr["Status"].ToString());
						result.message = Convert.ToString(dr["message"].ToString());

					}
				}

				dr.Close();
			}

			catch (Exception ex)
			{
				#region Exception Handling
				if (Convert.ToInt32(ConfigurationManager.AppSettings["ExceptionFlag"]) == 1)
				{
					string InputParameters = "UserID: " + objuserLogin.UserId;
					string Exception = Convert.ToString(ex.Message);
					int SMSId = 0;
					string VCNo = "";
					string STBNo = "";
					string Process = "\" insert User Details InsertUpdate_UserDetails";
					string AplicationName = "";
					string APIURL = "api/UserDetails/InsertUpdate_UserDetails";
					string LocationName = "";
					Int64 _UserId = objuserLogin.UserId;
					//string _sp_name = SITI_API.Core.Common.Utility.SPNameWithParam("USP_GetLCOAddressUpdateRequestStatusAndDetails", paramList);

					//int res = SITI_API.Core.DataAccessLayer.ExceptionLog.ExceptionLog.InsertExceptionDetail(InputParameters, Exception, SMSId, VCNo, STBNo, Process, AplicationName, APIURL, LocationName, _UserId, _sp_name);

				}
				#endregion
				throw ex;
			}
			return result;
		}
	}
}
