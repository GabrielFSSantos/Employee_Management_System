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
    public partial class Form1 : Form
    {
        Data dados = new Data();
        DataTable gestores;
        DataTable instrutores;
        bool gestor;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                dados.Setup();
            }catch (Exception ex) { }

            gestores = dados.getAll("GESTOR");
            instrutores = dados.getAll("INSTRUTOR");
            comboBox1.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (gestor)
            {
                var cargoGestor = gestores.AsEnumerable().Select(r => r.Field<string>("Cargo")).ToList();
                if (cargoGestor[comboBox1.SelectedIndex] == "Administrador") //Restrição #2
                {
                    Form2 form2 = new Form2(comboBox1.SelectedIndex);
                    form2.Show();
                }
                else
                {
                    MessageBox.Show("Empregado não é Administrator.");
                }
            }
            else
            {
                Form3 form3 = new Form3(comboBox1.SelectedIndex);
                form3.Show();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            gestor = true;
            carregarLogin();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            gestor = false;
            carregarLogin();
        }
        private void carregarLogin()
        {
            var nomeGestores = gestores.AsEnumerable().Select(r => r.Field<string>("Nome")).ToList();
            var nomeInstrutores = instrutores.AsEnumerable().Select(r => r.Field<string>("Nome")).ToList();
            comboBox1.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = false;
            button4.Visible = false;
            Form1.ActiveForm.BackColor = Color.White;
            comboBox1.Items.Clear();
            if (gestor)
            {
                foreach (var gestor in nomeGestores)
                {
                    comboBox1.Items.Add(gestor);
                }
            }
            else
            {
                foreach (var instrutor in nomeInstrutores)
                {
                    comboBox1.Items.Add(instrutor);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = true;
            button4.Visible = true;
            Form1.ActiveForm.BackColor = Color.FromArgb(35, 12, 65);
        }
    }
}
