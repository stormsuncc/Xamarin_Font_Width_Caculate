using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;

namespace Xamarin_Font_Width_Caculate.iOS
{
    public class CalculateTextWidthService : ICalculateTextWidthService
    {
        public double calculateWidth(string text, int textSize)
        {
            var uiLabel = new UILabel();
            uiLabel.Text = text;
            uiLabel.Font = uiLabel.Font.WithSize(textSize);
            var length = uiLabel.Text.StringSize(uiLabel.Font);
            return length.Width;
        }

        public double calculateWidth(string text)
        {
            var uiLabel = new UILabel();
            uiLabel.Text = text;
            var length = uiLabel.Text.StringSize(uiLabel.Font);
            return length.Width;
        }

        public double calculateWidthPixel(string text, int textSize)
        {
            var uiLabel = new UILabel();
            var font = uiLabel.Font.WithSize(textSize);
            var attrs = new UIStringAttributes() {
                Font = font,
            };
            var size  = new NSString(text).GetSizeUsingAttributes(attrs);

            return size.Width;
        }
    }
}