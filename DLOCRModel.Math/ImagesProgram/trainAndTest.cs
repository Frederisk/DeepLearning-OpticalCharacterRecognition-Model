using System;
using System.Collections.Generic;
using System.Text;

using MathNet.Numerics.LinearAlgebra;
namespace DLOCRModel.Math.ImagesProgram {
    public class trainAndTest {
        private int trainNumber;
        private int resultNumber;
        Matrix<double> trainMatrix;
        Matrix<double> testMatrix;
        Matrix<double> resultMatrix;
        Matrix<double> resultTestMatrix;
        public trainAndTest() {
            trainNumber = 1000;
            resultNumber = 100;
        }
        public trainAndTest(int resultNumber) {
            this.resultNumber = resultNumber;
            this.trainNumber = resultNumber * 10;
        }
        public trainAndTest(int trainNumber,int resultNumber) {
            this.trainNumber = trainNumber;
            this.resultNumber = resultNumber;
        }
        public void TrainMatrix() {
            int category=1;
            int a=1;
            Random rd = new Random();
            Matrix<double> matrix = Matrix<double>.Build.Random(trainNumber,5000);
            Matrix<double> test = Matrix<double>.Build.Random(trainNumber, 62);
            for(int i = 0; i < trainNumber; i++) {
                category = rd.Next(1,63);
                a = rd.Next(1, 1017);
                FntConvertMatrix fnt = new FntConvertMatrix(category);
                matrix.SetRow(i, fnt.getImages().Row(a));
                double[] b = new double[62];
                for(int j = 0; j < 62; j++) {
                    b[j] = 0;
                    if (j == category - 1) {
                        b[j] = 1;
                    }
                }
                test.SetRow(i, b);
            }
            trainMatrix = matrix;
            testMatrix = test;
        }
               
        public void ResultMatrix() {
            int category = 1;
            int a = 1;
            Random rd = new Random();
            Matrix<double> matrix = Matrix<double>.Build.Random(resultNumber, 5000);
            Matrix<double> result = Matrix<double>.Build.Random(resultNumber, 62);
            for (int i = 0; i < resultNumber; i++) {
                category = rd.Next(1, 63);
                a = rd.Next(1, 1017);
                FntConvertMatrix fnt = new FntConvertMatrix(category);
                matrix.SetRow(i, fnt.getImages().Row(a));
                double[] b = new double[62];
                for (int j = 0; j < 62; j++) {
                    b[j] = 0;
                    if (j == category - 1) {
                        b[j] = 1;
                    }
                }
                result.SetRow(i, b);
            }
            resultMatrix = matrix;
            resultTestMatrix = result;
        }

        public Matrix<double> getTrainMatrix() {
            TrainMatrix();
            return trainMatrix;
        }
        public Matrix<double> getTestMatrix() {
            TrainMatrix();
            return testMatrix;
        }
        public Matrix<double> getResultMatrix() {
            ResultMatrix();
            return resultMatrix;
        }
        public Matrix<double> getResultTestMatrix() {
            ResultMatrix();
            return resultTestMatrix;
        }
    }
}
