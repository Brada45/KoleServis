using KoleServis.Core;
using KoleServis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoleServis.MVVM.ViewModel
{
    class WorkerMainViewModel:Core.ViewModel
    {
        public INavigationService _navigation;
        private bool _isToggled;
        public bool IsToggled
        {
            get => _isToggled;
            set
            {
                _isToggled = value;
                OnPropertyChanged(nameof(IsToggled));
            }
        }



        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand NavigateToBillsCommand { get; set; }

        public WorkerMainViewModel(INavigationService navigation) {
            Navigation = navigation;
            NavigateToBillsCommand = new RelayCommand(o => { Navigation.NavigateTo<CreateBillViewModel>(true); }, o => true);

        }
    }
}
