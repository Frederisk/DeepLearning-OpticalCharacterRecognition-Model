#include "pch.hpp"

#include "DLOCRModel.Calculate.hpp"

String^ DLOCRModel::Calculate::Class1::Foo() {
    // export
    {
        array<Double, 2>^ mat = Math::ExportClass::BuildRandomMatArr<Double>(10, 10);
        array<Double>^ vct = Math::ExportClass::BuildRandomVctArr<Double>(10);
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