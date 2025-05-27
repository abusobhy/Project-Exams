using AutoMapper;
using BL.Contracts;
using BL.Contracts.UserSevice;
using BL.Dtos;
using BL.Services.BaseSer;
using DAL.Contracts;
using Domain.Entities;

namespace BL.Services
{
	public class QuestionService : BaseService<TbQuestion, QuestionDto>, IQuestion
	{
		
        public QuestionService(ITbRepository<TbQuestion> repository, IMapper mapper, IUserService userService) : base(repository, mapper, userService)
        {
            
        }


        public QuestionDto QuestionNow(Guid examId, int order)
        {


            var Question = GetAll().Where(a => a.ExamId == examId && a.QuestionOrder == order)
                                .ToList().OrderBy(q => q.QuestionOrder)
                                .FirstOrDefault();


            //var questions = allQuestions.FirstOrDefault(q => q.Id == id);

            return Question;
        }

        public QuestionDto GetNextQuestionId(Guid examId, int order)
        {

            var NextQuestions = GetAll().Where(a => a.ExamId == examId && a.QuestionOrder > order)
                                        .ToList().OrderBy(q => q.QuestionOrder)
                                        .FirstOrDefault();



            return NextQuestions;
        }

    }
}
