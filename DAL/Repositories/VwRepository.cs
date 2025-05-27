using DAL.Contracts;
using DAL.Data;
using DAL.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace DAL.Repositories
{
	public class VwRepository<T> : IVwRepository<T> where T : class
	{
		private readonly AppDbContext _context;
		private readonly DbSet<T> _dbSet;
		private readonly ILogger<VwRepository<T>> _logger;
		public VwRepository(AppDbContext context, ILogger<VwRepository<T>> log)
		{
			_context = context;
			_dbSet = _context.Set<T>();
			_logger = log;
		}

		public List<T> GetAll()
		{
			try
			{
				return _dbSet.ToList();
			}
			catch (Exception ex)
			{
				throw new DataAccessException(ex, "", _logger);
			}
		}
		public T GetById(Guid id)
		{
			try
			{
				return _dbSet.AsNoTracking().FirstOrDefault();
				//return _dbSet.Where(a => a.Id == id).FirstOrDefault();
			}
			catch (Exception ex)
			{
				throw new DataAccessException(ex, "", _logger);
			}
		}

		//migrationBuilder.Sql(@"create view VwUsersRoles
		//							as
		//						SELECT dbo.AspNetUserRoles.UserId,  dbo.AspNetUsers.UserName ,dbo.AspNetUsers.Email,
		//						dbo.AspNetUserRoles.RoleId, dbo.AspNetRoles.Name
		//						FROM dbo.AspNetUsers INNER JOIN
		//	   				  dbo.AspNetUserRoles ON dbo.AspNetUsers.Id = dbo.AspNetUserRoles.UserId INNER JOIN
		//						  dbo.AspNetRoles ON dbo.AspNetUserRoles.RoleId = dbo.AspNetRoles.Id ");



		//public T GetByIdForDeleted(Guid id)
		//{
		//    try
		//    {
		//        return _dbSet.Where(a => a.Id == id).FirstOrDefault();
		//        //return _dbSet.Where(a => a.Id == id).FirstOrDefault();
		//    }
		//    catch (Exception ex)
		//    {
		//        throw new DataAccessException(ex, "", _logger);
		//    }
		//}




	}
}
