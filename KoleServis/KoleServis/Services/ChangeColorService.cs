using System.Windows;
using System.Windows.Media;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;

namespace KoleServis.Services
{
    public class ChangeColorService
    {
        public void ChangeThemeColor(string primaryColor)
        {
            String color=primaryColor.ToLower();
            var oldDictionary = Application.Current.Resources.MergedDictionaries
                .FirstOrDefault(d => d.Source != null && d.Source.OriginalString.Contains("Resources/Colors/Colors-"));

            if (oldDictionary != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(oldDictionary);
            }

            var newDictionary = new ResourceDictionary
            {
                Source = new Uri("Resources/Colors/Colors-" + color + "-dic.xaml", UriKind.Relative)
            };
            Application.Current.Resources.MergedDictionaries.Add(newDictionary);

            Properties.Settings.Default.color = color;
            Properties.Settings.Default.Save();


        }

    }
}
