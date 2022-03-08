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
        Grid grid2X1, grid3X3,grid4X4;
        Image b;
        Button uus_mang, reegel_btn, razmer_btn;
        public bool esimene;
        int[,] Tulemused = new int[3, 3];
        int tulemus = -1;





        public tripstrapsnull()
        {

            grid2X1 = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Green,
                RowDefinitions =
                {

                    new RowDefinition { Height = new GridLength(1
                    , GridUnitType.Star) },
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


            reegel_btn = new Button()
            {
                Text = "reegel"
            };

            razmer_btn = new Button()
            {
                Text = "4x4"
            };
            razmer_btn.Clicked += Razmer_btn_Clicked;

            StackLayout btn = new StackLayout
            {
                Children = { uus_mang, reegel_btn, },
            };

            reegel_btn.Clicked += Reegel_btn_Clicked;
            grid2X1.Children.Add(btn, 0, 1);
            uus_mang.Clicked += Uus_mang_Clicked;
            Content = grid2X1;
        }

        private void Razmer_btn_Clicked(object sender, EventArgs e)
        { 

        }

        private void Reegel_btn_Clicked(object sender, EventArgs e)
        {

            DisplayAlert("Reegel", "Mängijad panevad kordamööda väljaku vabadele lahtritele 3×3 märke (üks on alati ristid, teine ​​nullid). Võidab see, kes seab esimesena 3 tükki vertikaalselt, horisontaalselt või diagonaalselt ritta. Esimese käigu teeb mängija, kes paneb ristid.","OK");
        }

        public async void Kes_on_esimene()
        {
            string esimene_valik = await DisplayPromptAsync("Kes on esimene?", "Tee valiku X-1 või O-2", initialValue: "1", maxLength: 1, keyboard: Keyboard.Numeric);
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
                    BackgroundColor = Color.White,
                    RowDefinitions =
                {

                    new RowDefinition { Height = new GridLength(2, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(2, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(2, GridUnitType.Star) }
                },
                    ColumnDefinitions =
                {
                   new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) },
                   new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) },
                   new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) }

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
            else if (Tulemused[0, 0] == 1 && Tulemused[0, 1] == 1 && Tulemused[0,2] == 1 || Tulemused[1, 0] == 1 && Tulemused[1, 1] == 1 && Tulemused[1, 2] == 1 ||
                Tulemused[2, 0] == 1 && Tulemused[2, 1] == 1 && Tulemused[2, 2] == 1)
            {
                tulemus = 1;
            }
            else if(Tulemused[0, 0] == 1 && Tulemused[1, 1] == 1 && Tulemused[2, 2] == 1 || Tulemused[0, 2] == 1 && Tulemused[1, 1] == 1 && Tulemused[2, 0] == 1)
            {
                tulemus = 1;
            }

            else if (Tulemused[0, 0] == 2 && Tulemused[1, 0] == 2 && Tulemused[2, 0] == 2 || Tulemused[0, 1] == 2 && Tulemused[1, 1] == 2 && Tulemused[2, 1] == 2 ||
            Tulemused[0, 2] == 2 && Tulemused[1, 2] == 2 && Tulemused[2, 2] == 2)
            {
                tulemus = 2;
            }

            else if (Tulemused[0, 0] == 2 && Tulemused[0, 1] == 2 && Tulemused[0, 2] == 2 || Tulemused[1, 0] == 2 && Tulemused[1, 1] == 2 && Tulemused[1, 2] == 2 ||
                Tulemused[2, 0] == 2 && Tulemused[2, 1] == 2 && Tulemused[2, 2] == 2)
            {
                tulemus = 2;
            }
            else if (Tulemused[0, 0] == 2 && Tulemused[1, 1] == 2 && Tulemused[2, 2] == 2 || Tulemused[0, 2] == 2 && Tulemused[1, 1] == 2 && Tulemused[2, 0] == 2)
            {
                tulemus = 2;
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
            else if (tulemus == 2)
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
                Tulemused[r, c] = 2;
            }
            grid3X3.Children.Add(b, c, r);
            Lopp();

        }
    }
}