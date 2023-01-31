using Biblioteka_project_2.Models;

namespace Biblioteka_project_2.ViewModels
{
    public class BookViewModel
    {
        public IQueryable<Book> Books { get; set; }

        public string TitleSortOrder { get; set; }
        public string CategorySortOrder { get; set; }
        public string AuthorSortOrder { get; set; }



    }
}
