using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabalho_ESII.Code;

namespace Trabalho_ESII
{
    public partial class Form4 : Form
    {
        Data dados = new Data();
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var table = dados.runSQL(textBox1.Text);
            dataGridView1.DataSource = table;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
