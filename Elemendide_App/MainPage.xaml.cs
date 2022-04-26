using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Elemendide_App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            //InitializeComponent();
            StackLayout st = new StackLayout();
           /* Button Ent_btn = new Button()
            {
                Text = "Entry",
                BackgroundColor = Color.LightCoral,
            };

            Button Timer_btn = new Button()
            {
                Text = "Timer",
                BackgroundColor = Color.LightCoral,
            };*/
            Button cliker = new Button()
            {
                Text = "Clicker",
                BackgroundColor = Color.LightCoral,
            };

            Button Date_btn = new Button
            {
                Text = "Date/Time",
                BackgroundColor = Color.LightCoral,
            };

            /*Button SS_btn = new Button
            {
                Text = "Stepper/Slider",
                BackgroundColor = Color.LightCoral,
            };*/
           /* Button frame_btn = new Button
            {
                Text = "Frame",
                BackgroundColor = Color.LightCoral,
            };*/
            Button image_btn = new Button
            {
                Text = "image",
                BackgroundColor = Color.LightCoral,
            };
            Button svet_btn = new Button
            {
                Text = "valgusfoor",
                BackgroundColor = Color.LightCoral,
            };
            Button rgb_btn = new Button
            {
                Text = "rgb color",
                BackgroundColor = Color.LightCoral,
            };
            Button trips_btn = new Button
            {
                Text= "TripsTrapsnull",
                BackgroundColor = Color.LightCoral
            };
            Button table_page = new Button
            {
                Text = "table_page",
                BackgroundColor = Color.LawnGreen
            };
            Button maakonad_btn = new Button
            {
                Text = "maakonad",
                BackgroundColor = Color.LawnGreen
            };
            Button horoskop_btn = new Button
            {
                Text = "horoskop",
                BackgroundColor = Color.LawnGreen
            };
            Button list_page = new Button
            {
                Text = "List Page",
                BackgroundColor = Color.LawnGreen
            };



            /*st.Children.Add(Ent_btn);
            st.Children.Add(Timer_btn);*/
            st.Children.Add(cliker);
            st.Children.Add(Date_btn);
            //st.Children.Add(SS_btn);
            //st.Children.Add(frame_btn);
            st.Children.Add(image_btn);
            st.Children.Add(svet_btn);
            st.Children.Add(rgb_btn);
            st.Children.Add(trips_btn);
            st.Children.Add(table_page);
            st.Children.Add(maakonad_btn);
            st.Children.Add(horoskop_btn);
            st.Children.Add(list_page);
            st.BackgroundColor = Color.AntiqueWhite;
            Content = st;
            /*Ent_btn.Clicked += Ent_btn_Clicked;
            Timer_btn.Clicked += Timer_btn_Clicked;*/
            cliker.Clicked += Cliker_Clicked;
            Date_btn.Clicked += Date_btn_Clicked;
           // SS_btn.Clicked += SS_btn_Clicked;
            //frame_btn.Clicked += Frame_btn_Clicked;
            image_btn.Clicked += Image_btn_Clicked;
            svet_btn.Clicked += Svet_btn_Clicked;
            rgb_btn.Clicked += Rgb_btn_Clicked;
            trips_btn.Clicked += Trips_btn_Clicked;
            table_page.Clicked += Table_page_Clicked;
            maakonad_btn.Clicked += Maakonad_btn_Clicked;
            horoskop_btn.Clicked += Horoskop_btn_Clicked;
            list_page.Clicked += List_page_Clicked;
        }

        private async void List_page_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new List_Page());
        }

        private async void Horoskop_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new horoskop());
        }

        private async void Maakonad_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new maakonad());
        }

        private async void Table_page_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Picker_Page());
        }

        private async void Trips_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new tripstrapsnull());
        }

        private async void Rgb_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new rgb());
        }

        private async void Svet_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Valgusfoor());
        }

        private async void Image_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Image_Page());
        }

        private async void Frame_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Frame_Page());
        }

        private async void SS_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StepperSlider_Page());
        }

        private async void Date_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DateTime_Page());
        }

        private async void Cliker_Clicked(object sender, EventArgs e)
        {
             await Navigation.PushAsync(new cliker());
        }

        private async void Timer_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TimerPage());
        }

        private async void Ent_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Ent_page());
        }
    }
    
}
