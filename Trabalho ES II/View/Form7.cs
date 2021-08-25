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
    public partial class Form7 : Form
    {
        Data dados = new Data();
        DataTable matriculas;
        public Form7()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            var empregados = dados.getAll("EMPREGADO");
            var codEmpregados = empregados.AsEnumerable().Select(r => r.Field<string>("Nome")).ToList();
            cbNome.Items.Clear();
            foreach (var empregado in codEmpregados)
            {
                cbNome.Items.Add(empregado);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var empregado = cbNome.SelectedItem.ToString();
            DataTable dt = dados.getEmpregado(empregado);
            dataGridView1.DataSource = dt;
        }
    }
}
