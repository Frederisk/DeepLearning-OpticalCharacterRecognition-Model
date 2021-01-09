using System;
using System.Collections.Generic;

using System.IO;
using MathNet.Numerics.LinearAlgebra;
using System.Drawing;
namespace DLOCRModel.Math.ImagesProgram {
    public class ConvertMatrix {
        public static byte[] imageToByteArray(Image imageIn) {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();

        }
        public static Matrix<double> getImages() {
            int k;
            
            //var imageSpecies = Matrix<byte>.Build;
            Matrix<double> imageSpecies = Matrix<double>.Build.Random(1016, 3000);
            //List<Matrix<byte>> images=null;
            List<String> count = filePath();
            for (int i = 0; i < count.Count; i++) {
                Image oneImage = Image.FromFile(count[i]);
                double[] copy = new double[3000];
                byte[] byteArray = imageToByteArray(oneImage);
                for(k = 0; k < byteArray.Length; k++) {
                    copy[k] = byteArray[k];
                }
                for (int j = k; j < 3000; j++) {
                    copy[j] = 255;
                }

                imageSpecies.SetRow(i, copy);
            }
            return imageSpecies;
        }
        //public static double[] ConverByteToDouble(byte[] byteArray) {
            
        //    double[] a = new double[2000];
        //    for(int i = 0; i < byteArray.Length; i++) {
        //        a[i] = byteArray[i];
        //    }
        //    return a;
        //}

        //get file path
        public static List<String> filePath() {
            List<String> images=new List<string>(1016);
            String imagePath = "Training samples\\EnglishFnt\\English\\Fnt\\Sample001";
            DirectoryInfo dir = new DirectoryInfo(imagePath);
            FileInfo[] fileInfo = dir.GetFiles("*.png");
            for(int i = 0; i < fileInfo.Length; i++) {
                String fullName = fileInfo[i].FullName;
                images.Add(fullName);
            }
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
