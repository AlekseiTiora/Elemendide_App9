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
    public partial class List_Page : ContentPage
    {
        public ObservableCollection<Telefon> telefons { get; set; }
        Label lbl_list;
        ListView list;
        Button Kustuta_btn, lisa_btn;
        public List_Page()
        {
            telefons = new ObservableCollection<Telefon>
            {
                new Telefon {Nimetus="Samsung Galaxy S22", Tootja ="Samsung", Hind=1249, Pilt ="s22.png" },
                new Telefon {Nimetus="Sony XA1", Tootja ="Sony", Hind=250, Pilt ="xa1.png" },
                new Telefon {Nimetus="Xiaomi Mi 11 Lite 5G", Tootja ="Xiaomi", Hind=339, Pilt ="lite11.png" },
                new Telefon {Nimetus="iPhone 13", Tootja ="Apple", Hind=1179, Pilt ="iphone.png" }
            };
            lbl_list = new Label
            {
                Text="Telefonide loetelu",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            Kustuta_btn = new Button
            {
                Text="Kustuta telefon"
            };
            Kustuta_btn.Clicked += Kustuta_btn_Clicked;
            lisa_btn = new Button
            {
                Text = "Lisa telefon"
            };
            lisa_btn.Clicked += Lisa_btn_Clicked;
            list = new ListView
            {
                SeparatorColor = Color.Aqua,
                Header = "Minu kolektion:",
                Footer = DateTime.Now.ToString("T"),

                HasUnevenRows = true,
                ItemsSource = telefons,
                ItemTemplate = new DataTemplate(()=>
                {
                    ImageCell imageCell = new ImageCell { TextColor = Color.Red, DetailColor = Color.Green };
                    imageCell.SetBinding(ImageCell.TextProperty, "Nimetus");
                    Binding companyBinding = new Binding { Path = "Tootja", StringFormat = "Tore telefon firmalt {0}" };
                    imageCell.SetBinding(ImageCell.DetailProperty, companyBinding);
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "Pilt");
                    return imageCell;
                })
            };
            //list.ItemSelected += List_ItemSelected;
            list.ItemTapped += List_ItemTapped;
            this.Content = new StackLayout { Children = { 
                    lbl_list, list,Kustuta_btn,lisa_btn } };
        }

        private void Lisa_btn_Clicked(object sender, EventArgs e)
        {
            telefons.Add(new Telefon { Nimetus = "Telefon", Tootja = "Tootja", Hind = 1 });
        }

        private void Kustuta_btn_Clicked(object sender, EventArgs e)
        {
            Telefon phone = list.SelectedItem as Telefon;
            if(phone !=null)
            {
                telefons.Remove(phone);
                list.SelectedItem = null;
            }
        }

        private async void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Telefon selectedPhone = e.Item as Telefon;
            if (selectedPhone != null)
                await DisplayAlert("Выбранная модель", $"{selectedPhone.Tootja} -{selectedPhone.Nimetus}", "OK");
        }

        private void List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                lbl_list.Text = e.SelectedItem.ToString();
        }
    }
}