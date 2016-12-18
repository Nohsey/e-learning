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
    /// Interaction logic for RegLesOnd.xaml
    /// </summary>
    public partial class RegLesOnd : Window
    {
        #region fields
        DatabaseClass db = new DatabaseClass();
        lesonderwerpbeheer _lastForm = new lesonderwerpbeheer();
        List<Vak> _lvVakken = new List<Vak>();
        #endregion 

        struct Vak
        {
            public string vakID { get; set; }
            public string vakNaam { get; set; }
        }

        public RegLesOnd(lesonderwerpbeheer lastForm)
        {
            InitializeComponent();
            _lastForm = lastForm;
            PopulateComboBox();
        }

        

        private void PopulateComboBox()
        {
            DataTable dtVakken = new DatabaseClass().GetVakken();

            foreach (DataRow row in dtVakken.Rows)
            {
                _lvVakken.Add(new Vak() { vakID = row["VakID"].ToString(), vakNaam = row["Omschrijving"].ToString() });
            }

            cbVakken.ItemsSource = _lvVakken;
        }

        private void btTerug_Click(object sender, RoutedEventArgs e)
        {
            _lastForm.Show();
            this.Close();
        }

        private void btToevoegen_Click(object sender, RoutedEventArgs e)
        {
            string svakID = ((Vak)(cbVakken.SelectedItem)).vakID;
            db.newLesOnderwerp(svakID, tbLesOmschrijving.Text, this);

        }
    }
}
