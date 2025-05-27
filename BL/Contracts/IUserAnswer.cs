using BL.Contracts.BaseCon;
using BL.Dtos;
using Domain.Entities;


namespace BL.Contracts
{
	public interface IUserAnswer : IBaseService<TbUserAnswer, UserAnswerDto>
	{
        public UserAnswerDto OneUserAnswerDto(Guid id);
        public UserAnswerDto SendAfterCheckingTheAnswer(UserAnswerDto userAnswerDto, QuestionDto questionDto, UserExamDto userExamDto, string RightAnswer);

        public int ResultFromUserAnswer(Guid id);
    }
}
