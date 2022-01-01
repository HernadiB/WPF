using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using static Penzugyi_tanacsado.Model.MainWindowViewModel;

namespace Penzugyi_tanacsado
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connection = new SqlConnection(@"Data Source=HERNADI;Initial Catalog=tanacsado;Integrated Security=True");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void megjelenit_Click(object sender, RoutedEventArgs e)
        {
            //Megjelenit(AllData(OpenConnection()));
        }

        private void exportAll_Click(object sender, RoutedEventArgs e)
        {
            //ExportAllData(AllData(OpenConnection()));
        }

        //private void szures_Click(object sender, RoutedEventArgs e)
        //{
        //    Megjelenit(FilteredData());
        //}

        private void Ujadat_Click(object sender, RoutedEventArgs e)
        {
            SecoundWindow secondWindow = new SecoundWindow();
            secondWindow.Show();
        }
        public void Megjelenit(List<Values> data)
        {
            dataGrid1.ItemsSource = data;
            dataGrid1.Visibility = Visibility.Visible;
        }
        //public List<Values> FilteredData() //Javítani: Ha üresek a valuek, dobjon messaget
        //{
        //    string nev = t_nev.Text;
        //    int also = int.Parse(also_ar.Text);
        //    int felso = int.Parse(felso_ar.Text);
        //    //List<Values> lista = Filter(AllData(OpenConnection()), nev, also, felso);
        //    //return lista;
        //}
    }
}
