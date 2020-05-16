using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace OpenSaveTest.View
{
    public class ButtonsBase : Control
    {


        public object Service
        {
            get { return (object)GetValue(ServiceProperty); }
            set { SetValue(ServiceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Service.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ServiceProperty =
            DependencyProperty.Register("Service", typeof(object), typeof(ButtonsBase), new PropertyMetadata(null));


        protected virtual void PropertyChange(object service, Dictionary<string, Button> dictionary)
        {
        }

    }
}