namespace BL.Contracts.BaseCon
{
	public interface IVwBaseService<T, DTO>
	{

		List<DTO> GetAll();
		DTO GetById(Guid id);
	}
}
