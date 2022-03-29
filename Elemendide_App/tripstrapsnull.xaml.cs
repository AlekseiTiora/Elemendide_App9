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
        Xamarin.Forms.Image b;
        Button uus_mang, theme, rules, music_btn;
        public bool esimene;
        int tulemus = -1;
        int[,] Tulemused = new int[3, 3] { { 2, 2, 2 }, { 2, 2, 2 }, { 2, 2, 2 } };
        string src = "nolik.png";
        string src2 = "krestik.png";
        string theme1;
        Color color;

        public tripstrapsnull()
        {
            grid2X1 = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Orange,
                RowDefinitions =
                {

                    new RowDefinition { Height = new GridLength(2, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                },
            };

            Uus_mang();
            uus_mang = new Button()
            {
                Text = "Uus mäng",
            };

            theme = new Button()
            {
                Text = "Muuda teemat",
            };

            theme.Clicked += theme_Clicked;

            rules = new Button()
            {
                Text = "Reeglit",
            };

            music_btn = new Button()
            {
                Text = "Audio"
            };

            StackLayout btn = new StackLayout
            {
                Children = { uus_mang, theme, rules, music_btn }
            };

            rules.Clicked += Rules_Clicked;
            grid2X1.Children.Add(btn, 0, 1);
            uus_mang.Clicked += Uus_mang_Clicked;
            music_btn.Clicked += Music_btn_Clicked;
            Content = grid2X1;


        }

        int music = 0;
        private void Music_btn_Clicked(object sender, EventArgs e)
        {
            if (music == 0)
            {
                DependencyService.Get<IAudio>().PlayAudioFile("music.mp3");
                music++;
            }
            else if (music == 1)
            {
                DependencyService.Get<IAudio>().Stop("music.mp3");
                music = 0;
            }


        }

        private void Rules_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Reegel", "Mängijad panevad kordamööda väljaku vabadele lahtritele 3×3 märke" +
                " (üks on alati ristid, teine ​​nullid). Võidab see, kes seab esimesena 3 tükki vertikaalselt, " +
                "horisontaalselt või diagonaalselt ritta. Esimese käigu teeb mängija, kes paneb ristid.", "OK");
        }

        private async void theme_Clicked(object sender, EventArgs e)
        {
            theme1 = await DisplayPromptAsync("Teema", "standart teemat-1,  rohaline teema-2 ", initialValue: "1", maxLength: 1, keyboard: Keyboard.Numeric);
            if (theme1 == "1")
            {
                grid2X1.BackgroundColor = Color.Orange;
                grid3X3.BackgroundColor = Color.Orange;
                src = "nolik.png";
                src2 = "krestik.png";
            }
            else if (theme1 == "2")
            {
                grid2X1.BackgroundColor = Color.Green;
                grid3X3.BackgroundColor = Color.Green;
                src = "bo.png";
                src2 = "bx.png";
            }

            color = grid3X3.BackgroundColor;
        }

        public async void Kes_on_esimene()
        {
            string esimene_valik = await DisplayPromptAsync("Kes on esimene?", "Tee valiku Krestik-1 või Nolik-2", initialValue: "1", maxLength: 1, keyboard: Keyboard.Numeric);
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
                Tulemused = new int[3, 3] { { 2, 2, 2 }, { 2, 2, 2 }, { 2, 2, 2 } };
                grid3X3 = new Grid
                {
                    BackgroundColor = Color.Orange,

                };
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        b = new Xamarin.Forms.Image { Source = "Nimetu.png" };
                        grid3X3.Children.Add(b, j, i);
                        TapGestureRecognizer tap = new TapGestureRecognizer();
                        tap.Tapped += Tap_Tapped;
                        b.GestureRecognizers.Add(tap);
                    }
                }
                grid2X1.Children.Add(grid3X3, 0, 0);
                grid2X1.BackgroundColor = Color.Orange;
                theme.IsEnabled = true;
            }
        }
        public int Kontroll()
        {
            if (Tulemused[0, 0] == 1 && Tulemused[1, 0] == 1 && Tulemused[2, 0] == 1 || Tulemused[0, 1] == 1 && Tulemused[1, 1] == 1 && Tulemused[2, 1] == 1 || Tulemused[0, 2] == 1 && Tulemused[1, 2] == 1 && Tulemused[2, 2] == 1)
            {
                tulemus = 1;
            }
            else if (Tulemused[0, 0] == 1 && Tulemused[0, 1] == 1 && Tulemused[0, 2] == 1 || Tulemused[1, 0] == 1 && Tulemused[1, 1] == 1 && Tulemused[1, 2] == 1 || Tulemused[2, 0] == 1 && Tulemused[2, 1] == 1 && Tulemused[2, 2] == 1)
            {
                tulemus = 1;
            }
            else if (Tulemused[0, 0] == 1 && Tulemused[1, 1] == 1 && Tulemused[2, 2] == 1 || Tulemused[0, 2] == 1 && Tulemused[1, 1] == 1 && Tulemused[2, 0] == 1)
            {
                tulemus = 1;
            }
            else if (Tulemused[0, 0] == 0 && Tulemused[1, 0] == 0 && Tulemused[2, 0] == 0 || Tulemused[0, 1] == 0 && Tulemused[1, 1] == 0 && Tulemused[2, 1] == 0 || Tulemused[0, 2] == 0 && Tulemused[1, 2] == 0 && Tulemused[2, 2] == 0)
            {
                tulemus = 0;
            }
            else if (Tulemused[0, 0] == 0 && Tulemused[0, 1] == 0 && Tulemused[0, 2] == 0 || Tulemused[1, 0] == 0 && Tulemused[1, 1] == 0 && Tulemused[1, 2] == 0 || Tulemused[2, 0] == 0 && Tulemused[2, 1] == 0 && Tulemused[2, 2] == 0)
            {
                tulemus = 0;
            }
            else if (Tulemused[0, 0] == 0 && Tulemused[1, 1] == 0 && Tulemused[2, 2] == 0 || Tulemused[0, 2] == 0 && Tulemused[1, 1] == 0 && Tulemused[2, 0] == 0)
            {
                tulemus = 0;
            }
            else if (Tulemused[0, 0] == 4 && Tulemused[1, 0] == 4 && Tulemused[2, 0] == 4 && Tulemused[0, 1] == 4 && Tulemused[1, 1] == 4 &&
                Tulemused[2, 1] == 4 && Tulemused[0, 2] == 4 && Tulemused[1, 2] == 4 && Tulemused[2, 2] == 4)
            {
                tulemus = -3;
            }
            else
            {
                tulemus = -1;
            }

            if (checkTie())
            {
                DisplayAlert("Mängu lõpp", "mäng on viigis", "OK");
            }

            return tulemus;
        }

        private bool checkTie()
        {
            for (int i = 0; i < Tulemused.GetLength(0); i++)
            {
                for (int j = 0; j < Tulemused.GetLength(1); j++)
                {
                    if (Tulemused[i, j] == 2)
                    {
                        return false;
                    }
                }
            }
            
            uus_mang.IsEnabled = true;
            return true;
        }
        public void Lopp()
        {
            tulemus = Kontroll();
            if (tulemus == 1)
            {
                DisplayAlert("Võit", "Nolik on võitja!", "Ok");
                tulemus = -1;
                uus_mang.IsEnabled = true;
            }
            else if (tulemus == 0)
            {
                DisplayAlert("Võit", "Krestik on võitja!", "Ok");
                tulemus = -1;
                uus_mang.IsEnabled = true;
            }
            else if (tulemus == -3)
            {
                DisplayAlert("Võit", "Nicja", "Ok");
                uus_mang.IsEnabled = true;
            }
        }
        private void Tap_Tapped(object sender, EventArgs e)
        {
            var b = (Xamarin.Forms.Image)sender;
            var r = Grid.GetRow(b);
            var c = Grid.GetColumn(b);
            if (esimene == true)
            {
                b.Source = src;
                esimene = false;
                Tulemused[r, c] = 1;
                theme.IsEnabled = false;
                uus_mang.IsEnabled = false;
            }
            else
            {
                b.Source = src2;
                esimene = true;
                Tulemused[r, c] = 0;
                theme.IsEnabled = false;
                uus_mang.IsEnabled = false;
            }
            grid3X3.Children.Add(b, c, r);
            Lopp();
        }
    }
}