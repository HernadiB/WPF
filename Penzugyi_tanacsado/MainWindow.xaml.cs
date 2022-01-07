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
using Syncfusion.UI.Xaml.Grid.Converter;
using System.Windows.Controls.Primitives;
using System.Diagnostics;
using Syncfusion.XlsIO;
using Excel = Microsoft.Office.Interop.Excel;


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
            tanacsadoEntities2 szak = new tanacsadoEntities2();
            var item = szak.szakterulet.ToList();
            megnevezes = item;
            DataContext = megnevezes;
        }

        public void LoadData()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM AllData ORDER BY SzakterületMegnevezése, TanácsadóNeve, TalálkozóDátuma DESC", connection);
            DataTable dt = new DataTable();
            connection.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            connection.Close();
            datagrid.ItemsSource = dt.DefaultView;
        }

        public void Tanacsadasok_megjelenitese(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void Szures_be(object sender, RoutedEventArgs e)
        {
            int alsoH = (int)Convert.ToInt32(Oradij_also_hatara.Text);
            int felsoH = (int)Convert.ToInt32(Oradij_felso_hatara.Text);
            int kimeneti = 0;
            bool isNumberA = int.TryParse(Oradij_also_hatara.Text, out kimeneti);
            bool isNumberF = int.TryParse(Oradij_felso_hatara.Text, out kimeneti);

            if (!isNumberA || !isNumberF)
            {
                MessageBox.Show("Az óradíj csak szám lehet!");
            }
            else if (alsoH == null || felsoH == null)
            {
                MessageBox.Show("Kérem ellenőrizze az óradíjakat!");
            }
            else
            {
                if (alsoH < felsoH && alsoH % 1000 == 0 && felsoH % 1000 == 0)
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM AllData WHERE (TanácsadóÓradíja BETWEEN {this.Oradij_also_hatara.Text} AND {this.Oradij_felso_hatara.Text}) AND (SzakterületMegnevezése = '{this.szakterulet.SelectedValue}') ORDER BY SzakterületMegnevezése, TanácsadóNeve, TalálkozóDátuma DESC", connection);
                    DataTable dt = new DataTable();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    dt.Load(sdr);
                    datagrid.ItemsSource = dt.DefaultView;
                    connection.Close();
                }
                else if (alsoH > felsoH)
                {
                    MessageBox.Show("Az alsó határ nagyobb mint a felső határ!");
                }
                else if (alsoH % 1000 != 0 || felsoH % 1000 != 0)
                {
                    MessageBox.Show("Az alsó és felső határ csak 1000-rel osztható szám lehet!");
                }
            }
        }

        private void Szures_ki(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void Felvetel(object sender, RoutedEventArgs e)
        {
            Új_találkozó_felvétele ujTalalkozo = new Új_találkozó_felvétele();
            ujTalalkozo.ShowDialog();
        }

        private void Bezaras(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Exportalas(object sender, RoutedEventArgs e)
        {
            int alsoH = (int)Convert.ToInt32(Oradij_also_hatara.Text);
            int felsoH = (int)Convert.ToInt32(Oradij_felso_hatara.Text);
            DataGrid dg = datagrid;
            dg.SelectAllCells();
            dg.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, dg);
            datagrid.UnselectAllCells();
            String result = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            StreamWriter sw = new StreamWriter($"tanacsadok_{szakterulet.SelectedValue}_({alsoH}-{felsoH} Ft)_{DateTime.Now:yyyy-MM-dd}.csv");
            sw.WriteLine(result);
            sw.Close();
            MessageBox.Show("Az adatok sikeresen másolva a vágólapra!");
        }
    }
}
