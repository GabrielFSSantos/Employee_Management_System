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
    public partial class Form2 : Form
    {
        Data dados = new Data();
        DataTable empregados;
        private int gestorID;
        public Form2(int gestorID)
        {
            InitializeComponent();
            this.gestorID = gestorID;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            empregados = dados.getAll("EMPREGADO");
            var nomeEmpregados = empregados.AsEnumerable().Select(r => r.Field<string>("Nome")).ToList();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dados.insertEmpregado(tbNome.Text, tbEndereco.Text, tbTelefone.Text, cbCargo.SelectedItem.ToString(),gestorID);
            Form5 form5 = new Form5();
            form5.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            empregados = dados.getAll("EMPREGADO");
            dataGridView1.DataSource = empregados;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dados.deleteRow(Convert.ToInt16(row.Cells["CódigoE"].Value), "EMPREGADO");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
            Form.ActiveForm.Show();
            //Form1 form1 = new Form1();
            //form1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
            Form7 form7 = new Form7();
            form7.Show();
        }
    }
}
