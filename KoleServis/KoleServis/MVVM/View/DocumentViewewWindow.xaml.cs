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
    /// Interaction logic for DocumentViewewWindow.xaml
    /// </summary>
    public partial class DocumentViewewWindow : Window
    {
        public DocumentViewewWindow()
        {
            InitializeComponent();
        }
        public void SetDocument(FlowDocument document)
        {
            DocumentReader.Document = document; 
        }
    }
}
