using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin_Font_Width_Caculate
{
    public interface ICalculateTextWidthService
    {
        double calculateWidth(string text, int textSize);
        double calculateWidthPixel(string text, int textSize);
    }
}
