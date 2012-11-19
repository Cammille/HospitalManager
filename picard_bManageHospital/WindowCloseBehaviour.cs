using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace picard_bManageHospital
{

    /// <summary>
    /// permet de fermer une fenêtre par binding MVVM
    /// </summary>
    public static class WindowCloseBehaviour
    {
        public static void SetClose(DependencyObject target, bool value)
        {
            target.SetValue(CloseProperty, value);
        }
        public static readonly DependencyProperty CloseProperty =
                    DependencyProperty.RegisterAttached(
                    "Close",
                    typeof(bool),
                    typeof(WindowCloseBehaviour),
                    new UIPropertyMetadata(false, OnClose));

        private static void OnClose(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is bool && ((bool)e.NewValue))
            {
                Window window = GetWindow(sender);
                if (window != null)
                    window.Close();
            }
        }
        private static Window GetWindow(DependencyObject sender)
        {
            Window window = null;
            if (sender is Window)
                window = (Window)sender;
            if (window == null)
                window = Window.GetWindow(sender);
            return window;
        }
    }
}
