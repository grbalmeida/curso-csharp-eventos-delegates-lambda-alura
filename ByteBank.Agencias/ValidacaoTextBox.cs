using System.Windows.Controls;

namespace ByteBank.Agencias
{
    public delegate bool ValidacaoEventHandler(string texto);

    public class ValidacaoTextBox : TextBox
    {
        public event ValidacaoEventHandler Validacao;
    }
}
