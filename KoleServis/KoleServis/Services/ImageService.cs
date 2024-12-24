using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace KoleServis.Services
{
     public static class ImageService
    {
        public static byte[] BitmapImageToByteArray(BitmapImage bitmapImage)
        {
            if (bitmapImage == null)
                return null;

            // Kreirajte memorijski tok za enkodovanje
            using (var memoryStream = new MemoryStream())
            {
                // Koristite enkoder, npr. PNG
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                encoder.Save(memoryStream);

                // Vratite niz bajtova
                return memoryStream.ToArray();
            }
        }
        public static BitmapImage LoadImageFromFile(string filePath)
        {
            // Učitajte sliku iz fajla u BitmapImage
            var bitmap = new BitmapImage();
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.StreamSource = stream;
                bitmap.EndInit();
            }
            bitmap.Freeze(); // Omogućava bezbedan rad u više niti
            return bitmap;
        }
        public static BitmapImage ByteArrayToImage(byte[] byteArray, int targetWidth=200, int targetHeight=200)
        {
            if (byteArray == null || byteArray.Length == 0)
                return null;

            // Pretvori niz bajtova u BitmapImage
            var bitmapImage = new BitmapImage();
            using (var memoryStream = new MemoryStream(byteArray))
            {
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = memoryStream;
                bitmapImage.EndInit();
            }

            bitmapImage.Freeze(); // Omogućava sigurnu upotrebu u WPF

            // Promeni veličinu slike proporcionalno
            return ResizeImage(bitmapImage, targetWidth, targetHeight);
        }

        private static BitmapImage ResizeImage(BitmapImage originalImage, int targetWidth, int targetHeight)
        {
            var drawingVisual = new System.Windows.Media.DrawingVisual();
            using (var drawingContext = drawingVisual.RenderOpen())
            {
                // Proporcionalno skaliranje
                var scaleX = (double)targetWidth / originalImage.PixelWidth;
                var scaleY = (double)targetHeight / originalImage.PixelHeight;
                var scale = Math.Min(scaleX, scaleY);

                var scaledWidth = originalImage.PixelWidth * scale;
                var scaledHeight = originalImage.PixelHeight * scale;

                var rect = new System.Windows.Rect(0, 0, scaledWidth, scaledHeight);
                drawingContext.DrawImage(originalImage, rect);
            }

            var renderTarget = new RenderTargetBitmap(
                (int)(targetWidth),
                (int)(targetHeight),
                96, 96, // DPI
                System.Windows.Media.PixelFormats.Pbgra32);

            renderTarget.Render(drawingVisual);

            // Pretvori RenderTargetBitmap u BitmapImage
            var resizedImage = new BitmapImage();
            using (var stream = new MemoryStream())
            {
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(renderTarget));
                encoder.Save(stream);

                stream.Seek(0, SeekOrigin.Begin);
                resizedImage.BeginInit();
                resizedImage.CacheOption = BitmapCacheOption.OnLoad;
                resizedImage.StreamSource = stream;
                resizedImage.EndInit();
                resizedImage.Freeze();
            }

            return resizedImage;
        }
    }
}
