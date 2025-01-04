using KoleServis.Services;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ChangeLanguageService.ChangeLanguage(Properties.Settings.Default.lang.Equals("True")?true:false);
            ChangeBoldItalicService cbis=new ChangeBoldItalicService();
            cbis.ChangeBold(Properties.Settings.Default.bold);
            cbis.ChangeItalic(Properties.Settings.Default.italic);
            new ChangeColorService().ChangeThemeColor(Properties.Settings.Default.color);
            ChangeFontService.ChangeFont(Properties.Settings.Default.font);

        }
    }
}
