using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
	public interface IVwRepository<T> where T : class
	{
		List<T> GetAll();
		T GetById(Guid id);
	}
}
