using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace SBCore
{
    public class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        private bool open;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsOpen
        {
            get
            {
                return this.open;
            }
            set
            {
                if (this.open != value)
                {
                    this.open = value;
                    this.RaisePropertyChanged("IsOpen");
                }
            }
        }

        [Obsolete("This method is obsolete. Call RaisePropertyChanged instead.", false)]
        protected void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            if (this.PropertyChanged == null)
            {
                return;
            }
            MemberExpression body = propertyExpression.Body as MemberExpression;
            if (body != null)
            {
                PropertyInfo property = body.Member as PropertyInfo;
                if (property != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(property.Name));
                }
            }
        }

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged == null)
            {
                return;
            }
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        ~ViewModelBase()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }
    }
}
