using Database_Books.Forms;
using System;
using System.Windows.Forms;

namespace Database_Books.ControlUser
{
    public partial class TelaRelatorios : UserControl
    {
        public bool DataInicioLeitura_Format_Atual = false;
        public bool DataFimLeitura_Format_Atual = false;
        public bool DataEmprestimo_Format_Atual = false;
        public bool DataDevolucao_Format_Atual = false;

        public TelaRelatorios()
        {
            InitializeComponent();
        }
        void TelaRelatorios_Load(object sender, EventArgs e)
        {
            BoxStatus.SelectedIndex = 0;
            BoxFormato.SelectedIndex = 0;
        }

        public bool CheckBoxApresentaValorEmprestimo 
        {
            get { return checkBoxApresentaValorEmprestimo.Checked; }
            private set { checkBoxApresentaValorEmprestimo.Checked = value; }
        }
        public bool CheckBoxApresentaValorLivro
        {
            get { return checkBoxApresentaValorLivro.Checked; }
            private set { checkBoxApresentaValorLivro.Checked = value; }
        }
        public bool CheckBoxEmprestado
        {
            get {return checkBoxEmprestado.Checked; }
            private set {checkBoxEmprestado.Checked = value; }
        }
        public string Status
        {
            get { return BoxStatus.SelectedItem?.ToString(); }
            private set { BoxStatus.SelectedItem = value; }
        }
        public string Formato
        {
            get {return BoxFormato.SelectedItem.ToString();}
            private set {BoxFormato.SelectedItem = value;}
        }

        #region Data de leitura
        public string DataInicio_1
        {
            get { return DataInicioLeitura_1.Value.ToString("dd/MM/yyy"); }
            private set { DataInicioLeitura_1.Text = value; }
        }
        public string DataInicio_2
        {
            get { return DataInicioLeitura_2.Value.ToString("dd/MM/yyy"); }
            private set { DataInicioLeitura_2.Text = value; }
        }
        public string DataFim_1
        {
            get { return DataFimLeitura_1.Value.ToString("dd/MM/yyy"); }
            private set { DataFimLeitura_1.Text = value; }
        }
        public string DataFim_2
        {
            get { return DataFimLeitura_2.Value.ToString("dd/MM/yyy"); }
            private set { DataFimLeitura_2.Text = value; }
        }

        void DataInicioLeitura_1_ValueChanged(object sender, EventArgs e)
        {
            DataInicioLeitura_1.Format = DateTimePickerFormat.Short;
            DataInicioLeitura_Format_Atual = true;
        }
        void DataInicioLeitura_2_ValueChanged(object sender, EventArgs e)
        {
            DataInicioLeitura_2.Format = DateTimePickerFormat.Short;
            DataInicioLeitura_Format_Atual = true;
        }

        void DataFimLeitura_1_ValueChanged(object sender, EventArgs e)
        {
            DataFimLeitura_1.Format = DateTimePickerFormat.Short;
            DataFimLeitura_Format_Atual = true;
        }
        void DataFimLeitura_2_ValueChanged(object sender, EventArgs e)
        {
            DataFimLeitura_2.Format = DateTimePickerFormat.Short;
            DataFimLeitura_Format_Atual = true;
        }
        #endregion

        #region Datas de Emprestimo
        public string _DataEmprestimo_1
        {
            get { return DataEmprestimo_1.Value.ToString("dd/MM/yyy"); }
            private set { DataEmprestimo_1.Text = value; }
        }
        public string _DataEmprestimo_2
        {
            get { return DataEmprestimo_2.Value.ToString("dd/MM/yyy"); }
            private set { DataEmprestimo_2.Text = value; }
        }
        public string _DataDevolucao_1
        {
            get { return DataDevolucao_1.Value.ToString("dd/MM/yyy"); }
            private set { DataDevolucao_1.Text = value; }
        }
        public string _DataDevolucao_2
        {
            get { return DataDevolucao_2.Value.ToString("dd/MM/yyy"); }
            private set { DataDevolucao_2.Text = value; }
        }

        void DataEmprestimo_1_ValueChanged(object sender, EventArgs e)
        {
            DataEmprestimo_1.Format = DateTimePickerFormat.Short;
            DataEmprestimo_Format_Atual = true;
        }
        void DataEmprestimo_2_ValueChanged(object sender, EventArgs e)
        {
            DataEmprestimo_2.Format = DateTimePickerFormat.Short;
            DataEmprestimo_Format_Atual = true;
        }
        void DataDevolucao_1_ValueChanged(object sender, EventArgs e)
        {
            DataDevolucao_1.Format = DateTimePickerFormat.Short;
            DataDevolucao_Format_Atual = true;
        }
        void DataDevolucao_2_ValueChanged(object sender, EventArgs e)
        {
            DataDevolucao_2.Format = DateTimePickerFormat.Short;
            DataDevolucao_Format_Atual = true;
        }

        #endregion

        void btnExibirInfoRelFinanceiro_Click(object sender, EventArgs e)
        {
            if (checkBoxApresentaValorEmprestimo.Checked || checkBoxApresentaValorLivro.Checked)
            {
                RelatorioFinanceiro relatorioFinanceiro = new RelatorioFinanceiro(this);
                relatorioFinanceiro.ShowDialog();
            }
            else { MessageBox.Show("Selecione ao menos uma opção para visualizar o relatório!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
        }

        void btnExibirInfoRelLivro_Click(object sender, EventArgs e)
        {
            RelatorioLivro relatorioLivro = new RelatorioLivro(this);
            relatorioLivro.ShowDialog();
        }

        void checkBoxEmprestado_CheckedChanged(object sender, EventArgs e)
        {
            switch (checkBoxEmprestado.Checked)
            {
                case true:
                    DataEmprestimo_1.Visible = true;
                    DataEmprestimo_2.Visible = true;
                    DataDevolucao_1.Visible = true;
                    DataDevolucao_2.Visible = true;
                    break;
                case false:
                    DataEmprestimo_1.Visible = false;
                    DataEmprestimo_2.Visible = false;
                    DataDevolucao_1.Visible = false;
                    DataDevolucao_2.Visible = false;
                    break;
            }
        }
    }
}