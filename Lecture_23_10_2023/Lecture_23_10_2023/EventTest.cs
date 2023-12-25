using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023
{
    public delegate void Notify();
    public delegate void AddYear(int years);
    class EventTest
    {
        public event Notify PingUsers;
        public event AddYear AddYearsEvent;
        public void Subsribe(User user)
        {
            PingUsers += user.Ping;
            AddYearsEvent += user.AddAge;
        }
        public void Subsribe(Car car)
        {
            PingUsers += car.Ping;
            AddYearsEvent += car.AddSpeed;
        }
        public void Ping()
        {
            PingUsers?.Invoke();
        }
        public void AddAge(int years)
        {
            AddYearsEvent?.Invoke(years);
        }

    }
    class Car
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public void Ping()
        {
            Console.WriteLine($"This is car: {Name}. Age: {Speed}");
        }
        public void AddSpeed(int speed)
        {
            Speed += speed;
        }
    }
    class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public void Ping()
        {
            Console.WriteLine($"Hello from {Name}. Age: {Age}");
        }
        public void AddAge(int years)
        {
            Age += years;
        }
    }
 
}
