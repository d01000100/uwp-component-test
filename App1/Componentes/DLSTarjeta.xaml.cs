using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace App1.Componentes
{
    public sealed partial class DLSTarjeta : UserControl
    {
        public DLSTarjeta()
        {
            this.InitializeComponent();
            this.Contenido = null;
        }

        /** Definir una propiedad de tipo Object, nos permite recibir XAML y renderizarlo dentro del componente */
        public Object Contenido
        {
            get { return (Object)GetValue(ContenidoProperty); }
            set { SetValue(ContenidoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Contenido.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContenidoProperty =
            DependencyProperty.Register("Contenido", typeof(Object), typeof(DLSTarjeta), new PropertyMetadata(null));

        /* Intento de estilar sombra alrededor de la tarjeta WIP */

        private SpriteVisual shadowRect = null;

        private void InitComposition()
        {
            Compositor compositor = ElementCompositionPreview.GetElementVisual(GridTarjeta).Compositor;

            //Create LayerVisual
            LayerVisual layerVisual = compositor.CreateLayerVisual();
            layerVisual.Size = new Vector2(900, 900);

            //Create SpriteVisuals to use as LayerVisual child
            shadowRect = compositor.CreateSpriteVisual();
            shadowRect.Brush = compositor.CreateColorBrush(Windows.UI.Colors.Blue);
            shadowRect.Size = new Vector2(200,300);
            shadowRect.Offset = new Vector3(4, 4, 0);

            //Add children to the LayerVisual
            layerVisual.Children.InsertAtTop(shadowRect);

            //Create DropShadow
            DropShadow shadow = compositor.CreateDropShadow();
            shadow.Color = Colors.DarkSlateGray;
            shadow.Offset = new Vector3(0, 0, 0);
            shadow.BlurRadius = 12;
            shadow.SourcePolicy = CompositionDropShadowSourcePolicy.InheritFromVisualContent;

            //Associate Shadow with LayerVisual
            layerVisual.Shadow = shadow;

            ElementCompositionPreview.SetElementChildVisual(GridTarjeta, layerVisual);
        }

        private void NewLoaded(object sender, RoutedEventArgs e)
        {
            shadowRect.Size = new Vector2((float)GridTarjeta.ActualWidth, (float)GridTarjeta.ActualHeight);
        }
    }
}
