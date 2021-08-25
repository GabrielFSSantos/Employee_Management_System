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
    public partial class Form3 : Form
    {
        Data dados = new Data();
        private int instrutorID;

        public Form3(int instrutorID)
        {
            InitializeComponent();
            this.instrutorID = instrutorID;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DataTable turmas = dados.getAll("TURMA");
            DataTable empregados = dados.getAll("EMPREGADO");
            var nomeEmpregados = empregados.AsEnumerable().Select(r => r.Field<string>("Nome")).ToList();
            foreach (var empregado in nomeEmpregados)
            {
                comboBox1.Items.Add(empregado);
            }

            var nomeTurmas = turmas.AsEnumerable().Select(r => r.Field<int>("CódigoT")).ToList();
            foreach (var turma in nomeTurmas)
            {
                comboBox2.Items.Add(turma);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dados.insertMatricula(comboBox1.SelectedIndex + 1, int.Parse(comboBox2.SelectedItem.ToString()));
            dataGridView1.DataSource = dados.getMatricula();
            Form5 form5 = new Form5();
            form5.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
            Form4 form4 = new Form4();
            form4.Show();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Nome_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
            Form.ActiveForm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
            Form6 form6 = new Form6();
            form6.Show();
        }
    }
}
