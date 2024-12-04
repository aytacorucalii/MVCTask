using MediClub.Models;

namespace MediClub.MVC.Models;

public class Doctor
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Surname { get; set; }
        public string Finkod { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }
        public int Specialization { get; set; }
    public ICollection<Appointment>? Appointments { get; set; }
	public ICollection<HospitalDoctor>? HospitalDoctors { get; set; }
}

