// DLOCRModel.OpenCV.cpp : 此檔案包含 'main' 函式。程式會於該處開始執行及結束執行。
//

#pragma comment(lib,"opencv_world451.lib")
#pragma comment(lib,"opencv_world451d.lib")

#include "Program.hpp"
#include <iostream>
#include <opencv2/core.hpp>

int __stdcall main(const int argc, char** argv) {
    return DLOCRModel::OpenCV::Program::Main(argc, argv);
}

int DLOCRModel::OpenCV::Program::Main(const int argc, char* argv[]) {
    const auto mat = cv::Mat(10, 10, CV_8UC3);
    std::cout << "mat channels is: " << mat.channels() << std::endl;
    std::cout << "Hello World!" << std::endl;
    return 0;
}