// DLOCRModel_OpenCV.cpp : 此檔案包含 'main' 函式。程式會於該處開始執行及結束執行。
//
#pragma comment(lib,"opencv_world451.lib")
#pragma comment(lib,"opencv_world451d.lib")

#include <iostream>
#include <opencv2/core.hpp>


int main() {
    cv::Mat mat = cv::Mat(100, 100, CV_8UC1);

    std::cout << "Hello World!\n";
}

