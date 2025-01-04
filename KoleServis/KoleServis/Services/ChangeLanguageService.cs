using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KoleServis.Services
{
    public class ChangeLanguageService
    {
        public static void ChangeLanguage(bool IsToggled)
        {
            string lang = IsToggled ? "srb" : "en";

            Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);

            var oldDictionary = Application.Current.Resources.MergedDictionaries
                .FirstOrDefault(d => d.Source != null && d.Source.OriginalString.Contains("Resources/Dictionary-"));

            if (oldDictionary != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(oldDictionary);
            }

            var newDictionary = new ResourceDictionary
            {
                Source = new Uri($"Resources/Dictionary-{lang}.xaml", UriKind.Relative)
            };
            Application.Current.Resources.MergedDictionaries.Add(newDictionary);
            Properties.Settings.Default.lang = IsToggled.ToString();
            Properties.Settings.Default.Save();
        }
    }
}
