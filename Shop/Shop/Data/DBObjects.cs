using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;

namespace Shop.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            
            if (!content.Category.Any()) 
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }
            if (!content.Car.Any())
            {
                content.AddRange(
                    new Car
                    {
                        name = "Tesla model S",
                        shortDesc = "Fast car",
                        longDesc = "With the lowest drag coefficient on Earth and unmatched efficiency, Model S is built for speed and range. Together with a wider body and chassis, these elements help you go down the straight or around corners quicker than ever.",
                        img = "/img/teslas.jpg",
                        //img = "https://tesla-cdn.thron.com/delivery/public/thumbnail/tesla/2b585eac-984d-4ca3-8cc5-31d437f695fd/bvlatuR/std/1540x866/modelsplaid-1?lcid=2b084dd2-ade1-49ec-a470-45363112146c&v=33&dpr=525", 
                        price = 45000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Electric cars"]
                    },
                    new Car
                    {
                        name = "Ford Fiesta",
                        shortDesc = "Quite and calm",
                        longDesc = "Car for city life",
                        img = "/img/fordfiesta.jpg",
                        //img = "https://www.winnerauto.ua/uploads/gallery_photo/photo/0298/16.jpg?v2",
                        price = 11000,
                        isFavourite = false,
                        available = true,
                        Category = Categories["Classic cars"]
                    },
                    new Car
                    {
                        name = "BMW M3",
                        shortDesc = "Bold and stylish",
                        longDesc = "Сonvenient, fast car for the city",
                        img = "/img/bmw-m3.jpg",
                        //img = "https://www.tipcars.eu/bmw-m3/coupe/petrol/bmw-m3-4-0i-v8-309kw-manual-25294599.html?bez-reklam&photo-gallery=2",
                        price = 60000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Classic cars"]
                    },
                    new Car
                    {
                        name = "Mercedes C class",
                        shortDesc = "Comfortable and large",
                        longDesc = "For those who love convenience",
                        img = "/img/c-class.jpeg",
                        //img = "https://www.tipcars.eu/bmw-m3/coupe/petrol/bmw-m3-4-0i-v8-309kw-manual-25294599.html?bez-reklam&photo-gallery=2",
                        price = 65000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Classic cars"]
                    }
                    );
            }

            content.SaveChanges();
        }

        private static Dictionary<string, Category> category; 
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category() {categoryName = "Electric cars", desc = "A new kind of cars"},
                        new Category() {categoryName = "Classic cars", desc = "Cars with an internal combustion engine"}
                    };
                    category = new Dictionary<string, Category>();
                    foreach (var el in list)
                    {
                        category.Add(el.categoryName,el);
                    }
                }

                return category;
            }
        }
    }
}
