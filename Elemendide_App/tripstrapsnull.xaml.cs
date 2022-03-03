using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Elemendide_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class tripstrapsnull : ContentPage
    {
        Grid grid2X1, grid3X3;
        Image b;
        Button uus_mang;
        public bool esimene;
        int[,] Tulemused = new int[3, 3];
        int tulemus = -1;




        public tripstrapsnull()
        {

            grid2X1 = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Blue,
                RowDefinitions =
                {

                    new RowDefinition { Height = new GridLength(2, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                },
                ColumnDefinitions =
                {

                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                },
            };

            Uus_mang();
            uus_mang = new Button()
            {
                Text = "Uus mäng"
            };
            grid2X1.Children.Add(uus_mang, 0, 1);
            uus_mang.Clicked += Uus_mang_Clicked;
            Content = grid2X1;
        }
        public async void Kes_on_esimene()
        {
            string esimene_valik = await DisplayPromptAsync("Kes on esimene?", "Tee valiku Kollane-1 või Punane-2", initialValue: "1", maxLength: 1, keyboard: Keyboard.Numeric);
            if (esimene_valik == "1")
            {
                esimene = true;
            }
            else
            {
                esimene = false;
            }
        }
        private void Uus_mang_Clicked(object sender, EventArgs e)
        {
            Uus_mang();
        }

        public async void Uus_mang()
        {
            bool uus = await DisplayAlert("Uus mäng", "Kas tõesti tahad uus mäng?", "Tahan küll!", "Ei taha!");
            if (uus)
            {
                
                Kes_on_esimene();
                int[,] Tulemused = new int[3, 3];
                tulemus = -1;
                grid3X3 = new Grid
                {
                    BackgroundColor = Color.Blue,
                    RowDefinitions =
                {

                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                },
                    ColumnDefinitions =
                {
                   new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                   new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                   new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }

                }
                };
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        b = new Image { Source = "Nimetu.png" };
                        grid3X3.Children.Add(b, j, i);
                        TapGestureRecognizer tap = new TapGestureRecognizer();
                        tap.Tapped += Tap_Tapped;
                        b.GestureRecognizers.Add(tap);
                    }

                }
                grid2X1.Children.Add(grid3X3, 0, 0);
            }

        }


        public int Kontroll()
        {
            if (Tulemused[0,0] == 1 && Tulemused[1,0] ==1 && Tulemused[2,0]==1 || Tulemused[0, 1] == 1 && Tulemused[1, 1] == 1 && Tulemused[2, 1] == 1 ||
                Tulemused[0, 2] == 1 && Tulemused[1, 2] == 1 && Tulemused[2, 2] == 1)
            {
                tulemus = 1;
            }
            else if (Tulemused[0, 0] == 1 && Tulemused[1, 0] == 1 && Tulemused[2, 0] == 1 || Tulemused[0, 1] == 1 && Tulemused[1, 1] == 1 && Tulemused[2, 1] == 1 ||
                Tulemused[0, 2] == 1 && Tulemused[1, 2] == 1 && Tulemused[2, 2] == 1)
            {
                tulemus = 1;
            }
            else if(Tulemused[0, 0] == 1 && Tulemused[1, 1] == 1 && Tulemused[2, 2] == 1 || Tulemused[0, 2] == 1 && Tulemused[1, 1] == 1 && Tulemused[2, 0] == 1)
            {
                tulemus = 1;
            }
            return tulemus;
        }
        public void Lopp()
        {
            tulemus = Kontroll();
            if (tulemus == 1)
            {
                DisplayAlert("Võit", "Esimene on võitja! ", "ok");
                //tulemus = 2;
            }
            else if (tulemus == 0)
            {
                DisplayAlert("Võit", "Teine on võitja! ", "ok");
                //tulemus = 2;
            }
        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            var b = (Image)sender;
            var r = Grid.GetRow(b);
            var c = Grid.GetColumn(b);
            if (esimene == true)
            {
                b = new Image { Source = "krestik.png" };
                esimene = false;
                Tulemused[r, c] = 1;
            }
            else
            {
                b = new Image { Source = "nolik.png" };
                esimene = true;
                Tulemused[r, c] = 0;
            }
            grid3X3.Children.Add(b, c, r);
            Lopp();

        }
    }
}