namespace MediClub.MVC.Models
{
	public class HospitalDoctor
	{
			public int HospitalId { get; set; }
			public Hospital? Hospital { get; set; }

			public int DoctorId { get; set; }
			public Doctor? Doctor { get; set; }
		

	}
}
