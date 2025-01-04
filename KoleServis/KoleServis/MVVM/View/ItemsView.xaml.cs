using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace KoleServis.MVVM.View
{
    /// <summary>
    /// Interaction logic for ItemsView.xaml
    /// </summary>
    public partial class ItemsView : UserControl
    {
        public ItemsView()
        {
            InitializeComponent();
        }
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string pattern = @"^[0-9]*(\.[0-9]{0,2})?$";
            Regex regex = new Regex(pattern);

            e.Handled = !regex.IsMatch(e.Text);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                textBox.Text = textBox.Text.Replace(" ", string.Empty);

                textBox.SelectionStart = textBox.Text.Length;
            }
        }
        private void TextBox_IntCheck(object sender, TextCompositionEventArgs e)
        {
            string pattern = @"^\d+$";
            Regex regex = new Regex(pattern);

            e.Handled = !regex.IsMatch(e.Text);
        }





    }
}
