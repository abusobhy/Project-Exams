﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
	public interface ITbRepository<T> where T : class
	{
		List<T> GetAll();
		T GetById(Guid id);
		bool Add(T entity);
		bool Update(T entity);
		bool Delete(Guid id);
		bool ChangeStatus(Guid id,Guid userId, int status);
	}
}
