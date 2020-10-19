using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfProjectApp
{
    public static class Imager
    {
        private static Dictionary<String, Bitmap> stringBitmaps = new Dictionary<string, Bitmap>();
        public static Bitmap GetBitmap(String txt)
        {
            if (stringBitmaps.ContainsKey(txt))
            {
                return stringBitmaps[txt];
            }
            Bitmap bitmap = new Bitmap(txt);
            stringBitmaps.Add(txt, bitmap);
            return stringBitmaps[txt];
        }
        public static Bitmap ShowImage(int x, int y)
        {
            if (!stringBitmaps.ContainsKey("empty"))
            {
                Bitmap bitmap = new Bitmap(x,y);
                Graphics gfx = Graphics.FromImage(bitmap);
                gfx.FillRectangle(new SolidBrush(System.Drawing.Color.AliceBlue), 0,0,x,y);
                stringBitmaps.Add("empty", bitmap);
                return bitmap;
            }
            return stringBitmaps["empty"];
        }
        public static void EmptyCache()
        {
            stringBitmaps.Clear();
        }
        public static BitmapSource CreateBitmapSourceFromGdiBitmap(Bitmap bitmap)
        {
            if (bitmap == null)
                throw new ArgumentNullException("bitmap");

            var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

            var bitmapData = bitmap.LockBits(
                rect,
                ImageLockMode.ReadWrite,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            try
            {
                var size = (rect.Width * rect.Height) * 4;

                return BitmapSource.Create(
                    bitmap.Width,
                    bitmap.Height,
                    bitmap.HorizontalResolution,
                    bitmap.VerticalResolution,
                    PixelFormats.Bgra32,
                    null,
                    bitmapData.Scan0,
                    size,
                    bitmapData.Stride);
            }
            finally
            {
                bitmap.UnlockBits(bitmapData);
            }
        }
    }
}
