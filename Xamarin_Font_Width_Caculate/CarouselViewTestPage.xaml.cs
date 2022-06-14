using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin_Font_Width_Caculate
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarouselViewTestPage : ContentPage
    {
        public ObservableCollection<string> Datas { get; set; } = new ObservableCollection<string>();

        public CarouselViewTestPage()
        {
            InitializeComponent();
            BindingContext = this;

            for (int i = 0; i < 20; i ++)
            {
                Datas.Add($"datas[{i}]");
            }
        }
    }
}