using Lumia.Imaging;
using Lumia.Imaging.Adjustments;
using Lumia.Imaging.Artistic;
using Lumia.Imaging.Transforms;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using Microsoft.Xna.Framework.Media;
using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using Windows.Storage.Streams;

namespace PikFilter
{
    public partial class MainPage : PhoneApplicationPage
    {

        private string _fileName = string.Empty;
        private String filtername = string.Empty;
        private StreamImageSource source;

        public MainPage()
        {
            InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            allfilters.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void mycamera_Click(object sender, EventArgs e)
        {
            CameraCaptureTask capture = new CameraCaptureTask();
            capture.Completed += TakeImage;
            capture.Show();
        }

        private async void TakeImage(object sender, PhotoResult e)
        {
            if (e.TaskResult != TaskResult.OK || e.ChosenPhoto == null)
            {
                MessageBox.Show("Invalid Operation");
                return;
            }

            try
            {
                source = new StreamImageSource(e.ChosenPhoto);

                //Gaussian Noise Filter
                using (var gaussianfilter = new FilterEffect(source))
                {
                    var gaussian = new GaussianNoiseFilter();
                    gaussianfilter.Filters = new IFilter[] { gaussian };

                    var target = new WriteableBitmap((int)img1.ActualWidth, (int)img1.ActualHeight);

                    using (var renderer = new WriteableBitmapRenderer(gaussianfilter, target))
                    {
                        await renderer.RenderAsync();
                        img1.Source = target;
                    }
                }

                //GreyScale Filter
                using (var greyscalefilter = new FilterEffect(source))
                {
                    var greyscale = new GrayscaleFilter();
                    greyscalefilter.Filters = new IFilter[] { greyscale };

                    var target = new WriteableBitmap((int)img2.ActualWidth, (int)img2.ActualHeight);

                    using (var renderer = new WriteableBitmapRenderer(greyscalefilter, target))
                    {
                        await renderer.RenderAsync();
                        img2.Source = target;
                    }
                }

                //Greyscale negative filter
                using (var greyscalenegfilter = new FilterEffect(source))
                {
                    var greyscaleneg = new GrayscaleNegativeFilter();
                    greyscalenegfilter.Filters = new IFilter[] { greyscaleneg };

                    var target = new WriteableBitmap((int)img3.ActualWidth, (int)img3.ActualHeight);

                    using (var renderer = new WriteableBitmapRenderer(greyscalenegfilter, target))
                    {
                        await renderer.RenderAsync();
                        img3.Source = target;
                    }
                }

                //Fog filter
                using (var Fogfilter = new FilterEffect(source))
                {
                    var fog = new FogFilter();
                    Fogfilter.Filters = new IFilter[] { fog };

                    var target = new WriteableBitmap((int)img4.ActualWidth, (int)img4.ActualHeight);

                    using (var renderer = new WriteableBitmapRenderer(Fogfilter, target))
                    {
                        await renderer.RenderAsync();
                        img4.Source = target;
                    }
                }

                //Cartoon filter
                using (var cartoonfilter = new FilterEffect(source))
                {
                    var cartoon = new CartoonFilter();
                    cartoonfilter.Filters = new IFilter[] { cartoon };

                    var target = new WriteableBitmap((int)img5.ActualWidth, (int)img5.ActualHeight);

                    using (var renderer = new WriteableBitmapRenderer(cartoonfilter, target))
                    {
                        await renderer.RenderAsync();
                        img5.Source = target;
                    }
                }

                //Color Boost
                using (var colorboostfilter = new FilterEffect(source))
                {
                    var colorboost = new ColorBoostFilter();
                    colorboostfilter.Filters = new IFilter[] { colorboost };

                    var target = new WriteableBitmap((int)img6.ActualWidth, (int)img6.ActualHeight);

                    using (var renderer = new WriteableBitmapRenderer(colorboostfilter, target))
                    {
                        await renderer.RenderAsync();
                        img6.Source = target;
                    }
                }

                //Flip filter
                using (var Flipfilter = new FilterEffect(source))
                {
                    var flip = new FlipFilter(FlipMode.Horizontal);
                    Flipfilter.Filters = new IFilter[] { flip };

                    var target = new WriteableBitmap((int)img7.ActualWidth, (int)img7.ActualHeight);

                    using (var renderer = new WriteableBitmapRenderer(Flipfilter, target))
                    {
                        await renderer.RenderAsync();
                        img7.Source = target;
                    }
                }

                //Mirror Filter
                using (var Mirrorfilter = new FilterEffect(source))
                {
                    var Mirror = new MirrorFilter();
                    Mirrorfilter.Filters = new IFilter[] { Mirror };

                    var target = new WriteableBitmap((int)img8.ActualWidth, (int)img8.ActualHeight);

                    using (var renderer = new WriteableBitmapRenderer(Mirrorfilter, target))
                    {
                        await renderer.RenderAsync();
                        img8.Source = target;
                    }
                }

                //Noise filter
                using (var noisefilter = new FilterEffect(source))
                {
                    var noise = new NoiseFilter();
                    noisefilter.Filters = new IFilter[] { noise };

                    var target = new WriteableBitmap((int)img9.ActualWidth, (int)img9.ActualHeight);

                    using (var renderer = new WriteableBitmapRenderer(noisefilter, target))
                    {
                        await renderer.RenderAsync();
                        img9.Source = target;
                    }
                }

                //Negative Filter
                using (var negativefilter = new FilterEffect(source))
                {
                    var negative = new NegativeFilter();
                    negativefilter.Filters = new IFilter[] { negative };

                    var target = new WriteableBitmap((int)img10.ActualWidth, (int)img10.ActualHeight);

                    using (var renderer = new WriteableBitmapRenderer(negativefilter, target))
                    {
                        await renderer.RenderAsync();
                        img10.Source = target;
                    }
                }

                //Sketch filter
                using (var Sketchfilter = new FilterEffect(source))
                {
                    var Sketch = new SketchFilter(SketchMode.Gray);
                    Sketchfilter.Filters = new IFilter[] { Sketch };

                    var target = new WriteableBitmap((int)img11.ActualWidth, (int)img11.ActualHeight);

                    using (var renderer = new WriteableBitmapRenderer(Sketchfilter, target))
                    {
                        await renderer.RenderAsync();
                        img11.Source = target;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void albums_Click(object sender, EventArgs e)
        {
            PhotoChooserTask choosepic = new PhotoChooserTask();
            choosepic.Completed += TakeImage;
            choosepic.Show();
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            SaveImageToPhone sitp = new SaveImageToPhone();
            try
            {
                switch (filtername)
                {
                    case "GaussianNoise": GaussianNoiseFilter gaus = new GaussianNoiseFilter();
                        sitp.SaveImage(source, img1, _fileName, gaus);
                        break;
                    case "Grayscale": GrayscaleFilter gray = new GrayscaleFilter();
                        sitp.SaveImage(source, img2, _fileName, gray);
                        break;
                    case "Grayscaleneg": GrayscaleNegativeFilter grayneg = new GrayscaleNegativeFilter();
                        sitp.SaveImage(source, img3, _fileName, grayneg);
                        break;
                    case "Fog": FogFilter fogfltr = new FogFilter();
                        sitp.SaveImage(source, img4, _fileName, fogfltr);
                        break;
                    case "Cartoon": CartoonFilter cart = new CartoonFilter();
                        sitp.SaveImage(source, img5, _fileName, cart);
                        break;
                    case "Colorboost": ColorBoostFilter cbf = new ColorBoostFilter();
                        sitp.SaveImage(source, img6, _fileName, cbf);
                        break;
                    case "Flip": FlipFilter flipfltr = new FlipFilter(FlipMode.Horizontal);
                        sitp.SaveImage(source, img7, _fileName, flipfltr);
                        break;
                    case "Mirror": MirrorFilter mir = new MirrorFilter();
                        sitp.SaveImage(source, img8, _fileName, mir);
                        break;
                    case "Noise": NoiseFilter noi = new NoiseFilter();
                        sitp.SaveImage(source, img9, _fileName, noi);
                        break;
                    case "Negative": NegativeFilter neg = new NegativeFilter();
                        sitp.SaveImage(source, img10, _fileName, neg);
                        break;
                    case "Sketch": SketchFilter skt = new SketchFilter(SketchMode.Gray);
                        sitp.SaveImage(source, img11, _fileName, skt);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addfilter_Click(object sender, EventArgs e)
        {
            //if (allfilters.Visibility == System.Windows.Visibility.Collapsed)
            //{
            //    allfilters.Visibility = System.Windows.Visibility.Visible;
            //    addfilter.IconUri = new Uri("/Images/minus.png", UriKind.Relative);
            //    addfilter.Text = "hide filter";
            //}
            //else if (allfilters.Visibility == System.Windows.Visibility.Visible)
            //{
            //    allfilters.Visibility = System.Windows.Visibility.Collapsed;
            //    addfilter.IconUri = new Uri("/Images/add.png", UriKind.Relative);
            //    addfilter.Text = "add filter";
            //}
            allfilters.Visibility = System.Windows.Visibility.Visible;
            
        }

        private void ApplyFilterToImage(Image img)
        {
            myimage.Source = img.Source;
        }


        private void img1_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ApplyFilterToImage(img1);
            filtername = "GaussianNoise";
            allfilters.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void img2_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ApplyFilterToImage(img2);
            filtername = "Grayscale";
            allfilters.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void img3_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ApplyFilterToImage(img3);
            filtername = "Grayscaleneg";
            allfilters.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void img4_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ApplyFilterToImage(img4);
            filtername = "Fog";
            allfilters.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void img5_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ApplyFilterToImage(img5);
            filtername = "Cartoon";
            allfilters.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void img6_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ApplyFilterToImage(img6);
            filtername = "Colorboost";
            allfilters.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void img7_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ApplyFilterToImage(img7);
            filtername = "Flip";
            allfilters.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void img8_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ApplyFilterToImage(img8);
            filtername = "Mirror";
            allfilters.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void img9_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ApplyFilterToImage(img9);
            filtername = "Noise";
            allfilters.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void img10_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ApplyFilterToImage(img10);
            filtername = "Negative";
            allfilters.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void img11_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ApplyFilterToImage(img11);
            filtername = "Sketch";
            allfilters.Visibility = System.Windows.Visibility.Collapsed;
        }

        private async void croppic_Click(object sender, EventArgs e)
        {
            using (var cropfilters = new FilterEffect(source))
            {
                var CropFilter = new CropFilter(new Windows.Foundation.Rect(0, 0, 250, 250));

                cropfilters.Filters = new IFilter[] { CropFilter };

                var croptarget = new WriteableBitmap((int)myimage.ActualWidth, (int)myimage.ActualHeight);

                using (var renderer = new WriteableBitmapRenderer(cropfilters, croptarget))
                {
                    await renderer.RenderAsync();
                    myimage.Source = croptarget;
                }
            }
        }

        private async void autofiximg_Click(object sender, EventArgs e)
        {
             using(var filterEffect = new FilterEffect(source))
             {
                var analyzer = new AutoFixAnalyzer(source);
                AutoFixAnalyzerResult autoFixSuggestions = await analyzer.AnalyzeAsync();

                var temperatureAndTintFilter = new TemperatureAndTintFilter();
                temperatureAndTintFilter.Temperature = autoFixSuggestions.TemperatureParameter;
                temperatureAndTintFilter.Tint = autoFixSuggestions.TintParameter;

                var saturationLightnessFilter = new SaturationLightnessFilter();
                saturationLightnessFilter.SaturationCurve = autoFixSuggestions.SaturationCurve;
                saturationLightnessFilter.LightnessCurve = autoFixSuggestions.LightnessCurve;

                filterEffect.Filters = new IFilter[] { saturationLightnessFilter, temperatureAndTintFilter };
                var croptarget = new WriteableBitmap((int)myimage.ActualWidth, (int)myimage.ActualHeight);
                using (var renderer = new WriteableBitmapRenderer(filterEffect, croptarget))
                {
                    await renderer.RenderAsync();
                    myimage.Source = croptarget;
                }
             }
        }

        private async void roateimage_Click(object sender, EventArgs e)
        {
            using (var rotfilters = new FilterEffect(source))
            {
                var RotFilter = new RotationFilter(90);

                rotfilters.Filters = new IFilter[] { RotFilter };

                var croptarget = new WriteableBitmap((int)myimage.ActualWidth, (int)myimage.ActualHeight);

                using (var renderer = new WriteableBitmapRenderer(rotfilters, croptarget))
                {
                    await renderer.RenderAsync();
                    myimage.Source = croptarget;
                }
            }
        }

        private void filtersinfo_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/FiltersInfo.xaml",UriKind.RelativeOrAbsolute));
        }
    }
}