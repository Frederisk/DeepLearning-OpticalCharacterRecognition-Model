using System;

using MathNet.Numerics.LinearAlgebra;

namespace DLOCRModel.Math.Layer {

    /// <summary>
    /// 感知機
    /// </summary>
    /// <remarks>
    /// 主要學習層
    /// </remarks>
    public class AffineDouble : IHiddenLayer<Double> {

        /// <summary>
        /// 乘法矩陣
        /// </summary>
        private readonly Matrix<Double> _mat;

        /// <summary>
        /// 加法向量
        /// </summary>
        private readonly Vector<Double> _vct;

        /// <summary>
        /// 向後傳播用資訊
        /// </summary>
        private Matrix<Double> _forMatrix;

        public Matrix<Double> DMatrix { get; private set; }
        public Vector<Double> DVector { get; private set; }

        public AffineDouble(Matrix<Double> mat, Vector<Double> vct) {
            this._mat = mat;
            this._vct = vct;
        }

        /// <summary>
        /// 向前傳播
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Matrix<Double> Forward(Matrix<Double> input) {
            this._forMatrix = input;
            var m = input * this._mat;

            for (int i = 0; i < m.ColumnCount; i++) {
                m.SetColumn(i, m.Column(i) + this._vct);
            }

            return m;
        }

        /// <summary>
        /// 向後傳播
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
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