using KoleServis.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KoleServis.Services
{
    public interface INavigationService
    {
        ViewModel CurrentView { get; }
        ViewModel CurrentViewMain { get; }
        void NavigateTo<T>(bool isMain) where T:ViewModel;
    }
    public class NavigationService:ObservableObject,INavigationService
    {
        private ViewModel _currentView;
        private ViewModel _currentViewMain;
        private readonly Func<Type,ViewModel> _viewModelFactory;

        public ViewModel CurrentView {
            get => _currentView;
            private set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }
        public ViewModel CurrentViewMain
        {
            get => _currentViewMain;
            private set
            {
                _currentViewMain = value;
                OnPropertyChanged(nameof(CurrentViewMain));
            }
        }
        private readonly IServiceProvider _serviceProvider;

        public NavigationService(Func<Type, ViewModel> viewModelFactory)
        {
            if (_viewModelFactory == viewModelFactory) return;
            _viewModelFactory = viewModelFactory;
        }


        public void NavigateTo<TViewModel>(bool isMain) where TViewModel : ViewModel
        {
            
            ViewModel viewModel= _viewModelFactory.Invoke(typeof(TViewModel));
            if (isMain)
            {
                CurrentViewMain = viewModel;
            }
            else
            {
                CurrentView = viewModel;
            }
        }

    }
}
