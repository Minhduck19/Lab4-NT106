using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace Bai7
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        public string Language { get; set; }
        public string Sex { get; set; } 
    }

    public class Food
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Price { get; set; }
        public string CreatedBy { get; set; }
        public string Address { get; set; }     
        public string ImageUrl { get; set; }    
        public string Description { get; set; }
    }

    public static class DataProvider
    {
        private const string UserFile = "users.json";
        private const string FoodFile = "foods.json";

        public static User CurrentUser; 

        public static List<User> GetUsers()
        {
            if (!File.Exists(UserFile)) return new List<User>();
            var json = File.ReadAllText(UserFile);
            return JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();
        }

        public static void SaveUser(User u)
        {
            var list = GetUsers();
            list.Add(u);
            File.WriteAllText(UserFile, JsonConvert.SerializeObject(list, Newtonsoft.Json.Formatting.Indented));
        }

        public static List<Food> GetFoods()
        {
            if (!File.Exists(FoodFile)) return new List<Food>();
            var json = File.ReadAllText(FoodFile);
            return JsonConvert.DeserializeObject<List<Food>>(json) ?? new List<Food>();
        }

        public static void AddFood(Food f)
        {
            var list = GetFoods();
            list.Add(f);
            File.WriteAllText(FoodFile, JsonConvert.SerializeObject(list, Newtonsoft.Json.Formatting.Indented));
        }

        public static void DeleteFood(string id)
        {
            var list = GetFoods();
            var item = list.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                list.Remove(item);
                File.WriteAllText(FoodFile, JsonConvert.SerializeObject(list, Newtonsoft.Json.Formatting.Indented));
            }
        }
    }
}