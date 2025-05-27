using AutoMapper;
using BL.Contracts;
using BL.Contracts.UserSevice;
using BL.Dtos;
using BL.Services.BaseSer;
using DAL.Contracts;
using Domain.Entities;


namespace BL.Services
{
	public class ExamService : BaseService<TbExam, ExamDto> , IExam
	{
		public ExamService(ITbRepository<TbExam> repository, IMapper mapper, IUserService userService) : base(repository, mapper,userService)
		{

		}
	}
}
