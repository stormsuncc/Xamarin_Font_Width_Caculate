using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Xamarin_Font_Width_Caculate
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private string showText;
        public string ShowText { get => showText; private set { showText = value;  OnPropertyChanged(); } }
        /// <summary>
        /// 屏幕宽高 (in pixels)
        /// </summary>
        private string screenSizePixel;
        public String ScreenSizePixel { get => screenSizePixel; private set { screenSizePixel = value; OnPropertyChanged(); } }

        private string screenSizeNoPixel;
        public String ScreenSizeNoPixel { get => screenSizeNoPixel; private set { screenSizeNoPixel = value; OnPropertyChanged(); } }

        private double screenDensity;
        public double ScreenDensity { get => screenDensity; private set { screenDensity = value; OnPropertyChanged(); } }

        private string messageLabelWidth;
        public String MessageLabelWidth { get => messageLabelWidth; private set { messageLabelWidth = value; OnPropertyChanged(); } }

        private double fontWidth;
        public double FontWidth { get => fontWidth; private set { fontWidth = value; OnPropertyChanged(); } }

        public MainPage()
        {
            InitializeComponent();
            xMessageLabel.SizeChanged += SizeChangedEventHandler;
            BindingContext = this;
            ShowText = "こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！";
            
        }

        

        protected override void OnAppearing()
        {
            base.OnAppearing();
            initData();
        }

        void initData()
        {
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            ScreenSizePixel = $"{mainDisplayInfo.Width} x {mainDisplayInfo.Height}";
            ScreenSizeNoPixel = $"{Application.Current.MainPage.Width} x {Application.Current.MainPage.Width}";
            ScreenDensity = mainDisplayInfo.Density;


            
            MessageLabelWidth = $"{xMessageLabel.Width}";

            var service = DependencyService.Get<ICalculateTextWidthService>();
            FontWidth = service.calculateWidth("は", 20);

            int labelWidth = 100;
            int maxLine = 2;
            int charatorSize = ((int)(labelWidth / fontWidth)) * maxLine;

            ShowText = ShowText.Substring(0, charatorSize);

 

   
        }

        public void SizeChangedEventHandler(object sender, EventArgs e) {
            var label = sender as Label;
            var w = label.Width;
            MessageLabelWidth = MessageLabelWidth = $"SizeChanged : {w}"; ;
        }

































        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
