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
using System.Windows.Shapes;

namespace KoleServis.MVVM.View
{
    /// <summary>
    /// Interaction logic for UnseccessfulAction.xaml
    /// </summary>
    public partial class UnseccessfulAction : Window
    {
        public UnseccessfulAction()
        {
            InitializeComponent();
        }
        private void OnOkClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
