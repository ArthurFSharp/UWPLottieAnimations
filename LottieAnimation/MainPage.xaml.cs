using LottieUWP;
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

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LottieAnimation
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            LaunchAnimation.Speed = 3F;

            PlaneAnimation.Speed = 3F;                       // Speed of the animation

            PlaneAnimation.RepeatCount = 4;                  // By default at -1. Number of repetition of the animation.

            PlaneAnimation.RepeatMode = RepeatMode.Reverse;  // Sets the play mode when the animation plays again.
        }

        private void AnimationButton_Click(object sender, RoutedEventArgs e)
        {
            LaunchAnimation.PlayAnimation();
        }
    }
}
