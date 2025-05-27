using DAL.Contracts;
using DAL.Data;
using DAL.Exceptions;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace DAL.Repositories
{
	public class TbRepository<T> : ITbRepository<T> where T : BaseTb
	{
		
		private readonly AppDbContext _context;
		
		private readonly DbSet<T> _dbSet;
		
		private readonly ILogger<TbRepository<T>> _logger;
		public TbRepository(AppDbContext context, ILogger<TbRepository<T>> log)
		{
			_context = context;
			_dbSet = _context.Set<T>();
			_logger = log;
		}

		public List<T> GetAll()
		{
			try
			{
				return _dbSet.Where(a => a.CurrentState > 0).ToList();
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
				return _dbSet.Where(a => a.Id == id).AsNoTracking().FirstOrDefault();
				//return _dbSet.Where(a => a.Id == id).FirstOrDefault();
			}
			catch (Exception ex)
			{
				throw new DataAccessException(ex, "", _logger);
			}
		}
		public T GetByIdForDeleted(Guid id)
		{
			try
			{
				return _dbSet.Where(a => a.Id == id).FirstOrDefault();
				//return _dbSet.Where(a => a.Id == id).FirstOrDefault();
			}
			catch (Exception ex)
			{
				throw new DataAccessException(ex, "", _logger);
			}
		}
		public bool Add(T entity)
		{
			try
			{
				entity.CreatedDate = DateTime.Now;
				entity.Id = Guid.NewGuid();
				entity.CurrentState = 1;
				_dbSet.Add(entity);
				_context.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				throw new DataAccessException(ex, "", _logger);
			}

		}

		public bool Update(T entity)
		{
			try
			{
				_context.ChangeTracker.Clear();
				var dbData = GetById(entity.Id);
				entity.CreatedDate = dbData.CreatedDate;
				entity.CreatedBy = dbData.CreatedBy;
				entity.UpdatedDate = DateTime.Now;
				//entity.CurrentState = dbData.CurrentState;
				_context.Entry(entity).State = EntityState.Modified;
				_context.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				throw new DataAccessException(ex, "", _logger);
			}
		}

		public bool ChangeStatus(Guid id, Guid userId, int status)
		{
			try
			{
				var entity = GetByIdForDeleted(id);
				if (entity != null)
				{
					entity.CurrentState = 0;
					entity.UpdatedBy = userId;
					entity.UpdatedDate= DateTime.Now;
					
					_context.SaveChanges();
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				throw new DataAccessException(ex, "", _logger);
			}
		}

		public bool Delete(Guid id)
		{
			try
			{
				var entity = GetById(id);
				if (entity != null)
				{
					_dbSet.Remove(entity);
					_context.SaveChanges();
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				throw new DataAccessException(ex, "", _logger);
			}
		}



	}
}
