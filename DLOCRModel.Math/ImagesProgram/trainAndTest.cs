using System;

using MathNet.Numerics.LinearAlgebra;

namespace DLOCRModel.Math.ImagesProgram {

    public class TrainAndTest {
        private readonly Int32 _trainNumber;
        private readonly Int32 _resultNumber;
        private Matrix<Double> _trainMatrix;
        private Matrix<Double> _testMatrix;
        private Matrix<Double> _resultMatrix;
        private Matrix<Double> _resultTestMatrix;

        private Boolean _hasTrainMatrix;
        private Boolean _hasResultMatrix;

        public TrainAndTest(int resultNumber) :
            this(resultNumber, resultNumber * 10) {
        }

        public TrainAndTest(int trainNumber = 1000, int resultNumber = 100) {
            this._trainNumber = trainNumber;
            this._resultNumber = resultNumber;
        }

        private void TrainMatrix() {
            var rd = new Random((1 << 13) - 1);
            Matrix<Double> matrix = Matrix<Double>.Build.Dense(this._trainNumber, 16384);
            Matrix<Double> test = Matrix<Double>.Build.Dense(this._trainNumber, 62);
            for (Int32 i = 0; i < this._trainNumber; i++) {
                Int32 category = rd.Next(1, 63);
                Int32 a = rd.Next(1, 1017);
                FntConvertMatrix fnt = new FntConvertMatrix(category);
                matrix.SetRow(i, fnt.GetImages().Row(a));
                // TODO: 放棄修正
                //var bs = new List<Double>();
                //for (Int32 j = 0; j < 62; j++) {
                //    bs.Add(j == (category - 1) ? 1 : 0);
                //}
                //test.SetRow(i, bs.ToArray());
                var b = new Double[62];
                for (Int32 j = 0; j < 62; j++) {
                    b[j] = 0;
                    if (j == category - 1) {
                        b[j] = 1;
                    }
                }
                test.SetRow(i, b);
            }
            this._trainMatrix = matrix;
            this._testMatrix = test;
        }

        private void ResultMatrix() {
            // TODO: 大段邏輯重複，放棄修正
            var rd = new Random();
            Matrix<Double> matrix = Matrix<Double>.Build.Random(this._resultNumber, 16384);
            Matrix<Double> result = Matrix<Double>.Build.Random(this._resultNumber, 62);
            for (Int32 i = 0; i < this._resultNumber; i++) {
                int category = rd.Next(1, 63);
                int a = rd.Next(1, 1017);
                FntConvertMatrix fnt = new FntConvertMatrix(category);
                matrix.SetRow(i, fnt.GetImages().Row(a));
                Double[] b = new Double[62];
                for (int j = 0; j < 62; j++) {
                    b[j] = 0;
                    if (j == category - 1) {
                        b[j] = 1;
                    }
                }
                result.SetRow(i, b);
            }
            this._resultMatrix = matrix;
            this._resultTestMatrix = result;
        }

        private Matrix<Double> GetMatrix(ref Boolean has, Action act, Matrix<Double> result) {
            if (has) return result;
            act();
            has = true;
            return result;
        }

        public Matrix<Double> GetTrainMatrix() =>
            GetMatrix(ref this._hasTrainMatrix, this.TrainMatrix, this._trainMatrix);

        public Matrix<Double> GetTestMatrix() =>
            GetMatrix(ref this._hasTrainMatrix, this.TrainMatrix, this._testMatrix);

        public Matrix<Double> GetResultMatrix() =>
            GetMatrix(ref this._hasResultMatrix, this.ResultMatrix, this._resultMatrix);

        public Matrix<Double> GetResultTestMatrix() =>
            GetMatrix(ref this._hasResultMatrix, this.ResultMatrix, this._resultTestMatrix);
    }
}