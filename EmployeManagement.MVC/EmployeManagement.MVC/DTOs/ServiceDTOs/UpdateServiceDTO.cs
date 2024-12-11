namespace EmployeManagement.MVC.DTOs.ServiceDTOs
{
    public class UpdateServiceDTO
    {

        public string Title { get; set; } 
        public string Description { get; set; } 
        public string MainImageUrl { get; set; }
        public IFormFile MainImage { get; set; } 
        public List<IFormFile>? Images { get; set; }
    }
}
