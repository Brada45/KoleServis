using KoleServis.Core;
using KoleServis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoleServis.MVVM.ViewModel
{
    public class MainViewModel : Core.ViewModel
    {

        public INavigationService _navigation;
        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                
                    _navigation = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(INavigationService navigationService)
        {
            Navigation = navigationService;

        }
    }
}
