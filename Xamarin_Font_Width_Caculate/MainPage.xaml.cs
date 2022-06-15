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

        private FormattedString showFormattedText;
        public FormattedString ShowFormattedText { get => showFormattedText; private set { showFormattedText = value; OnPropertyChanged(); } }

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

        private string fontWidth;
        public string FontWidth { get => fontWidth; private set { fontWidth = value; OnPropertyChanged(); } }

        private string htmlString;
        public string HtmlString { get => htmlString; private set { htmlString = value; OnPropertyChanged(); } }

        public MainPage()
        {
            InitializeComponent();
            xMessageLabel.SizeChanged += SizeChangedEventHandler;
            BindingContext = this;
            ShowText = "こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！";



            FormattedString fs = "";
            fs.Spans.Add(new Span() { 
                Text= "こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！こにちは！",
                TextColor=Color.Red,
            });

            ShowFormattedText = fs;

            StringBuilder sbHtml = new StringBuilder();
            sbHtml.AppendLine($"<div style=\"background-color:DodgerBlue; height:100px;\">");
            sbHtml.AppendLine($"<span>");
            sbHtml.AppendLine($"hello world!");
            sbHtml.AppendLine($"</span>");
            sbHtml.AppendLine($"</div>");

            HtmlString = sbHtml.ToString();
        }

        

        protected override void OnAppearing()
        {
            base.OnAppearing();
            initData();
        }

        void initData()
        {
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            //(int) (mainDisplayInfo.Width / mainDisplayInfo.Density)


            ScreenSizePixel = $"{mainDisplayInfo.Width} x {mainDisplayInfo.Height}";
            ScreenSizeNoPixel = $"{Application.Current.MainPage.Width} x {Application.Current.MainPage.Width}";
            ScreenDensity = mainDisplayInfo.Density;


            
            MessageLabelWidth = $"{xMessageLabel.Width}";

            var service = DependencyService.Get<ICalculateTextWidthService>();

            var fw = service.calculateWidth("は", 20);
            FontWidth = $"{service.calculateWidth("は", 20)} / {service.calculateWidthPixel("は", 20)}" ;

            int labelWidth = 100;
            int maxLine = 2;
            int charatorSize = ((int)(labelWidth / fw)) * maxLine;

            ShowText = ShowText.Substring(0, charatorSize);

 

   
        }

        public void SizeChangedEventHandler(object sender, EventArgs e) {
            var label = sender as Label;
            var w = label.Width;
            MessageLabelWidth = MessageLabelWidth = $"SizeChanged : {w}"; ;
        }

































        

        private async void Button_Clicked(object sender, EventArgs e)
        {
           await Application.Current.MainPage.Navigation.PushAsync(new CarouselViewTestPage());
        }

        private async void Button2_Clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ListViewUnevenRowsTextPage());
        }

        private async void Button3_Clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new FlexLayoutTestPage());
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
