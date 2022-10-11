using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aurora.Wpf;


namespace Aurora.Test.Model
{
    public class MainViewViM : ViewModelBase
    {
        private bool m_StoreWindowState = true;
        private RelayCommand m_RelayCommand;
        
        public RelayCommand ReloadCommand => this.m_RelayCommand ?? (this.m_RelayCommand = new RelayCommand(ReloadCommandMethod, null));

        public bool StoreWindowState
        {
            get => m_StoreWindowState;
            set
            {
                m_StoreWindowState = value;
                OnPropertyChanged();
            }
        }

        private void ReloadCommandMethod(object parameter)
        {
            
        }

    }
}
