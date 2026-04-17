using DineInsights.Core;
using DineInsights.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DineInsights.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;
        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }
        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? restaurantID)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            if (restaurantID.HasValue)
            {
                Restaurant = restaurantData.GetRestaurantById(restaurantID.Value);
            }
            else
            {
                Restaurant = new Restaurant();
            }
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            
            if (!ModelState.IsValid)
            {
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }
            if (Restaurant.ID > 0)
            {
                restaurantData.UpdateRestaurant(Restaurant);
                TempData["Message"] = $"Restaurant {Restaurant.Name} updated";
            }
            else
            {
                restaurantData.AddNewRestaurant(Restaurant);
                TempData["Message"] = $"Restaurant {Restaurant.Name} created";
            }
            restaurantData.Commit();
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.ID });
        }
    }
}
