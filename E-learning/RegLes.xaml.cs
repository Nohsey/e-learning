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

namespace E_learning
{
    /// <summary>
    /// Interaction logic for RegLes.xaml
    /// </summary>
    public partial class RegLes : Window
    {
        #region fields
        LesonderwerpWijzig _form = new LesonderwerpWijzig();
        string _sloID = "";
        DatabaseClass db = new DatabaseClass();
        #endregion

        public RegLes(string sloID, LesonderwerpWijzig form )
        {
            InitializeComponent();

            _form = form;
            _sloID = sloID;
        }

        private void btToevoegen_Click(object sender, RoutedEventArgs e)
        {
            db.newLes(_sloID, tbLesNaam.Text, tblUitleg.Text, this, _form);
        }

        private void btTerug_Click(object sender, RoutedEventArgs e)
        {
            _form.Show();
            this.Close();
        }
    }
}
