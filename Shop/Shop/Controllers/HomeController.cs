using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.interfaces;
using Shop.Data.Models;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class HomeController: Controller
    {
        private  IAllCars _carRep;

        public HomeController(IAllCars carRep)
        {
            _carRep = carRep;
        }

        public ViewResult Index()
        {
            //var homeCars = new HomeViewModel
            //{
            //    favCars = _carRep.GetFavCars
            //};
            //return View(homeCars);
            ViewBag.Title = "Page with cars";
            HomeViewModel obj = new HomeViewModel();
            obj.favCars = _carRep.GetFavCars;
            return View(obj);

        } 
    }
}
