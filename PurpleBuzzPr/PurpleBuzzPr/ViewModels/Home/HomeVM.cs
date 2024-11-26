using PurpleBuzzPr.Models;
using PurpleBuzzPr.Areas.Admin;

namespace PurpleBuzzPr.ViewModels.Home
{
    public class HomeVM
    {
        public IEnumerable<Service> Services { get; set; }
        public IEnumerable<Work> Works { get; set; }
    }
}
