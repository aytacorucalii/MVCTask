namespace MediClub.MVC.Models
{
	public class Hospital
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string? Address { get; set; }


		public ICollection<HospitalDoctor>? HospitalDoctors { get; set; }
	}

}