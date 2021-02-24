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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gestione_Stalla
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Stalla stalla;
        public MainWindow()
        {
            InitializeComponent();
            stalla = new Stalla();
            razze_cmb.ItemsSource = Enum.GetValues(typeof(Animale.Razze));
            razze_cmb.SelectedItem = Animale.Razze.Null;

        }


        public void  AddAnimale(Animale a)
        {
            stalla.CompraCapo(a);
            AggiornaLista();
        }

        private void compra_btn_Click(object sender, RoutedEventArgs e)
        {
            NuovoAnimale nuovo = new NuovoAnimale(this);
            nuovo.Show();
            
        }

        private void vendi_btn_Click(object sender, RoutedEventArgs e)
        {
            int mesi;
            bool b = int.TryParse(mesi_txt.Text, out mesi);
            
            if(!b)
            {
                MessageBox.Show("valore mesi non valido");
            }
            else
            {
                List<Animale> animaliVenduti = stalla.VendiAnimaliMesi(mesi);
                AggiornaLista();
                string s = "";
                foreach (Animale a in stalla.Animali)
                {
                  
                    s += a.ToString() + "\n";                    
                }
                MessageBox.Show(s);
            }


        }

        private void stampa_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(razze_cmb.SelectedItem != null)
                    StampaRazza((Animale.Razze)razze_cmb.SelectedItem);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AggiornaLista()
        {
            animali_lst.Items.Clear();
            animali_lst.ItemsSource = stalla.Animali;
        }

        public void StampaRazza(Animale.Razze razza)
        {
            string s = "";
            foreach(Animale a in stalla.Animali)
            {
                if(a.Razza == razza)
                {
                    s += a.ToString() + "\n";
                }
            }
            MessageBox.Show(s);
        }
    }
}
