using SGEI_App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGEI_App
{
    public partial class FormImportacoes : Form
    {
        private readonly SGEIContext db = new SGEIContext();
        public FormImportacoes()
        {
            InitializeComponent();
        }

        private void ListarImportacoes()
        {
            dgvImportacoes.DataSource = db.IMPORTACOES.ToList();
        }

        private void FormImportacoes_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ListarImportacoes();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                var novoImportacao = new Importacoes
                {

                    DATA_IMPORTACAO = DateTime.Parse(textData.Text),
                    PORTO_ORIGEM = textPorto.Text,
                    SITUACAO = textSituacao.Text,
                    TIPO = textTipo.Text,
                };

                db.IMPORTACOES.Add(novoImportacao);
                db.SaveChanges();

                MessageBox.Show("Registro adicionado!");


                // 👇 APENAS limpa os campos para cadastrar outro
                textData.Text = "";
                textPorto.Text = "";
                textSituacao.Text = "";
                textTipo.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvImportacoes.CurrentRow != null)
            {
                int id = (int)dgvImportacoes.CurrentRow.Cells["Id_Importacao"].Value;
                var importacao = db.IMPORTACOES.Find(id);

                importacao.DATA_IMPORTACAO = DateTime.Parse(textData.Text);
                importacao.PORTO_ORIGEM = textPorto.Text;
                importacao.SITUACAO = textSituacao.Text;
                importacao.TIPO = textTipo.Text;

                db.SaveChanges();
                MessageBox.Show("Importação atualizado!");
                ListarImportacoes();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvImportacoes.CurrentRow != null)
            {
                int id = (int)dgvImportacoes.CurrentRow.Cells["Id_Importacao"].Value;
                var importacao = db.IMPORTACOES.Find(id);

                db.IMPORTACOES.Remove(importacao);
                db.SaveChanges();
                MessageBox.Show("Importacao excluído!");
                ListarImportacoes();
            }
        }
    }
}
