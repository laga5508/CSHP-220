using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloWorld.Models
{
       
    class Program
    {
        static void Main(string[] args)
        {
            #region exercise
            //var autos = new List<Auto>();
            //autos.Add(new Auto { Name = "SUV", MaxSpeed = 101, Price = 2000 });
            //autos.Add(new Auto { Name = "Sedan", MaxSpeed = 120, Price = 1000 });
            //autos.Add(new Auto { Name = "Coupe", MaxSpeed = 110, Price = 3000 });

            //// TBD: Fix the lowest price auto
            //Auto auto = autos.OrderBy(p => p.Price).FirstOrDefault();

            //Console.WriteLine("Lowest Price: Name={0} Price={1}", auto.Name, auto.Price);
            //Auto fastestAuto = autos.OrderByDescending(p => p.MaxSpeed).FirstOrDefault();

            //// TBD: Fix the fastest auto
            //Console.WriteLine("Fastest Speed: Name={0} Speed={1}", fastestAuto.Name, fastestAuto.MaxSpeed);

            //Console.ReadLine();
            #endregion

            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });

            var helloPasswordUsers = users.Where(x => x.Password == "hello");

            foreach (var user in helloPasswordUsers)
            {
                Console.WriteLine($"{user.Name} is using hello as a password");
            }
            Console.WriteLine("-----------------------------------------------------------");
            users.RemoveAll(x => x.Name.ToLower() == x.Password);

            foreach (var user in users)
            {
                Console.WriteLine($"User: {user.Name}, Password: {user.Password}");
            }
            Console.WriteLine("-----------------------------------------------------------");
            users.Remove(users.Where(x => x.Password == "hello").FirstOrDefault());

            foreach (var user in users)
            {
                Console.WriteLine($"User: {user.Name}, Password: {user.Password}");
            }



            Console.ReadLine();
        }
    }
}