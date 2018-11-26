using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesForProgrammers.models
{
    /// <summary>
    /// CRUD Functionality for jokes
    /// </summary>
    public class JokeDb
    {
        /// <summary>
        /// retrieves all active jokes
        /// </summary>
        /// <param name="_db"></param>
        /// <returns></returns>
        public static async Task<List<Joke>> GetAllJokes(JokeDBContext _db)
        {
            return await _db.Jokes.ToListAsync();
        }

        /// <summary>
        /// Get all Jokes by category
        /// </summary>
        /// <param name="_db"> db context</param>
        /// <param name="category">the exact category name</param>
        /// <returns></returns>
        public static List<Joke> GetAllJokesByCategory(JokeDBContext _db, string category)
        {
            return (from j in _db.Jokes where j.Category == category select j).ToList();
        }

        public static void AddJoke(JokeDBContext db, Joke newData)
        {
            db.Jokes.Add(newData);
            db.SaveChanges();
        }

        public static void UpdateJoke(JokeDBContext db, int jokeId, string text, string category)
        {
            throw new NotImplementedException();
        }

        public static void DeleteJoke(JokeDBContext db, int jokeId)
        {
            Joke j = db.Jokes.Find(jokeId); //find joke and start tracking.
            db.Jokes.Remove(j); // marks tracked joke as deleted.
            db.SaveChanges(); //sends delete to the DB.
        }

        public static bool DoesExist(JokeDBContext db, int id)
        {
            return db.Jokes.Where(j => j.JokeId == id).Any();
        }
    }
}
