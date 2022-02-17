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
    public partial class StepperSlider_Page : ContentPage
    {
        
        Label lbl;
        Slider sld;
        Stepper stp;
        public StepperSlider_Page()
        {
            lbl = new Label();

            sld = new Slider
            {
                Minimum = 0,
                Maximum = 100,
                Value = 30,
                MinimumTrackColor = Color.White,
                MaximumTrackColor = Color.Black,
                ThumbColor = Color.Red
            };
            sld.ValueChanged += Sld_ValueChanged;
            stp = new Stepper
            {
                Minimum = 0,
                Maximum = 100,
                Increment = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.EndAndExpand
            };
            stp.ValueChanged += Stp_ValueChanged;
            StackLayout st = new StackLayout
            {
                Children = { lbl, sld, stp }
            };
            Content = st;
        }

        private void Stp_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lbl.Text = String.Format("Valitud {0:F1}", e.NewValue);
            lbl.FontSize = e.NewValue + 10;
            lbl.Rotation = e.NewValue;
        }

        private void Sld_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lbl.Text = String.Format("Valitud {0:F1}", e.NewValue);
            lbl.FontSize = e.NewValue + 10;
            lbl.Rotation = e.NewValue;
        }
    }
}