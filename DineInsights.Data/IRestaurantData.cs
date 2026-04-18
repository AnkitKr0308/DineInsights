using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DineInsights.Core;

namespace DineInsights.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetRestaurantById(int id);
        Restaurant UpdateRestaurant(Restaurant updatedRestaurant);
        Restaurant AddNewRestaurant(Restaurant newRestaurant);
        Restaurant DeleteRestaurant(int Id);
        int Commit();
    }
}
