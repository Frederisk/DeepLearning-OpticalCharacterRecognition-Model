using System;

using MathNet.Numerics.LinearAlgebra;

namespace DLOCRModel.Math.Layer {

    /// <summary>
    /// ReLU層
    /// </summary>
    /// <remarks>
    /// 該層屬於激活函數，並不具備學習能力
    /// </remarks>
    public sealed class ReluDouble : IHiddenLayer<Double> {
        private Matrix<Double> _maskMatrix;

        /// <summary>
        /// 向前傳播
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Matrix<Double> Forward(Matrix<Double> input) {
            this._maskMatrix = input.Map(num => (Double)(num <= 0 ? 1 : 0));
            return input.Map2((num, mask) => mask is 0 ? num : 0, this._maskMatrix);
        }

        /// <summary>
        /// 向後傳播
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Matrix<Double> Backward(Matrix<Double> input) {
            return input.Map2((num, mask) => mask is 0 ? num : 0, this._maskMatrix);
        }
    }
}