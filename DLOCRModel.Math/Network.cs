using System;
using System.Collections.Generic;
using System.Linq;

using DLOCRModel.Math.Layer;

using MathNet.Numerics.LinearAlgebra;

namespace DLOCRModel.Math {

    public sealed class NetworkDouble {
        private readonly List<IHiddenLayer<Double>> _hiddenLayers;
        private readonly IOutputLayer<Double> _outputLayer;

        public NetworkDouble(IEnumerable<IHiddenLayer<Double>> hiddenLayers, IOutputLayer<Double> outputLayer) {
            this._hiddenLayers = new List<IHiddenLayer<Double>>();
            this._hiddenLayers.AddRange(hiddenLayers);

            this._outputLayer = outputLayer;
        }

        private Matrix<Double> Predict(Matrix<Double> input) {
            return this._hiddenLayers.Aggregate(input, (current, layer) => layer.Forward(current));
        }

        private Double Loss(Matrix<Double> input, Matrix<Double> teach) {
            var y = this.Predict(input);
            return this._outputLayer.Forward(y, teach);
        }

        public IEnumerable<(Matrix<Double> Mat, Vector<Double> Vct)> Gradient(Matrix<Double> input, Matrix<Double> teach) {
            this.Loss(input, teach);
            var dOut = this._outputLayer.Backward();
            for (int i = this._hiddenLayers.Count; i > 0; i--) {
                dOut = this._hiddenLayers[i - 1].Backward(dOut);
            }

            foreach (var layer in this._hiddenLayers) {
                if (layer is AffineDouble affine) {
                    yield return (affine.DMatrix, affine.DVector);
                }
            }
        }
    }
}