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

        //public static Byte[] ImageToByteArray(Image imageIn) {
        //    MemoryStream ms = new MemoryStream();
        //    imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        //    return ms.ToArray();
        //}
        public static IEnumerable<Double> ImageToDoubleArray(Bitmap imageIn) {
            Double[] doubleArray = new Double[imageIn.Width * imageIn.Height];
            int i = 0;
            for (int x = 0; x < imageIn.Width; x++) {
                for (int y = 0; y < imageIn.Height; y++) {
                    Color color = imageIn.GetPixel(x, y);
                    doubleArray[i] = color.GetBrightness();
                    i++;
                }
            }
            return doubleArray;
        }

        public Matrix<Double> GetImages() {
            const Int32 width = 128;
            const Int32 height = 128;

            Matrix<Double> imageSpecies = Matrix<Double>.Build.Dense(1016, width * height);
            List<String> count = this.FilePath();
            for (Int32 i = 0; i < count.Count; i++) {
                var oneImage = Image.FromFile(count[i]);
                var doubleArray = ImageToDoubleArray(new Bitmap(oneImage, width, height));
                imageSpecies.SetRow(i, doubleArray.ToArray());
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
    }
}