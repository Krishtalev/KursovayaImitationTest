using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Imitation
{
    class Model
    {
        private double current_time;
        private int current_state;

        public double[] Statistic;
        private int events;
        private double width_border;
        private double max_border;
        private int max_bin;

        private MarkovianChain randomEnvironment;
        private ArrivalProcess arrivalProcess;
        private Service service;

        public Model(double width, double max_value, int N, double[][] Q, double[] Lambda, double[] Mu, double[] alpha, double[] beta)
        {
            randomEnvironment = new MarkovianChain(Q,N);
            arrivalProcess = new ArrivalProcess(Lambda,N);
            Resource rs = new Resource(alpha,beta);
            service = new Service(Mu,rs);

            current_state = randomEnvironment.get_state();
            current_time = 0;
            events = 0;
            width_border = width;
            max_border = max_value;
            max_bin = (int)(max_border / width_border) + 1;
            Statistic = new double[max_bin+1];

            randomEnvironment.nextState(current_time);
            arrivalProcess.calculateTime(current_time,current_state);
        }

        public void simulate(int max)
        {
            while (events < max)
            {
                events++;
                double ts = randomEnvironment.get_ts();
                double ta = arrivalProcess.get_ta();
                double tl = service.findNearest();
                double min_time = Math.Min(ts, Math.Min(ta, tl));

                double dt = min_time - current_time;
                double v = service.calculateVolume();
                if (v == 0)
                {
                    Statistic[0] += dt;
                }
                else
                {
                    int id = (int)(v / width_border) + 1;
                    if (id > max_bin) id = max_bin;
                    Statistic[id] += dt;
                }

                current_time = min_time;
                if (min_time == ts)
                {
                    randomEnvironment.nextState(current_time);
                    current_state = randomEnvironment.get_state();
                    arrivalProcess.calculateTime(current_time, current_state);
                    service.on_state_shift(current_state, current_time);
                }
                if (min_time == ta)
                {
                    service.addRequest(current_state, current_time);
                    arrivalProcess.calculateTime(current_time, current_state);
                }
                if (min_time == tl) service.serveRequest();
            } 
            for (int i = 1; i < Statistic.Length; i++)
            {
                Statistic[i] += Statistic[i - 1]; 
            }
            for (int i = 0; i < Statistic.Length; i++)
            {
                Statistic[i] /= current_time;
            }
            
            exportStatistic();
        }
        private void exportStatistic()
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workBook;
            Excel.Worksheet workSheet;
            workBook = excelApp.Workbooks.Add();
            workSheet = (Excel.Worksheet)workBook.Worksheets.get_Item(1);
           
            for (int j = 1; j <= Statistic.Length; j++)
            {
                workSheet.Cells[j, 1] = (j-1)*width_border;
                workSheet.Cells[j, 2] = Statistic[j - 1];
                           
            }
            excelApp.Visible = true;
            excelApp.UserControl = true;
        }
        //public int get_i()
        //{
        //    return service.calculate_requests();
        //}
        //public double get_v()
        //{
        //    return service.calculateVolume();
        //}
    }
}
