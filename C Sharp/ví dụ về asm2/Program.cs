using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ví_dụ_về_asm2
{
    internal class MyCircleClass
    {
        // Procedural (calculate area of circle)
        private static double CalculateArea(double radius)
        {
            return Math.PI * radius * radius;
        }

        // Object-Oriented (Circle object)
        public class Circle
        {
            public double Radius { get; set; }
        }

        // Event Driven (button click event listener)
        private void Calculate_Click(object sender, EventArgs e)
        {
            Circle example = new Circle { Radius = 5 };
            double area = CalculateArea(example.Radius);
            Console.WriteLine($"The area of the circle with radius {example.Radius} is {area}");
        }

        // Main method to simulate the event
        public static void Main()
        {
            MyCircleClass myClass = new MyCircleClass();
            myClass.Calculate_Click(null, null);
        }
    }
}
