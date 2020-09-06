using ByteBank.Agencias.DAL;
using System;
using System.Windows.Controls;

namespace ByteBank.Agencias
{
    public class AgenciasListBox : ListBox
    {
        private readonly MainWindow _janelaMae;

        public AgenciasListBox(MainWindow janelaMae)
        {
            _janelaMae = janelaMae ?? throw new ArgumentNullException(nameof(janelaMae));
        }

        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);

            var agenciaSelecionada = (Agencia)SelectedItem;

            _janelaMae.txtNumero.Text = agenciaSelecionada.Numero;
            _janelaMae.txtNome.Text = agenciaSelecionada.Nome;
            _janelaMae.txtTelefone.Text = agenciaSelecionada.Telefone;
            _janelaMae.txtEndereco.Text = agenciaSelecionada.Descricao;
            _janelaMae.txtDescricao.Text = agenciaSelecionada.Descricao;

        }
    }
}
