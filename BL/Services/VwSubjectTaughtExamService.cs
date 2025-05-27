using AutoMapper;
using BL.Contracts;
using BL.Dtos;
using BL.Services.BaseSer;
using DAL.Contracts;
using Domain.Entities;


namespace BL.Services
{
	public class VwSubjectTaughtExamService : VwBaseService<VwSubjectTaughtExam,VwSubjectTaughtExamDto> ,IVwSubjectTaughtExam
	{
        public VwSubjectTaughtExamService(IVwRepository<VwSubjectTaughtExam> repository, IMapper mapper) : base (repository, mapper)
        {
            
        }
    }
}
