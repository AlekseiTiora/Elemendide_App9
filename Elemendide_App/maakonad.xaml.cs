using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Elemendide_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class maakonad : ContentPage
    {
        Picker p, p2;
        StackLayout st;
        WebView webView;
        List<string> lehed = new List<string>() { "https://visitharju.ee/ru/"
            , "https://et.wikipedia.org/wiki/J%C3%B5geva_maakond",
            "https://et.wikipedia.org/wiki/Hiiumaa",
            "https://et.wikipedia.org/wiki/Ida-Viru_maakond",
            "https://et.wikipedia.org/wiki/J%C3%A4rva_maakond",
            "https://et.wikipedia.org/wiki/L%C3%A4%C3%A4ne_maakond",
            "https://et.wikipedia.org/wiki/L%C3%A4%C3%A4ne-Viru_maakond",
            "https://et.wikipedia.org/wiki/P%C3%A4rnu_maakond",
            "https://et.wikipedia.org/wiki/P%C3%B5lva_maakond",
            "https://et.wikipedia.org/wiki/Rapla_maakond",
            "https://et.wikipedia.org/wiki/Saare_maakond",
            "https://et.wikipedia.org/wiki/Tartu_maakond",
            "https://et.wikipedia.org/wiki/Valga_maakond",
            "https://et.wikipedia.org/wiki/Viljandi_maakond",
            "https://et.wikipedia.org/wiki/V%C3%B5ru_maakond" };
        public maakonad()
        {

            p = new Picker
            {
                Title = "Maakonnad",
                VerticalOptions = LayoutOptions.Start

            };
            p.Items.Add("Harjumaa");
            p.Items.Add("Jõgevamaa");
            p.Items.Add("Hiiumaa");
            p.Items.Add("Ida-Virumaa");
            p.Items.Add("Järvamaa");
            p.Items.Add("Läänemaa");
            p.Items.Add("Lääne-Viruma");
            p.Items.Add("Pärnumaa");
            p.Items.Add("Põlvamaa");
            p.Items.Add("Raplamaa");
            p.Items.Add("Saaremaa");
            p.Items.Add("Tartumaa");
            p.Items.Add("Valgamaa");
            p.Items.Add("Viljandimaa");
            p.Items.Add("Võrumaa");
            p2 = new Picker
            {
                Title = "Maakonna pealinn"
            };
            p2.Items.Add("Tallinn");
            p2.Items.Add("Jõgeva");
            p2.Items.Add("Kärdla");
            p2.Items.Add("Jõhvi");
            p2.Items.Add("Paide");
            p2.Items.Add("Haapsalu");
            p2.Items.Add("Rakvere");
            p2.Items.Add("Pärnu");
            p2.Items.Add("Põlva");
            p2.Items.Add("Rapla");
            p2.Items.Add("Kuressaare");
            p2.Items.Add("Tartu");
            p2.Items.Add("Valga");
            p2.Items.Add("Viljandi");
            p2.Items.Add("Võru");
            webView = new WebView
            { };
            st = new StackLayout { Children = { p, p2 } };
            Content = st;

            p.SelectedIndexChanged += P_SelectedIndexChanged;
            p2.SelectedIndexChanged += P2_SelectedIndexChanged;
        }



        private async void P2_SelectedIndexChanged(object sender, EventArgs e)
        {
            p.SelectedIndex = p2.SelectedIndex;
            if (webView != null)
            {
                st.Children.Remove(webView);
            }
            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = lehed[p2.SelectedIndex] },
                VerticalOptions = LayoutOptions.End,
            };
            st.Children.Add(webView);
        }
        private async void P_SelectedIndexChanged(object sender, EventArgs e)
        {
            p2.SelectedIndex = p.SelectedIndex;
                if (webView != null)
                {
                    st.Children.Remove(webView);
                }
                webView = new WebView
                {
                    Source = new UrlWebViewSource { Url = lehed[p.SelectedIndex] },
                    VerticalOptions = LayoutOptions.FillAndExpand,
                };
                st.Children.Add(webView);

        }
    }
}