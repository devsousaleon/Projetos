using Database_Books.ControlUser;
using System;
using System.Windows.Forms;

namespace Database_Books
{
    public partial class ScreenBook : Form
    {
        private readonly FormLogin _loginForm;

        public ScreenBook(FormLogin loginForm)
        {
            InitializeComponent();
            this._loginForm = loginForm;
        }

        public void CarregarTela(UserControl novaTela)
        {
            panelTelas.Controls.Clear();
            novaTela.Dock = DockStyle.Fill;
            panelTelas.Controls.Add(novaTela);
        }

        #region Buttons_LoadScreen
        void btnHome_Click(object sender, EventArgs e)
        {
            CarregarTela(new TelaInicial(this._loginForm));
        }
        void btnCadastrarLivro_Click(object sender, EventArgs e)
        {
            CarregarTela(new TelaCadastroLivro(this));
        }
        void btnLivros_Click(object sender, EventArgs e)
        {
            CarregarTela(new TelaLivros(this));
        }
        void btnUsuarios_Click(object sender, EventArgs e)
        {
            CarregarTela(new TelaUsuarios());
        }
        void btnSobre_Click(object sender, EventArgs e)
        {
            CarregarTela(new TelaSobre());
        }
        #endregion

        void ScreenBook_Load(object sender, EventArgs e)
        {
            CarregarTela(new TelaInicial(this._loginForm));
        }
        void btnRelatorios_Click(object sender, EventArgs e)
        {
            CarregarTela(new TelaRelatorios());
        }

        void ScreenBook_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }        
    }
}