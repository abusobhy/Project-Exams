using BL.Contracts.BaseCon;
using BL.Dtos;
using Domain.Entities;


namespace BL.Contracts
{
	public interface IQuestion : IBaseService<TbQuestion,QuestionDto>
	{
        public QuestionDto QuestionNow(Guid examId, int order);

        public QuestionDto GetNextQuestionId(Guid examId, int order);



    }
}
