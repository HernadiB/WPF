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
        SqlCommand comTanacsado = new SqlCommand();
        SqlCommand comUgyfel = new SqlCommand();
        SqlCommand comTalalkozo = new SqlCommand();

        public List<tanacsado> tanacsadoNeve { get; set; }
        public List<ugyfel> ugyfelNeve { get; set; }

        public Új_találkozó_felvétele()
        {
            InitializeComponent();
            Bindt();
            Bindu();
        }
        private void Bindt()
        {
            tanacsadoEntities4 tanacsadoneve = new tanacsadoEntities4();
            var item = tanacsadoneve.tanacsado.ToList();
            tanacsadoNeve = item;
            DataContext = tanacsadoNeve;

        }

        private void Bindu()
        {
            tanacsadoEntities3 ugyfelneve = new tanacsadoEntities3();
            var item = ugyfelneve.ugyfel.ToList();
            ugyfelNeve = item;
            DataContext = ugyfelNeve;
        }

        private void Felvetel(object sender, RoutedEventArgs e)
        {
            comTanacsado.Connection = connection;
            comUgyfel.Connection = connection;
            comTalalkozo.Connection = connection;

            connection.Open();

            comTanacsado.CommandText = @"INSERT INTO tanacsado (nev) VALUES (@tnev)";
            comTanacsado.Parameters.AddWithValue("@tnev", Tanacsado_neve.SelectedValue);
            comTanacsado.ExecuteNonQuery();

            comUgyfel.CommandText = @"INSERT INTO ugyfel (nev) VALUES (@unev)";
            comUgyfel.Parameters.AddWithValue("@unev", Ugyfel_neve.SelectedValue);
            comUgyfel.ExecuteNonQuery();

            comTalalkozo.CommandText = @"INSERT INTO talalkozo (datum, idopont, idotartam) VALUES (@datum, @idopont, @idotartam)";
            comTalalkozo.Parameters.AddWithValue("@datum", Talalkozo_datuma.SelectedDate);
            comTalalkozo.Parameters.AddWithValue("@idopont", Talalkozo_ideje.Text);
            comTalalkozo.Parameters.AddWithValue("@idotartam", Convert.ToInt32(Talalkozo_idotartama.Text));
            comTalalkozo.ExecuteNonQuery();

            connection.Close();

            MessageBox.Show("Az adatok sikeresen elmentve!");
            this.Close();
        }

        private void Megse(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
