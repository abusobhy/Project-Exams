using AppResources.Exam;
using AutoMapper;
using BL.Contracts;
using BL.Contracts.UserSevice;
using BL.Dtos;
using BL.Services.BaseSer;
using DAL.Contracts;
using Domain.Entities;


namespace BL.Services
{
	public class UserExamService : BaseService<TbUserExam,UserExamDto>,IUserExam
	{
        public UserExamService(ITbRepository<TbUserExam> repository, IMapper mapper, IUserService userService) : base(repository, mapper, userService)
		{
            
        }
        // بتجيب ريكور اليورز علشان نسجل فيه النتيجه النهائيه
        public UserExamDto OneUserExamDto(Guid id)
        {
            var dataUserExam = GetAll()
                .FirstOrDefault(a => a.UserId == id &&  a.CurrentState == 1);
            return dataUserExam;
        }

        public UserExamDto FillingUserExamDto(Guid idExam,Guid id)
        {
            var dataUserExam = new UserExamDto()
            {
                ExamId = idExam,
                StartTime = DateTime.Now,
                UserId = id,
                CurrentState = 1
            };
            return dataUserExam;
        }
    }
}
