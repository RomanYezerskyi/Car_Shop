using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.interfaces;
using Shop.Data.Models;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class CarsController: Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategoryies;

        public CarsController(IAllCars iAllCars, ICarsCategory iCarsCat)
        {
            _allCars = iAllCars;
            _allCategoryies = iCarsCat;
        }

        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Car> cars = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                cars = _allCars.Cars.OrderBy(i => i.id);
            }
            else
            {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Electric cars")).OrderBy(i => i.id);
                    currCategory = "Electric cars";
                }
                else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Classic cars")).OrderBy(i => i.id);
                    currCategory = "Classic cars";
                }

            }
           
            var carObj = new CarsListViewModel
            {
                AllCars = cars,
                carCategory = currCategory
            };
            ViewBag.Title = "Page with cars";
            return View(carObj);
        }

    }
}
