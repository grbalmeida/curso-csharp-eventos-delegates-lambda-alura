using ByteBank.Agencias.DAL;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

            ValidarCampoNulo(txtNumero, EventArgs.Empty);
            ValidarSomenteDigito(txtNumero, EventArgs.Empty);

            ValidarCampoNulo(txtNome, EventArgs.Empty);
            ValidarCampoNulo(txtTelefone, EventArgs.Empty);
            ValidarCampoNulo(txtEndereco, EventArgs.Empty);
            ValidarCampoNulo(txtDescricao, EventArgs.Empty);
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
            RoutedEventHandler dialogResultTrue = (o, e) => DialogResult = true;
            RoutedEventHandler dialogResultFalse = (o, e) => DialogResult = false;

            var okEventHandler = dialogResultTrue + Fechar;
            var cancelarEventHandler = dialogResultFalse + Fechar;

            btnOk.Click += okEventHandler;
            btnCancelar.Click += cancelarEventHandler;

            txtNumero.TextChanged += ValidarCampoNulo;
            txtNumero.TextChanged += ValidarSomenteDigito;

            txtNome.TextChanged += ValidarCampoNulo;
            txtDescricao.TextChanged += ValidarCampoNulo;
            txtEndereco.TextChanged += ValidarCampoNulo;
            txtTelefone.TextChanged += ValidarCampoNulo;
        }

        private void ValidarSomenteDigito(object sender, EventArgs e)
        {
            var txt = sender as TextBox;

            var todosCaracteresSaoDigitos = !string.IsNullOrEmpty(txt.Text) && txt.Text.All(char.IsDigit);

            txt.Background = todosCaracteresSaoDigitos
                ? new SolidColorBrush(Colors.White)
                : new SolidColorBrush(Colors.OrangeRed);
        }

        private void ValidarCampoNulo(object sender, EventArgs e)
        {
            var txt = sender as TextBox;
            var textoEstaVazio = string.IsNullOrEmpty(txt.Text);

            txt.Background = textoEstaVazio
                ? new SolidColorBrush(Colors.OrangeRed)
                : new SolidColorBrush(Colors.White);
        }

        private void Fechar(object sender, EventArgs e) =>
            Close();
    }
}
