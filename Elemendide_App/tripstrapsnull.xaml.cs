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
        Button uus_mang, reegel_btn, stil_btn, razmer_btn, music_btn;
        public bool esimene;
        public bool razmere;
        int[,] Tulemused = new int[3, 3];
        int tulemus = 0;
        public int F = 0;
        int razmerpole = 0;
        string nolik = "nolik.png";
        string krestik = "krestik.png";





        public tripstrapsnull()
        {

            grid2X1 = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Green,
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
                Text = "Uus mäng"
            };


            reegel_btn = new Button()
            {
                Text = "reegel"
            };

            razmer_btn = new Button()
            {
                Text = "Suurus"
            };

            music_btn = new Button()
            {
                Text = "Audio"
            };

            stil_btn = new Button()
            {
                Text = "stil"
            };
            stil_btn.Clicked += stil_btn_Clicked;



            StackLayout btn = new StackLayout
            {
                Children = { uus_mang, reegel_btn,stil_btn, razmer_btn, music_btn }
            };



            reegel_btn.Clicked += Reegel_btn_Clicked;
            grid2X1.Children.Add(btn, 0, 1);
            uus_mang.Clicked += Uus_mang_Clicked;
            razmer_btn.Clicked += Razmer_btn_Clicked;
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

        public async void Razmer_btn_Clicked(object sender, EventArgs e)
        {

            string razmer = await DisplayPromptAsync("Kas sa tahad 3x3 või 4x4?", "Tee valiku 3x3-1 või 4x4-2", initialValue: "1", maxLength: 1, keyboard: Keyboard.Numeric);
            if (razmer == "1")
            {
                razmere = true;
                Uus_mang();

            }
            else if (razmer == "2")
            {
                razmere = false;
                Uus_mang();

            }
            else
            {
                razmere = true;
            }

        }

        private async void stil_btn_Clicked(object sender, EventArgs e)
        {
            string theme = await DisplayPromptAsync("Teema", "default teemat-1, 2- tema", initialValue: "1", maxLength: 1, keyboard: Keyboard.Numeric);
            if (theme == "1")
            {
                grid2X1.BackgroundColor = Color.Green;
                grid3X3.BackgroundColor = Color.Green;
                nolik = "nolik.png";
                krestik = "krestik.png";
            }
            else if (theme == "2")
            {
                grid2X1.BackgroundColor = Color.Orange;
                grid3X3.BackgroundColor = Color.Orange;
                nolik = "bo.png";
                krestik = "bx.png";
            }

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
            grid3X3.IsEnabled = true;
        }

        public async void Uus_mang()
        {
            bool uus = await DisplayAlert("Uus mäng", "Kas tõesti tahad uus mäng?", "Tahan küll!", "Ei taha!");
            if (uus)
            {

                Kes_on_esimene();
                tulemus = -1;

                if (razmere == true)
                {
                    Tulemused = new int[3, 3];
                    razmerpole = 3;
                }
                else
                {
                    Tulemused = new int[4, 4];
                    razmerpole = 4;
                }

                grid3X3 = new Grid
                {
                    BackgroundColor = Color.Green,

                };
                for (int i = 0; i < razmerpole; i++)
                {
                    for (int j = 0; j < razmerpole; j++)
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
            //nol
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
            //
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
            return true;
        }

        public int Kontroll4na4()
        {
            if (Tulemused[0, 0] == 1 && Tulemused[1, 0] == 1 && Tulemused[2, 0] == 1 && Tulemused[3, 0] == 1 || Tulemused[0, 1] == 1 && Tulemused[1, 1] == 1 &&
                Tulemused[2, 1] == 1 && Tulemused[3, 1] == 1 || Tulemused[0, 2] == 1 && Tulemused[1, 2] == 1 && Tulemused[2, 2] == 1 && Tulemused[3, 2] == 1 || Tulemused[0, 3] == 1 && Tulemused[1, 3] == 1 && Tulemused[2, 3] == 1 && Tulemused[3, 3] == 1)
            {
                tulemus = 1;
            }
            else if (Tulemused[0, 0] == 1 && Tulemused[0, 1] == 1 && Tulemused[0, 2] == 1 && Tulemused[0, 3] == 1 || Tulemused[1, 0] == 1 && Tulemused[1, 1] == 1 &&
                Tulemused[1, 2] == 1 && Tulemused[1, 3] == 1 || Tulemused[2, 0] == 1 && Tulemused[2, 1] == 1 && Tulemused[2, 2] == 1 && Tulemused[2, 3] == 1 || Tulemused[3, 0] == 1 && Tulemused[3, 1] == 1 && Tulemused[3, 2] == 1 && Tulemused[3, 3] == 1)
            {
                tulemus = 1;
            }
            else if (Tulemused[0, 0] == 1 && Tulemused[1, 1] == 1 && Tulemused[2, 2] == 1 && Tulemused[3, 3] == 1 || Tulemused[0, 3] == 1 && Tulemused[1, 2] == 1 &&
                Tulemused[2, 1] == 1 && Tulemused[3, 0] == 1)
            {
                tulemus = 1;
            }

            //nol
            else if (Tulemused[0, 0] == 2 && Tulemused[1, 0] == 2 && Tulemused[2, 0] == 2 && Tulemused[3, 0] == 2 || Tulemused[0, 1] == 2 && Tulemused[1, 1] == 2 &&
                Tulemused[2, 1] == 2 && Tulemused[3, 1] == 2 || Tulemused[0, 2] == 2 && Tulemused[1, 2] == 2 && Tulemused[2, 2] == 2 && Tulemused[3, 2] == 2 || Tulemused[0, 3] == 2 && Tulemused[1, 3] == 2 && Tulemused[2, 3] == 2 && Tulemused[3, 3] == 2)
            {
                tulemus = 2;
            }
            else if (Tulemused[0, 0] == 2 && Tulemused[0, 1] == 2 && Tulemused[0, 2] == 2 && Tulemused[0, 3] == 2 || Tulemused[1, 0] == 2 && Tulemused[1, 1] == 2 &&
                Tulemused[1, 2] == 2 && Tulemused[1, 3] == 2 || Tulemused[2, 0] == 2 && Tulemused[2, 1] == 2 && Tulemused[2, 2] == 2 && Tulemused[2, 3] == 2 || Tulemused[3, 0] == 2 && Tulemused[3, 1] == 2 && Tulemused[3, 2] == 2 && Tulemused[3, 3] == 2)
            {
                tulemus = 2;
            }
            else if (Tulemused[0, 0] == 2 && Tulemused[1, 1] == 2 && Tulemused[2, 2] == 2 && Tulemused[3, 3] == 2 || Tulemused[0, 3] == 2 && Tulemused[1, 2] == 2 &&
                Tulemused[2, 1] == 2 && Tulemused[3, 0] == 2)
            {
                tulemus = 2;
            }
            else if (Tulemused[0, 0] == 4 && Tulemused[1, 0] == 4 && Tulemused[2, 0] == 4 && Tulemused[3, 0] == 4 && Tulemused[0, 1] == 4 && Tulemused[1, 1] == 4 &&
                Tulemused[2, 1] == 4 && Tulemused[3, 1] == 4 && Tulemused[0, 2] == 4 && Tulemused[1, 2] == 4 && Tulemused[2, 2] == 4 && Tulemused[3, 2] == 4 && Tulemused[0, 3] == 4 && Tulemused[1, 3] == 4 && Tulemused[2, 3] == 4 && Tulemused[3, 3] == 4)
            {
                tulemus = -3;
            }
            /*else
            {
                tulemus = -3;
            }*/
            return tulemus;
        }
        public void Lopp()
        {
            if (razmere == true)
            {
                tulemus = Kontroll();
            }
            else if (razmere == false)
            {
                tulemus = Kontroll4na4();
            }

            if (tulemus == 1)
            {
                DisplayAlert("Võit", "Esimene on võitja! ", "ok");
                grid3X3.IsEnabled = false;
                razmer_btn.IsEnabled = true;
                //tulemus = 2;
            }
            else if (tulemus == 2)
            {
                DisplayAlert("Võit", "Teine on võitja! ", "ok");
                grid3X3.IsEnabled = false;
                razmer_btn.IsEnabled = true;
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
                b.Source = krestik;
                esimene = false;
                Tulemused[r, c] = 1;
            }
            else
            {
                b.Source = nolik;
                esimene = true;
                Tulemused[r, c] = 2;
            }
            grid3X3.Children.Add(b, c, r);
            Lopp();

        }
    }
}