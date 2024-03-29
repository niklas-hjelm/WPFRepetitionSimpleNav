﻿using System;
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
using WPFRepetition.Models;

namespace WPFRepetition.UserControls
{
    /// <summary>
    /// Interaction logic for CenterView.xaml
    /// </summary>
    public partial class CenterView : UserControl
    {
        public DataModel DataModel { get; set; }

        public CenterView()
        {
            InitializeComponent();
            DataModel = DataManager.DataModel;
            DataContext = DataModel;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            DataModel.Counter = 0;
        }
    }
}
