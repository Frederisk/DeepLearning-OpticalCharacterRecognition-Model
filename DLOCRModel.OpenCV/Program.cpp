// DLOCRModel.OpenCV.cpp : 此檔案包含 'main' 函式。程式會於該處開始執行及結束執行。
//

#pragma comment(lib,"opencv_world451.lib")
#pragma comment(lib,"opencv_world451d.lib")

#include "Program.h"
#include <iostream>
#include <opencv2/core.hpp>

int __stdcall main(int argc, char** argv) {
    return DLOCRModel::OpenCV::Progarm::Main(argc, argv);
}

int DLOCRModel::OpenCV::Progarm::Main(int argc, char* argv[]) {
    std::cout << "Hello World!" << std::endl;
    return 0;
}