using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Xamarin_Font_Width_Caculate
{
    public class MyLabel : Label
    {
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            Console.WriteLine($"触发方法 [OnSizeAllocated] : [{width} x {height}]");
            resizeText();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            Console.WriteLine($"触发方法 [OnPropertyChanged] : [{propertyName}]");

            if(propertyName != null && (propertyName.Equals(nameof(Text)) | propertyName.Equals(nameof(FontSize))))
            {
                resizeText();
                
            }
        }

        void resizeText()
        {
            // linewidth * 2 / fontsize 
        }

    }
}
