using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

using MathNet.Numerics.LinearAlgebra;

namespace DLOCRModel.Math.ImagesProgram {

    public class FntConvertMatrix {
        private readonly String _imagePath;

        public FntConvertMatrix(Int32 a = 1) {
            this._imagePath = $@"EnglishFnt\English\Fnt\Sample{a:000}";
        }

        public static Byte[] ImageToByteArray(Image imageIn) {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        public Matrix<Double> GetImages() {
            Matrix<Double> imageSpecies = Matrix<Double>.Build.Dense(1016, 5000);
            List<String> count = this.FilePath();
            for (Int32 i = 0; i < count.Count; i++) {
                var oneImage = Image.FromFile(count[i]);
                Double[] copy = new Double[5000];
                var byteArray = ImageToByteArray(oneImage);
                int k;
                for (k = 0; k < byteArray.Length; k++) {
                    copy[k] = byteArray[k];
                }
                for (int j = k; j < 5000; j++) {
                    copy[j] = 255;
                }
                imageSpecies.SetRow(i, copy);
            }
            return imageSpecies;
        }

        public List<String> FilePath() {
            List<String> images = new List<String>(1016);
            var dir = new DirectoryInfo(this._imagePath);
            var fileInfos = dir.GetFiles("*.png");
            images.AddRange(fileInfos.Select(t => t.FullName));
            return images;
        }

        //public static Bitmap ToGray(Bitmap bmp) {
        //    for (int i = 0; i < bmp.Width; i++) {
        //        for (int j = 0; j < bmp.Height; j++) {
        //            //获取该点的像素的RGB的颜色
        //            Color color = bmp.GetPixel(i, j);
        //            //利用公式计算灰度值
        //            int gray = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
        //            Color newColor = Color.FromArgb(gray, gray, gray);
        //            bmp.SetPixel(i, j, newColor);
        //        }
        //    }
        //    return bmp;
        //}
    }
}