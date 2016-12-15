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

namespace E_learning
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region fields
        DatabaseClass db = new DatabaseClass();

        string sUsername = "";
        string sPassword = "";
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            tbUser.Focus();
        }

        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            sUsername = tbUser.Text;
            sPassword = pbPassword.Password;

            db.try_login(sUsername, sPassword, this);
            
        }
    }
}
