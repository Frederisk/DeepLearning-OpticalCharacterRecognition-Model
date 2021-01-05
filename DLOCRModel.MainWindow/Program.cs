using System;

using DLOCRModel.Calculate;

using MathNet.Numerics.LinearAlgebra;

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
        }
    }
}