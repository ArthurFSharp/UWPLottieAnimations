using System;
using System.Collections.Generic;
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

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CompositionAnimation
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Compositor _compositor;
        private SpriteVisual _visual;

        public MainPage()
        {
            this.InitializeComponent();

            CreateShape();
            AnimateShape();
        }
        
        private void CreateShape()
        {
            _compositor = ElementCompositionPreview.GetElementVisual(this).Compositor;
            _visual = _compositor.CreateSpriteVisual();

            _visual.Size = new Vector2(150, 150);
            _visual.Offset = new Vector3(50, 50, 0);
            _visual.Brush = _compositor.CreateColorBrush(Colors.Cyan);

            ElementCompositionPreview.SetElementChildVisual(this, _visual);
        }

        private void AnimateShape()
        {
            if (_compositor != null &&
                _visual != null)
            {
                var animation = _compositor.CreateScalarKeyFrameAnimation();

                var easing = _compositor.CreateLinearEasingFunction();
                animation.InsertKeyFrame(0.0f, 0.0f);
                animation.InsertKeyFrame(1.0f, 360.0f, easing);

                animation.Duration = TimeSpan.FromMilliseconds(3000);
                animation.IterationBehavior = AnimationIterationBehavior.Forever;

                _visual.StartAnimation(nameof(_visual.RotationAngleInDegrees), animation);
                _visual.CenterPoint = new Vector3(_visual.Size.X / 2.0f, _visual.Size.Y / 2.0f, 0);
            }
        }
    }
}
