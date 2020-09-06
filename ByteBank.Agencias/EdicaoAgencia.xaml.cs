﻿using ByteBank.Agencias.DAL;
using System;
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

            txtNome.TextChanged += ConstruirDelegateValidacaoCampoNulo(txtNome);
            txtDescricao.TextChanged += ConstruirDelegateValidacaoCampoNulo(txtDescricao);
            txtEndereco.TextChanged += ConstruirDelegateValidacaoCampoNulo(txtEndereco);
            txtNumero.TextChanged += ConstruirDelegateValidacaoCampoNulo(txtNumero);
            txtTelefone.TextChanged += ConstruirDelegateValidacaoCampoNulo(txtTelefone);
        }

        private TextChangedEventHandler ConstruirDelegateValidacaoCampoNulo(TextBox txt)
        {
            return (o, e) =>
            {
                var textoEstaVazio = string.IsNullOrEmpty(txt.Text);

                txt.Background = textoEstaVazio
                    ? new SolidColorBrush(Colors.OrangeRed)
                    : new SolidColorBrush(Colors.White);
            };
        }

        private void Fechar(object sender, EventArgs e) =>
            Close();
    }
}
