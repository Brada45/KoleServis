using KoleServis.MVVM.ViewModel;
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

namespace KoleServis.MVVM.View
{
    /// <summary>
    /// Interaction logic for ConfirmWindow.xaml
    /// </summary>
    public partial class ConfirmWindow : Window
    {
        public ConfirmWindow(Action<bool> resultCallback)
        {
            InitializeComponent();
            var viewModel = new ConfirmWindowViewModel();
            viewModel.Result = resultCallback;
            viewModel.CloseWindow = () => this.Close();
            DataContext = viewModel;
        }
    }

}
