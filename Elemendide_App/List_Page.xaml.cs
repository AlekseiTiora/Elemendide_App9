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
    public partial class List_Page : ContentPage
    {
        public List<Telefon> telefons { get; set; }
        Label lbl_list;
        ListView list;
        public List_Page()
        {
            telefons = new List<Telefon>
            {
                new Telefon {Nimetus="Samsung Galaxy S22", Tootja ="Samsung", Hind=1249},
                new Telefon {Nimetus="Xiaomi Mi 11 Lite 5G NE", Tootja ="Xiaomi", Hind=399},
                new Telefon {Nimetus="Xiaomi Mi 11 Lite 5G", Tootja ="Xiaomi", Hind=339},
                new Telefon {Nimetus="iPhnoe 13", Tootja ="Apple", Hind=1179}
            };
            lbl_list = new Label
            {
                Text="Telefonide loetelu",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            list = new ListView
            {
                HasUnevenRows = true,
                ItemsSource = telefons,
                ItemTemplate = new DataTemplate(()=>
                {
                    Label nimetus = new Label { FontSize = 20 };
                    nimetus.SetBinding(Label.TextProperty, "Nimetus");

                    Label tootja = new Label();
                    tootja.SetBinding(Label.TextProperty, "Tootja");

                    Label hind = new Label();
                    hind.SetBinding(Label.TextProperty, "Hind");

                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0,5),
                            Orientation = StackOrientation.Vertical,
                            Children = {nimetus,tootja,hind}
                        }
                    };
                })
            };
            //list.ItemSelected += List_ItemSelected;
            list.ItemTapped += List_ItemTapped;
            this.Content = new StackLayout { Children = { lbl_list, list } };
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