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

        public bool StoreWindowState
        {
            get => m_StoreWindowState;
            set
            {
                m_StoreWindowState = value;
                OnPropertyChanged();
            }
        }
    }
}
