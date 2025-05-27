using BL.Contracts.BaseCon;
using BL.Dtos;
using Domain.Entities;


namespace BL.Contracts
{
	public interface IUserExam : IBaseService<TbUserExam,UserExamDto>
	{

        public UserExamDto OneUserExamDto(Guid id);
        public UserExamDto FillingUserExamDto(Guid idExam, Guid id);

    }
}
