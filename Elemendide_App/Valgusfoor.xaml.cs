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
    public partial class Valgusfoor : ContentPage
    {
        Frame fr;
        Frame fr2;
        Frame fr3;
        Label lbl;
        Label lbl1;
        Label lbl2;
        Label lbl3;
        Button btn;
        Button btn1;
        bool bl = false;
        public Valgusfoor()
        {
            lbl = new Label()
            {
                Text = "Valgusfoor",
                BackgroundColor = Color.Black,
                TextColor = Color.White
            };
            lbl1 = new Label()
            {
                Text = "Punane",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            fr = new Frame
            {
                Content = lbl1,
                WidthRequest = 200,
                HeightRequest = 200,
                BackgroundColor = Color.Gray,
                CornerRadius = 1000,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center

            };
            lbl2 = new Label()
            {
                Text = "Kollane",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            fr2 = new Frame
            {
                Content=lbl2,
                WidthRequest = 200,
                HeightRequest = 200,
                BackgroundColor = Color.Gray,
                CornerRadius = 1000,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center

            };
            lbl3 = new Label()
            {
                Text = "rohaline",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            fr3 = new Frame
            {
                Content=lbl3,
                WidthRequest = 200,
                HeightRequest = 200,
                BackgroundColor = Color.Gray,
                CornerRadius = 1000,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center

            };

            btn = new Button
            {
                Text = "Sisse",
                HorizontalOptions=LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start
            };
            btn.Clicked += Btn_Clicked;

            btn1 = new Button
            {
                Text = "Välja",
                HorizontalOptions = LayoutOptions.End
            };
            btn1.Clicked += Btn1_Clicked;

            StackLayout st = new StackLayout
            {
                Children = { lbl,fr,fr2,fr3,btn,btn1 }
            };
            Content = st;
        }

        private void Btn1_Clicked(object sender, EventArgs e)
        {
                bl = false;
                fr.BackgroundColor = Color.Gray;
                fr2.BackgroundColor = Color.Gray;
                fr3.BackgroundColor = Color.Gray;
        }

        private async void Btn_Clicked(object sender, EventArgs e)
        {
            bl = true;
            while(true)
            { 
                fr.BackgroundColor = Color.Red;
                await Task.Delay(1000);
                fr.BackgroundColor = Color.Gray;
                fr2.BackgroundColor = Color.Yellow;
                await Task.Delay(1000);

                fr2.BackgroundColor = Color.Gray;
                fr3.BackgroundColor = Color.Green;
                await Task.Delay(1000);
                fr3.BackgroundColor = Color.Gray;
                fr.BackgroundColor = Color.Red;

 
            }


        }
    }
}