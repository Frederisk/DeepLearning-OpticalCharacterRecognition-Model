
using System;

using MathNet.Numerics.LinearAlgebra;

namespace DLOCRModel.Math.Layer {
    interface ILayer<T> where T : struct, IFormattable, IEquatable<T> {
        public Matrix<T> Forward(Matrix<T> input);
        public Matrix<T> Backward(Matrix<T> input);
    }
}