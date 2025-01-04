using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KoleServis.Services
{
    public class ChangeBoldItalicService
    {

        public  void ChangeBold(String font)
        {

            var oldDictionary = Application.Current.Resources.MergedDictionaries
                .FirstOrDefault(d => d.Source != null && d.Source.OriginalString.Contains("Resources/FontWeight/FontWeight-"));

            if (oldDictionary != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(oldDictionary);
            }

            var newDictionary = new ResourceDictionary
            {
                Source = new Uri("Resources/FontWeight/FontWeight-" + font + "-dic.xaml", UriKind.Relative)
            };
            Application.Current.Resources.MergedDictionaries.Add(newDictionary);
            Properties.Settings.Default.bold = font;
            Properties.Settings.Default.Save();
        }
        public void ChangeItalic(String font)
        {

            var oldDictionary = Application.Current.Resources.MergedDictionaries
                .FirstOrDefault(d => d.Source != null && d.Source.OriginalString.Contains("Resources/FontStyle/FontStyle-"));

            if (oldDictionary != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(oldDictionary);
            }

            var newDictionary = new ResourceDictionary
            {
                Source = new Uri("Resources/FontStyle/FontStyle-" + font + "-dic.xaml", UriKind.Relative)
            };
            Application.Current.Resources.MergedDictionaries.Add(newDictionary);
            Properties.Settings.Default.italic = font;
            Properties.Settings.Default.Save();
        }
    }
}

