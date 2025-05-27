using AutoMapper;
using BL.Contracts;
using BL.Dtos;
using BL.Services.BaseSer;
using DAL.Contracts;
using Domain.Entities;


namespace BL.Services
{
	public class VwSEQuestionService : VwBaseService<VwSEQuestion,VwSEQuestionDto> ,IVwSEQuestion
	{
        public VwSEQuestionService(IVwRepository<VwSEQuestion> repository, IMapper mapper) : base (repository, mapper)
        {
            
        }
    }
}
