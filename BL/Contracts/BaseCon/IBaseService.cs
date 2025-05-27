namespace BL.Contracts.BaseCon
{
	public interface IBaseService<T, DTO>
	{

		List<DTO> GetAll();
		DTO GetById(Guid id);
		
		bool Add(DTO entity, Guid userId);
		
		bool Update(DTO entity, Guid userId);
		
		bool ChangeStatus(Guid id, int status);
	}
}
