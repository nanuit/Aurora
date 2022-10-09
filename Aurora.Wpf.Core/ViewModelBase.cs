﻿using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Aurora.Wpf.Core
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChange
        public event PropertyChangedEventHandler? PropertyChanged;
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public void VerifyPropertyName(string propertyName)
        {
            // Verify that the property name matches a real, 
            // public, instance property on this object. 
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                string msg = "Invalid property name: " + propertyName;
                //if (this.ThrowOnInvalidPropertyName)
                //    throw new Exception(msg);
                //else
                    Debug.Fail(msg);
            }
        }
    }
}
