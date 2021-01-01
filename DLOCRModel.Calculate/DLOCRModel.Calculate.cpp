#include "pch.hpp"

#include "DLOCRModel.Calculate.hpp"

String^ DLOCRModel::Calculate::Class1::Foo() {
    String^ st = gcnew String("Hello World" + DLOCRModel::Math::ExportClass::GetExclamationMark());
    return st;
}