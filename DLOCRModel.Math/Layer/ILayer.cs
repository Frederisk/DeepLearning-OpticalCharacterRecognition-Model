using System;

using MathNet.Numerics.LinearAlgebra;

namespace DLOCRModel.Math.Layer {

    internal interface IHiddenLayer<T> where T : struct, IFormattable, IEquatable<T> {

        public Matrix<T> Forward(Matrix<T> input);

        public Matrix<T> Backward(Matrix<T> input);
    }

    internal interface IOutputLayer<T> where T : struct, IFormattable, IEquatable<T> {

        public T Forward(Matrix<T> input, Matrix<T> teach);

        public Matrix<T> Backward(Matrix<T> input);
    }

    internal interface IUpdateableLayer {

        public void Update(Object data);
    }
}