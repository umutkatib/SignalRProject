using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
	public interface ICategoryService : IGenericService<Category>
	{
		public int TCategoryCount();
		public int TActiveCategoryCount();
		public int TPassiveCategoryCount();
	}
}
