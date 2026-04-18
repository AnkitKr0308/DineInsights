using DineInsights.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DineInsights.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{ID=1, Name="Scott's Pizza", Location="Maryland", Cuisine=CuisineType.Italian},
                new Restaurant{ID=2, Name="Cinnamon Club", Location="London", Cuisine=CuisineType.Indian},
                new Restaurant{ID=3, Name="La Costa", Location="California", Cuisine=CuisineType.Mexican}
            };
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant GetRestaurantById(int id)
        {
            return restaurants.SingleOrDefault(r => r.ID == id);
        }

        public Restaurant UpdateRestaurant(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.ID == updatedRestaurant.ID);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }

        public Restaurant AddNewRestaurant(Restaurant newRestaurant)
        {
            newRestaurant.ID = restaurants.Max(r => r.ID) + 1;
            restaurants.Add(newRestaurant);
            return newRestaurant;
        }
        public Restaurant DeleteRestaurant(int Id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.ID == Id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }
        public int Commit()
        {
            return 0;
        }
    }
}
