using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KoleServis.Services
{
    public class ChangeFontService
    {

        public static void ChangeFont(String font)
        {
            string tmp=font.ToLower().Replace(" ","-");
           /* if (font.Equals("Arial"))
            {
                tmp = "arial";
            }else if(font.Equals("Times New Roman"))
            {
                tmp = "times-new-roman";
            }else if(font.Equals("Courier New"))
            {
                tmp = "courier-new";
            }*/


            var oldDictionary = Application.Current.Resources.MergedDictionaries
                .FirstOrDefault(d => d.Source != null && d.Source.OriginalString.Contains("Resources/Fonts-"));

            if (oldDictionary != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(oldDictionary);
            }

            var newDictionary = new ResourceDictionary
            {
                Source = new Uri("Resources/Fonts-"+tmp+"-dic.xaml", UriKind.Relative)
            };
            Application.Current.Resources.MergedDictionaries.Add(newDictionary);

            Properties.Settings.Default.font=font;
            Properties.Settings.Default.Save();
        }
    }
}
