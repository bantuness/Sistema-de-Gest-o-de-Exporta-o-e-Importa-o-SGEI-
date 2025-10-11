using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SGEI_App.Models;







namespace SGEI_App


{



    public partial class Form1 : Form
    {


        private readonly SGEIContext db = new SGEIContext();

        public Form1()
        {
            InitializeComponent();
        }

        private void ListarClientes()
        {
            dgvClientes.DataSource = db.CLIENTES.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void lblCnpj_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                var novoCliente = new Cliente
                {
                    NOME = txtNome.Text,
                    CNPJ_CPF = txtCnpj.Text,
                    PAIS = txtPais.Text,
                };

                db.CLIENTES.Add(novoCliente);
                db.SaveChanges();

                MessageBox.Show("Cliente adicionado com sucesso!");

                // 👇 APENAS limpa os campos para cadastrar outro
                txtNome.Text = "";
                txtCnpj.Text = "";
                txtPais.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }

        }


        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            ListarClientes();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow != null)
            {
                int id = (int)dgvClientes.CurrentRow.Cells["Id_Cliente"].Value;
                var cliente = db.CLIENTES.Find(id);

                cliente.NOME = txtNome.Text;
                cliente.CNPJ_CPF = txtCnpj.Text;
                cliente.PAIS = txtPais.Text;

                db.SaveChanges();
                MessageBox.Show("Cliente atualizado!");
                ListarClientes();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow != null)
            {
                int id = (int)dgvClientes.CurrentRow.Cells["Id_Cliente"].Value;
                var cliente = db.CLIENTES.Find(id);

                db.CLIENTES.Remove(cliente);
                db.SaveChanges();
                MessageBox.Show("Cliente excluído!");
                ListarClientes();
            }
        }
    }
}
