using DineInsights.Core;
using DineInsights.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DineInsights.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        public Restaurant Restaurant { get; set; }
        public DeleteModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantID)
        {
            Restaurant = restaurantData.GetRestaurantById(restaurantID);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost(int restaurantID)
        {
            Restaurant = restaurantData.DeleteRestaurant(restaurantID);
            restaurantData.Commit();
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"{Restaurant.Name} deleted successfully";
            return RedirectToPage("./List");
        }
    }
}
