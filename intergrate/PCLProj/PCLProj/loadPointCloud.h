#pragma once
#include<string>
extern "C"
{
	__declspec(dllexport) int readPointCloudFile(float* voPoints);
}