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
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace Penzugyi_tanacsado
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connection = new SqlConnection(@"Data Source=HERNADI;Initial Catalog=tanacsado;Integrated Security=True");

        public List<szakterulet> megnevezes { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Bindc();
        }

        private void Bindc()
        {
            tanacsadoEntities tanacs = new tanacsadoEntities();
            var item = tanacs.szakterulet.ToList();
            megnevezes = item;
            DataContext = megnevezes;
        }

        private void FelvetelClick(object sender, RoutedEventArgs e)
        {
            Új_találkozó_felvétele ujTalalkozo = new Új_találkozó_felvétele();
            ujTalalkozo.ShowDialog();
        }

        private void Bezaras(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
