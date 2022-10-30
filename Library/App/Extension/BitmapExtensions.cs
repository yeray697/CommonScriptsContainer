using System.Drawing.Imaging;

namespace App.Extension
{
    public static class BitmapExtensions
    {
        public static Bitmap RecolorImage(this Image source, Color color)
        {
            float[][] matrixColor = {
                    new float[] {   0,   0,   0,   0,  0}, // Red scale factor
                    new float[] {   0,   0,   0,   0,  0}, // Green scale factor
                    new float[] {   0,   0,   0,   0,  0}, // Blue scale factor
                    new float[] {   0,   0,   0,   1,  0}, // alpha scale factor
                    new float[] {   color.R,   color.G,   color.B,   0,  1}};// offset
            ColorMatrix colorMatrixColor = new ColorMatrix(matrixColor);
            ImageAttributes colorImageAttributes = new ImageAttributes();
            colorImageAttributes.SetColorMatrix(colorMatrixColor, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            Rectangle destRect = new Rectangle(0, 0, source.Width, source.Height);
            Bitmap bcolor = new Bitmap(destRect.Width, destRect.Height);
            using (Graphics gColor = Graphics.FromImage(bcolor))
            {
                gColor.DrawImage(source,
                    new Point[] {
                                new Point(0, 0),
                                new Point(destRect.Width, 0),
                                new Point(0, destRect.Height),
                    },
                    destRect, GraphicsUnit.Pixel, colorImageAttributes);
            }
            return bcolor;
        }
    }
}
