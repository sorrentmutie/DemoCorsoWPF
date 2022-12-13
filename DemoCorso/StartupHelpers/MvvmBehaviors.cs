using System;
using System.Windows;

namespace DemoCorso.StartupHelpers;



public class AttachedProperties : DependencyObject
{
    public static string GetTag(DependencyObject d)
    {
        return (string)d.GetValue(TagProperty);
    }
    public static void SetTag(DependencyObject d, string value)
    {
        d.SetValue(TagProperty, value);
    }

    public static readonly DependencyProperty TagProperty = DependencyProperty.RegisterAttached(
        "Tag", typeof(string), typeof(AttachedProperties), new PropertyMetadata(string.Empty));
}


public static class MvvmBehaviors
{

    public static string GetLoadedMethodName(DependencyObject obj)
    {
        return (string)obj.GetValue(LoadedMethodNameProperty);
    }

    public static void SetLoadedMethodName(DependencyObject obj, string value)
    {
        obj.SetValue(LoadedMethodNameProperty, value);
    }

    // Using a DependencyProperty as the backing store for LoadedMethodName.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty LoadedMethodNameProperty =
        DependencyProperty.RegisterAttached("LoadedMethodName", typeof(string),
            typeof(MvvmBehaviors), new PropertyMetadata(null, OnLoadedMethodNameChanged));

    static void OnLoadedMethodNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        FrameworkElement element = d as FrameworkElement;
        if (element != null)
        {

            element.Loaded += (s, e2) =>
            {
                var viewModel = element.DataContext;
                if (viewModel == null) return;
                var methodInfo = viewModel.GetType().GetMethod(e.NewValue.ToString());
                if (methodInfo != null) methodInfo.Invoke(viewModel, null);
            };
        }
    }
}
