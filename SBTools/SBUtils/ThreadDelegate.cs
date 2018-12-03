using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Action = System.Action;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Runtime.InteropServices;

namespace SBUtils
{
    public delegate void FooBarDelegate();

    public class ActionDelegateThreads
    {
        private FooBarDelegate _action;
        private FooBarDelegate _postaction;

        public void ActionDelegate(FooBarDelegate action, FooBarDelegate postaction)
        {
            _action = action;
            _postaction = postaction;

            Thread t = new Thread(ejecutar);
            t.SetApartmentState(ApartmentState.STA);

            t.Start();
        }

        private void ejecutar()
        {
            if (_action != null)
                _action();

            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                if (_postaction != null)
                    _postaction();
            });
        }
    }
}
