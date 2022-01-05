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
using System.Data;
using System.Data.SqlClient;

namespace Penzugyi_tanacsado
{
    /// <summary>
    /// Interaction logic for Új_találkozó_felvétele.xaml
    /// </summary>
    public partial class Új_találkozó_felvétele : Window
    {
        SqlConnection connection = new SqlConnection(@"Data Source=HERNADI;Initial Catalog=tanacsado;Integrated Security=True");

        public List<tanacsado> tanacsadoNeve { get; set; }
        public List<ugyfel> ugyfelNeve { get; set; }

        public Új_találkozó_felvétele()
        {
            InitializeComponent();
            Bindc();
            Bindu();
        }

        private void Bindu()
        {
            tanacsadoEntities3 ugyfel_neve = new tanacsadoEntities3();
            var item = ugyfel_neve.ugyfel.ToList();
            ugyfelNeve = item;
            DataContext = ugyfelNeve;
        }

        private void Bindc()
        {
            tanacsadoEntities2 tanacsado_neve = new tanacsadoEntities2();
            var item = tanacsado_neve.tanacsado.ToList();
            tanacsadoNeve = item;
            DataContext = tanacsadoNeve;

        }

        private void Felvetel(object sender, RoutedEventArgs e)
        {

        }

        private void Megse(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
