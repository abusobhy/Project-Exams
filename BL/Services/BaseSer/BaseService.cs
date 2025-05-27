using AutoMapper;
using BL.Contracts.BaseCon;
using BL.Contracts.UserSevice;
using DAL.Contracts;
using Domain;


namespace BL.Services.BaseSer
{
	public class BaseService<T, DTO> : IBaseService<T, DTO> where T : BaseTb
    {
        private readonly ITbRepository<T> _repository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
		public BaseService(ITbRepository<T> repository, IMapper mapper, IUserService userService)
		{
			_repository = repository;
			_mapper = mapper;
			_userService = userService;
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

        public bool Add(DTO entity, Guid userId)
        {
            var dbObj = _mapper.Map<DTO, T>(entity);
            dbObj.CreatedBy = _userService.GetLoggedInUser(); 

            return _repository.Add(dbObj);
        }

        public bool Update(DTO entity, Guid userId)
        {
            var dbObj = _mapper.Map<DTO, T>(entity);
            dbObj.UpdatedBy = _userService.GetLoggedInUser();

			return _repository.Update(dbObj);
        }
        public bool ChangeStatus(Guid id, int status)
        {
            return _repository.ChangeStatus(id, _userService.GetLoggedInUser(), status);
        }


    }
}
