using AutoMapper;
using BL.Dtos;
using Domain.Entities;


namespace MySolution.BL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TbExam,ExamDto>().ReverseMap();
            CreateMap<TbQuestion,QuestionDto>().ReverseMap();
            CreateMap<TbSubjectsTaught,SubjectsTaughtDto>().ReverseMap();
            CreateMap<TbUserAnswer,UserAnswerDto>().ReverseMap();
            CreateMap<TbUserExam,UserExamDto>().ReverseMap();
            CreateMap<VwSEQuestion,VwSEQuestionDto>().ReverseMap();
            CreateMap<VwSubjectTaughtExam,VwSubjectTaughtExamDto>().ReverseMap();
            
        }
    }
}
