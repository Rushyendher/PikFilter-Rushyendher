using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace PikFilter
{
    public partial class FiltersInfo : PhoneApplicationPage
    {
        public FiltersInfo()
        {
            InitializeComponent();
            this.Loaded += FiltersInfo_Loaded;
        }

        void FiltersInfo_Loaded(object sender, RoutedEventArgs e)
        {
            gaussianinfo.Text = "In electronics and signal processing, a Gaussian filter is a filter whose impulse response is a Gaussian function. Gaussian filters have the properties of having no overshoot to a step function input while minimizing the rise and fall time. This behavior is closely connected to the fact that the Gaussian filter has the minimum possible group delay. It is considered the ideal time domain filter, just as the sinc is the ideal frequency domain filter. The Gaussian function is non-zero for x in all real numbers and would theoretically require an infinite window length. However, since it decays rapidly, it is often reasonable to truncate the filter window and implement the filter directly for narrow windows, in effect by using a simple rectangular window function.";
            grayinfo.Text = "In photography and computing, a grayscale or greyscale digital image is an image in which the value of each pixel is a single sample, that is, it carries only intensity information. Images of this sort, also known as black-and-white, are composed exclusively of shades of gray, varying from black at the weakest intensity to white at the strongest. Grayscale images are distinct from one-bit bi-tonal black-and-white images, which in the context of computer imaging are images with only the two colors, black, and white (also called bilevel or binary images). Grayscale images have many shades of gray in between. Grayscale images are often the result of measuring the intensity of light at each pixel in a single band of the electromagnetic spectrum, and in such cases they are monochromatic proper when only a given frequency is captured. But also they can be synthesized from a full color image; see the section about converting to grayscale.";
            grayinfo1.Text = "we can change the given into a filter that is cartoon filter,every pixel value is changed.";
        }
    }
}