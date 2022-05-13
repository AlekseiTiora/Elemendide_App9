using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Elemendide_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class europariigid : ContentPage
    {
        public ObservableCollection<riigid> riigi { get; set; }
        Label lbl_list;
        ListView list;
        Button Kustuta_btn, lisa_btn;
        public europariigid()
        {
            riigi = new ObservableCollection<riigid>
            {
                new riigid { Nimetus = "Soome", Pealinn = "Helsingi", Elanikkond = "1 328 439", Pilt = "finland.png" },
                new riigid { Nimetus = "Estonia", Pealinn = "Tallinn", Elanikkond = "5 595 981", Pilt = "estonia.png" },
                new riigid { Nimetus = "Venemaa", Pealinn = "Moskva", Elanikkond = "145 478 097", Pilt = "venemaa.png" },
                new riigid { Nimetus = "Ukraine", Pealinn = "Kiev", Elanikkond = "41 167 336", Pilt = "ukraine.png" }
            };
            lbl_list = new Label
            {
                Text = "Riigid",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            Kustuta_btn = new Button
            {
                Text = "Kustuta riik"
            };
            Kustuta_btn.Clicked += Kustuta_btn_Clicked;
            lisa_btn = new Button
            {
                Text = "Lisa riik"
            };
            lisa_btn.Clicked += Lisa_btn_Clicked;
            list = new ListView
            {
                SeparatorColor = Color.Aqua,
                Header = "Riik:",
                Footer = DateTime.Now.ToString("T"),

                HasUnevenRows = true,
                ItemsSource = riigi,
                ItemTemplate = new DataTemplate(() =>
                {
                    ImageCell imageCell = new ImageCell { TextColor = Color.Red, DetailColor = Color.Green };
                    imageCell.SetBinding(ImageCell.TextProperty, "Nimetus");
                    Binding companyBinding = new Binding { Path = "Pealinn", StringFormat = "Pealinn on: {0}" };
                    imageCell.SetBinding(ImageCell.DetailProperty, companyBinding);
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "Pilt");
                    return imageCell;
                })
            };
            list.ItemTapped += List_ItemTapped;
            this.Content = new StackLayout
            {
                Children = {
                    lbl_list, list,Kustuta_btn,lisa_btn }
            };
        }

        private async void Lisa_btn_Clicked(object sender, EventArgs e)
        {
            string Nimetus = await DisplayPromptAsync("Millise riigi soovite lisada?", "kirjuta siia:", keyboard: Keyboard.Text);
            string riik = await DisplayPromptAsync("Mis pealinn see on?", "kirjuta siia:", keyboard: Keyboard.Text);
            string elaniku = await DisplayPromptAsync("Kui palju inimesi seal elab?", "kirjuta siia:", keyboard: Keyboard.Telephone);
            string pilt = await DisplayPromptAsync("kirjuta lipu linki et saaks foto", "kirjuta siia:", keyboard: Keyboard.Text);

            if (Nimetus == "" || riik == "" || elaniku == "" || pilt == "") return;
            riigid newest = new riigid { Nimetus = Nimetus, Pealinn = riik, Elanikkond = elaniku, Pilt = pilt };
            foreach (riigid thing in riigi)
            {
                if (thing.Nimetus == newest.Nimetus)
                    return;
            }
            riigi.Add(item: newest);
        }


        private void Kustuta_btn_Clicked(object sender, EventArgs e)
        {
            riigid riig = list.SelectedItem as riigid;
            if (riig !=null)
            {
                riigi.Remove(riig);
                list.SelectedItem = null;
            }
        }

        private async void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            riigid selectedRiig = e.Item as riigid;
            if(selectedRiig !=null)
                await DisplayAlert("Valik Riig", $"Riik-{selectedRiig.Pealinn}, \nElannikkond-{selectedRiig.Elanikkond}", "OK");
        } 
    }
}