using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JokesForProgrammers.models
{
    /// <summary>
    /// represents a single programming joke
    /// </summary>
    public class Joke
    {
        [Key]
        public int JokeId { get; set; }
        /// <summary>
        /// the actual text of the joke
        /// </summary>
        [Required]
        public string JokeText { get; set; }
        /// <summary>
        /// Category of joke ex. programming, database
        /// </summary>
        public string Category { get; set; }

    }
}
