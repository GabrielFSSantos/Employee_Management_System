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
    public partial class Form6 : Form
    {
        Data dados = new Data();
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            var turmas = dados.getAll("TURMA");
            var codigoTurmas = turmas.AsEnumerable().Select(r => r.Field<int>("CódigoT")).ToList();
            foreach (var turma in codigoTurmas)
            {
                comboBox2.Items.Add(turma);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int turma = int.Parse(comboBox2.SelectedItem.ToString());
            DataTable dt = dados.getAlunos(turma);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
            Form4 form4 = new Form4();
            form4.Show();
        }
    }
}
