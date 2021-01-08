using System;

using MathNet.Numerics.LinearAlgebra;

namespace DLOCRModel.Math.Layer {

    public sealed class SoftmaxWithLossDouble : IOutputLayer<Double> {
        private Matrix<Double> _teach;
        private Matrix<Double> _y;
        private Double _loss;

        public Double Forward(Matrix<Double> input, Matrix<Double> teach) {
            this._teach = teach;
            this._y = Function.SoftmaxDouble(input);
            this._loss = Function.CrossEntropyErrorDouble(this._y, this._teach);
            return this._loss;
        }

        public Matrix<Double> Backward(Matrix<Double> input) {
            var size = input.RowCount; // TODO: should be batch size, not sure.
            var dx = (this._y - this._teach) / size;
            return dx;
        }
    }
}