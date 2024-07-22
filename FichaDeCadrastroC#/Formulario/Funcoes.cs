using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Windows.Forms;

namespace Formulario
{
    class Funcoes
    {
        public static void MsgErro(string Msg) 
        {
            MessageBox.Show(Msg, "teste pq sim ",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error);
        }
        public static void MsgAlerta(string Msg)
        {
            MessageBox.Show(Msg, "teste pq sim ",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Warning);
        }
        public static void MsgOK(string Msg)
        {
            MessageBox.Show(Msg, "teste pq sim ",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information);
        }
        public static bool Pergunta(string Msg)
        {
            if(MessageBox.Show(Msg, "teste pq sim ",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question) == DialogResult.Yes);
                  return true;
            
        }
        public static void PriMaiuscula(Control ctr)
        {
            TextInfo textIfo = new CultureInfo("pt-BR", false).TextInfo;
            
            string t = ctr.Text;
            t = t.Replace(" Das ", "das")
                .Replace(" Da ", "da")
                .Replace(" Do ", "do")
                .Replace(" Dos ", "do")
                .Replace(" De ", "de");
            ctr.Text = t;
            if (ctr is TextBox txt)
            {
                txt.SelectionStart = txt.Text.Length;
            }
           else if(ctr is ComboBox cb)
            {
                cb.SelectionStart = cb.Text.Length;
            }
        }
    }
}
