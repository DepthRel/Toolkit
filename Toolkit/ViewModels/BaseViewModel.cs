using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Toolkit.ViewModels
{
    /// <summary>
    /// An abstract class that represents some convenience for projects using the ViewModel architecture model
    /// The class implements the INotifyPropertyChanged interface and implements a method for notifying about a value change using OnPropertyChanged
    /// The SetProperty method is implemented, which sets a new value to the property and automatically calls OnPropertyChanged
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Set property and notify <seealso cref="PropertyChanged"/>
        /// </summary>
        /// <typeparam name="T">Type of variable for setting new value</typeparam>
        /// <param name="storage">Reference to variable for setting new value</param>
        /// <param name="value">Value for setting to variable</param>
        /// <param name="propertyName">The property name which call method</param>
        /// <returns>Is new value set for variable</returns>
        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}