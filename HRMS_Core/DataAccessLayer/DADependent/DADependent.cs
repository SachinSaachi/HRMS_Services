using Common.Modles.UserDetails;
using Common.Modles;
using HRMS_Core.DataAccessLayer.DatabaseHelper.Datablase.Common;
using HRMS_Core.DataAccessLayer.DatabaseHelper.Datablase.DatabaseHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Common.Modles.DependentDetail;

namespace HRMS_Core.DataAccessLayer.Dependent
{
	public interface IDADependent
	{
		Result InsertUpdate_DependentDetails(Dependent_Modle _dependent_Modle);
	}
	public class DADependent: IDADependent
	{
		private IExecuteQuery _executeQuery;
		public DADependent(IExecuteQuery executeQuery)
		{
			_executeQuery = executeQuery;
		}
		public Result InsertUpdate_DependentDetails(Dependent_Modle _dependent_Modle)
		{
			var Createdby = "";
			var Modifiedby = "";
			String SQL = String.Empty;
			Result result = new Result();
			DataTableReader dr;
			ParameterList paramList = new ParameterList();
			try
			{
				SQL = "Usp_InsertUpdate_DependentDetails";
				if (_dependent_Modle.DependentDetailId != 0)
				{
					Modifiedby = DateTime.Now.ToString();
				}
				else
				{
					Createdby = DateTime.Now.ToString();
				}
				paramList.Add(new SQLParameter("@DependentDetailId", _dependent_Modle.DependentDetailId));
				paramList.Add(new SQLParameter("@UserId", _dependent_Modle.UserId));
				paramList.Add(new SQLParameter("@DependentName", _dependent_Modle.DependentName));
				paramList.Add(new SQLParameter("@Relation", _dependent_Modle.Relation));
				paramList.Add(new SQLParameter("@Gender", _dependent_Modle.Gender));
				paramList.Add(new SQLParameter("@DOB", _dependent_Modle.DOB));
				paramList.Add(new SQLParameter("@BirthPlace", _dependent_Modle.BirthPlace));
				paramList.Add(new SQLParameter("@BloodGroup", _dependent_Modle.BloodGroup));
				paramList.Add(new SQLParameter("@Occupation", _dependent_Modle.Occupation));
				paramList.Add(new SQLParameter("@Is_Active", _dependent_Modle.Is_Active));
				paramList.Add(new SQLParameter("@OrgId", _dependent_Modle.OrgId));
				paramList.Add(new SQLParameter("@Remarks", _dependent_Modle.Remarks));
				paramList.Add(new SQLParameter("@Createdby", _dependent_Modle.Createdby));
				paramList.Add(new SQLParameter("@CreatedOn", Createdby));
				paramList.Add(new SQLParameter("@ModifiedBy", _dependent_Modle.ModifiedBy));
				paramList.Add(new SQLParameter("@ModifiedOn", Modifiedby));

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
					string InputParameters = "UserID: " + _dependent_Modle.UserId;
					string Exception = Convert.ToString(ex.Message);
					int SMSId = 0;
					string VCNo = "";
					string STBNo = "";
					string Process = "\" insert Dependent Details";
					string AplicationName = "";
					string APIURL = "api/Dependent/Save";
					string LocationName = "";
					Int64 _UserId = _dependent_Modle.UserId;
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
