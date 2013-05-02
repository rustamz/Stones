using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace Stones
{
    class ImageShell
    {
        private Bitmap originalBitmap = null;
        private Bitmap workBitmap = null;

        private void MakeGray(Bitmap bmp)
        {
            // Задаём формат Пикселя.
            PixelFormat pxf = PixelFormat.Format24bppRgb;

            // Получаем данные картинки.
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            //Блокируем набор данных изображения в памяти
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, pxf);

            // Получаем адрес первой линии.
            IntPtr ptr = bmpData.Scan0;

            // Задаём массив из Byte и помещаем в него надор данных.
            // int numBytes = bmp.Width * bmp.Height * 3; 
            //На 3 умножаем - поскольку RGB цвет кодируется 3-мя байтами
            //Либо используем вместо Width - Stride
            int numBytes = bmpData.Stride * bmp.Height;
            int widthBytes = bmpData.Stride;
            byte[] rgbValues = new byte[numBytes];

            // Копируем значения в массив.
            Marshal.Copy(ptr, rgbValues, 0, numBytes);

            // Перебираем пикселы по 3 байта на каждый и меняем значения
            for (int counter = 0; counter < rgbValues.Length; counter += 3)
            {

                int value = rgbValues[counter] + rgbValues[counter + 1] + rgbValues[counter + 2];
                byte color_b = 0;

                color_b = Convert.ToByte(value / 3);

                rgbValues[counter] = color_b;
                rgbValues[counter + 1] = color_b;
                rgbValues[counter + 2] = color_b;

            }
            // Копируем набор данных обратно в изображение
            Marshal.Copy(rgbValues, 0, ptr, numBytes);

            // Разблокируем набор данных изображения в памяти.
            bmp.UnlockBits(bmpData);
        }

        private void MakeMonochrome(Bitmap bmp, byte Bound)
        {
            // Задаём формат Пикселя.
            PixelFormat pxf = PixelFormat.Format24bppRgb;

            // Получаем данные картинки.
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            //Блокируем набор данных изображения в памяти
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, pxf);

            // Получаем адрес первой линии.
            IntPtr ptr = bmpData.Scan0;

            // Задаём массив из Byte и помещаем в него надор данных.
            // int numBytes = bmp.Width * bmp.Height * 3; 
            // На 3 умножаем - поскольку RGB цвет кодируется 3-мя байтами
            // Либо используем вместо Width - Stride
            int numBytes = bmpData.Stride * bmp.Height;
            int widthBytes = bmpData.Stride;
            byte[] rgbValues = new byte[numBytes];

            // Копируем значения в массив.
            Marshal.Copy(ptr, rgbValues, 0, numBytes);

            // Перебираем пикселы по 3 байта на каждый и меняем значения
            for (int counter = 0; counter < rgbValues.Length; counter += 3)
            {

                int value = rgbValues[counter] + rgbValues[counter + 1] + rgbValues[counter + 2];
                byte color_b = 0;

                color_b = Convert.ToByte(value / 3);

                if (color_b > Bound)
                    color_b = 255;
                else
                    color_b = 0;

                rgbValues[counter] = color_b;
                rgbValues[counter + 1] = color_b;
                rgbValues[counter + 2] = color_b;

            }
            // Копируем набор данных обратно в изображение
            Marshal.Copy(rgbValues, 0, ptr, numBytes);

            // Разблокируем набор данных изображения в памяти.
            bmp.UnlockBits(bmpData);
        }

        private void Sobel(Bitmap SourceBmp, out Bitmap DestinationBmp)
        {
            // Обесцвечиваем исходное изображение
            Bitmap GraySource = (Bitmap)SourceBmp.Clone();
            MakeGray(GraySource);

            // подготовка выходного изображения
            DestinationBmp = new Bitmap(SourceBmp.Width, SourceBmp.Height);
            
            // Ядро по Собелю
            int[,] gx = new int[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            int[,] gy = new int[,] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
            // Ядро по Щарру
            //int[,] gx = new int[,] { { 3, 0, -3 }, { -10, 0, 10 }, { 3, 0, -3 } };
            //int[,] gy = new int[,] { { 3, 10, 3 }, { 0, 0, 0 }, { -3, -10, -3 } };

            // вычисление
            for (int i = 1; i < GraySource.Height - 1; i++)
            {
                for (int j = 1; j < GraySource.Width - 1; j++)
                {
                    float new_x = 0, new_y = 0;

                    for (int hw = 0; hw < 3; hw++)
                    {
                        for (int wi = 0; wi < 3; wi++)
                        {
                            int _i = i + hw - 1;
                            int _j = j + wi - 1;
                            int curr = GraySource.GetPixel(_j, _i).B;
                            new_x += gx[hw, wi] * curr;
                            new_y += gy[hw, wi] * curr;
                        }
                    }

                    if (new_x * new_x + new_y * new_y > 128 * 128)
                        DestinationBmp.SetPixel(j, i, Color.White);
                    else
                        DestinationBmp.SetPixel(j, i, Color.Black);
                }
            }
        }

        public ImageShell()
        {
            //
        }

        public ImageShell(Bitmap SourceBitmap)
        {
            originalBitmap = (Bitmap)SourceBitmap.Clone();
            workBitmap = (Bitmap)originalBitmap.Clone();
        }

        public Bitmap Image
        {
            get { return workBitmap; }
            set { originalBitmap = (Bitmap)value.Clone(); workBitmap = (Bitmap)originalBitmap.Clone(); }
        }

        #region Методы доступные пользователю

        public void MakeGray()
        {
            MakeGray(workBitmap = (Bitmap)originalBitmap.Clone());
        }

        public void MakeMonochrome(byte Bound)
        {
            MakeMonochrome(workBitmap = (Bitmap)originalBitmap.Clone(), Bound);
        }

        public void Soble()
        {
            Sobel(originalBitmap, out workBitmap);
        }

        public byte[,] RedSource()
        {
            byte[,] Result = new byte[Image.Width, Image.Height];
            for (int i = 0; i < Image.Width; i++)
            {
                for (int j = 0; j < Image.Height; j++)
                {
                    Result[i, j] = Image.GetPixel(i, j).R;   
                }
            }

            return Result;
        }

        public byte[,] GreenSource()
        {
            byte[,] Result = new byte[Image.Width, Image.Height];
            for (int i = 0; i < Image.Width; i++)
            {
                for (int j = 0; j < Image.Height; j++)
                {
                    Result[i, j] = Image.GetPixel(i, j).G;
                }
            }

            return Result;
        }

        public byte[,] BlueSource()
        {
            byte[,] Result = new byte[Image.Width, Image.Height];
            for (int i = 0; i < Image.Width; i++)
            {
                for (int j = 0; j < Image.Height; j++)
                {
                    Result[i, j] = Image.GetPixel(i, j).B;
                }
            }

            return Result;
        }

        #endregion
    }
}
