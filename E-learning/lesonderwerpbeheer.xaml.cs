﻿using System;
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
    /// Interaction logic for lesonderwerpbeheer.xaml
    /// </summary>
    public partial class lesonderwerpbeheer : Window
    {
        #region fields
        DatabaseClass db = new DatabaseClass();
        List<AlleLesOnderdeel> lstAlleLesOnderdeel = new List<AlleLesOnderdeel>();
        #endregion 

        struct AlleLesOnderdeel
        {
            public string aloID { get; set; }
            public string aloNaam { get; set; }
        }

        public lesonderwerpbeheer()
        {
            InitializeComponent();
            PopulateListBox();
        }

        private void PopulateListBox()
        {
            DataTable dtAlleLesOnderwerp = new DatabaseClass().GetAlleLesOnderwerp();

            foreach (DataRow row in dtAlleLesOnderwerp.Rows)
            {
                lstAlleLesOnderdeel.Add(new AlleLesOnderdeel() { aloID = row["LesonderwerpID"].ToString(), aloNaam = row["LesOmschrijving"].ToString() });
            }

            lbAlleLesOndwrp.ItemsSource = lstAlleLesOnderdeel;
        }
    }
}