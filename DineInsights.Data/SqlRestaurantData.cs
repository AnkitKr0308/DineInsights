using DineInsights.Core;
using Microsoft.EntityFrameworkCore;

namespace DineInsights.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly DineInsightsDbContext db;

        public SqlRestaurantData(DineInsightsDbContext db)
        {
            this.db = db;
        }
        public Restaurant AddNewRestaurant(Restaurant newRestaurant)
        {
            db.Restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restaurant DeleteRestaurant(int Id)
        {
            var restaurant = GetRestaurantById(Id);
            if (restaurant != null)
            {
                db.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public Restaurant GetRestaurantById(int id)
        {
            return db.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var restaurant = from r in db.Restaurants
                             where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                             orderby name
                             select r;
            return restaurant;
        }

        public Restaurant UpdateRestaurant(Restaurant updatedRestaurant)
        {
            var entity = db.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
