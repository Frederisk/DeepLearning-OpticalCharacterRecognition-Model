using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

using MathNet.Numerics.LinearAlgebra;

namespace DLOCRModel.Math.ImagesProgram {

    public class HndConvertMatrix {
        private readonly String _imagePath;

        public HndConvertMatrix(Int32 a = 1) {
            this._imagePath = $@"EnglishHnd\English\Hnd\Img\Sample{a:000}";
        }

        public static Byte[] ImageToByteArray(Image imageIn) {
            using var ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        public Matrix<Double> GetImages() {
            Matrix<Double> imageSpecies = Matrix<Double>.Build.Dense(55, 10000);
            List<String> count = FilePath();
            for (Int32 i = 0; i < count.Count; i++) {
                var oneImage = Image.FromFile(count[i]);
                var copy = new Double[10000];
                var byteArray = ImageToByteArray(oneImage);
                Int32 k;
                for (k = 0; k < byteArray.Length; k++) {
                    copy[k] = byteArray[k];
                }
                for (int j = k; j < 10000; j++) {
                    copy[j] = 255;
                }
                imageSpecies.SetRow(i, copy);
            }
            return imageSpecies;
        }

        public List<String> FilePath() {
            var images = new List<String>(55);
            var dir = new DirectoryInfo(this._imagePath);
            FileInfo[] fileInfos = dir.GetFiles("*.png");
            images.AddRange(fileInfos.Select(t => t.FullName));
            return images;
        }
    }
}