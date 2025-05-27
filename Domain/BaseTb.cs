namespace Domain
{
	public class BaseTb
	{
		public Guid Id { get; set; }

		public Guid? UpdatedBy { get; set; }

		public int CurrentState { get; set; }

		public DateTime CreatedDate { get; set; }

		public Guid CreatedBy { get; set; }

		public DateTime? UpdatedDate { get; set; }

	}
}
