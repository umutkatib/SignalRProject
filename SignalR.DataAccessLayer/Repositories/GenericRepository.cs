using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalR.DataAccessLayer.Repositories
{
	public class GenericRepository<T> : IGenericDal<T> where T : class
	{
		private readonly SignalRContext _context;

		public GenericRepository(SignalRContext context)
		{
			_context = context;
		}

		public void Add(T Entity)
		{
			_context.Add(Entity);
			_context.SaveChanges();
		}

		public void Delete(T Entity)
		{
			_context.Remove(Entity);
			_context.SaveChanges();
		}

		public T GetByID(int id)
		{
			return _context.Set<T>().Find(id);
		}

		public List<T> GetListAll()
		{
			return _context.Set<T>().ToList();
		}

		public void Update(T Entity)
		{
			_context.Update(Entity);
			_context.SaveChanges();
		}


	}
}
