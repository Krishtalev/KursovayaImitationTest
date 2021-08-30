using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imitation
{
    interface IDistributionFunction
    {
        static private double gamma_d(double d)
        {
            double r = 2.71 / (2.71 + d);
            double n1;
            double n2;
            Random rnd = new Random();
            do
            {
                double a1 = rnd.NextDouble();
                double a2 = rnd.NextDouble();
                if (a1 <= r)
                {
                    n1 = Math.Pow((a1 / r), (1 / d));
                    n2 = a2 * Math.Pow(n1, (d - 1));
                }
                else
                {
                    n1 = 1 - Math.Log((a1 - r) / (1 - r));
                    n2 = a2 * Math.Pow(2.71, -n1);
                }
            } while (n2 > Math.Pow(n1, (d - 1)) * Math.Pow(2.71, -n1));
            return n1;
        }
        static public double fun1(double alpha, double beta)
        {
            int i = (int)alpha;
            double d = alpha - i;
            double e = 0;
            if (d > 0)
            {
                e = gamma_d(d);
            }

            double ans = 0;
            Random rnd = new Random();
            double b = 0;
            for (int j = 0; j < i; j++)
            {
                b = rnd.NextDouble();
                ans -= Math.Log(b);
            }
            return ((ans + e) / beta);
        }
    }
}
