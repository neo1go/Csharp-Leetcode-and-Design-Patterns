using Emgu.CV;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using YoloDotNet;
using YoloDotNet.Extensions;
using SkiaSharp;
using ImageSharpExtensions = SixLabors.ImageSharp.GraphicOptionsDefaultsExtensions;
using System.Drawing;


namespace WebcamDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Yolo _yolo;
        private Dispatcher _dispatcher;  //updates the Main Thread
        //Object detection is done on a different thread, so the Main Thread doesnt freeze up

        private CancellationTokenSource? _webcamCancellationTokenSource;
        private CancellationToken _webcamCancellationToken; //used to control Start and Stop Button Function



        public MainWindow()
        {
            _yolo = new Yolo(((@"C:\CameraProjectAssets\yolov8s.onnx")));
            _dispatcher = Dispatcher.CurrentDispatcher;
            InitializeComponent();
        }



        private async Task WebcamAsync(CancellationToken cancellationToken)
        {
            //Create new VideoCapture instance configuration
            using var capture = new VideoCapture(0, VideoCapture.API.DShow);
            capture.Set(Emgu.CV.CvEnum.CapProp.FrameCount, 30);
            capture.Set(Emgu.CV.CvEnum.CapProp.FrameWidth, 640);
            capture.Set(Emgu.CV.CvEnum.CapProp.FrameHeight, 480);

            using var stream = new MemoryStream();

           // var poseOptions = CustomKeyPointColorMap.KeyPointOptions;



            while (!cancellationToken.IsCancellationRequested)
            {
                //read current webcam frame into a stream
                capture.QueryFrame().ToBitmap().Save(stream, ImageFormat.Bmp);   //jeder Frame wird gespeichert
                stream.Position = 0;

                //Feed stream to YoloDotNet for processing
                using var img = await SixLabors.ImageSharp.Image.LoadAsync(stream); //kommt von SixLabors
               

                var results  = _yolo.RunObjectDetection(img);           //RunObjectDetection ist aber von SKImage

                // var results = _yolo.RunPoseEstimation(img);

                img.Draw(results);

                // - img.Draw(results,poseOptions);



                //Display processed frame on the main thread
                await _dispatcher.InvokeAsync(async () => WebcamImage.Source = await ImageSharpToBitmapAsync(img));

            }

        }

        private static async Task<BitmapSource> ImageSharpToBitmapAsync(SixLabors.ImageSharp.Image image)
        {
            //Diese Methode nimmt das Bild der Kamera, speichert sie um dann anzeigen zu können im User Interface
            using var ms = new MemoryStream();  //erst wird die Bitmap in den Speicher gestreamt und dann zum Anzeigen in eine neue Variable übergeben für bitmap Image
            await image.SaveAsBmpAsync(ms);
            ms.Position = 0;

            var bitmap = new BitmapImage();   //hier wird das Bitmap-Bild aus dem Speicher erzeugt
            bitmap.BeginInit();
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.StreamSource = ms;
            bitmap.EndInit();
            return bitmap;
        }



        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            //Create a new cancellationToken for controlling start and stop
            _webcamCancellationTokenSource = new CancellationTokenSource();
            _webcamCancellationToken = _webcamCancellationTokenSource.Token;

            //Invoke webcam in a new thread with passed-in cancellation token
            //Das Token wird zweimal übergeben. Einmal weil die Methode diese Variable benötigt und das zweite Mal zum korrekten Abbrechen, quasi on und off
            Task.Run(() => WebcamAsync(_webcamCancellationToken), _webcamCancellationToken);
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            _webcamCancellationTokenSource?.Cancel();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            _yolo.Dispose();
        }
    }
}