namespace MediClub.MVC.Areas.Admin.DTOs;
public class CreateDoctorDTOs
{
    public string? Name { get; set; }
    public string Surname { get; set; }
    public string Finkod { get; set; }
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string Username => Name+" "+Surname;
    public bool IsActive { get; set; }
    public int Specialization { get; set; }
    public List<int>? HospitalIds { get; set; }
}
