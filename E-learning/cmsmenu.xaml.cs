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
    /// Interaction logic for cmsmenu.xaml
    /// </summary>
    public partial class cmsmenu : Window
    {

        #region fields
        DatabaseClass db = new DatabaseClass();
        #endregion

        public cmsmenu()
        {
            InitializeComponent();
        }

        private void btLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            login.Show();
            this.Close();
        }
    }
}
