#include "pch.hpp"

#include "DLOCRModel.Calculate.hpp"

using MathNet::Numerics::LinearAlgebra::Matrix;

String^ DLOCRModel::Calculate::Class1::Foo() {
    // export
    {
        Nullable<Int32>^ a = nullptr;
        array<Double, 2>^ mat = Math::ExportClass::BuildRandomMatArr<Double>(10, 10, Nullable<Int32>());
        array<Double>^ vct = Math::ExportClass::BuildRandomVctArr<Double>(10, Nullable<Int32>());
        Console::WriteLine("mat type is: " + mat->GetType()->ToString());
        int num = 0;
        for each (Double item in mat) {
            Console::Write(item.ToString() + " ");
            num++;
            if (!(num % 10)) Console::WriteLine();
        }
        Console::WriteLine("vct type is: " + vct->GetType()->ToString());
        for each (Double item in vct) {
            Console::Write(item.ToString() + " ");
        }
    }
    // import
    {
        using DoubleMatrix = MathNet::Numerics::LinearAlgebra::Matrix<Double>;
        using DoubleVector = MathNet::Numerics::LinearAlgebra::Vector<Double>;
        auto mat = DoubleMatrix::Build->Random(10, 10);
        auto vct = DoubleVector::Build->Random(10);
        Console::WriteLine("mat type is: " + mat->GetType()->ToString());
        Console::WriteLine(mat->ToString());
        Console::WriteLine("vct type is: " + vct->GetType()->ToString());
        Console::WriteLine(vct->ToString());
    }
    // return string
    String^ st = gcnew String("Hello World" + Math::ExportClass::GetExclamationMark());
    return st;
}

void DLOCRModel::Calculate::FeedforwardNetworkPiece::setX(array<double, 2>^ X0)
{
    X = gcnew array<double, 2>(64, 64);//矩阵大小暂定为64*64
    for (int i = 0; i < 64; i++) {
        for (int j = 0; j < 64; j++) {
            X->SetValue(X0->GetValue(i, j), i, j);
        }
    }
}

void DLOCRModel::Calculate::FeedforwardNetworkPiece::setW(array<double, 2>^ W0)
{
    W = gcnew array<double, 2>(64, 64);//矩阵大小暂定为64*64
    for (int i = 0; i < 64; i++) {
        for (int j = 0; j < 64; j++) {
            W->SetValue(W0->GetValue(i, j), i, j);
        }
    }
}

void DLOCRModel::Calculate::FeedforwardNetworkPiece::setB(array<double>^ B0)
{
    B = gcnew array<double>(64);//矩阵大小暂定为1*64
    for (int i = 0; i < 64; i++) {
        B->SetValue(B0->GetValue(i), i);
    }
}

array<double, 2>^ DLOCRModel::Calculate::FeedforwardNetworkPiece::getX()
{
    return X;
}

array<double, 2>^ DLOCRModel::Calculate::FeedforwardNetworkPiece::getY()
{
    return Y;
}

array<double, 2>^ DLOCRModel::Calculate::FeedforwardNetworkPiece::getW()
{
    return W;
}

array<double>^ DLOCRModel::Calculate::FeedforwardNetworkPiece::getB()
{
    return B;
}

array<double, 2>^ DLOCRModel::Calculate::FeedforwardNetworkPiece::ReLu()
{
    throw gcnew System::NotImplementedException();
    // TODO: 在此处插入 return 语句
}

void DLOCRModel::Calculate::FeedforwardNetworkPiece::forward()
{
    throw gcnew System::NotImplementedException();
}

void DLOCRModel::Calculate::FeedforwardNetworkPiece::backward()
{
    throw gcnew System::NotImplementedException();
}



DLOCRModel::Calculate::FeedforwardNetworkPiece::FeedforwardNetworkPiece(array<double, 2>^ X0, array<double, 2>^ W0, array<double>^ B0)
{
    setX(X0);
    setW(W0);
    setB(B0);
}

DLOCRModel::Calculate::FeedforwardNetworkPiece::FeedforwardNetworkPiece(array<double, 2>^ X0)
{
    setX(X0);
    RandWB();
}

DLOCRModel::Calculate::FeedforwardNetworkPiece::FeedforwardNetworkPiece()
{
    X = gcnew array<double, 2>(64, 64);
    RandWB();
}



double DLOCRModel::Calculate::FeedforwardNetworkPiece::loss(array<double, 2>^ X,array<double, 2>^ T)
{

    throw gcnew System::NotImplementedException();
}

array<double, 2>^ DLOCRModel::Calculate::FeedforwardNetworkPiece::gradient(array<double, 2>^ X, array<double, 2>^ T)
{
    throw gcnew System::NotImplementedException();
    // TODO: 在此处插入 return 语句
}

array<double, 2>^ DLOCRModel::Calculate::FeedforwardNetworkPiece::numerical_gradient(array<double, 2>^ X, array<double, 2>^ T)
{
    throw gcnew System::NotImplementedException();
    // TODO: 在此处插入 return 语句
}

void DLOCRModel::Calculate::FeedforwardNetworkPiece::RandWB()
{

}
