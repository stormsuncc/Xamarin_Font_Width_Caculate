using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Xamarin_Font_Width_Caculate
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewUnevenRowsTextPage : ContentPage, INotifyPropertyChanged
    {

        private ImageSource imageUrl;
        public ImageSource ImageUrl
        {
            get => imageUrl; set
            {
                imageUrl = value; OnPropertyChanged();
            }
        }

        /**
         * https://cdn.braze.eu/appboy/communication/marketing/content_cards_message_variations/images/628afaa2dec9c61dd1d1967d/dae74c0a5690f52202f864dd141179213f2bbcda/original.png?1653275301
         * https://sptest4.club-off.com/Shain-rx/contents/files/bra/common/topics/apptest/0428/banner.jpg
         * https://sptest4.club-off.com/Shain-rx/contents/files/bra/common/topics/haseko/haseko_day/202102/img/off.jpg
        */
        public ObservableCollection<ImageSource> Images { set; get; } = new ObservableCollection<ImageSource>();

        string[] imgs = {
                        "https://sptest4.club-off.com/Shain-rx/contents/files/bra/common/topics/haseko/haseko_day/202102/img/off.jpg",
                        "https://sptest4.club-off.com/Shain-rx/contents/files/bra/common/topics/apptest/0428/banner.jpg",
                        "https://cdn.braze.eu/appboy/communication/marketing/content_cards_message_variations/images/628afaa2dec9c61dd1d1967d/dae74c0a5690f52202f864dd141179213f2bbcda/original.png?1653275301",
            };

        public ListViewUnevenRowsTextPage()
        {
            InitializeComponent();

            BindingContext = this;

            Images.Add(ImageSource.FromUri(new Uri(imgs[0])));
            Images.Add(ImageSource.FromUri(new Uri(imgs[1])));
            Images.Add(ImageSource.FromUri(new Uri(imgs[2])));

            var header = xListView.Header;
            var headerTemplate = xListView.HeaderTemplate;
            string sss = "";

            _resizeListViewHeader();

        }


        void _resizeListViewHeader()
        {

            Task.Run(async () =>
            {
                await Task.Delay(3000);


                MainThread.BeginInvokeOnMainThread(() =>
                {
                    //var header = (View)xListView.Header;
                    //header.HeightRequest = 100;
                    //header.BackgroundColor = Color.Red;
                    ImageUrl = imgs[2];
                });

            });

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