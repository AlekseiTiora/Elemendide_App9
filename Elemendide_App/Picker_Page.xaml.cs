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
    public partial class Picker_Page : ContentPage
    {
        Picker picker;
        WebView webView;
        StackLayout st;
        Entry entry;
        Button btn, btn2, btn3, btn4;
        string key = "";
        List<string> lehed = new List<string>()  { "https://tahvel.edu.ee/#/", "https://moodle.edu.ee/", "https://www.tthk.ee/", "https://www.google.com/", newUrl };
        public Picker_Page()
        {
            picker = new Picker
            {
                Title = "Webilehed"
            };
            picker.Items.Add("Tahvel");
            picker.Items.Add("Moodle");
            picker.Items.Add("tthk");
            picker.Items.Add("google");
            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;
            webView = new WebView
            { };

            entry = new Entry()
            {
                Placeholder = "Sisesta siia url"

            };
            btn2 = new Button
            {
                Text = "kodu",
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.End
            };
            btn3 = new Button
            {
                Text = "<-",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start
            };
            btn4 = new Button
            {
                Text = "->",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start
            };
            SwipeGestureRecognizer swipe = new SwipeGestureRecognizer();
            swipe.Swiped += Swipe_Swiped;
            swipe.Direction = SwipeDirection.Right;
            webView.GestureRecognizers.Add(swipe);
            btn2.Clicked += Btn2_Clicked;
            btn3.Clicked += Btn3_Clicked;
            entry.TextChanged += Ed_TextChanged;
            st = new StackLayout { Children = { picker, entry, btn2, btn3, btn4 } };
            Content = st;
        }

        private void Ed_TextChanged(object sender, TextChangedEventArgs e)
        {
            entry.TextChanged -= Ed_TextChanged;
            char key = e.NewTextValue?.Last() ?? ' ';
            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = key },
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            st.Children.Add(webView);
        }

        public async void Btn3_Clicked(object sender, EventArgs e)
        {
            if (webView.CanGoBack)
            {
                webView.GoBack();
            }
        }

        public async void Btn2_Clicked(object sender, EventArgs e)
        {
            if (webView != null)
            {
                st.Children.Remove(webView);
            }
            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = "https://www.google.ee" },
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            st.Children.Add(webView);
        }

        
        private void Swipe_Swiped(object sender, SwipedEventArgs e)
        {
            webView.Source = new UrlWebViewSource { Url = lehed[4] };
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (webView != null)
            {
                st.Children.Remove(webView);
            }
            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = lehed[picker.SelectedIndex] },
                VerticalOptions = LayoutOptions.FillAndExpand,

            };
            st.Children.Add(webView);
        }
    }
}
