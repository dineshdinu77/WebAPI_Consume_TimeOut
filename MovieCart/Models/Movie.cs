namespace MovieCart.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string? Description { get; set; }
        public DateTime Created { get; set; }
    }
}
