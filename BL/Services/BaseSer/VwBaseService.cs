using AutoMapper;
using BL.Contracts.BaseCon;
using DAL.Contracts;


namespace BL.Services.BaseSer
{
	public class VwBaseService<T, DTO> : IVwBaseService<T, DTO> where T : class
	{
		private readonly IVwRepository<T> _repository;
		private readonly IMapper _mapper;
		public VwBaseService(IVwRepository<T> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}
		public List<DTO> GetAll()
		{
			var list = _repository.GetAll();
			return _mapper.Map<List<T>, List<DTO>>(list);
		}

		public DTO GetById(Guid id)
		{
			var obj = _repository.GetById(id);
			return _mapper.Map<T, DTO>(obj);
		}


	}
}
