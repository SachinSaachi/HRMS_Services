using Common.Modles;
using Common.Modles.DependentDetail;
using HRMS_Core.DataAccessLayer.Dependent;

namespace HRMS_Core.BussinessLogic.Dependent
{
	public interface IBLDependent
	{
		Result InsertUpdate_DependentDetails(Dependent_Modle dependent_Modle);
	}
	public class BLDependent: IBLDependent
	{
		private IDADependent _dadependent;
		public BLDependent(IDADependent dADependent) {
			_dadependent=dADependent;
		}	
		public Result InsertUpdate_DependentDetails(Dependent_Modle dependent_Modle)
		{
			return _dadependent.InsertUpdate_DependentDetails(dependent_Modle);

		}
	}
}
