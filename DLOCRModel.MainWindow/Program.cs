using System;
using System.Collections.Generic;
using System.Globalization;

using DLOCRModel.Math;
using DLOCRModel.Math.Layer;

using MathNet.Numerics.LinearAlgebra;

using DLOCRModel.Math.ImagesProgram;

using static System.Math;

namespace DLOCRModel.MainWindow {

    internal class Program {

        private static void Main(String[] args) {

            trainAndTest trainandtest = new trainAndTest();
            // 訓練
            Matrix<Double> trainMatrix =trainandtest.getTrainMatrix();
            Matrix<Double> testMatrix = trainandtest.getTestMatrix();
            // 測試
            Matrix<Double> resultMatrix =trainandtest.getResultMatrix();
            Matrix<Double> resultTestMatrix = trainandtest.getResultTestMatrix();

            /////////////////////////
            /// 超參數
            /////////////////////////
            // 訓練次數
            Int32 iterNum = 1 << 14; // 16384
            // 學習樣本總數
            Int32 trainNum = trainMatrix.ColumnCount;
            // 批次內數量
            Int32 batchNum = 1 << 7; // 128
            // 學習速率
            Double learnRate = 0.1;

            var perEpoch = Max(iterNum / batchNum, 1);

            var trainLossList = new List<Double>();

            var ranM = new Func<Int32, Int32, Matrix<Double>>(Matrix<Double>.Build.Random);
            var ranV = new Func<Int32, Vector<Double>>(Vector<Double>.Build.Random);

            var size = new {
                input = 3000,
                hidden1 = 500,
                hidden2 = 100,
                output = testMatrix.RowCount
            };

            var mat1 = ranM(size.input, size.hidden1);
            var vct1 = ranV(size.hidden1);
            var mat2 = ranM(size.hidden1, size.hidden2);
            var vct2 = ranV(size.hidden2);
            var mat3 = ranM(size.hidden2, size.output);
            var vct3 = ranV(size.output);

            var hiddenLayers = new List<IHiddenLayer<Double>> {
                new AffineDouble(mat1, vct1),
                new ReluDouble(),
                new AffineDouble(mat2, vct2),
                new AffineDouble(mat3, vct3)
            };

            var network = new NetworkDouble(hiddenLayers, new SoftmaxWithLossDouble());

            var ran = new Random((1 << 13) - 1);
            // 訓練回合
            for (int i = 0; i < iterNum; i++) {
                var trainBatch = Matrix<Double>.Build.Dense(trainNum, batchNum);
                var testBatch = Matrix<Double>.Build.Dense(trainNum, batchNum);

                for (int j = 0; j < batchNum; j++) {
                    var rNum = ran.Next(trainNum);
                    trainBatch.SetColumn(j, trainMatrix.Column(rNum));
                    testBatch.SetColumn(j, testMatrix.Column(rNum));
                }

                var grad = network.Gradient(trainBatch, testBatch);
                network.Update(grad, learnRate);

                var loss = network.Loss(trainBatch, testBatch);
                trainLossList.Add(loss);
                // 列印結果評估
                if (!(i % perEpoch is 0)) {
                    continue;
                }

                var trainAccuracy = network.Accuracy(trainMatrix, testMatrix);
                var testAccuracy = network.Accuracy(resultMatrix, resultTestMatrix);
                Console.WriteLine(i.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine(nameof(trainAccuracy) + ": " + trainAccuracy.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine(nameof(testAccuracy) + ": " + testAccuracy.ToString(CultureInfo.InvariantCulture));
            }
        }
    }
}