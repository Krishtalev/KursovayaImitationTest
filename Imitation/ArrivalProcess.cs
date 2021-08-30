using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imitation
{
    class ArrivalProcess
    {
        double[] Lambda;
        double arrival_time;
        public ArrivalProcess(double[] l, int N)
        {
            Lambda = l; //new double[] { 0.5, 1.0, 2.0};
            for (int i = 0; i < l.Length; i++)
            {
                Lambda[i] *= N;
            }
            arrival_time = 1000;
        }
        public double get_ta()
        {
            return arrival_time;
        }

        public void calculateTime(double t, int s)
        {
            Random rnd = new Random();
            double a = rnd.NextDouble();
            arrival_time = t - Math.Log(a)/Lambda[s];
        }
    }
}
