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
    public partial class Form3 : Form
    {
        public double[] alpha;
        public double[] beta;
        public double N;

        public Form3(int n, ref double[] a, ref double[] b)
        {
            InitializeComponent();
            dataGridView1.RowCount = 2;
            dataGridView1.ColumnCount = n;
            dataGridView2.RowCount = 2;
            dataGridView2.ColumnCount = n;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView2.AllowUserToResizeColumns = false;
            dataGridView2.AllowUserToResizeRows = false;
            dataGridView2.AllowUserToAddRows = false;
            alpha = a;
            beta = b;
            N = n;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //validation
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var r = dataGridView1.Rows[0];
            for (int i = 0; i < N; i++)
            {
                alpha[i] = Convert.ToDouble(r.Cells[i].Value.ToString());
                beta[i] = Convert.ToDouble(r.Cells[i].Value.ToString());
            }
            this.Close();
        }
    }
}
