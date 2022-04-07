using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Utils.Exceptions;

namespace Entities.Models
{
    public class Store : IEnumerable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        List<Game> games { get; set; }

        public Store()
        {
            games = new List<Game>();
        }
        public void AddGame(Game game)
        {
            if (games.Exists(g => g.Name != game.Name && g.IsDeleted == true))
            {
                games.Add(game);
            }

            throw new AlreadyExistsException("bu oyun var");
        }

        public Game GetGameById(int? id)
        {
            return games.Find(g => g.Id == id && g.IsDeleted == false);

        }

        public void RemoveGameById(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }

            Game gameRemov = games.Find(g => g.Id == id && g.IsDeleted == false);

            if (gameRemov == null)
            {
                throw new NotFoundException("bele oyu  yoxdur");
            }
            gameRemov.IsDeleted = true;


        }

        public List<Game> FilterGamesByPrice(int min, int max)
        {
            if (!games.Exists(g => g.Price > min && g.Price < max))
            {
                throw new NotFoundException("Bu araliqda oyun yoxdu");

            }

            return games.FindAll(g => g.Price > min && g.Price < max);
        }

        public List<Game> FilterGamesByDiscountedPrice(double min, double max)
        {
            if (!games.Exists(g => g.GetDisCountedPrice(min) > min && g.GetDisCountedPrice(max) < max))
            {
                throw new NotFoundException("Bu araliqda oyun yoxdu");
            }
            
            return games.FindAll(g => g.Price > min && g.Price < max);
        }


        public IEnumerator GetEnumerator()
        {
            foreach (var item in games)
            {
                yield return item;
            }
        }


        public void Sort()
        {
            
            int n = games.Count;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (games[j].Price > games[j + 1].Price)
                    {
                        Game temp = games[j];
                        games[j] = games[j + 1];
                        games[j + 1] = temp;
                    }
        }

    }
}
