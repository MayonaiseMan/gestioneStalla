using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Gestione_Stalla
{
    /// <summary>
    /// Logica di interazione per NuovoAnimale.xaml
    /// </summary>
    public partial class NuovoAnimale : Window
    {
        MainWindow main;
        public NuovoAnimale(MainWindow m)
        {
            InitializeComponent();
            razze_cmb.ItemsSource = Enum.GetValues(typeof(Animale.Razze));
            main = m;
        }

        private void ok_btn_Click(object sender, RoutedEventArgs e)
        {
            string nome = null;
            DateTime time;
            Animale.Razze razza;

            try
            {
                if (!string.IsNullOrEmpty(nome_txt.Text))
                    nome = nome_txt.Text;

                time = DateTime.Parse(nascita_txt.Text);

                if (razze_cmb.SelectedItem != null)
                    razza =(Animale.Razze) razze_cmb.SelectedItem;

                main.AddAnimale(new Animale(nome, razza, time));
                

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                
                
            }

            this.Close();
        }
    }
}
