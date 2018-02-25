using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
    public abstract class Figure 
    {
        protected  bool IsValidParams (params double[] arr)
        {
            return arr.All(x => x>0) ? true :false;
        }

        public abstract double Area();       
    }


    public sealed class Circle : Figure
    {
        double radius;
       public double Radius
        {
            get => radius;
            set {
                if (value>0)
                    radius = value;
                else
                    throw new FormatException();
            }
        }
         
        public Circle (double rad)
        {
            Radius = rad;       
        }

        public override double Area()
        {
            return Math.PI * radius * radius;
        }
    }

    public sealed class Triangle : Figure
    {
        public double Cathetus1 { get; private set; }
        public double Cathetus2 { get; private set; }
        public double Hypotenuse { get; private set; }

        public Triangle(double h, double c1, double c2)
        {
            if (IsValidParams(h, c1, c2) &&
                (Math.Pow(h, 2) == Math.Pow(c1, 2) + Math.Pow(c2, 2)))
            {
                Hypotenuse = h;
                Cathetus1 = c1;
                Cathetus2 = c2;
            }
            else
                throw new FormatException();
        }

        public override double Area()
        {
            return 0.5*Cathetus1*Cathetus2;
        }  
    }
}
