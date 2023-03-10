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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace PokemonNuevo
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        DispatcherTimer dtTime;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btAtaque1_click(object sender, RoutedEventArgs e)
        {
            Storyboard ataque1 = (Storyboard)this.Resources["Ataque1"];
            ataque1.Begin();

            int i = 0;
            do
            {
                i++;
                this.pbEnergia.Value -= 0.2;
            } while (i < 10);

            if (pbEnergia.Value >= 100)
            {
                this.dtTime.Stop();
                this.imgPocionVida.Opacity = 1;
            }


        }

        private void btAtaque2_click(object sender, RoutedEventArgs e)
        {
            Storyboard ataque2 = (Storyboard)this.Resources["Ataque2"];
            ataque2.Begin();

        }

        private void btCubrirse_click(object sender, RoutedEventArgs e)
        {
            Storyboard cubrirse = (Storyboard)this.Resources["Cubrirse"];
            cubrirse.Begin();
        }

        private void btDormir_click(object sender, RoutedEventArgs e)
        {
            Storyboard dormir = (Storyboard)this.Resources["Dormir"];
            dormir.Begin();
        }

        private void imgPocionVida_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Storyboard vida = (Storyboard)this.Resources["Vida"];
            vida.Begin();


            this.pbVida.Value += 0.20;
            if (pbVida.Value >= 100)
            {
                this.dtTime.Stop();
                this.imgPocionVida.Opacity = 1;

            }
        }

        private void imgPocionEnergia_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Storyboard energia = (Storyboard)this.Resources["Energia"];
            energia.Begin();


            this.pbEnergia.Value -= 0.2;
            if (pbEnergia.Value >= 100)
            {
                this.dtTime.Stop();
                this.imgPocionEnergia.Opacity = 1;

            }

        }
    }
}

