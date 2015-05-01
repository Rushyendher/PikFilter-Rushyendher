using Lumia.Imaging;
using Lumia.Imaging.Artistic;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using Microsoft.Xna.Framework.Media;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Windows.Storage.Streams;

namespace PikFilter
{
    public class SaveImageToPhone
    {
        private string _fileName = string.Empty;
        WriteableBitmap target;

        public async void SaveImage(StreamImageSource source, Image Img, String FilterName, IFilter Filter)
        {
            using (var imgfilters = new FilterEffect(source))
            {
                var filt = Filter;
                imgfilters.Filters = new IFilter[] { filt };

                var target = new WriteableBitmap((int)Img.ActualWidth, (int)Img.ActualHeight);
                using (var renderer = new WriteableBitmapRenderer(imgfilters, target))
                {
                    await renderer.RenderAsync();
                    Img.Source = target;
                }

                var jpegRenderer = new JpegRenderer(imgfilters);

                IBuffer jpegOutput = await jpegRenderer.RenderAsync();

                MediaLibrary library = new MediaLibrary();
                _fileName = string.Format("ImageFilta", DateTime.Now.Second) + ".jpg";
                var picture = library.SavePicture(_fileName, jpegOutput.AsStream());
                MessageBox.Show("Image saved to phone","Message",MessageBoxButton.OK);
            }
        }
    }
}
