using System;
using System.Collections.Generic;
using System.Data;
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

namespace E_learning
{
    /// <summary>
    /// Interaction logic for Keuzemenu_Leerling.xaml
    /// </summary>
    public partial class Keuzemenu_Leerling : Window
    {
        #region fields
        DatabaseClass db = new DatabaseClass();
        List<Vak> lstVakken = new List<Vak>();
        #endregion 

        public Keuzemenu_Leerling()
        {
            InitializeComponent();
            PopulateListBox();
        }

        struct Vak
        {
            public string ID { get; set; }
            public string VakNaam { get; set; }
        }

        struct LesOnderdeel
        {
            public string loID { get; set; }
            public string loNaam { get; set; }
        }

        struct Les
        {
            public string lesID { get; set; }
            public string lesNaam { get; set; }
        }
        private void PopulateListBox()
        {
            DataTable dtVakken = new DatabaseClass().GetVakken();

             foreach (DataRow row in dtVakken.Rows)
             {
                 lstVakken.Add(new Vak() { ID = row["VakID"].ToString(), VakNaam = row["Omschrijving"].ToString() });
             }

             lbVakken.ItemsSource = lstVakken;
        }

        private void lbVakken_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<LesOnderdeel> lstLesOnderdeel = new List<LesOnderdeel>();
            string sVakID = "";
            
            if (lbVakken.SelectedItem != null)
            {
                sVakID = ((Vak)(lbVakken.SelectedItem)).ID;
            }

            DataTable dtLesOnderdeel = db.GetLesOnderwerp(sVakID);

            foreach (DataRow row in dtLesOnderdeel.Rows)
            {
                lstLesOnderdeel.Add(new LesOnderdeel() { loID = row["LesonderwerpID"].ToString(), loNaam = row["LesOmschrijving"].ToString() });
            }
            lbLesOnderwerp.ItemsSource = lstLesOnderdeel;
        }

        private void lbLesOnderwerp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Les> lstLessen = new List<Les>();
            string slesonderwerpID = "";

            if (lbLesOnderwerp.SelectedItem != null)
            {
                slesonderwerpID = ((LesOnderdeel)(lbLesOnderwerp.SelectedItem)).loID;

                DataTable dtLes = db.GetLes(slesonderwerpID);

                foreach (DataRow row in dtLes.Rows)
                {
                    lstLessen.Add(new Les() { lesID = row["LesID"].ToString(), lesNaam = row["lesNaam"].ToString() });
                }
                lbLessen.ItemsSource = lstLessen;
            }

            
        }

        private void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (lbLessen.SelectedIndex == -1)
            {
                MessageBox.Show("Selecteer eerst een les om verder te gaan!");
            }

            else {
                string sLesID = ((Les)(lbLessen.SelectedItem)).lesID;
                LesForm les = new LesForm(sLesID);
                les.Show();
                this.Hide();
            }
        }
        
        private void btLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            login.Show();
            this.Close();
        }
    }
}
