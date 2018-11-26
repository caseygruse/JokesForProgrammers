using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesForProgrammers.models
{
    public class JokeDBContext : DbContext
    {
        public JokeDBContext(DbContextOptions options)
            : base(options)
        {

        }

        public virtual DbSet<Joke> Jokes { get; set; }
    }
}
