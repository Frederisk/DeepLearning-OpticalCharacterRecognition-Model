using System;

using MathNet.Numerics.LinearAlgebra;

namespace DLOCRModel.Math.Layer {

    public class AffineDouble : ILayer<Double> {
        private readonly Matrix<Double> _mat;
        private readonly Vector<Double> _vct;
        private Matrix<Double> _forMatrix;

        public Matrix<Double> DMatrix { get; private set; }
        public Vector<Double> DVector { get; private set; }

        public AffineDouble(Matrix<Double> mat, Vector<Double> vct) {
            this._mat = mat;
            this._vct = vct;
        }

        public Matrix<Double> Forward(Matrix<Double> input) {
            this._forMatrix = input;
            var m = input * this._mat;

            for (int i = 0; i < m.ColumnCount; i++) {
                m.SetColumn(i, m.Column(i) + this._vct);
            }

            return m;
        }

        public Matrix<Double> Backward(Matrix<Double> input) {
            var dx = input * this._mat.Transpose();
            this.DMatrix = this._forMatrix.Transpose() * input;
            for (int i = 0; i < input.ColumnCount; i++) {
                this.DVector += input.Column(i);
            }

            return dx;
        }
    }
}