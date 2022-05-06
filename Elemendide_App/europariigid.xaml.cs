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
                new riigid { Nimetus = "Finland", Pealinn = "Samsung", Elanikkond = 1249, Pilt = "s22.png" },
                new riigid { Nimetus = "Estonia", Pealinn = "Samsung", Elanikkond = 1249, Pilt = "s22.png" },
                new riigid { Nimetus = "Venemaa", Pealinn = "Samsung", Elanikkond = 1249, Pilt = "s22.png" },
                new riigid { Nimetus = "Ukraine", Pealinn = "Samsung", Elanikkond = 1249, Pilt = "s22.png" }
            };
        }
    }
}