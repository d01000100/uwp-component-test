using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace App1.Componentes
{
    public sealed partial class DLSTipografia : UserControl
    {
        public DLSTipografia()
        {
            this.InitializeComponent();
            this.Texto = "Lorem ipsum";
        }



        public string Texto
        {
            get { return (string)GetValue(TextoProperty); }
            set { SetValue(TextoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Texto.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextoProperty =
            DependencyProperty.Register("Texto", typeof(string), typeof(DLSTipografia), new PropertyMetadata(0));


    }
}
