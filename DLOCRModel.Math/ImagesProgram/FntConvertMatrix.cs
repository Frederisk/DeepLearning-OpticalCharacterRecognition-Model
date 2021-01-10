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
        public static Double[] ImageToDoubleArray(Bitmap imageIn) {
            Double[] doubleArray=new Double[16384];
            int i = 0;
            for(int x = 0; x < 128; x++) {
                for(int y = 0; y < 128; y++) {
                    Color color = imageIn.GetPixel(x,y);
                    doubleArray[i] = color.R+color.G+color.B;
                    i++;
                }
            }
            return doubleArray;
        }

        public Matrix<Double> GetImages() {
            Matrix<Double> imageSpecies = Matrix<Double>.Build.Dense(1016, 16384);
            List<String> count = this.FilePath();
            for (Int32 i = 0; i < count.Count; i++) {
                var oneImage = Image.FromFile(count[i]);
                Double[] copy = new Double[16384];
                var doubleArray = ImageToDoubleArray((Bitmap)oneImage);                                
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

        
    }
}