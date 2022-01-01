using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;
using Ookii.Dialogs.Wpf;

namespace Penzugyi_tanacsado.Model
{
    public class MainWindowViewModel
    {
        public static void ExportAllData(List<Values> AllData)
        {
            //var dg = new VistaFolderBrowserDialog();
            //bool? success = dg.ShowDialog();

            //if (success == true)
            //{
            //    string fileName = Path.Combine(dg.SelectedPath, $"tanacsadok_{DateTime.Now:yyyy-MM-dd}.csv");
            //    File.WriteAllLines(fileName, AllData.Select(x => String.Join(';',
            //        x.talalkozoDatuma,
            //        x.talalkozoKezdesiIdopontja,
            //        x.ugyfelNeve,
            //        x.tanacsadoNeve,
            //        x.szakterulet,
            //        x.talalkozoIdotartama,
            //        x.teljesOsszeg))); 
            //}

            //int alsoH = (int)Convert.ToUInt32(also_ar.Value);
            //int felsoH = (int)Convert.ToUInt32(felsoHatar.Value);
            //if (folderBrowserDialog1.ShowDialog() != DialogResult.OK)
            //{
            //    return;
            //}
            //string fileName = Path.Combine(folderBrowserDialog1.SelectedPath, $"tanacsadok_{Szakterulet.SelectedValue}_({alsoH}-{felsoH} Ft)_{DateTime.Now:yyyy-MM-dd}.csv");
            //File.WriteAllLines(fileName,
            //    tanacsadoDataSet.AllData.Select(x => string.Join(";", x.ItemArray))
            //    );
        }

        //public static List<Values> Filter(List<Values> AllData, string nev, int min, int max)
        //{
        //    List<Values> adatok = new List<Values>();
        //    foreach (var item in AllData)
        //    {
        //        item.tanacsadoNeve = new String(item.tanacsadoNeve.Where(Char.IsDigit).ToArray());
        //    }
        //    List<Values> adatok2 = new List<Values>();
        //    if ((AllData.Any(x => x.tanacsadoNeve == nev)))
        //    {

        //    }
        //}

        //}

        //public static List<Values> AllData(IDbConnection connection)
        //{

        //}
    }
}
