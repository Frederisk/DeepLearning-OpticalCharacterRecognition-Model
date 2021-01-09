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

        public Double Loss(Matrix<Double> input, Matrix<Double> teach) {
            var y = this.Predict(input);
            return this._outputLayer.Forward(y, teach);
        }

        public Double Accuracy(Matrix<Double> input, Matrix<Double> teach) {
            var y = this.Predict(input);
            Double a = 0;
            //var x = Vector<Int32>.Build.Dense(input.ColumnCount);
            //var t = Vector<Int32>.Build.Dense(input.ColumnCount);
            for (int i = 0; i < input.ColumnCount; i++) {
                //x[i] = input.Column(i).MaximumIndex();
                //t[i] = teach.Column(i).MaximumIndex();
                if (input.Column(i).MaximumIndex() == teach.Column(i).MaximumIndex()) {
                    a++;
                }
            }
            return a / input.ColumnCount;
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

        public void Update(IEnumerable<(Matrix<Double> Mat, Vector<Double> Vct)> updateTuples, Double rate) {
            var updateQueue = new Queue<(Matrix<Double> Mat, Vector<Double> Vct)>(updateTuples);
            foreach (var t in this._hiddenLayers) {
                if (!(t is AffineDouble)) {
                    continue;
                }

                var item = updateQueue.Dequeue();
                ((AffineDouble)t).Update(item.Mat, item.Vct, rate);
            }
        }
    }
}