using System;

using MathNet.Numerics.LinearAlgebra;

namespace DLOCRModel.Math.Layer {

    /// <summary>
    ///
    /// </summary>
    public sealed class ReluDouble : ILayer<Double> {
        private Matrix<Double> _maskMatrix;

        private Boolean _isForwarded;

        /// <summary>
        /// 向前傳播
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Matrix<Double> Forward(Matrix<Double> input) {
            this._isForwarded = true;

            this._maskMatrix = input.Map((num) => (Double)(num <= 0 ? 1 : 0));
            return input.Map2((num, mask) => mask is 0 ? num : 0, this._maskMatrix);
        }

        /// <summary>
        /// 向後傳播
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Matrix<Double> Backward(Matrix<Double> input) {
            if (!this._isForwarded) {
                throw new Exception();
            }

            return input.Map2((num, mask) => mask is 0 ? num : 0, this._maskMatrix);
        }
    }
}