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
    public partial class FormExportacoes : Form
    {
        private readonly SGEIContext db = new SGEIContext();
        public FormExportacoes()
        {
            InitializeComponent();
        }

        private void ListarExportacoes()
        {
            dgvExportacoes.DataSource = db.EXPORTACOES.ToList();
        }

        private void FormExportacoes_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                var novoExportacao = new Exportacoes
                {
                    DATA_EXPORTACAO = DateTime.Parse(textData.Text),
                    PORTO_DESTINO = textPorto.Text,
                    SITUACAO = textSituacao.Text,
                    TIPO = textTipo.Text,
                };

                db.EXPORTACOES.Add(novoExportacao);
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

        private void btnListar_Click(object sender, EventArgs e)
        {
            ListarExportacoes();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvExportacoes.CurrentRow != null)
            {
                int id = (int)dgvExportacoes.CurrentRow.Cells["Id_Exportcao"].Value;
                var exportacao = db.EXPORTACOES.Find(id);

                db.EXPORTACOES.Remove(exportacao);
                db.SaveChanges();
                MessageBox.Show("Exportacao excluído!");
                ListarExportacoes();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvExportacoes.CurrentRow != null)
            {
                int id = (int)dgvExportacoes.CurrentRow.Cells["Id_Exportacao"].Value;
                var exportacao = db.EXPORTACOES.Find(id);

                exportacao.DATA_EXPORTACAO = DateTime.Parse(textData.Text);
                exportacao.PORTO_DESTINO = textPorto.Text;
                exportacao.SITUACAO = textSituacao.Text;
                exportacao.TIPO = textTipo.Text;

                db.SaveChanges();
                MessageBox.Show("Exportação atualizado!");
                ListarExportacoes();
            }
        }
    }
}
