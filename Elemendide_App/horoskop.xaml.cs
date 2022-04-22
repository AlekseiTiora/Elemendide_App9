﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Elemendide_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class horoskop : ContentPage
    {
        Label lbl;
        DatePicker dp;
        StackLayout st;
        Image img;
        Button btn;
        WebView webView;

        int link = 0;
        List<string> lehed = new List<string>() {
            "https://ru.wikipedia.org/wiki/%D0%9A%D0%BE%D0%B7%D0%B5%D1%80%D0%BE%D0%B3_(%D0%B7%D0%BD%D0%B0%D0%BA_%D0%B7%D0%BE%D0%B4%D0%B8%D0%B0%D0%BA%D0%B0)",
            "https://ru.wikipedia.org/wiki/%D0%9E%D0%B2%D0%B5%D0%BD_(%D0%B7%D0%BD%D0%B0%D0%BA_%D0%B7%D0%BE%D0%B4%D0%B8%D0%B0%D0%BA%D0%B0)",
            "https://ru.wikipedia.org/wiki/%D0%A2%D0%B5%D0%BB%D0%B5%D1%86_(%D0%B7%D0%BD%D0%B0%D0%BA_%D0%B7%D0%BE%D0%B4%D0%B8%D0%B0%D0%BA%D0%B0)",
            "https://ru.wikipedia.org/wiki/%D0%91%D0%BB%D0%B8%D0%B7%D0%BD%D0%B5%D1%86%D1%8B_(%D0%B7%D0%BD%D0%B0%D0%BA_%D0%B7%D0%BE%D0%B4%D0%B8%D0%B0%D0%BA%D0%B0)",
            "https://ru.wikipedia.org/wiki/%D0%A0%D0%B0%D0%BA_(%D0%B7%D0%BD%D0%B0%D0%BA_%D0%B7%D0%BE%D0%B4%D0%B8%D0%B0%D0%BA%D0%B0)",
            "https://ru.wikipedia.org/wiki/%D0%9B%D0%B5%D0%B2_(%D0%B7%D0%BD%D0%B0%D0%BA_%D0%B7%D0%BE%D0%B4%D0%B8%D0%B0%D0%BA%D0%B0)",
            "https://ru.wikipedia.org/wiki/%D0%94%D0%B5%D0%B2%D0%B0_(%D0%B7%D0%BD%D0%B0%D0%BA_%D0%B7%D0%BE%D0%B4%D0%B8%D0%B0%D0%BA%D0%B0)",
            "https://ru.wikipedia.org/wiki/%D0%92%D0%B5%D1%81%D1%8B_(%D0%B7%D0%BD%D0%B0%D0%BA_%D0%B7%D0%BE%D0%B4%D0%B8%D0%B0%D0%BA%D0%B0)",
            "https://ru.wikipedia.org/wiki/%D0%A1%D0%BA%D0%BE%D1%80%D0%BF%D0%B8%D0%BE%D0%BD_(%D0%B7%D0%BD%D0%B0%D0%BA_%D0%B7%D0%BE%D0%B4%D0%B8%D0%B0%D0%BA%D0%B0)",
            "https://ru.wikipedia.org/wiki/%D0%A1%D1%82%D1%80%D0%B5%D0%BB%D0%B5%D1%86_(%D0%B7%D0%BD%D0%B0%D0%BA_%D0%B7%D0%BE%D0%B4%D0%B8%D0%B0%D0%BA%D0%B0)",
            "https://ru.wikipedia.org/wiki/%D0%92%D0%BE%D0%B4%D0%BE%D0%BB%D0%B5%D0%B9_(%D0%B7%D0%BD%D0%B0%D0%BA_%D0%B7%D0%BE%D0%B4%D0%B8%D0%B0%D0%BA%D0%B0)",
            "https://ru.wikipedia.org/wiki/%D0%A0%D1%8B%D0%B1%D1%8B_(%D0%B7%D0%BD%D0%B0%D0%BA_%D0%B7%D0%BE%D0%B4%D0%B8%D0%B0%D0%BA%D0%B0)"
        };

        public horoskop()
        {
            dp = new DatePicker()
            {
                Format = "D",
                TextColor = Color.Black,
                BackgroundColor = Color.White

            };
            lbl = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                TextColor = Color.Black,
            };
            img = new Image
            {

            };
            webView = new WebView
            {

            };
            btn = new Button
            {
                Text = "rohkem informatsiooni"
            };
            btn.IsVisible = false;
            btn.Clicked += Btn_Clicked;
            dp.DateSelected += Dp_DateSelected;
            st = new StackLayout { Children = { dp,lbl,img,btn } };
            Content = st;
        }

        private async void Btn_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync(lehed[index: link]);
        }

        private void Dp_DateSelected(object sender, DateChangedEventArgs e)
        {
            var m = e.NewDate.Month;
            var d = e.NewDate.Day;
            if (m == 1 && d >= 1 && d <= 20 || m == 12 && d <= 22)
            {
                img.Source = new UriImageSource
                {
                    Uri = new System.Uri("https://pngimg.com/uploads/capricorn/capricorn_PNG99.png"),

                };
                link = 0;
                lbl.Text = "Скорпионам в 2022 году нужно будет много трудиться, чтобы достичь желаемого. Удачный период для представителей знака — с января по май и ноябрь-декабрь." +
                    " В личной жизни возможны трудности, но и удачные шансы тоже будут. Например, свободные Скорпионы смогут найти новую любовь." +
                    " Повезет и тем, кто захочет избавиться от исчерпавших себя отношений. Самое удачное время для любви — июль и август";

                btn.IsVisible = true;


            }
            if (m == 3 && d >= 21 && d <= 31 || m == 4 && d <= 19)
            {
                img.Source = new UriImageSource
                {
                    Uri = new System.Uri("https://pngimg.com/uploads/aries/aries_PNG58.png")
                };
                link = 1;
                lbl.Text = "В 2022 году Овнов ждёт гармония во всех областях жизни. Их по праву можно назвать везунчиками этого времени, ведь кризисных периодов не предвидится." +
                    " Самый благоприятный для представителей знака период — вторая половина года, с конца весны по ноябрь. В это время представителей знака ожидает карьерный рост, улучшение финансовой сферы, везение в личной жизни." +
                    " Кроме того, этот момент удачен для реализации самых смелых идей. Летом Овнов ожидает период, благоприятный для создания отношений и работы над ними. Вероятны новые знакомства и бурные романы, или укрепление уже существующих связей.";

                btn.IsVisible = true;
            }
            if (m == 4 && d >= 21 && d <= 30 || m == 5 && d <= 20)
            {
                img.Source = new UriImageSource
                {
                    Uri = new System.Uri("https://pngimg.com/uploads/taurus/taurus_PNG61.png")
                };
                link = 2;
                lbl.Text = "Тельца в 2022 году ждет чередование спокойных и интенсивных периодов течения жизни. Стоит приготовиться к тому, что первые два месяца зимы могут быть сложными для многих сфер жизни. Гармоничный период — весна" +
                    ". В это время Тельцам будет везти в финансах и вопросах карьеры. Летом рекомендуется знакомиться с новыми людьми или работать над существующими отношениями." +
                    " Жизненные трудности могут возникнуть в сентябре и в ноябре. В последний месяц осени может возникнуть нестабильность в личной жизни, но она компенсируется везением в финансах и карьере.";

                btn.IsVisible = true;
            }
            if (m == 5 && d >= 21 && d <= 31 || m == 6 && d <= 20)
            {
                img.Source = new UriImageSource
                {

                    Uri = new System.Uri("https://pngimg.com/uploads/gemini/gemini_PNG40.png")
                };
                link = 3;
                lbl.Text = "С января по май Близнецов ждет время приложения интенсивных усилий в работе, когда представители знака будут стремиться к достижению целей. Несмотря на трудности в работе, в этот период представителям воздушной стихии будет везти в любви." +
                    " С мая по ноябрь Близнецы будут удачливы в начинаниях, возникнет ощущение, что Фортуна на их стороне." +
                    " В течение года не стоит впадать в иллюзии, стоит решать свои проблемы здраво и рационально." +
                    " Есть небольшой риск обманов со стороны партнёров и коллег по бизнесу — рекомендуется фильтровать окружение, оставляя в нем только тех, кому можно доверять.";

                btn.IsVisible = true;
            }
            if (m == 6 && d >= 21 && d <= 30 || m == 7 && d <= 22)
            {
                img.Source = new UriImageSource
                {
                    Uri = new System.Uri("https://pngimg.com/uploads/cancer_zodiac/cancer_zodiac_PNG45.png")
                };
                link = 4;
                lbl.Text = "Для Раков год будет благоприятен для того, чтобы решиться на перемены, сменить место жительства и совершить путешествия в новые места." +
                    " Сложностей и кризисов не ожидается. Во многих сферах жизни Раков ждет удача в периоды с января по май, а также в ноябре-декабре." +
                    " В это время возможны бонусы, подарки, улучшение финансовой ситуации, карьерный взлёт. В конце весны — начале лета представители знака сфокусируются на личной жизни, которая будет приносить им яркие эмоции.";

                btn.IsVisible = true;
            }
            if (m == 7 && d >= 23 && d <= 31 || m == 8 && d <= 20)
            {
                img.Source = new UriImageSource
                {
                    Uri = new System.Uri("https://pngimg.com/uploads/leo/leo_PNG42.png")
                };
                link = 5;
                lbl.Text = "Львов ждёт решающий год, когда многое может измениться. Необходимо много трудиться, возможны ситуации, когда придётся чем-то жертвовать." +
                    " С мая по ноябрь представителей знака ждёт благоприятный период, когда все предыдущие усилия оправдают себя. Жизнь заставит внести коррективы не только в профессиональную сферу, но и в отношения" +
                    ". Возможны трудности в любви в марте и апреле, но уже в мае-июне вопросы личной жизни наладятся. С августа и до конца года сложностей в отношениях не предвидится, наступает период гармонии и взаимопонимания с партнёром.";

                btn.IsVisible = true;
            }
            if (m == 8 && d >= 23 && d <= 31 || m == 9 && d <= 20)
            {
                img.Source = new UriImageSource
                {
                    Uri = new System.Uri("https://pngimg.com/uploads/virgo/virgo_PNG61.png")
                };
                link = 6;
                lbl.Text = "Девам рекомендуется пересмотреть свою жизнь в 2022 году, любые перемены будут реализовываться легко." +
                    " С января по май и с ноября по декабрь может ощущаться напряжение. В этот период Девам будет сложно реализовать свои амбиции. Возможно, придется жертвовать социальными достижениями, направляя свои усилия в сферу личной жизни." +
                    " В апреле в этой сфере будет непросто, есть риск расставаний." +
                    " Однако уже летом свободных Дев ждут новые знакомства. Представители знака, которые находятся в отношениях, смогут их укрепить. Особенно благоприятно время с июня по август.";

                btn.IsVisible = true;
            }
            if (m == 9 && d >= 22 && d <= 31 || m == 10 && d <= 21)
            {
                img.Source = new UriImageSource
                {

                    Uri = new System.Uri("https://pngimg.com/uploads/libra/libra_PNG47.png")
                };
                link = 7;
                lbl.Text = "Весов в 2022 году ожидает успех в карьере, однако крупные достижения возможны только если представители знака будут прикладывать к этому свои личные усилия. С мая по ноябрь возможны трудности, ощущение того, что нет удачи в делах." +
                    " Однако стоит сконцентрироваться на той сфере, которая в этот период на фоне остальных выглядит успешной — это отношения. " +
                    "Рекомендуется использовать это время для новых знакомств, укрепления отношений или вступления в брак.";

                btn.IsVisible = true;
            }
            if (m == 10 && d >= 22 && d <= 30 || m == 11 && d <= 20)
            {
                img.Source = new UriImageSource
                {

                    Uri = new System.Uri("https://pngimg.com/uploads/scorpio/scorpio_PNG49.png")
                };
                link = 8;
                lbl.Text = "Скорпионам в 2022 году нужно будет много трудиться, чтобы достичь желаемого." +
                    " Удачный период для представителей знака — с января по май и ноябрь-декабрь. В личной жизни возможны трудности, но и удачные шансы тоже будут." +
                    " Например, свободные Скорпионы смогут найти новую любовь. Повезет и тем, кто захочет избавиться от исчерпавших себя отношений. Самое удачное время для любви — июль и август.";

                btn.IsVisible = true;
            }
            if (m == 11 && d >= 21 && d <= 31 || m == 12 && d <= 21)
            {
                img.Source = new UriImageSource
                {

                    Uri = new System.Uri("https://pngimg.com/uploads/sagittarius/sagittarius_PNG78.png")
                };
                link = 9;
                lbl.Text = "Для Стрельцов год будет благоприятным. Особенная удача ожидает представителей знака в вопросах карьеры. " +
                    "С мая по ноябрь Стрельцов ждут подарки судьбы, привилегии и бонусы в самых разных сферах жизни." +
                    " В этот период рекомендуется запуск проектов и участие в крупных мероприятиях. В личной жизни Стрельцам повезёт весной, в конце лета и в последние месяцы осени. " +
                    "В это время есть шансы наладить личную жизнь, встретить свою вторую половинку и заключить брак.";

                btn.IsVisible = true;
            }
            if (m == 1 && d >= 20 && d <= 30 || m == 2 && d <= 18)
            {
                img.Source = new UriImageSource
                {

                    Uri = new System.Uri("https://pngimg.com/uploads/aquarius/aquarius_PNG33.png")
                };
                link = 10;
                lbl.Text = "Водолеев ожидает год интенсивной работы. " +
                    "Возникнет необходимость изменений деятельности, но они будут даваться сложно, возникнет ощущение наличия внешних препятствий. Однако не стоит отчаиваться, с мая по ноябрь представителей знака ждёт удача во всех делах. " +
                    "На фоне загруженности в профессии, многим Водолеям уже к весне захочется легкости и новизны в любовной сфере. Для гармонизации личной жизни благоприятны май, июль и осенние месяцы до самого нового года.";

                btn.IsVisible = true;
            }
            if (m == 2 && d >= 19 && d <= 30 || m == 3 && d <= 20)
            {
                img.Source = new UriImageSource
                {

                    Uri = new System.Uri("https://pngimg.com/uploads/pisces/pisces_PNG50.png")
                };
                link = 11;
                lbl.Text = "Рыбы в 2022 году будут любимчиками фортуны. Это благоприятное время для развития, создания новых проектов и обновления жизни. " +
                    "Особенно удачный для этого период ожидается в первые четыре месяца года, а также с ноября по декабрь. Рыбам не стоит бояться кризисов и серьезных испытаний, год пройдет спокойно." +
                    " Такая же удача ждёт представителей знака и в личной жизни. Это прекрасное время для того, чтобы знакомиться, создавать отношения или работать над уже существующими.";

                btn.IsVisible = true;
            }
        }
    }
}