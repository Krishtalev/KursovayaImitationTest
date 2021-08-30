using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Imitation
{
    public partial class Form1 : Form
    {
        int n = 0;
        public double[] Lambda;
        public double[] Lambda1;
        public double[] Mu;
        public double[] Mu1;
        public double[][] Q;
        public double[][] Q1;
        public double[] alpha;
        public double[] alpha1;
        public double[] beta;
        public double[] beta1;
        
        public Form1()
        {
            InitializeComponent();
        }
           

        private void button2_Click(object sender, EventArgs e)
        {
            int N = (int)numericUpDown2.Value;
            int N2 = (int)numericUpDown2.Value;
            double step = 0.1;
            double step2 = 0.1;
            double max = 50;
            double max2 = 50;
            Model mm = new Model(step, max, N, Q, Lambda, Mu, alpha, beta);
            Model mm2 = new Model(step2, max2, N2, Q1, Lambda1, Mu1, alpha1, beta1);
            mm.simulate(6000000);
            mm2.simulate(6000000);
            double Kolmogorov_distance = 0;
            for (int i = 0; i < mm2.Statistic.Length; i++)
            {
                double dis = Math.Abs(mm.Statistic[i] - mm2.Statistic[i]);
                if (Kolmogorov_distance < dis) Kolmogorov_distance = dis;
            }
            label7.Text = Kolmogorov_distance.ToString();
            // Model mm = new Model(0.1, 50, 4, 3);
            // mm.simulate(2000000);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            n = (int)numericUpDown1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Q = new double[n][];
            Q1 = new double[n][];
            for (int i = 0; i < n; i++)
            {
                Q[i] = new double[n];
                Q1[i] = new double[n];
            }
            Form2 form2 = new Form2(n, ref Q);
            form2.ShowDialog();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Q1[i][j] = Q[i][j];
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) button3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Lambda = new double[n];
            Lambda1 = new double[n];
            Form4 form4 = new Form4(n, ref Lambda);
            form4.ShowDialog();
            for (int j = 0; j < n; j++)
            {
                Lambda1[j] = Lambda[j];
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) button4.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            alpha = new double[n];
            alpha1 = new double[n];
            beta = new double[n];
            beta1 = new double[n];
            Form3 form3 = new Form3(n, ref alpha, ref beta);
            form3.ShowDialog();
            for (int j = 0; j < n; j++)
            {
                alpha1[j] = alpha[j];
                beta1[j] = beta[j];
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) button5.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Mu = new double[n];
            Mu1 = new double[n];
            Form4 form4 = new Form4(n, ref Mu);
            form4.ShowDialog();
            for (int j = 0; j < n; j++)
            {
                Mu1[j] = Mu[j]; 
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int N = (int)numericUpDown2.Value;
            double step = 0.1;
            double max = 50;
            Model mm = new Model(step, max, N, Q, Lambda, Mu, alpha, beta);
            mm.simulate(500000);
            Model mm2 = new Model(step, max, N, Q, Lambda, Mu, alpha, beta);
            mm2.simulate(500000);
            double Kolmogorov_distance = 0;
            for (int i = 0; i < mm2.Statistic.Length; i++)
            {               
                double dis = Math.Abs(mm.Statistic[i] - mm2.Statistic[i]);
                if (Kolmogorov_distance < dis) Kolmogorov_distance = dis;
            }
            label7.Text = Kolmogorov_distance.ToString();
        }
    }
}
