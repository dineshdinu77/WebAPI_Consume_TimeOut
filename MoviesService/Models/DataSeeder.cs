namespace MoviesService.Models
{
    public class DataSeeder
    {
        public static void Initialize(MoviesContext context)
        {
            // Look for any movies.
            if (context.Movies.Any())
            {
                return;   // DB has been seeded
            }

            var movies = new Movie[]
            {
            new Movie { MovieId = 1, MovieName = "Inception", Description = "A thief, who steals corporate secrets through use of dream-sharing technology, is given the inverse task of planting an idea into the mind of a CEO.", Created = DateTime.Parse("2010-07-16") },
            new Movie { MovieId = 2, MovieName = "The Matrix", Description = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", Created = DateTime.Parse("1999-03-31") },
            new Movie { MovieId = 3, MovieName = "Interstellar", Description = "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.", Created = DateTime.Parse("2014-11-07") }
            };

            foreach (Movie m in movies)
            {
                context.Movies.Add(m);
            }
            context.SaveChanges();
        }
    }
}
