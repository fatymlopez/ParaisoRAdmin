using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ParaisoRealA.Controllers
{
    public class CtrlEntry : Entry
    {
        public CtrlEntry()
        {
            this.HeightRequest = 50;
        }

        public static readonly BindableProperty ImageProperty = BindableProperty.Create(nameof(Image), typeof(string),
          typeof(CtrlEntry), string.Empty);



        public static readonly BindableProperty LineColorProperty = BindableProperty.Create(nameof(LineColor), typeof(Xamarin.Forms.Color),
            typeof(CtrlEntry), Color.Gray);

        public static readonly BindableProperty ImageHeightProperty = BindableProperty.Create(nameof(ImageHeigth), typeof(int),
            typeof(CtrlEntry), 40);

        public static readonly BindableProperty ImageWidthProperty = BindableProperty.Create(nameof(ImageWidth), typeof(int),
            typeof(CtrlEntry), 40);


        public static readonly BindableProperty ImageAlignmentProperty = BindableProperty.Create(nameof(ImgAlignment), typeof(ImageAlignment),
            typeof(CtrlEntry), ImageAlignment.Left);

        public string Image
        {
            get { return (string)GetValue(ImageProperty); }
            set { SetValue(ImageAlignmentProperty, value); }
        }

        public int ImageWidth
        {
            get { return (int)GetValue(ImageWidthProperty); }
            set { SetValue(ImageWidthProperty, value); }

        }

        public ImageAlignment ImgAlignment
        {
            get { return (ImageAlignment)GetValue(ImageAlignmentProperty); }
            set { SetValue(ImageAlignmentProperty, value); }
        }

        public int ImageHeigth
        {
            get { return (int)GetValue(ImageHeightProperty); }
            set { SetValue(ImageHeightProperty, value); }

        }

        public Color LineColor
        {
            get { return (Color)GetValue(LineColorProperty); }
            set { SetValue(LineColorProperty, value); }
        }

        public enum ImageAlignment
        {
            Left,
            Right
        }
    }
}



