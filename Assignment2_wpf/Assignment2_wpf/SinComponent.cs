using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_wpf
{
    internal class SinComponent
    {
        //static method that returns a double and takes in a double.
        //This static method returns Sin(2*theta).

        static public double calculateSin(double theta)
        {
            return Math.Sin(2*theta);
        }

    }
}
