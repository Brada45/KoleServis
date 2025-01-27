﻿using KoleServis.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KoleServis.MVVM.ViewModel
{
    public class ConfirmWindowViewModel : INotifyPropertyChanged
    {

        private ICommand _rejectCommand;
        private ICommand _confirmCommand;

        public ICommand ConfirmCommand => _confirmCommand ??= new RelayCommand(ConfirmAction, CanExecuteCommand);

        public ICommand RejectCommand => _rejectCommand ??= new RelayCommand(RejectAction, CanExecuteCommand);

        
        public event PropertyChangedEventHandler PropertyChanged;
        public Action<bool> Result { get; set; }
        public Action CloseWindow { get; set; }

        private void ConfirmAction(object parameter)
        {
            Result?.Invoke(true);
            CloseWindow?.Invoke();
        }

        private void RejectAction(object parameter)
        {
            Result?.Invoke(false);
            CloseWindow?.Invoke();
        }

        private bool CanExecuteCommand(object parameter)
        {
            return true;
        }
    }


}
