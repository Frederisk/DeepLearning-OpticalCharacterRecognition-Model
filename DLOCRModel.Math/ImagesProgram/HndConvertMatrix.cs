using System;
using System.Collections.Generic;

using System.IO;
using MathNet.Numerics.LinearAlgebra;
using System.Drawing;

namespace DLOCRModel.Math.ImagesProgram {
    public class HndConvertMatrix {
        String imagePath;
        public HndConvertMatrix() {
            imagePath = "EnglishHnd\\English\\Hnd\\Img\\Sample001";
        }
        public HndConvertMatrix(int a) {
            if (a < 10 && a > 0) {
                imagePath = "EnglishHnd\\English\\Hnd\\Img\\Sample00" + a.ToString();
            }
            else if (a >= 10 && a <= 62) {
                imagePath = "EnglishHnd\\English\\Hnd\\Img\\Sample0" + a.ToString();
            }
            else {
                imagePath = "EnglishHnd\\English\\Hnd\\Img\\Sample001";
            }
        }

        public static byte[] imageToByteArray(Image imageIn) {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();

        }
        public Matrix<double> getImages() {
            int k;

            //var imageSpecies = Matrix<byte>.Build;
            Matrix<double> imageSpecies = Matrix<double>.Build.Random(55, 10000);
            //List<Matrix<byte>> images=null;
            List<String> count = filePath();
            for (int i = 0; i < count.Count; i++) {
                Image oneImage = Image.FromFile(count[i]);
                double[] copy = new double[10000];
                byte[] byteArray = imageToByteArray(oneImage);
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



        public List<String> filePath() {
            List<String> images = new List<string>(55);

            DirectoryInfo dir = new DirectoryInfo(imagePath);
            FileInfo[] fileInfo = dir.GetFiles("*.png");
            for (int i = 0; i < fileInfo.Length; i++) {
                String fullName = fileInfo[i].FullName;
                images.Add(fullName);
            }
            return images;

        }
    }
}
