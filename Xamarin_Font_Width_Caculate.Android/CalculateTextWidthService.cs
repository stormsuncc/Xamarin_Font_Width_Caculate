using Android.Content.Res;
using Android.Widget;
using Xamarin.Forms;
using Xamarin_Font_Width_Caculate.Droid;

[assembly: Dependency(typeof(CalculateTextWidthService))]
namespace Xamarin_Font_Width_Caculate.Droid
{

    public class CalculateTextWidthService : ICalculateTextWidthService
    {
        public double calculateWidth(string text, int textSize)
        {
            TextView textView = new TextView(Android.App.Application.Context);
            textView.TextSize = textSize;
            var length = textView.Paint.MeasureText(text);
            return length / Resources.System.DisplayMetrics.ScaledDensity;
        }

        public double calculateWidthPixel(string text, int textSize)
        {
            TextView textView = new TextView(Android.App.Application.Context);
            textView.TextSize = textSize;
            return textView.Paint.MeasureText(text);
        }
    }
}