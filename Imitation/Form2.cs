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
    public partial class Form2 : Form
    {
        public double[][] m;
        public double N;
       
        public Form2(int n, ref double[][] a)
        {
            InitializeComponent();
            dataGridView1.RowCount = n + 1;
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
            for (int i = 0; i < N; i++)
            {
                var r = dataGridView1.Rows[i];
                for (int j = 0; j < N; j++)
                {
                    m[i][j] = Convert.ToDouble(r.Cells[j].Value.ToString());
                }
            }
            this.Close();
        }
    }
}
