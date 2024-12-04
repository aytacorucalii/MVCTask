using System;

namespace MediClub.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int DoctorId { get; set; } 
        public int PatientId { get; set; } 
        public DateTime AppointmentDate { get; set; } 
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; } 
        public bool IsActive { get; set; } 
    }
}
