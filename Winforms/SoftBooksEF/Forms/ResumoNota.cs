using Database_Books.ControlUser;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows.Forms;

namespace Database_Books.Forms
{
    public partial class ResumoNota : Form
    {
        private readonly TelaLivros _telaLivros;

        public ResumoNota(TelaLivros telaLivros)
        {
            InitializeComponent();
            this._telaLivros = telaLivros;
        }
        async void ResumoNota_Load(object sender, EventArgs e)
        {
            try
            {
                using (var _context = new DataDbContext())
                {
                    var CarregarResumoNota = await _context.LeituraLivros
                        .FirstOrDefaultAsync( x => x.Id == _telaLivros.IdSelecionado);

                    txtResumoLivro.Text = CarregarResumoNota?.ResumoLivro;
                    txtAnotacaoLivro.Text = CarregarResumoNota?.Anotacao;
                    NotaNivel.Value = CarregarResumoNota?.Nota ?? 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado ao tentar trazer as informações! \n" + ex, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        async void btnSalvarResumoNota_Click(object sender, EventArgs e)
        {
            string ResumoLivro = null;
            string Anotacao = null;

            if (!string.IsNullOrWhiteSpace(txtResumoLivro.Text))
                ResumoLivro = txtResumoLivro.Text;

            if (!string.IsNullOrWhiteSpace(txtAnotacaoLivro.Text))
                Anotacao = txtAnotacaoLivro.Text;

            try
            {
                using (var _context = new DataDbContext())
                {
                    var AtualizaResumoNota = await _context.LeituraLivros
                        .FirstOrDefaultAsync( x => x.Id == _telaLivros.IdSelecionado);

                    AtualizaResumoNota.ResumoLivro = ResumoLivro;
                    AtualizaResumoNota.Anotacao = Anotacao;
                    AtualizaResumoNota.Nota = NotaNivel.Value;

                    _context.Update(AtualizaResumoNota);
                    await _context.SaveChangesAsync(); 
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado ao tentar salvar as informações! \n" + ex, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void btnCancelarResumoNota_Click(object sender, EventArgs e)
        {
            DialogResult Resul = MessageBox.Show("Deseja fechar esta tela sem salvar as alterações?", "Dúvida", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Resul == DialogResult.Yes)
            {
                this.Close();
            }
        }       
    }
}