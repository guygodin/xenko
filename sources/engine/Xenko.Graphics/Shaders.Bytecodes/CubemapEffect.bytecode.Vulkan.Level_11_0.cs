﻿#if XENKO_GRAPHICS_API_VULKAN
//------------------------------------------------------------------------------
// <auto-generated>
//     Xenko Effect Compiler File Generated:
//     Effect [CubemapEffect]
//
//     Command Line: D:\Xenko\sources\engine\Xenko.Graphics\Shaders.Bytecodes\..\..\..\..\sources\assets\Xenko.Core.Assets.CompilerApp\bin\Release\net472\Xenko.Core.Assets.CompilerApp.exe --platform=Windows --property:RuntimeIdentifier=win-vulkan --output-path=D:\Xenko\sources\engine\Xenko.Graphics\Shaders.Bytecodes\obj\app_data --build-path=D:\Xenko\sources\engine\Xenko.Graphics\Shaders.Bytecodes\obj\build_app_data --package-file=Graphics.xkpkg
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Xenko.Graphics 
{
    public partial class CubemapEffect
    {
        private static readonly byte[] binaryBytecode = new byte[] {
7, 192, 254, 239, 0, 0, 9, 0, 0, 0, 0, 0, 22, 84, 101, 120, 116, 117, 114, 105, 110, 103, 46, 80, 111, 105, 110, 116, 83, 97, 109, 112, 108, 101, 114, 0, 0, 0, 0, 3, 0, 0, 0, 3, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 16, 0, 0, 0, 1, 0, 0, 0, 0, 0, 
0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 127, 255, 255, 255, 127, 127, 0, 0, 23, 84, 101, 120, 116, 117, 114, 105, 110, 103, 46, 76, 105, 110, 101, 97, 114, 83, 97, 109, 112, 108, 101, 114, 21, 0, 0, 0, 3, 0, 0, 0, 3, 0, 0, 0, 3, 0, 0, 0, 
0, 0, 0, 0, 16, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 127, 255, 255, 255, 127, 127, 0, 0, 29, 84, 101, 120, 116, 117, 114, 105, 110, 103, 46, 76, 105, 110, 101, 97, 114, 66, 111, 114, 100, 101, 114, 83, 97, 109, 
112, 108, 101, 114, 21, 0, 0, 0, 4, 0, 0, 0, 4, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 16, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 127, 255, 255, 255, 127, 127, 0, 0, 44, 84, 101, 120, 116, 117, 
114, 105, 110, 103, 46, 76, 105, 110, 101, 97, 114, 67, 108, 97, 109, 112, 67, 111, 109, 112, 97, 114, 101, 76, 101, 115, 115, 69, 113, 117, 97, 108, 83, 97, 109, 112, 108, 101, 114, 148, 0, 0, 0, 3, 0, 0, 0, 3, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 16, 0, 0, 0, 4, 
0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 127, 255, 255, 255, 127, 127, 0, 0, 28, 84, 101, 120, 116, 117, 114, 105, 110, 103, 46, 65, 110, 105, 115, 111, 116, 114, 111, 112, 105, 99, 83, 97, 109, 112, 108, 101, 114, 85, 0, 0, 0, 3, 0, 
0, 0, 3, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 16, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 127, 255, 255, 255, 127, 127, 0, 0, 34, 84, 101, 120, 116, 117, 114, 105, 110, 103, 46, 65, 110, 105, 115, 111, 
116, 114, 111, 112, 105, 99, 82, 101, 112, 101, 97, 116, 83, 97, 109, 112, 108, 101, 114, 85, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 16, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 
255, 127, 255, 255, 255, 127, 127, 0, 0, 28, 84, 101, 120, 116, 117, 114, 105, 110, 103, 46, 80, 111, 105, 110, 116, 82, 101, 112, 101, 97, 116, 83, 97, 109, 112, 108, 101, 114, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 16, 0, 0, 0, 1, 0, 
0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 127, 255, 255, 255, 127, 127, 0, 0, 29, 84, 101, 120, 116, 117, 114, 105, 110, 103, 46, 76, 105, 110, 101, 97, 114, 82, 101, 112, 101, 97, 116, 83, 97, 109, 112, 108, 101, 114, 21, 0, 0, 0, 1, 0, 
0, 0, 1, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 16, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 127, 255, 255, 255, 127, 127, 0, 0, 23, 84, 101, 120, 116, 117, 114, 105, 110, 103, 46, 82, 101, 112, 101, 97, 
116, 83, 97, 109, 112, 108, 101, 114, 21, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 16, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 127, 255, 255, 255, 127, 127, 0, 5, 0, 0, 
0, 0, 7, 80, 101, 114, 68, 114, 97, 119, 10, 0, 0, 0, 26, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 7, 80, 101, 114, 68, 114, 97, 119, 0, 7, 80, 101, 114, 68, 114, 97, 119, 1, 0, 
0, 0, 255, 255, 255, 255, 1, 0, 0, 0, 1, 0, 7, 71, 108, 111, 98, 97, 108, 115, 10, 0, 0, 0, 26, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 7, 71, 108, 111, 98, 97, 108, 115, 0, 
7, 71, 108, 111, 98, 97, 108, 115, 5, 0, 0, 0, 255, 255, 255, 255, 1, 0, 0, 0, 1, 0, 22, 84, 101, 120, 116, 117, 114, 105, 110, 103, 46, 84, 101, 120, 116, 117, 114, 101, 67, 117, 98, 101, 48, 9, 0, 0, 0, 9, 0, 0, 0, 1, 0, 0, 0, 3, 0, 0, 0, 1, 0, 0, 
0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 17, 84, 101, 120, 116, 117, 114, 101, 67, 117, 98, 101, 48, 95, 105, 100, 51, 52, 1, 5, 0, 0, 0, 255, 255, 255, 255, 1, 0, 0, 0, 1, 0, 17, 84, 101, 120, 116, 117, 114, 105, 110, 103, 46, 83, 97, 109, 112, 
108, 101, 114, 8, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 12, 83, 97, 109, 112, 108, 101, 114, 95, 105, 100, 52, 50, 1, 5, 0, 0, 0, 255, 255, 255, 255, 1, 0, 0, 0, 
1, 0, 9, 78, 111, 83, 97, 109, 112, 108, 101, 114, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 9, 78, 111, 83, 97, 109, 112, 108, 101, 114, 1, 5, 0, 0, 0, 255, 255, 
255, 255, 1, 0, 0, 0, 1, 0, 2, 0, 0, 0, 0, 0, 7, 80, 101, 114, 68, 114, 97, 119, 64, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 3, 0, 0, 0, 3, 0, 0, 0, 4, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 64, 0, 0, 0, 1, 1, 0, 26, 83, 
112, 114, 105, 116, 101, 66, 97, 115, 101, 46, 77, 97, 116, 114, 105, 120, 84, 114, 97, 110, 115, 102, 111, 114, 109, 0, 20, 77, 97, 116, 114, 105, 120, 84, 114, 97, 110, 115, 102, 111, 114, 109, 95, 105, 100, 55, 51, 0, 0, 0, 0, 64, 0, 0, 0, 1, 1, 0, 0, 7, 71, 108, 111, 98, 
97, 108, 115, 84, 0, 0, 0, 1, 0, 0, 0, 0, 11, 0, 0, 0, 1, 0, 0, 0, 3, 0, 0, 0, 1, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 8, 0, 0, 0, 1, 1, 0, 27, 84, 101, 120, 116, 117, 114, 105, 110, 103, 46, 84, 101, 120, 116, 117, 114, 101, 48, 84, 101, 
120, 101, 108, 83, 105, 122, 101, 0, 22, 84, 101, 120, 116, 117, 114, 101, 48, 84, 101, 120, 101, 108, 83, 105, 122, 101, 95, 105, 100, 49, 53, 0, 0, 0, 0, 8, 0, 0, 0, 1, 1, 1, 0, 0, 0, 3, 0, 0, 0, 1, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 8, 0, 0, 
0, 1, 1, 0, 27, 84, 101, 120, 116, 117, 114, 105, 110, 103, 46, 84, 101, 120, 116, 117, 114, 101, 49, 84, 101, 120, 101, 108, 83, 105, 122, 101, 0, 22, 84, 101, 120, 116, 117, 114, 101, 49, 84, 101, 120, 101, 108, 83, 105, 122, 101, 95, 105, 100, 49, 55, 8, 0, 0, 0, 8, 0, 0, 0, 
1, 1, 1, 0, 0, 0, 3, 0, 0, 0, 1, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 8, 0, 0, 0, 1, 1, 0, 27, 84, 101, 120, 116, 117, 114, 105, 110, 103, 46, 84, 101, 120, 116, 117, 114, 101, 50, 84, 101, 120, 101, 108, 83, 105, 122, 101, 0, 22, 84, 101, 120, 116, 117, 
114, 101, 50, 84, 101, 120, 101, 108, 83, 105, 122, 101, 95, 105, 100, 49, 57, 16, 0, 0, 0, 8, 0, 0, 0, 1, 1, 1, 0, 0, 0, 3, 0, 0, 0, 1, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 8, 0, 0, 0, 1, 1, 0, 27, 84, 101, 120, 116, 117, 114, 105, 110, 103, 
46, 84, 101, 120, 116, 117, 114, 101, 51, 84, 101, 120, 101, 108, 83, 105, 122, 101, 0, 22, 84, 101, 120, 116, 117, 114, 101, 51, 84, 101, 120, 101, 108, 83, 105, 122, 101, 95, 105, 100, 50, 49, 24, 0, 0, 0, 8, 0, 0, 0, 1, 1, 1, 0, 0, 0, 3, 0, 0, 0, 1, 0, 0, 0, 
2, 0, 0, 0, 0, 0, 0, 0, 8, 0, 0, 0, 1, 1, 0, 27, 84, 101, 120, 116, 117, 114, 105, 110, 103, 46, 84, 101, 120, 116, 117, 114, 101, 52, 84, 101, 120, 101, 108, 83, 105, 122, 101, 0, 22, 84, 101, 120, 116, 117, 114, 101, 52, 84, 101, 120, 101, 108, 83, 105, 122, 101, 95, 105, 
100, 50, 51, 32, 0, 0, 0, 8, 0, 0, 0, 1, 1, 1, 0, 0, 0, 3, 0, 0, 0, 1, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 8, 0, 0, 0, 1, 1, 0, 27, 84, 101, 120, 116, 117, 114, 105, 110, 103, 46, 84, 101, 120, 116, 117, 114, 101, 53, 84, 101, 120, 101, 108, 
83, 105, 122, 101, 0, 22, 84, 101, 120, 116, 117, 114, 101, 53, 84, 101, 120, 101, 108, 83, 105, 122, 101, 95, 105, 100, 50, 53, 40, 0, 0, 0, 8, 0, 0, 0, 1, 1, 1, 0, 0, 0, 3, 0, 0, 0, 1, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 8, 0, 0, 0, 1, 1, 
0, 27, 84, 101, 120, 116, 117, 114, 105, 110, 103, 46, 84, 101, 120, 116, 117, 114, 101, 54, 84, 101, 120, 101, 108, 83, 105, 122, 101, 0, 22, 84, 101, 120, 116, 117, 114, 101, 54, 84, 101, 120, 101, 108, 83, 105, 122, 101, 95, 105, 100, 50, 55, 48, 0, 0, 0, 8, 0, 0, 0, 1, 1, 1, 
0, 0, 0, 3, 0, 0, 0, 1, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 8, 0, 0, 0, 1, 1, 0, 27, 84, 101, 120, 116, 117, 114, 105, 110, 103, 46, 84, 101, 120, 116, 117, 114, 101, 55, 84, 101, 120, 101, 108, 83, 105, 122, 101, 0, 22, 84, 101, 120, 116, 117, 114, 101, 55, 
84, 101, 120, 101, 108, 83, 105, 122, 101, 95, 105, 100, 50, 57, 56, 0, 0, 0, 8, 0, 0, 0, 1, 1, 1, 0, 0, 0, 3, 0, 0, 0, 1, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 8, 0, 0, 0, 1, 1, 0, 27, 84, 101, 120, 116, 117, 114, 105, 110, 103, 46, 84, 101, 
120, 116, 117, 114, 101, 56, 84, 101, 120, 101, 108, 83, 105, 122, 101, 0, 22, 84, 101, 120, 116, 117, 114, 101, 56, 84, 101, 120, 101, 108, 83, 105, 122, 101, 95, 105, 100, 51, 49, 64, 0, 0, 0, 8, 0, 0, 0, 1, 1, 1, 0, 0, 0, 3, 0, 0, 0, 1, 0, 0, 0, 2, 0, 0, 
0, 0, 0, 0, 0, 8, 0, 0, 0, 1, 1, 0, 27, 84, 101, 120, 116, 117, 114, 105, 110, 103, 46, 84, 101, 120, 116, 117, 114, 101, 57, 84, 101, 120, 101, 108, 83, 105, 122, 101, 0, 22, 84, 101, 120, 116, 117, 114, 101, 57, 84, 101, 120, 101, 108, 83, 105, 122, 101, 95, 105, 100, 51, 51, 
72, 0, 0, 0, 8, 0, 0, 0, 1, 1, 0, 0, 0, 0, 3, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 1, 1, 0, 21, 67, 117, 98, 101, 109, 97, 112, 69, 102, 102, 101, 99, 116, 46, 79, 112, 97, 99, 105, 116, 121, 0, 12, 79, 112, 97, 
99, 105, 116, 121, 95, 105, 100, 55, 52, 80, 0, 0, 0, 4, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 8, 80, 79, 83, 73, 84, 73, 79, 78, 0, 0, 0, 0, 0, 5, 0, 0, 0, 13, 67, 117, 98, 101, 109, 97, 112, 69, 102, 102, 
101, 99, 116, 1, 120, 26, 33, 63, 31, 104, 43, 113, 122, 10, 160, 69, 126, 205, 141, 29, 10, 83, 112, 114, 105, 116, 101, 66, 97, 115, 101, 1, 227, 25, 196, 119, 122, 150, 76, 62, 187, 143, 130, 89, 14, 78, 39, 241, 10, 83, 104, 97, 100, 101, 114, 66, 97, 115, 101, 1, 172, 190, 61, 77, 
68, 160, 70, 238, 222, 135, 17, 118, 190, 233, 199, 84, 16, 83, 104, 97, 100, 101, 114, 66, 97, 115, 101, 83, 116, 114, 101, 97, 109, 1, 163, 165, 191, 129, 133, 242, 163, 216, 153, 114, 41, 63, 128, 100, 48, 211, 9, 84, 101, 120, 116, 117, 114, 105, 110, 103, 1, 230, 218, 239, 13, 217, 10, 85, 
249, 84, 156, 111, 93, 41, 30, 97, 165, 0, 2, 0, 0, 0, 0, 1, 0, 0, 0, 1, 28, 64, 56, 247, 125, 7, 187, 113, 48, 186, 174, 249, 213, 163, 164, 238, 0, 127, 8, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 8, 80, 79, 83, 73, 84, 73, 79, 78, 0, 2, 0, 0, 
0, 7, 80, 101, 114, 68, 114, 97, 119, 1, 0, 0, 0, 9, 78, 111, 83, 97, 109, 112, 108, 101, 114, 41, 0, 0, 0, 0, 72, 8, 0, 0, 3, 2, 35, 7, 0, 0, 1, 0, 7, 0, 8, 0, 67, 0, 0, 0, 0, 0, 0, 0, 17, 0, 2, 0, 1, 0, 0, 0, 11, 0, 6, 0, 
1, 0, 0, 0, 71, 76, 83, 76, 46, 115, 116, 100, 46, 52, 53, 48, 0, 0, 0, 0, 14, 0, 3, 0, 0, 0, 0, 0, 1, 0, 0, 0, 15, 0, 8, 0, 0, 0, 0, 0, 4, 0, 0, 0, 109, 97, 105, 110, 0, 0, 0, 0, 14, 0, 0, 0, 51, 0, 0, 0, 56, 0, 0, 0, 
3, 0, 3, 0, 2, 0, 0, 0, 194, 1, 0, 0, 5, 0, 4, 0, 4, 0, 0, 0, 109, 97, 105, 110, 0, 0, 0, 0, 5, 0, 5, 0, 8, 0, 0, 0, 86, 83, 95, 73, 78, 80, 85, 84, 0, 0, 0, 0, 6, 0, 7, 0, 8, 0, 0, 0, 0, 0, 0, 0, 80, 111, 115, 105, 
116, 105, 111, 110, 95, 105, 100, 55, 50, 0, 0, 0, 5, 0, 5, 0, 10, 0, 0, 0, 95, 48, 105, 110, 112, 117, 116, 95, 48, 0, 0, 0, 5, 0, 5, 0, 14, 0, 0, 0, 97, 95, 80, 79, 83, 73, 84, 73, 79, 78, 48, 0, 5, 0, 5, 0, 18, 0, 0, 0, 86, 83, 95, 83, 
84, 82, 69, 65, 77, 83, 0, 0, 6, 0, 7, 0, 18, 0, 0, 0, 0, 0, 0, 0, 80, 111, 115, 105, 116, 105, 111, 110, 95, 105, 100, 55, 50, 0, 0, 0, 6, 0, 8, 0, 18, 0, 0, 0, 1, 0, 0, 0, 83, 104, 97, 100, 105, 110, 103, 80, 111, 115, 105, 116, 105, 111, 110, 95, 
105, 100, 48, 0, 5, 0, 4, 0, 20, 0, 0, 0, 115, 116, 114, 101, 97, 109, 115, 0, 5, 0, 4, 0, 28, 0, 0, 0, 80, 101, 114, 68, 114, 97, 119, 0, 6, 0, 9, 0, 28, 0, 0, 0, 0, 0, 0, 0, 77, 97, 116, 114, 105, 120, 84, 114, 97, 110, 115, 102, 111, 114, 109, 95, 
105, 100, 55, 51, 0, 0, 0, 0, 5, 0, 3, 0, 30, 0, 0, 0, 0, 0, 0, 0, 5, 0, 5, 0, 37, 0, 0, 0, 86, 83, 95, 79, 85, 84, 80, 85, 84, 0, 0, 0, 6, 0, 8, 0, 37, 0, 0, 0, 0, 0, 0, 0, 83, 104, 97, 100, 105, 110, 103, 80, 111, 115, 105, 116, 
105, 111, 110, 95, 105, 100, 48, 0, 6, 0, 7, 0, 37, 0, 0, 0, 1, 0, 0, 0, 80, 111, 115, 105, 116, 105, 111, 110, 95, 105, 100, 55, 50, 0, 0, 0, 5, 0, 5, 0, 39, 0, 0, 0, 95, 48, 111, 117, 116, 112, 117, 116, 95, 48, 0, 0, 5, 0, 6, 0, 49, 0, 0, 0, 
103, 108, 95, 80, 101, 114, 86, 101, 114, 116, 101, 120, 0, 0, 0, 0, 6, 0, 6, 0, 49, 0, 0, 0, 0, 0, 0, 0, 103, 108, 95, 80, 111, 115, 105, 116, 105, 111, 110, 0, 6, 0, 7, 0, 49, 0, 0, 0, 1, 0, 0, 0, 103, 108, 95, 80, 111, 105, 110, 116, 83, 105, 122, 101, 
0, 0, 0, 0, 6, 0, 7, 0, 49, 0, 0, 0, 2, 0, 0, 0, 103, 108, 95, 67, 108, 105, 112, 68, 105, 115, 116, 97, 110, 99, 101, 0, 6, 0, 7, 0, 49, 0, 0, 0, 3, 0, 0, 0, 103, 108, 95, 67, 117, 108, 108, 68, 105, 115, 116, 97, 110, 99, 101, 0, 5, 0, 3, 0, 
51, 0, 0, 0, 0, 0, 0, 0, 5, 0, 5, 0, 56, 0, 0, 0, 118, 95, 80, 79, 83, 73, 84, 73, 79, 78, 48, 0, 5, 0, 5, 0, 66, 0, 0, 0, 78, 111, 83, 97, 109, 112, 108, 101, 114, 0, 0, 0, 71, 0, 4, 0, 14, 0, 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 
72, 0, 4, 0, 28, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 72, 0, 5, 0, 28, 0, 0, 0, 0, 0, 0, 0, 35, 0, 0, 0, 0, 0, 0, 0, 72, 0, 5, 0, 28, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 16, 0, 0, 0, 71, 0, 3, 0, 28, 0, 0, 0, 
2, 0, 0, 0, 71, 0, 4, 0, 30, 0, 0, 0, 34, 0, 0, 0, 0, 0, 0, 0, 71, 0, 4, 0, 30, 0, 0, 0, 33, 0, 0, 0, 1, 0, 0, 0, 72, 0, 5, 0, 49, 0, 0, 0, 0, 0, 0, 0, 11, 0, 0, 0, 0, 0, 0, 0, 72, 0, 5, 0, 49, 0, 0, 0, 
1, 0, 0, 0, 11, 0, 0, 0, 1, 0, 0, 0, 72, 0, 5, 0, 49, 0, 0, 0, 2, 0, 0, 0, 11, 0, 0, 0, 3, 0, 0, 0, 72, 0, 5, 0, 49, 0, 0, 0, 3, 0, 0, 0, 11, 0, 0, 0, 4, 0, 0, 0, 71, 0, 3, 0, 49, 0, 0, 0, 2, 0, 0, 0, 
71, 0, 4, 0, 56, 0, 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 71, 0, 4, 0, 66, 0, 0, 0, 34, 0, 0, 0, 0, 0, 0, 0, 71, 0, 4, 0, 66, 0, 0, 0, 33, 0, 0, 0, 41, 0, 0, 0, 19, 0, 2, 0, 2, 0, 0, 0, 33, 0, 3, 0, 3, 0, 0, 0, 
2, 0, 0, 0, 22, 0, 3, 0, 6, 0, 0, 0, 32, 0, 0, 0, 23, 0, 4, 0, 7, 0, 0, 0, 6, 0, 0, 0, 4, 0, 0, 0, 30, 0, 3, 0, 8, 0, 0, 0, 7, 0, 0, 0, 32, 0, 4, 0, 9, 0, 0, 0, 7, 0, 0, 0, 8, 0, 0, 0, 21, 0, 4, 0, 
11, 0, 0, 0, 32, 0, 0, 0, 1, 0, 0, 0, 43, 0, 4, 0, 11, 0, 0, 0, 12, 0, 0, 0, 0, 0, 0, 0, 32, 0, 4, 0, 13, 0, 0, 0, 1, 0, 0, 0, 7, 0, 0, 0, 59, 0, 4, 0, 13, 0, 0, 0, 14, 0, 0, 0, 1, 0, 0, 0, 32, 0, 4, 0, 
16, 0, 0, 0, 7, 0, 0, 0, 7, 0, 0, 0, 30, 0, 4, 0, 18, 0, 0, 0, 7, 0, 0, 0, 7, 0, 0, 0, 32, 0, 4, 0, 19, 0, 0, 0, 7, 0, 0, 0, 18, 0, 0, 0, 43, 0, 4, 0, 11, 0, 0, 0, 24, 0, 0, 0, 1, 0, 0, 0, 24, 0, 4, 0, 
27, 0, 0, 0, 7, 0, 0, 0, 4, 0, 0, 0, 30, 0, 3, 0, 28, 0, 0, 0, 27, 0, 0, 0, 32, 0, 4, 0, 29, 0, 0, 0, 2, 0, 0, 0, 28, 0, 0, 0, 59, 0, 4, 0, 29, 0, 0, 0, 30, 0, 0, 0, 2, 0, 0, 0, 32, 0, 4, 0, 31, 0, 0, 0, 
2, 0, 0, 0, 27, 0, 0, 0, 30, 0, 4, 0, 37, 0, 0, 0, 7, 0, 0, 0, 7, 0, 0, 0, 32, 0, 4, 0, 38, 0, 0, 0, 7, 0, 0, 0, 37, 0, 0, 0, 21, 0, 4, 0, 46, 0, 0, 0, 32, 0, 0, 0, 0, 0, 0, 0, 43, 0, 4, 0, 46, 0, 0, 0, 
47, 0, 0, 0, 1, 0, 0, 0, 28, 0, 4, 0, 48, 0, 0, 0, 6, 0, 0, 0, 47, 0, 0, 0, 30, 0, 6, 0, 49, 0, 0, 0, 7, 0, 0, 0, 6, 0, 0, 0, 48, 0, 0, 0, 48, 0, 0, 0, 32, 0, 4, 0, 50, 0, 0, 0, 3, 0, 0, 0, 49, 0, 0, 0, 
59, 0, 4, 0, 50, 0, 0, 0, 51, 0, 0, 0, 3, 0, 0, 0, 32, 0, 4, 0, 54, 0, 0, 0, 3, 0, 0, 0, 7, 0, 0, 0, 59, 0, 4, 0, 54, 0, 0, 0, 56, 0, 0, 0, 3, 0, 0, 0, 32, 0, 4, 0, 59, 0, 0, 0, 3, 0, 0, 0, 6, 0, 0, 0, 
26, 0, 2, 0, 64, 0, 0, 0, 32, 0, 4, 0, 65, 0, 0, 0, 0, 0, 0, 0, 64, 0, 0, 0, 59, 0, 4, 0, 65, 0, 0, 0, 66, 0, 0, 0, 0, 0, 0, 0, 54, 0, 5, 0, 2, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 248, 0, 2, 0, 
5, 0, 0, 0, 59, 0, 4, 0, 9, 0, 0, 0, 10, 0, 0, 0, 7, 0, 0, 0, 59, 0, 4, 0, 19, 0, 0, 0, 20, 0, 0, 0, 7, 0, 0, 0, 59, 0, 4, 0, 38, 0, 0, 0, 39, 0, 0, 0, 7, 0, 0, 0, 61, 0, 4, 0, 7, 0, 0, 0, 15, 0, 0, 0, 
14, 0, 0, 0, 65, 0, 5, 0, 16, 0, 0, 0, 17, 0, 0, 0, 10, 0, 0, 0, 12, 0, 0, 0, 62, 0, 3, 0, 17, 0, 0, 0, 15, 0, 0, 0, 65, 0, 5, 0, 16, 0, 0, 0, 21, 0, 0, 0, 10, 0, 0, 0, 12, 0, 0, 0, 61, 0, 4, 0, 7, 0, 0, 0, 
22, 0, 0, 0, 21, 0, 0, 0, 65, 0, 5, 0, 16, 0, 0, 0, 23, 0, 0, 0, 20, 0, 0, 0, 12, 0, 0, 0, 62, 0, 3, 0, 23, 0, 0, 0, 22, 0, 0, 0, 65, 0, 5, 0, 16, 0, 0, 0, 25, 0, 0, 0, 20, 0, 0, 0, 12, 0, 0, 0, 61, 0, 4, 0, 
7, 0, 0, 0, 26, 0, 0, 0, 25, 0, 0, 0, 65, 0, 5, 0, 31, 0, 0, 0, 32, 0, 0, 0, 30, 0, 0, 0, 12, 0, 0, 0, 61, 0, 4, 0, 27, 0, 0, 0, 33, 0, 0, 0, 32, 0, 0, 0, 144, 0, 5, 0, 7, 0, 0, 0, 34, 0, 0, 0, 26, 0, 0, 0, 
33, 0, 0, 0, 79, 0, 9, 0, 7, 0, 0, 0, 35, 0, 0, 0, 34, 0, 0, 0, 34, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 3, 0, 0, 0, 3, 0, 0, 0, 65, 0, 5, 0, 16, 0, 0, 0, 36, 0, 0, 0, 20, 0, 0, 0, 24, 0, 0, 0, 62, 0, 3, 0, 
36, 0, 0, 0, 35, 0, 0, 0, 65, 0, 5, 0, 16, 0, 0, 0, 40, 0, 0, 0, 20, 0, 0, 0, 24, 0, 0, 0, 61, 0, 4, 0, 7, 0, 0, 0, 41, 0, 0, 0, 40, 0, 0, 0, 65, 0, 5, 0, 16, 0, 0, 0, 42, 0, 0, 0, 39, 0, 0, 0, 12, 0, 0, 0, 
62, 0, 3, 0, 42, 0, 0, 0, 41, 0, 0, 0, 65, 0, 5, 0, 16, 0, 0, 0, 43, 0, 0, 0, 20, 0, 0, 0, 12, 0, 0, 0, 61, 0, 4, 0, 7, 0, 0, 0, 44, 0, 0, 0, 43, 0, 0, 0, 65, 0, 5, 0, 16, 0, 0, 0, 45, 0, 0, 0, 39, 0, 0, 0, 
24, 0, 0, 0, 62, 0, 3, 0, 45, 0, 0, 0, 44, 0, 0, 0, 65, 0, 5, 0, 16, 0, 0, 0, 52, 0, 0, 0, 39, 0, 0, 0, 12, 0, 0, 0, 61, 0, 4, 0, 7, 0, 0, 0, 53, 0, 0, 0, 52, 0, 0, 0, 65, 0, 5, 0, 54, 0, 0, 0, 55, 0, 0, 0, 
51, 0, 0, 0, 12, 0, 0, 0, 62, 0, 3, 0, 55, 0, 0, 0, 53, 0, 0, 0, 65, 0, 5, 0, 16, 0, 0, 0, 57, 0, 0, 0, 39, 0, 0, 0, 24, 0, 0, 0, 61, 0, 4, 0, 7, 0, 0, 0, 58, 0, 0, 0, 57, 0, 0, 0, 62, 0, 3, 0, 56, 0, 0, 0, 
58, 0, 0, 0, 65, 0, 6, 0, 59, 0, 0, 0, 60, 0, 0, 0, 51, 0, 0, 0, 12, 0, 0, 0, 47, 0, 0, 0, 61, 0, 4, 0, 6, 0, 0, 0, 61, 0, 0, 0, 60, 0, 0, 0, 127, 0, 4, 0, 6, 0, 0, 0, 62, 0, 0, 0, 61, 0, 0, 0, 65, 0, 6, 0, 
59, 0, 0, 0, 63, 0, 0, 0, 51, 0, 0, 0, 12, 0, 0, 0, 47, 0, 0, 0, 62, 0, 3, 0, 63, 0, 0, 0, 62, 0, 0, 0, 253, 0, 1, 0, 56, 0, 1, 0, 0, 5, 0, 0, 0, 1, 98, 231, 79, 236, 49, 10, 215, 127, 209, 227, 229, 251, 27, 85, 143, 203, 0, 186, 
11, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 7, 71, 108, 111, 98, 97, 108, 115, 2, 0, 0, 0, 22, 84, 101, 120, 116, 117, 114, 105, 110, 103, 46, 84, 101, 120, 116, 117, 114, 101, 67, 117, 98, 101, 48, 13, 0, 0, 0, 17, 84, 101, 120, 116, 117, 114, 105, 110, 103, 46, 83, 
97, 109, 112, 108, 101, 114, 21, 0, 0, 0, 9, 78, 111, 83, 97, 109, 112, 108, 101, 114, 41, 0, 0, 0, 0, 96, 11, 0, 0, 3, 2, 35, 7, 0, 0, 1, 0, 7, 0, 8, 0, 80, 0, 0, 0, 0, 0, 0, 0, 17, 0, 2, 0, 1, 0, 0, 0, 11, 0, 6, 0, 1, 0, 0, 
0, 71, 76, 83, 76, 46, 115, 116, 100, 46, 52, 53, 48, 0, 0, 0, 0, 14, 0, 3, 0, 0, 0, 0, 0, 1, 0, 0, 0, 15, 0, 8, 0, 4, 0, 0, 0, 4, 0, 0, 0, 109, 97, 105, 110, 0, 0, 0, 0, 54, 0, 0, 0, 57, 0, 0, 0, 76, 0, 0, 0, 16, 0, 3, 
0, 4, 0, 0, 0, 7, 0, 0, 0, 3, 0, 3, 0, 2, 0, 0, 0, 194, 1, 0, 0, 5, 0, 4, 0, 4, 0, 0, 0, 109, 97, 105, 110, 0, 0, 0, 0, 5, 0, 5, 0, 8, 0, 0, 0, 80, 83, 95, 83, 84, 82, 69, 65, 77, 83, 0, 0, 6, 0, 7, 0, 8, 0, 0, 
0, 0, 0, 0, 0, 80, 111, 115, 105, 116, 105, 111, 110, 95, 105, 100, 55, 50, 0, 0, 0, 6, 0, 7, 0, 8, 0, 0, 0, 1, 0, 0, 0, 67, 111, 108, 111, 114, 84, 97, 114, 103, 101, 116, 95, 105, 100, 50, 0, 5, 0, 12, 0, 12, 0, 0, 0, 83, 104, 97, 100, 105, 110, 103, 
95, 105, 100, 52, 40, 115, 116, 114, 117, 99, 116, 45, 80, 83, 95, 83, 84, 82, 69, 65, 77, 83, 45, 118, 102, 52, 45, 118, 102, 52, 49, 59, 0, 5, 0, 4, 0, 11, 0, 0, 0, 115, 116, 114, 101, 97, 109, 115, 0, 5, 0, 7, 0, 16, 0, 0, 0, 84, 101, 120, 116, 117, 114, 101, 
67, 117, 98, 101, 48, 95, 105, 100, 51, 52, 0, 0, 0, 5, 0, 6, 0, 20, 0, 0, 0, 83, 97, 109, 112, 108, 101, 114, 95, 105, 100, 52, 50, 0, 0, 0, 0, 5, 0, 4, 0, 34, 0, 0, 0, 71, 108, 111, 98, 97, 108, 115, 0, 6, 0, 9, 0, 34, 0, 0, 0, 0, 0, 0, 
0, 84, 101, 120, 116, 117, 114, 101, 48, 84, 101, 120, 101, 108, 83, 105, 122, 101, 95, 105, 100, 49, 53, 0, 0, 6, 0, 9, 0, 34, 0, 0, 0, 1, 0, 0, 0, 84, 101, 120, 116, 117, 114, 101, 49, 84, 101, 120, 101, 108, 83, 105, 122, 101, 95, 105, 100, 49, 55, 0, 0, 6, 0, 9, 
0, 34, 0, 0, 0, 2, 0, 0, 0, 84, 101, 120, 116, 117, 114, 101, 50, 84, 101, 120, 101, 108, 83, 105, 122, 101, 95, 105, 100, 49, 57, 0, 0, 6, 0, 9, 0, 34, 0, 0, 0, 3, 0, 0, 0, 84, 101, 120, 116, 117, 114, 101, 51, 84, 101, 120, 101, 108, 83, 105, 122, 101, 95, 105, 
100, 50, 49, 0, 0, 6, 0, 9, 0, 34, 0, 0, 0, 4, 0, 0, 0, 84, 101, 120, 116, 117, 114, 101, 52, 84, 101, 120, 101, 108, 83, 105, 122, 101, 95, 105, 100, 50, 51, 0, 0, 6, 0, 9, 0, 34, 0, 0, 0, 5, 0, 0, 0, 84, 101, 120, 116, 117, 114, 101, 53, 84, 101, 120, 
101, 108, 83, 105, 122, 101, 95, 105, 100, 50, 53, 0, 0, 6, 0, 9, 0, 34, 0, 0, 0, 6, 0, 0, 0, 84, 101, 120, 116, 117, 114, 101, 54, 84, 101, 120, 101, 108, 83, 105, 122, 101, 95, 105, 100, 50, 55, 0, 0, 6, 0, 9, 0, 34, 0, 0, 0, 7, 0, 0, 0, 84, 101, 120, 
116, 117, 114, 101, 55, 84, 101, 120, 101, 108, 83, 105, 122, 101, 95, 105, 100, 50, 57, 0, 0, 6, 0, 9, 0, 34, 0, 0, 0, 8, 0, 0, 0, 84, 101, 120, 116, 117, 114, 101, 56, 84, 101, 120, 101, 108, 83, 105, 122, 101, 95, 105, 100, 51, 49, 0, 0, 6, 0, 9, 0, 34, 0, 0, 
0, 9, 0, 0, 0, 84, 101, 120, 116, 117, 114, 101, 57, 84, 101, 120, 101, 108, 83, 105, 122, 101, 95, 105, 100, 51, 51, 0, 0, 6, 0, 7, 0, 34, 0, 0, 0, 10, 0, 0, 0, 79, 112, 97, 99, 105, 116, 121, 95, 105, 100, 55, 52, 0, 0, 0, 0, 5, 0, 3, 0, 36, 0, 0, 
0, 0, 0, 0, 0, 5, 0, 5, 0, 49, 0, 0, 0, 80, 83, 95, 73, 78, 80, 85, 84, 0, 0, 0, 0, 6, 0, 8, 0, 49, 0, 0, 0, 0, 0, 0, 0, 83, 104, 97, 100, 105, 110, 103, 80, 111, 115, 105, 116, 105, 111, 110, 95, 105, 100, 48, 0, 6, 0, 7, 0, 49, 0, 0, 
0, 1, 0, 0, 0, 80, 111, 115, 105, 116, 105, 111, 110, 95, 105, 100, 55, 50, 0, 0, 0, 5, 0, 5, 0, 51, 0, 0, 0, 95, 48, 105, 110, 112, 117, 116, 95, 48, 0, 0, 0, 5, 0, 5, 0, 54, 0, 0, 0, 118, 95, 80, 79, 83, 73, 84, 73, 79, 78, 48, 0, 5, 0, 6, 
0, 57, 0, 0, 0, 103, 108, 95, 70, 114, 97, 103, 67, 111, 111, 114, 100, 0, 0, 0, 0, 5, 0, 4, 0, 60, 0, 0, 0, 115, 116, 114, 101, 97, 109, 115, 0, 5, 0, 4, 0, 64, 0, 0, 0, 112, 97, 114, 97, 109, 0, 0, 0, 5, 0, 5, 0, 69, 0, 0, 0, 80, 83, 95, 
79, 85, 84, 80, 85, 84, 0, 0, 0, 6, 0, 7, 0, 69, 0, 0, 0, 0, 0, 0, 0, 67, 111, 108, 111, 114, 84, 97, 114, 103, 101, 116, 95, 105, 100, 50, 0, 5, 0, 5, 0, 71, 0, 0, 0, 95, 48, 111, 117, 116, 112, 117, 116, 95, 48, 0, 0, 5, 0, 10, 0, 76, 0, 0, 
0, 111, 117, 116, 95, 103, 108, 95, 102, 114, 97, 103, 100, 97, 116, 97, 95, 67, 111, 108, 111, 114, 84, 97, 114, 103, 101, 116, 95, 105, 100, 50, 0, 5, 0, 5, 0, 79, 0, 0, 0, 78, 111, 83, 97, 109, 112, 108, 101, 114, 0, 0, 0, 71, 0, 4, 0, 16, 0, 0, 0, 34, 0, 0, 
0, 0, 0, 0, 0, 71, 0, 4, 0, 16, 0, 0, 0, 33, 0, 0, 0, 13, 0, 0, 0, 71, 0, 4, 0, 20, 0, 0, 0, 34, 0, 0, 0, 0, 0, 0, 0, 71, 0, 4, 0, 20, 0, 0, 0, 33, 0, 0, 0, 21, 0, 0, 0, 72, 0, 5, 0, 34, 0, 0, 0, 0, 0, 0, 
0, 35, 0, 0, 0, 0, 0, 0, 0, 72, 0, 5, 0, 34, 0, 0, 0, 1, 0, 0, 0, 35, 0, 0, 0, 8, 0, 0, 0, 72, 0, 5, 0, 34, 0, 0, 0, 2, 0, 0, 0, 35, 0, 0, 0, 16, 0, 0, 0, 72, 0, 5, 0, 34, 0, 0, 0, 3, 0, 0, 0, 35, 0, 0, 
0, 24, 0, 0, 0, 72, 0, 5, 0, 34, 0, 0, 0, 4, 0, 0, 0, 35, 0, 0, 0, 32, 0, 0, 0, 72, 0, 5, 0, 34, 0, 0, 0, 5, 0, 0, 0, 35, 0, 0, 0, 40, 0, 0, 0, 72, 0, 5, 0, 34, 0, 0, 0, 6, 0, 0, 0, 35, 0, 0, 0, 48, 0, 0, 
0, 72, 0, 5, 0, 34, 0, 0, 0, 7, 0, 0, 0, 35, 0, 0, 0, 56, 0, 0, 0, 72, 0, 5, 0, 34, 0, 0, 0, 8, 0, 0, 0, 35, 0, 0, 0, 64, 0, 0, 0, 72, 0, 5, 0, 34, 0, 0, 0, 9, 0, 0, 0, 35, 0, 0, 0, 72, 0, 0, 0, 72, 0, 5, 
0, 34, 0, 0, 0, 10, 0, 0, 0, 35, 0, 0, 0, 80, 0, 0, 0, 71, 0, 3, 0, 34, 0, 0, 0, 2, 0, 0, 0, 71, 0, 4, 0, 36, 0, 0, 0, 34, 0, 0, 0, 0, 0, 0, 0, 71, 0, 4, 0, 36, 0, 0, 0, 33, 0, 0, 0, 2, 0, 0, 0, 71, 0, 4, 
0, 54, 0, 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 71, 0, 4, 0, 57, 0, 0, 0, 11, 0, 0, 0, 15, 0, 0, 0, 71, 0, 4, 0, 76, 0, 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 71, 0, 4, 0, 79, 0, 0, 0, 34, 0, 0, 0, 0, 0, 0, 0, 71, 0, 4, 
0, 79, 0, 0, 0, 33, 0, 0, 0, 41, 0, 0, 0, 19, 0, 2, 0, 2, 0, 0, 0, 33, 0, 3, 0, 3, 0, 0, 0, 2, 0, 0, 0, 22, 0, 3, 0, 6, 0, 0, 0, 32, 0, 0, 0, 23, 0, 4, 0, 7, 0, 0, 0, 6, 0, 0, 0, 4, 0, 0, 0, 30, 0, 4, 
0, 8, 0, 0, 0, 7, 0, 0, 0, 7, 0, 0, 0, 32, 0, 4, 0, 9, 0, 0, 0, 7, 0, 0, 0, 8, 0, 0, 0, 33, 0, 4, 0, 10, 0, 0, 0, 7, 0, 0, 0, 9, 0, 0, 0, 25, 0, 9, 0, 14, 0, 0, 0, 6, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 
0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 32, 0, 4, 0, 15, 0, 0, 0, 0, 0, 0, 0, 14, 0, 0, 0, 59, 0, 4, 0, 15, 0, 0, 0, 16, 0, 0, 0, 0, 0, 0, 0, 26, 0, 2, 0, 18, 0, 0, 0, 32, 0, 4, 0, 19, 0, 0, 
0, 0, 0, 0, 0, 18, 0, 0, 0, 59, 0, 4, 0, 19, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 27, 0, 3, 0, 22, 0, 0, 0, 14, 0, 0, 0, 21, 0, 4, 0, 24, 0, 0, 0, 32, 0, 0, 0, 1, 0, 0, 0, 43, 0, 4, 0, 24, 0, 0, 0, 25, 0, 0, 
0, 0, 0, 0, 0, 23, 0, 4, 0, 26, 0, 0, 0, 6, 0, 0, 0, 3, 0, 0, 0, 32, 0, 4, 0, 27, 0, 0, 0, 7, 0, 0, 0, 7, 0, 0, 0, 23, 0, 4, 0, 33, 0, 0, 0, 6, 0, 0, 0, 2, 0, 0, 0, 30, 0, 13, 0, 34, 0, 0, 0, 33, 0, 0, 
0, 33, 0, 0, 0, 33, 0, 0, 0, 33, 0, 0, 0, 33, 0, 0, 0, 33, 0, 0, 0, 33, 0, 0, 0, 33, 0, 0, 0, 33, 0, 0, 0, 33, 0, 0, 0, 6, 0, 0, 0, 32, 0, 4, 0, 35, 0, 0, 0, 2, 0, 0, 0, 34, 0, 0, 0, 59, 0, 4, 0, 35, 0, 0, 
0, 36, 0, 0, 0, 2, 0, 0, 0, 43, 0, 4, 0, 24, 0, 0, 0, 37, 0, 0, 0, 10, 0, 0, 0, 32, 0, 4, 0, 38, 0, 0, 0, 2, 0, 0, 0, 6, 0, 0, 0, 43, 0, 4, 0, 6, 0, 0, 0, 42, 0, 0, 0, 0, 0, 128, 63, 30, 0, 4, 0, 49, 0, 0, 
0, 7, 0, 0, 0, 7, 0, 0, 0, 32, 0, 4, 0, 50, 0, 0, 0, 7, 0, 0, 0, 49, 0, 0, 0, 43, 0, 4, 0, 24, 0, 0, 0, 52, 0, 0, 0, 1, 0, 0, 0, 32, 0, 4, 0, 53, 0, 0, 0, 1, 0, 0, 0, 7, 0, 0, 0, 59, 0, 4, 0, 53, 0, 0, 
0, 54, 0, 0, 0, 1, 0, 0, 0, 59, 0, 4, 0, 53, 0, 0, 0, 57, 0, 0, 0, 1, 0, 0, 0, 30, 0, 3, 0, 69, 0, 0, 0, 7, 0, 0, 0, 32, 0, 4, 0, 70, 0, 0, 0, 7, 0, 0, 0, 69, 0, 0, 0, 32, 0, 4, 0, 75, 0, 0, 0, 3, 0, 0, 
0, 7, 0, 0, 0, 59, 0, 4, 0, 75, 0, 0, 0, 76, 0, 0, 0, 3, 0, 0, 0, 59, 0, 4, 0, 19, 0, 0, 0, 79, 0, 0, 0, 0, 0, 0, 0, 54, 0, 5, 0, 2, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 248, 0, 2, 0, 5, 0, 0, 
0, 59, 0, 4, 0, 50, 0, 0, 0, 51, 0, 0, 0, 7, 0, 0, 0, 59, 0, 4, 0, 9, 0, 0, 0, 60, 0, 0, 0, 7, 0, 0, 0, 59, 0, 4, 0, 9, 0, 0, 0, 64, 0, 0, 0, 7, 0, 0, 0, 59, 0, 4, 0, 70, 0, 0, 0, 71, 0, 0, 0, 7, 0, 0, 
0, 61, 0, 4, 0, 7, 0, 0, 0, 55, 0, 0, 0, 54, 0, 0, 0, 65, 0, 5, 0, 27, 0, 0, 0, 56, 0, 0, 0, 51, 0, 0, 0, 52, 0, 0, 0, 62, 0, 3, 0, 56, 0, 0, 0, 55, 0, 0, 0, 61, 0, 4, 0, 7, 0, 0, 0, 58, 0, 0, 0, 57, 0, 0, 
0, 65, 0, 5, 0, 27, 0, 0, 0, 59, 0, 0, 0, 51, 0, 0, 0, 25, 0, 0, 0, 62, 0, 3, 0, 59, 0, 0, 0, 58, 0, 0, 0, 65, 0, 5, 0, 27, 0, 0, 0, 61, 0, 0, 0, 51, 0, 0, 0, 52, 0, 0, 0, 61, 0, 4, 0, 7, 0, 0, 0, 62, 0, 0, 
0, 61, 0, 0, 0, 65, 0, 5, 0, 27, 0, 0, 0, 63, 0, 0, 0, 60, 0, 0, 0, 25, 0, 0, 0, 62, 0, 3, 0, 63, 0, 0, 0, 62, 0, 0, 0, 61, 0, 4, 0, 8, 0, 0, 0, 65, 0, 0, 0, 60, 0, 0, 0, 62, 0, 3, 0, 64, 0, 0, 0, 65, 0, 0, 
0, 57, 0, 5, 0, 7, 0, 0, 0, 66, 0, 0, 0, 12, 0, 0, 0, 64, 0, 0, 0, 61, 0, 4, 0, 8, 0, 0, 0, 67, 0, 0, 0, 64, 0, 0, 0, 62, 0, 3, 0, 60, 0, 0, 0, 67, 0, 0, 0, 65, 0, 5, 0, 27, 0, 0, 0, 68, 0, 0, 0, 60, 0, 0, 
0, 52, 0, 0, 0, 62, 0, 3, 0, 68, 0, 0, 0, 66, 0, 0, 0, 65, 0, 5, 0, 27, 0, 0, 0, 72, 0, 0, 0, 60, 0, 0, 0, 52, 0, 0, 0, 61, 0, 4, 0, 7, 0, 0, 0, 73, 0, 0, 0, 72, 0, 0, 0, 65, 0, 5, 0, 27, 0, 0, 0, 74, 0, 0, 
0, 71, 0, 0, 0, 25, 0, 0, 0, 62, 0, 3, 0, 74, 0, 0, 0, 73, 0, 0, 0, 65, 0, 5, 0, 27, 0, 0, 0, 77, 0, 0, 0, 71, 0, 0, 0, 25, 0, 0, 0, 61, 0, 4, 0, 7, 0, 0, 0, 78, 0, 0, 0, 77, 0, 0, 0, 62, 0, 3, 0, 76, 0, 0, 
0, 78, 0, 0, 0, 253, 0, 1, 0, 56, 0, 1, 0, 54, 0, 5, 0, 7, 0, 0, 0, 12, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 0, 55, 0, 3, 0, 9, 0, 0, 0, 11, 0, 0, 0, 248, 0, 2, 0, 13, 0, 0, 0, 61, 0, 4, 0, 14, 0, 0, 0, 17, 0, 0, 
0, 16, 0, 0, 0, 61, 0, 4, 0, 18, 0, 0, 0, 21, 0, 0, 0, 20, 0, 0, 0, 86, 0, 5, 0, 22, 0, 0, 0, 23, 0, 0, 0, 17, 0, 0, 0, 21, 0, 0, 0, 65, 0, 5, 0, 27, 0, 0, 0, 28, 0, 0, 0, 11, 0, 0, 0, 25, 0, 0, 0, 61, 0, 4, 
0, 7, 0, 0, 0, 29, 0, 0, 0, 28, 0, 0, 0, 79, 0, 8, 0, 26, 0, 0, 0, 30, 0, 0, 0, 29, 0, 0, 0, 29, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 2, 0, 0, 0, 87, 0, 5, 0, 7, 0, 0, 0, 31, 0, 0, 0, 23, 0, 0, 0, 30, 0, 0, 
0, 79, 0, 8, 0, 26, 0, 0, 0, 32, 0, 0, 0, 31, 0, 0, 0, 31, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 2, 0, 0, 0, 65, 0, 5, 0, 38, 0, 0, 0, 39, 0, 0, 0, 36, 0, 0, 0, 37, 0, 0, 0, 61, 0, 4, 0, 6, 0, 0, 0, 40, 0, 0, 
0, 39, 0, 0, 0, 142, 0, 5, 0, 26, 0, 0, 0, 41, 0, 0, 0, 32, 0, 0, 0, 40, 0, 0, 0, 81, 0, 5, 0, 6, 0, 0, 0, 43, 0, 0, 0, 41, 0, 0, 0, 0, 0, 0, 0, 81, 0, 5, 0, 6, 0, 0, 0, 44, 0, 0, 0, 41, 0, 0, 0, 1, 0, 0, 
0, 81, 0, 5, 0, 6, 0, 0, 0, 45, 0, 0, 0, 41, 0, 0, 0, 2, 0, 0, 0, 80, 0, 7, 0, 7, 0, 0, 0, 46, 0, 0, 0, 43, 0, 0, 0, 44, 0, 0, 0, 45, 0, 0, 0, 42, 0, 0, 0, 254, 0, 2, 0, 46, 0, 0, 0, 56, 0, 1, 0, 
        };
    }
}
#endif