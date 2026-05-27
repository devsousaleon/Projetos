using Database_Books.ControlUser;
using Microsoft.EntityFrameworkCore;
using PdfiumViewer;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Database_Books.Forms
{
    public partial class VisualizadorPDF : Form
    {
        private readonly TelaLivros _telaLivros;
        string _caminhoArquivo = Path.Combine("C:\\SoftBooks\\TempPDF", "ArquivoPDF_Temp.pdf");

        public VisualizadorPDF(TelaLivros telaLivros)
        {
            InitializeComponent();
            this._telaLivros = telaLivros;
        }

        async void VisualizadorPDF_Load(object sender, EventArgs e)
        {            
            if (!Directory.Exists("C:\\SoftBooks\\TempPDF"))
                Directory.CreateDirectory("C:\\SoftBooks\\TempPDF");

            try
            {
                using (var _context = new DataDbContext())
                {
                    var BuscaIdCadastro = await _context.LeituraLivros
                        .Where(x => x.Id == _telaLivros.IdSelecionado)
                        .Select(x => x.CadastroLivroId)
                        .FirstOrDefaultAsync();

                    var CarregarVisualizadorPDF = await _context.ArquivosPDF
                        .Include(l => l.CadastroLivro)
                        .FirstOrDefaultAsync(x => x.CadastroLivroId == BuscaIdCadastro);

                    if (CarregarVisualizadorPDF != null)
                    {
                        byte[] pdfBytes = CarregarVisualizadorPDF.ConteudoPDF;

                        if (pdfBytes != null)
                        {
                            _caminhoArquivo = Path.Combine(_caminhoArquivo);

                            File.WriteAllBytes(_caminhoArquivo, pdfBytes);

                            var pdfviewer = new PdfViewer
                            {
                                Dock = DockStyle.Fill,
                                Document = PdfDocument.Load(_caminhoArquivo)
                            };

                            panelVisualizaPDF.Controls.Clear();
                            panelVisualizaPDF.Controls.Add(pdfviewer);
                        }                        
                    }
                    else
                    {
                        MessageBox.Show("PDF não encontrado no banco.");
                        this.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado ao tentar carregar o PDF! \n" + ex, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void VisualizadorPDF_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (Control control in panelVisualizaPDF.Controls)
            {
                if (control is PdfiumViewer.PdfViewer viewer)
                {
                    viewer.Document.Dispose();
                    viewer.Dispose();
                }
            }
            panelVisualizaPDF.Controls.Clear();

            if (!string.IsNullOrEmpty(_caminhoArquivo)
                && File.Exists(_caminhoArquivo))
            {
                File.Delete(_caminhoArquivo);
            }
        }
    }
}