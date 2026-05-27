using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Database_Books
{
    public partial class TelaInicial: UserControl
    {
        public TelaInicial(FormLogin formLivro)
        {
            InitializeComponent();
            lblOlaUser.Text = "Olá " + formLivro.NomeUsuario + ", o que vamos ler hoje?";
        }

        void TelaInicial_Load(object sender, EventArgs e)
        {
            //INFORMAÇÕES DE LIVROS EM LEITURA

            DataTable InfoInicialLeitura = new DataTable();
            SqlDataAdapter SqlInfoLeitura = new SqlDataAdapter(ComandosSQL.QueryBuscaLivrosLendo, ComandosSQL.StrConnection);
            SqlInfoLeitura.Fill(InfoInicialLeitura);

            GridViewInfoLeitura.Rows.Clear();

            foreach (DataRow linha in InfoInicialLeitura.Rows)
            {
                GridViewInfoLeitura.Rows.Add(linha.ItemArray);
            }

            // INFORMAÇÕES DE EMPRÉSTIMO

            DataTable InfoInicialEmprestimo = new DataTable();
            SqlDataAdapter SqlInfoEmprestimo = new SqlDataAdapter(ComandosSQL.QueryBuscaLivrosEmprestimo, ComandosSQL.StrConnection);
            SqlInfoEmprestimo.Fill(InfoInicialEmprestimo);

            GridViewInfoEmprestimo.Rows.Clear();

            foreach (DataRow linha in InfoInicialEmprestimo.Rows)
            {
                GridViewInfoEmprestimo.Rows.Add(linha.ItemArray);
            }
        }
    }
}