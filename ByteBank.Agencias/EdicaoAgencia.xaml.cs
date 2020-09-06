using ByteBank.Agencias.DAL;
using System;
using System.Windows;

namespace ByteBank.Agencias
{
    /// <summary>
    /// Interaction logic for EdicaoAgencia.xaml
    /// </summary>
    public partial class EdicaoAgencia : Window
    {
        private readonly Agencia _agencia;

        public EdicaoAgencia(Agencia agencia)
        {
            InitializeComponent();

            _agencia = agencia ?? throw new ArgumentNullException(nameof(agencia));
            AtualizarCamposDeTexto();
            AtualizarControles();
        }

        private void AtualizarCamposDeTexto()
        {
            txtNumero.Text = _agencia.Numero;
            txtNome.Text = _agencia.Nome;
            txtTelefone.Text = _agencia.Telefone;
            txtEndereco.Text = _agencia.Endereco;
            txtDescricao.Text = _agencia.Descricao;
        }

        private void AtualizarControles()
        {
            btnOk.Click += new RoutedEventHandler(btnOk_Click);
            btnCancelar.Click += new RoutedEventHandler(btnCancelar_Click);

            btnOk.Click += new RoutedEventHandler(Fechar);
            btnCancelar.Click += new RoutedEventHandler(Fechar);
        }

        private void btnOk_Click(object sender, EventArgs e) =>
            DialogResult = true;

        private void btnCancelar_Click(object sender, EventArgs e) =>
            DialogResult = false;

        private void Fechar(object sender, EventArgs e) =>
            Close();
    }
}
