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

        public List<szakterulet> megnevezes { get; set; }

        public Új_találkozó_felvétele()
        {
            InitializeComponent();
            Bindc();
        }

        private void Bindc()
        {
            tanacsadoEntities2 tanacs = new tanacsadoEntities2();
            var item = tanacs.szakterulet.ToList();
            megnevezes = item;
            DataContext = megnevezes;
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
