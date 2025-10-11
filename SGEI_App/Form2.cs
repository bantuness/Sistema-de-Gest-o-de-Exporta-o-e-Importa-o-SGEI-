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
    public partial class Form2 : Form
    {

        private readonly SGEIContext db = new SGEIContext();
        public Form2()
        {
            InitializeComponent();
        }

        private void ListarProdutos()
        {
            dgvProdutos.DataSource = db.PRODUTOS.ToList();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ListarProdutos();
        }

        private void dgvProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.CurrentRow != null)
            {
                int id = (int)dgvProdutos.CurrentRow.Cells["Id_Produtos"].Value;
                var produtos = db.PRODUTOS.Find(id);

                db.PRODUTOS.Remove(produtos);
                db.SaveChanges();
                MessageBox.Show("Cliente excluído!");
                ListarProdutos();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.CurrentRow != null)
            {
                int id = (int)dgvProdutos.CurrentRow.Cells["Id_Produtos"].Value;
                var produtos = db.PRODUTOS.Find(id);

                produtos.DESCRICAO = textDesc.Text;
                produtos.CATEGORIA = textCate.Text;
                produtos.PESO = decimal.Parse(textPeso.Text);
                produtos.VALORUNITARIO = decimal.Parse(textValor.Text);

                db.SaveChanges();
                MessageBox.Show("Produto atualizado!");
                ListarProdutos();
            }
        }

        private void textDesc_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                var novoProduto = new Produtos
                {
                    DESCRICAO = textDesc.Text,
                    CATEGORIA = textCate.Text,
                    PESO = decimal.Parse(textPeso.Text),
                    VALORUNITARIO = decimal.Parse(textValor.Text),
                };

                db.PRODUTOS.Add(novoProduto);
                db.SaveChanges();

                MessageBox.Show("Produto adicionado com sucesso!");

                // 👇 APENAS limpa os campos para cadastrar outro
                textDesc.Text = "";
                textCate.Text = "";
                textPeso.Text = "";
                textValor.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }
    }
}
