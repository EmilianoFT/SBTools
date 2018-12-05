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
    public delegate void FooBarDelegateRecurse(WLData WordListData);

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

    public class ActionDelegateThreadsRecurse
    {
        private FooBarDelegateRecurse _action;
        private FooBarDelegateRecurse _postaction;
        private WLData _WordListData;

        public void ActionDelegate(FooBarDelegateRecurse action, FooBarDelegateRecurse postaction, WLData WLD)
        {
            _action = action;
            _postaction = postaction;
            _WordListData = WLD;
            Thread t = new Thread(ejecutar);
            t.SetApartmentState(ApartmentState.STA);

            t.Start();
        }

        private void ejecutar()
        {
            if (_action != null)
                _action(_WordListData);

            if (_postaction != null)
            {
                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    if (_postaction != null)
                        _postaction(_WordListData);
                });
            }
        }
    }
}
