using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace Biblioteka_project_2.Models
{
    public class CategoryViewModel
    {
        [DisplayName("Category")]
        public string CategoryId { get; set; }
        public List<SelectListItem> ListOfCategories { get; set; }
    }
}
