using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DemoCorso.StartupHelpers
{
    public class MyViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void SetProperty<T>(ref T member, T value, [CallerMemberName] string propertyName = "")
        {
            if (object.Equals(member, value)) return;

            member = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class MyValidatableViewModelBase : MyViewModelBase, INotifyDataErrorInfo
    {
        private Dictionary<string, List<string>> errors = new();

        public bool HasErrors => errors.Count > 0;

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public IEnumerable GetErrors(string? propertyName)
        {
            if(errors.ContainsKey(propertyName!))
            {
                return errors[propertyName];
            } else
            {
                return null;
            }
        }
    }
}
