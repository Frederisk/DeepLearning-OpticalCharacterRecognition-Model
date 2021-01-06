using System;
using System.Collections.Generic;
using System.Text;

using MathNet.Numerics.LinearAlgebra;

namespace DLOCRModel.Math.Layer {
    public sealed class SoftmaxWithLossDouble {

        //public SoftmaxWithLossDouble(Int32 index) {
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="teachVector">teach data, it should be one-hot vector</param>
        //public SoftmaxWithLossDouble(Vector<Double> teachVector) {

        //}

        private Vector<Double> _teach;
        private Vector<Double> _y;

        public Matrix<Double> Forward(Vector<Double> input, Vector<Double> teach) {
            this._teach = teach;
            this._y = Function.SoftmaxDouble(input);

            throw new NotImplementedException();
        }

        public Matrix<Double> Backward(Matrix<Double> input) => throw new NotImplementedException();
    }
}
