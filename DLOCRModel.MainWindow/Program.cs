using System;

using MathNet.Numerics.LinearAlgebra;

using System.Drawing;

using DLOCRModel.Math.ImagesProgram;
namespace DLOCRModel.MainWindow {

    internal class Program {

        private static void Main(string[] args) {
            var vct = Vector<Double>.Build.DenseOfArray(new Double[] { 1, 2, 3 });
            var mat = Matrix<Double>.Build.DenseOfArray(
                new Double[,] {
                    {1, 0, 0},
                    {0, 1, 0},
                    {0, 0, 1}
                });// 1*3
            for (int i = 0; i < mat.ColumnCount; i++) {
                mat.SetColumn(i, mat.Column(i) + vct);
            }

            Console.WriteLine(mat);

            //Image oneImage = Image.FromFile("C://EnglishFnt//English//Fnt//Sample001//img001-00100.png");

            //input matrix(1016*3000)
            Matrix<double>test=ConvertMatrix.getImages();
            for(int i = 0; i < 10; i++) {
                Console.Write(test.Row(i));
                Console.WriteLine();
            }
            
            //System.Drawing.Image image = System.Drawing.Image.FromFile("C://EnglishFnt//English//Fnt//Sample001//img001-00011.png");
            
            //Console.WriteLine(DLOCRModel.Math.ImagesProgram.ConvertMatrix.imageToByteArray(image).Length);
        }
    }
}