using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_wpf.Functions
{
    internal interface IFunc
    {
        // interface called IFunc
        // has an abstract method called func
        // func returns a double value and takes in a double value
        double func(double value);
    }
}
