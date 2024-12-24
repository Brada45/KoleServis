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

            // Ukloni stari ResourceDictionary ako postoji
            if (oldDictionary != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(oldDictionary);
            }

            // Dodaj novi ResourceDictionary
            var newDictionary = new ResourceDictionary
            {
                Source = new Uri("Resources/FontWeight/FontWeight-" + font + "-dic.xaml", UriKind.Relative)
            };
            Application.Current.Resources.MergedDictionaries.Add(newDictionary);
        }
        public void ChangeItalic(String font)
        {

            var oldDictionary = Application.Current.Resources.MergedDictionaries
                .FirstOrDefault(d => d.Source != null && d.Source.OriginalString.Contains("Resources/FontStyle/FontStyle-"));

            // Ukloni stari ResourceDictionary ako postoji
            if (oldDictionary != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(oldDictionary);
            }

            // Dodaj novi ResourceDictionary
            var newDictionary = new ResourceDictionary
            {
                Source = new Uri("Resources/FontStyle/FontStyle-" + font + "-dic.xaml", UriKind.Relative)
            };
            Application.Current.Resources.MergedDictionaries.Add(newDictionary);
        }
    }
}

