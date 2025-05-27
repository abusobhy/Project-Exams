using AutoMapper;
using BL.Contracts;
using BL.Contracts.UserSevice;
using BL.Dtos;
using BL.Services.BaseSer;
using DAL.Contracts;
using Domain.Entities;
using System.Diagnostics.Metrics;


namespace BL.Services
{
	public class UserAnswerService : BaseService<TbUserAnswer,UserAnswerDto> , IUserAnswer
	{
        public UserAnswerService(ITbRepository<TbUserAnswer> repository, IMapper mapper, IUserService userService) : base(repository, mapper, userService)
		{
            
        }
        

        public UserAnswerDto OneUserAnswerDto(Guid id)
        {
            var dataUserAnswer = GetAll()
                .Where(a => a.UserExamId == id )
                .OrderByDescending(a => a.Result).FirstOrDefault();
            return dataUserAnswer;
        }

        public UserAnswerDto SendAfterCheckingTheAnswer(UserAnswerDto userAnswerDto, QuestionDto questionDto, UserExamDto userExamDto, string RightAnswer)
        {
            var data = new UserAnswerDto()
            {
                QuestionId = questionDto.Id,
                UserExamId = userExamDto.Id,
                Result = 0,
                SelectedAnswer = questionDto.RightAnswer,
                IsCorrect = false
            };


            if (RightAnswer == questionDto.RightAnswer)
            {

                if (userAnswerDto == null)
                    data.Result = 1;
                else
                    data.Result += userAnswerDto.Result + 1;


                data.SelectedAnswer = questionDto.RightAnswer;
                data.IsCorrect = true;
            }

            return data;
        }
   
        public int ResultFromUserAnswer(Guid id)
        {
           int res= GetAll()
                .Where(a => a.UserExamId == id && a.CurrentState==1)
                .OrderByDescending(a => a.Result).FirstOrDefault()!.Result;
            return res;
        }
    
    
    }
}
