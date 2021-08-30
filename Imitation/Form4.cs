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
    public partial class Form4 : Form
    {
        public double[] m;
        public double N;

        public Form4(int n, ref double[] a)
        {
            InitializeComponent();
            dataGridView1.RowCount = 2;
            dataGridView1.ColumnCount = n;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToAddRows = false;
            m = a;
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
                m[i] = Convert.ToDouble(r.Cells[i].Value.ToString());
            }
            this.Close();
        }
    }
}
