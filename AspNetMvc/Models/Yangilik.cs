using System.ComponentModel.DataAnnotations;

namespace AspNetMvc.Models
{
    public class Yangilik
    {
        public int Id { get; set; }

        [MinLength(5), MaxLength(255)]
        public string Title { get; set; }

        public string Description { get; set; }

        public IFormFile Image { get; set; }

    }
}
