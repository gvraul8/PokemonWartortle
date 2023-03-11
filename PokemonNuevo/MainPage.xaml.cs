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

        ///////////////////////////////////// VIDA ///////////////////////////////////////////////
     
        private void aumentarVida(object sender, PointerRoutedEventArgs e)
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(50);
            dtTime.Tick += increaseHealth;
            dtTime.Start();
            this.imgPocionVida.Opacity = 0.5;
        }

        private void increaseHealth(object sender, object e)
        {
            this.pbVida.Value += 0.2;
            if (pbVida.Value >= 100)
            {
                this.dtTime.Stop();
                this.imgPocionVida.Opacity = 1;
            }
        }

        private void imgPocionVida_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Storyboard vida = (Storyboard)this.Resources["Vida"];
            vida.Begin();

            this.aumentarVida(sender, e);
        }


        ///////////////////////////////////// ENERGIA ///////////////////////////////////////////////

        private void aumentarEnergia(object sender, PointerRoutedEventArgs e)
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(50);
            dtTime.Tick += increaseEnergy;
            dtTime.Start();
            this.imgPocionEnergia.Opacity = 0.5;
        }

        private void increaseEnergy(object sender, object e)
        {
            this.pbEnergia.Value += 0.2;
            if (pbEnergia.Value >= 100)
            {
                this.dtTime.Stop();
                this.imgPocionEnergia.Opacity = 1;
            }
        }

        private void imgPocionEnergia_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Storyboard energia = (Storyboard)this.Resources["Energia"];
            energia.Begin();

            this.aumentarEnergia(sender, e);

            this.btAtaque1.IsEnabled = true;
            this.btAtaque2.IsEnabled = true;
        }

        ///////////////////////////////////// ATAQUES ///////////////////////////////////////////////

        private void btAtaque1_click(object sender, RoutedEventArgs e)
        {
            Storyboard ataque1 = (Storyboard)this.Resources["Ataque1"];
            ataque1.Begin();

            this.pbEnergia.Value -= 20;

            if (pbEnergia.Value <= 0)
            { 
                // PREGUNTAR COMO PONER TOOLTIP CUANDO ESTAN DESACTIVADOS LOS BOTONES
                this.btAtaque1.IsEnabled = false;  
                this.btAtaque2.IsEnabled = false;
            }
        }

        private void btAtaque2_click(object sender, RoutedEventArgs e)
        {
            Storyboard ataque2 = (Storyboard)this.Resources["Ataque2"];
            ataque2.Begin();

            this.pbEnergia.Value -= 20;

            if (pbEnergia.Value <= 0)
            {
                this.btAtaque1.IsEnabled = false;
                this.btAtaque2.IsEnabled = false;
            }

        }

        private void btCubrirse_click(object sender, RoutedEventArgs e)
        {
            Storyboard cubrirse = (Storyboard)this.Resources["Cubrirse"];
            cubrirse.Begin();
        }


        ////////////////////////// DORMIR //////////////////////////////////////////

        private void descansar(object sender, RoutedEventArgs e)
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(25);
            dtTime.Tick += sleep;
            dtTime.Start();
        }

        private void sleep(object sender, object e)
        {
            this.pbVida.Value += 0.2;
            this.pbEnergia.Value += 0.2;
            if (pbVida.Value >= 100 && pbEnergia.Value >=100)
            {
                this.dtTime.Stop();
            }
        }

        private void btDormir_click(object sender, RoutedEventArgs e)
        {
            Storyboard dormir = (Storyboard)this.Resources["Dormir"];
            dormir.Begin();

            this.descansar(sender, e);
        }




    }
}

