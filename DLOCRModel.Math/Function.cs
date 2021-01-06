using System;

using MathNet.Numerics.LinearAlgebra;

using static System.Math;

namespace DLOCRModel.Math {

    internal static class Function {

        internal static Vector<Double> SoftmaxDouble(Vector<Double> input) {
            var c = input.Maximum();
            var exp = input.Map(num => Exp(num - c));
            var sum = exp.Sum();
            var y = exp / sum;

            return y;
        }

        internal static Matrix<Double> SoftmaxDouble(Matrix<Double> input) {
            var y = Matrix<Double>.Build.Dense(rows: input.RowCount, columns: input.ColumnCount);
            for (int i = 0; i < input.ColumnCount; i++) {
                y.SetColumn(i, SoftmaxDouble(input.Column(i)));
            }

            return y;
        }






    }
}