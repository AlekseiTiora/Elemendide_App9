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
    public partial class rgb : ContentPage
    {
        Label lbl;
        Label lbl2;
        Label lbl3;
        //---------
        Slider sld;
        Slider sld2;
        Slider sld3;
        //---------
        Stepper stp;
        Stepper stp2;
        Stepper stp3;
        //---------
        Button btn;
        BoxView box;

        public rgb()
        {
            lbl = new Label();
            lbl2 = new Label();
            lbl3 = new Label();
            box = new BoxView()
            {
                Color = Color.Black,
                WidthRequest = 400,
                HeightRequest = 350,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            sld = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 30,

                MinimumTrackColor = Color.White,
                MaximumTrackColor = Color.Black,
                ThumbColor = Color.Red
            };
            sld.ValueChanged += OnSlideValueChanged;

            sld2 = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 30,

                MinimumTrackColor = Color.White,
                MaximumTrackColor = Color.Black,
                ThumbColor = Color.Green
            };
            sld2.ValueChanged += OnSlideValueChanged;

            sld3 = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 30,
                MinimumTrackColor = Color.White,
                MaximumTrackColor = Color.Black,
                ThumbColor = Color.Blue
            };
            sld3.ValueChanged += OnSlideValueChanged;

            stp = new Stepper
            {
                Minimum = 0,
                Maximum = 255,
                Increment = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.EndAndExpand
            };
            stp.ValueChanged += Stp_ValueChanged;

            stp2 = new Stepper
            {
                Minimum = 0,
                Maximum = 255,
                Increment = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.EndAndExpand
            };
            stp2.ValueChanged += Stp_ValueChanged;

            stp3 = new Stepper
            {
                Minimum = 0,
                Maximum = 255,
                Increment = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.EndAndExpand
            };
            stp3.ValueChanged += Stp_ValueChanged;

            btn = new Button
            {
                Text = "random",
            };
            btn.Clicked += Btn_Clicked;


            

            StackLayout st = new StackLayout { Children = { box,sld,lbl,sld2,lbl2,sld3,lbl3,stp,stp2,stp3,btn } };
            Content = st;

            

        }

        private void Stp_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (sender == stp)
            {
                lbl.Text = String.Format("Red = {0:X2}", (int)e.NewValue);
                sld.Value = stp.Value;
            }
            else if (sender == stp2)
            {
                lbl2.Text = String.Format("Green = {0:X2}", (int)e.NewValue);
                sld2.Value = stp2.Value;
            }
            else if (sender == stp3)
            {
                lbl3.Text = String.Format("Blue = {0:X2}", (int)e.NewValue);
                sld3.Value = stp3.Value;
            }

            box.Color = Color.FromRgb((int)stp.Value,
                          (int)stp2.Value,
                          (int)stp3.Value);
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            Random r = new Random();
            box.Color = Color.FromRgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
            
            
        }

        private void OnSlideValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (sender == sld)
            {
                lbl.Text = String.Format("Red = {0:X2}", (int)e.NewValue);
            }
            else if ( sender == sld2)
            {
                lbl2.Text = String.Format("Green = {0:X2}", (int)e.NewValue);
            }
            else if ( sender == sld3)
            {
                lbl3.Text = String.Format("Blue = {0:X2}", (int)e.NewValue);
            }



            box.Color = Color.FromRgb((int)sld.Value,
                                      (int)sld2.Value,
                                      (int)sld3.Value);            
        }
    }
}