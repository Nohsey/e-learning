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
    /// Interaction logic for LesonderwerpWijzig.xaml
    /// </summary>
    public partial class LesonderwerpWijzig : Window
    {
        #region fields
        DatabaseClass db = new DatabaseClass();
        List<Les> lstLessenWijzig = new List<Les>();
        string _sLesOndID = "";
        lesonderwerpbeheer _lastForm = new lesonderwerpbeheer();
        #endregion

        struct Les
        {
            public string lesID { get; set; }
            public string lesNaam { get; set; }
        }

        public LesonderwerpWijzig(string lesonderwerpID, lesonderwerpbeheer lastForm)
        {
            InitializeComponent();
            _sLesOndID = lesonderwerpID;
            _lastForm = lastForm;
            PopulateListBox();
        }

        public LesonderwerpWijzig()
        {
            // TODO: Complete member initialization
        }

        private void PopulateListBox()
        {
            DataTable dtLesvanOnd = new DatabaseClass().GetLes(_sLesOndID);

            foreach (DataRow row in dtLesvanOnd.Rows)
            {
                lstLessenWijzig.Add(new Les() { lesID = row["LesID"].ToString(), lesNaam = row["lesNaam"].ToString() });
            }
            lbLessenVanOndwrp.ItemsSource = lstLessenWijzig;
        }

        private void btWijzig_Copy_Click(object sender, RoutedEventArgs e)
        {
            if (lbLessenVanOndwrp.SelectedIndex == -1)
            {
                MessageBox.Show("Selecteer eerst een les om verder te gaan!");
            }

            else
            {
                string sLesID = ((Les)(lbLessenVanOndwrp.SelectedItem)).lesID;
                this.Hide();
            }
        }

        private void btTerug_Click(object sender, RoutedEventArgs e)
        {
            _lastForm.Show();
            this.Close();
        }
    }
}
