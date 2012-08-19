using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace Sample.WPF
{
    public class MyLabel : Label
    {
        public event DependencyPropertyChangedEventHandler ContentChanged;

        static MyLabel()
        {
            ContentProperty.OverrideMetadata(typeof(MyLabel),
                new FrameworkPropertyMetadata(
                    new PropertyChangedCallback(OnContentChanged)));
        }

        private static void OnContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MyLabel mcc = d as MyLabel;
            if (mcc.ContentChanged != null)
            {
                DependencyPropertyChangedEventArgs args
                    = new DependencyPropertyChangedEventArgs(
                        ContentProperty, e.OldValue, e.NewValue);
                mcc.ContentChanged(mcc, args);
            }
        }
    }
}
