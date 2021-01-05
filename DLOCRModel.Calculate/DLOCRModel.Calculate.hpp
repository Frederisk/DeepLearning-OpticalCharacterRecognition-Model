#pragma once

using namespace System;
using MathNet::Numerics::LinearAlgebra::Matrix;
namespace DLOCRModel {
    namespace Calculate {
        public ref class Class1 abstract sealed {
        public:
            static String^ Foo();
        };

        public ref class FeedforwardNetworkPiece sealed {
        public:
            FeedforwardNetworkPiece(array<double,2>^ X0, array<double, 2>^ W0, array<double>^ B0);
            FeedforwardNetworkPiece(array<double, 2>^ X0);
            FeedforwardNetworkPiece();

            static double loss(array<double, 2>^ X,array<double, 2>^ T);//损失函数
            static array<double, 2>^ gradient(array<double, 2>^ X, array<double, 2>^ T);//数值微分法计算梯度
            static array<double, 2>^ numerical_gradient(array<double, 2>^ X, array<double, 2>^ T);//误差反向传播计算梯度
            
            void RandWB();//随机生成WB

            //设定输入资料、权值和偏权值
            void setX(array<double, 2>^ X0);
            void setW(array<double, 2>^ W0);
            void setB(array<double>^ B0);

            array<double, 2>^ getX();
            array<double, 2>^ getY();
            array<double, 2>^ getW();
            array<double>^ getB();

            static array<double, 2>^ ReLu();//活化函数
            void forward();//正向传播
            void backward();//反向传播

        private:
            
            array<double, 2>^ X;//input
            array<double, 2>^ W;
            array<double>^ B;
            array<double, 2>^ Y;//output
        };
    }
}