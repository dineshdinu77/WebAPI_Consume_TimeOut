using System.ComponentModel.DataAnnotations;

namespace MoviesService.Models
{
    public class Movie
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int MovieId { get; set; }

        [Required]
        public string MovieName { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public DateTime Created { get; set; } = DateTime.Now;


    }
}
