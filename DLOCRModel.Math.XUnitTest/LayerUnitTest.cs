using System;

using DLOCRModel.Math.Layer;

using MathNet.Numerics.LinearAlgebra;

using Xunit;

namespace DLOCRModel.Math.XUnitTest {

    public class LayerUnitTest {

        [Fact]
        public void AffineTest() {
        }

        [Fact]
        public void ReluTest() {
            // Arrange
            var reluLayer = new ReluDouble();
            var inputArray = new Double[3, 3] {
                { 1, 2, 3 },
                { -1, -2, -3 },
                { -1, 0, 1 }
            };
            var forwardArray = new Double[3, 3] {
                { 1, 2, 3 },
                { 0, 0, 0 },
                { 0, 0, 1 }
            };
            var anotherArray = new Double[3, 3] {
                { 1, 1, 1 },
                { 1, 1, 1 },
                { 1, 1, 1 }
            };
            var backwardArray = new Double[3, 3] {
                { 1, 1, 1 },
                { 0, 0, 0 },
                { 0, 0, 1 }
            };

            var input = Matrix<Double>.Build.DenseOfArray(inputArray);
            var forward = Matrix<Double>.Build.DenseOfArray(forwardArray);
            var another = Matrix<Double>.Build.DenseOfArray(anotherArray);
            var backward = Matrix<Double>.Build.DenseOfArray(backwardArray);

            // Act
            var forwardResult = reluLayer.Forward(input);
            var backwardResult = reluLayer.Backward(another);

            // Assert
            Assert.Equal(forwardResult, forward);
            Assert.Equal(backwardResult, backward);
        }
    }
}