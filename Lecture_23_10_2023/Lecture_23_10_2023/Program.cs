using Lecture_23_10_2023.DB;
using Lecture_23_10_2023.DB.Services;
using Lecture_23_10_2023.DB.Services.Base;
using Lecture_23_10_2023.UI;
using Lecture_23_10_2023.UI.Base;
using System;
using System.Collections.Generic;

namespace Lecture_23_10_2023
{

    class Main
    {
        public List<IUserInterface> Setup()
        {
            DbContext context = new DbContext();
            return new List<IUserInterface>
            {
                new GroupInfoUI(context),
                new ShowAllStudentsUI(context),
                new AddStudentUI(context)
            };
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            EventTest eventTest = new EventTest();
            User user1 = new User() { Name = "User1", Age=10 };
            User user2 = new User() { Name = "User2", Age=15 };
            eventTest.Subsribe(user1);
            eventTest.Subsribe(user2);
            eventTest.Ping();
            Console.WriteLine();
            eventTest.AddAge(4);
            eventTest.Ping();
            Console.WriteLine();
            Car car = new Car() { Name = "Car1", Speed = 123 };
            eventTest.Subsribe(car);

            user2.Name = "User9999";
            User user3 = new User() { Name = "User3", Age=20 };
            eventTest.Subsribe(user3);


            eventTest.Ping();
            Console.WriteLine();
            eventTest.AddAge(100);
            eventTest.Ping();



            //var uis = new Main().Setup();
            //while (true)
            //{
            //    for (int i = 0; i < uis.Count; i++)
            //    {
            //        Console.WriteLine($"{i+1}. {uis[i].Show()}");
            //    }
            //    var key = Console.ReadLine();
            //    if (key == "q")
            //        return;
            //    int actionIndex;
            //    var isInt = int.TryParse(key, out actionIndex);
            //    if (isInt == true && actionIndex <= uis.Count && actionIndex > 0)
            //        Console.WriteLine(uis[actionIndex - 1].Action());
            //    else
            //        Console.WriteLine($"Invalid value. Can`t parse {key}. Values must be in range [1:{uis.Count}].");
            //}

        }
    }
}
