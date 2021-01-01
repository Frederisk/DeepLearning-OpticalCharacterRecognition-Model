using System;

using MathNet.Numerics.LinearAlgebra;


namespace DLOCRModel.Math {
    public static class ExportClass {

        public static T[,] BuildRandomMatArr<T>(Int32 rows, Int32 columns, Int32? seed = null)
            where T : struct, IEquatable<T>, IFormattable
            => (seed is null
                ? Matrix<T>.Build.Random(rows, columns)
                : Matrix<T>.Build.Random(rows, columns, seed.Value)).ToArray();


        public static T[] BuildRandomVctArr<T>(Int32 length, Int32? seed = null)
            where T : struct, IEquatable<T>, IFormattable
            => (seed is null
                ? Vector<T>.Build.Random(length)
                : Vector<T>.Build.Random(length, seed.Value)).ToArray();


        public static String GetExclamationMark() => "!";

        static void foo() {
            
        }
    }
}
