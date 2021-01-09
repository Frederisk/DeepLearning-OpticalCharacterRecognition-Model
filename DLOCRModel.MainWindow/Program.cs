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
            ConvertMatrix input = new ConvertMatrix(52);
            Matrix<double> inputMatrix = input.getImages();
            for(int i=0; i < 20; i++) {
                Console.Write(inputMatrix.Row(i));
                Console.WriteLine();
            }
            
        }
    }
}