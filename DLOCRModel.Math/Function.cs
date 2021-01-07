using System;

using MathNet.Numerics.LinearAlgebra;

using static System.Math;

namespace DLOCRModel.Math {

    internal static class Function {

        private static readonly Double delta = 1e-7;

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

        internal static Double CrossEntropyErrorDouble(Vector<Double> input, Vector<Double> teach)
            => - (input + delta).Map(num => Log(num)) * teach;

        internal static Double CrossEntropyErrorDouble(Matrix<Double> input, Matrix<Double> teach) {
            Double sum = 0;
            for (Int32 i = 0; i < input.ColumnCount; i++) {
                sum += CrossEntropyErrorDouble(input.Column(i), teach.Column(i));
            }
            return sum;
        }
    }
}