using System;

using MathNet.Numerics.LinearAlgebra;

namespace DLOCRModel.Math.Layer {

    /// <summary>
    /// Softmax交叉熵損失輸出
    /// </summary>
    /// <remarks>
    /// 輸出層，不具有學習能力
    /// </remarks>
    public sealed class SoftmaxWithLossDouble : IOutputLayer<Double> {
        private Matrix<Double> _teach;
        private Matrix<Double> _y;
        private Double _loss;

        public Double Forward(Matrix<Double> input, Matrix<Double> teach) {
            this._teach = teach;
            // 正規化
            this._y = Function.SoftmaxDouble(input);
            // 交叉熵（多批次為平均值）
            this._loss = Function.CrossEntropyErrorDouble(this._y, this._teach);
            // 返回損失
            return this._loss;
        }

        public Matrix<Double> Backward(Matrix<Double> input) {
            return (this._y - this._teach) / input.ColumnCount;
        }
    }
}