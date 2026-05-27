using Database_Books.ControlUser;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Database_Books.Forms
{
    public partial class RelatorioLivro : Form
    {
        private readonly TelaRelatorios _telaRelatorios;

        public RelatorioLivro(TelaRelatorios telaRelatorios)
        {
            InitializeComponent();
            this._telaRelatorios = telaRelatorios;
        }

        void CarregarRelatorioLivro(string QuerySql, string QueryConnection)
        {
            DataTable RelLivro = new DataTable();
            SqlDataAdapter Adapter = new SqlDataAdapter(QuerySql, QueryConnection);
            Adapter.Fill(RelLivro);

            GridViewRelatorioLivro.Rows.Clear();

            foreach (DataRow linha in RelLivro.Rows)
            {
                GridViewRelatorioLivro.Rows.Add(linha.ItemArray);
            }
        }

        void RelatorioLivro_Load(object sender, EventArgs e)
        {
            string status = _telaRelatorios.Status;
            string formato = _telaRelatorios.Formato;
            string datainicioleitura_1 = _telaRelatorios.DataInicio_1;
            string datainicioleitura_2 = _telaRelatorios.DataInicio_2;
            string datafimleitura_1 = _telaRelatorios.DataFim_1;
            string datafimleitura_2 = _telaRelatorios.DataFim_2;
            string dataemprestimo_1 = _telaRelatorios._DataEmprestimo_1;
            string dataemprestimo_2 = _telaRelatorios._DataEmprestimo_2;
            string datadevolucao_1 = _telaRelatorios._DataDevolucao_1;
            string datadevolucao_2 = _telaRelatorios._DataDevolucao_2;

            if (!_telaRelatorios.CheckBoxEmprestado)
            {
                GridViewRelatorioLivro.Columns.Remove(PessoaEmprestimo);
                GridViewRelatorioLivro.Columns.Remove(DataEmprestimo);
                GridViewRelatorioLivro.Columns.Remove(DataDevolucao);

                if (!string.IsNullOrWhiteSpace(status) && status != "Todos")
                {
                    ComandosSQL.RelLivro += $" and L.StatusLeitura = '{status}'";
                }

                if (!string.IsNullOrWhiteSpace(formato) && formato != "Todos")
                {
                    ComandosSQL.RelLivro += $" and C.Formato = '{formato}'";
                }

                if (_telaRelatorios.DataInicioLeitura_Format_Atual)
                {
                    ComandosSQL.RelLivro += $" and L.DataInicioLeitura between '{datainicioleitura_1}' and '{datainicioleitura_2}' ";
                }

                if (_telaRelatorios.DataFimLeitura_Format_Atual)
                {
                    ComandosSQL.RelLivro += $" and L.DataFimLeitura between '{datafimleitura_1}' and '{datafimleitura_2}' ";
                }

                CarregarRelatorioLivro(ComandosSQL.RelLivro, ComandosSQL.StrConnection);
                ComandosSQL.RelLivro = ComandosSQL.RelLivroBackup;
            }
            else
            {
                GridViewRelatorioLivro.Columns.Remove(UsuarioLeitor);
                GridViewRelatorioLivro.Columns.Remove(DataInicioLeitura);
                GridViewRelatorioLivro.Columns.Remove(DataFimLeitura);

                if (_telaRelatorios.DataEmprestimo_Format_Atual)
                {
                    ComandosSQL.RelLivroEmprestimo += $" and E.DataEmprestimo between '{dataemprestimo_1}' and '{dataemprestimo_2}'";
                }

                if (_telaRelatorios.DataDevolucao_Format_Atual)
                {
                    ComandosSQL.RelLivroEmprestimo += $" and E.DataDevolucao between '{datadevolucao_1}' and '{datadevolucao_2}'";
                }

                CarregarRelatorioLivro(ComandosSQL.RelLivroEmprestimo, ComandosSQL.StrConnection);
                ComandosSQL.RelLivroEmprestimo = ComandosSQL.RelLivroEmprestimoBackup;
            }
        }
        public void ExportarPanelEDataGridParaPDF(DataGridView dgv)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "PDF file |*.pdf";
                dlg.Title = "Salvar relatório completo";
                dlg.FileName = "relatorio_completo.pdf";

                if (dlg.ShowDialog() != DialogResult.OK) return;

                
                Document doc = new Document(PageSize.A4.Rotate(), 20, 20, 20, 20);
                PdfWriter.GetInstance(doc, new FileStream(dlg.FileName, FileMode.Create));
                doc.Open();

                
                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                iTextSharp.text.Font fTitulo = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font fData = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.ITALIC);
                iTextSharp.text.Font fTabela = new iTextSharp.text.Font(bf, 10);

                
                Paragraph titulo = new Paragraph("Relatório teste de sistema", fTitulo) { Alignment = Element.ALIGN_CENTER };
                Paragraph data = new Paragraph("Gerado em: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fData) { Alignment = Element.ALIGN_CENTER };
                doc.Add(titulo);
                doc.Add(data);
                doc.Add(new Paragraph("\n"));

                
                PdfPTable tabela = new PdfPTable(dgv.ColumnCount) { WidthPercentage = 100f };
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    PdfPCell header = new PdfPCell(new Phrase(col.HeaderText, fTabela))
                    {
                        BackgroundColor = new BaseColor(220, 220, 220),
                        HorizontalAlignment = Element.ALIGN_CENTER
                    };
                    tabela.AddCell(header);
                }

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        tabela.AddCell(new Phrase(cell.Value?.ToString() ?? "", fTabela));
                    }
                }
                doc.Add(tabela);

                doc.Close();
                MessageBox.Show("PDF completo gerado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void btnSalvarPDF_Click(object sender, EventArgs e)
        {
            ExportarPanelEDataGridParaPDF(GridViewRelatorioLivro);
        }
    }
}