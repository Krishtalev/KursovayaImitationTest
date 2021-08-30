using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imitation
{

    class Resource: IDistributionFunction
    {
        double[] alpha;
        double[] beta;
        public Resource(double[] a, double[] b)
        {
            alpha = a;
            beta = b;
        }

        private Func<double,double,double>[] G = { IDistributionFunction.fun1, IDistributionFunction.fun1 , IDistributionFunction.fun1 };    
        public double calculateVolume(int state)
        {
            Random rnd = new Random();
            double a = rnd.NextDouble();
            return G[state].Invoke(alpha[state],beta[state]);
        }
    }
}
