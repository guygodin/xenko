﻿#if XENKO_GRAPHICS_API_VULKAN
//------------------------------------------------------------------------------
// <auto-generated>
//     Xenko Effect Compiler File Generated:
//     Effect [SpriteEffectExtTexture]
//
//     Command Line: D:\Xenko\sources\engine\Xenko.Graphics\Shaders.Bytecodes\..\..\..\..\sources\assets\Xenko.Core.Assets.CompilerApp\bin\Debug\net472\Xenko.Core.Assets.CompilerApp.exe --platform=Windows --property:RuntimeIdentifier=win-vulkan --output-path=D:\Xenko\sources\engine\Xenko.Graphics\Shaders.Bytecodes\obj\app_data --build-path=D:\Xenko\sources\engine\Xenko.Graphics\Shaders.Bytecodes\obj\build_app_data --package-file=Graphics.xkpkg
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Xenko.Graphics 
{
    public partial class SpriteEffectExtTexture
    {
        private static readonly byte[] binaryBytecode = new byte[] {
7, 192, 254, 239, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 7, 71, 108, 111, 98, 97, 108, 115, 10, 0, 0, 0, 26, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 7, 71, 108, 111, 98, 97, 
108, 115, 0, 7, 71, 108, 111, 98, 97, 108, 115, 5, 0, 0, 0, 255, 255, 255, 255, 1, 0, 0, 0, 1, 0, 48, 83, 112, 114, 105, 116, 101, 69, 102, 102, 101, 99, 116, 69, 120, 116, 84, 101, 120, 116, 117, 114, 101, 46, 88, 101, 110, 107, 111, 73, 110, 116, 101, 114, 110, 97, 108, 95, 84, 
101, 120, 116, 117, 114, 101, 69, 120, 116, 48, 9, 0, 0, 0, 7, 0, 0, 0, 1, 0, 0, 0, 3, 0, 0, 0, 1, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 30, 88, 101, 110, 107, 111, 73, 110, 116, 101, 114, 110, 97, 108, 95, 84, 101, 120, 116, 
117, 114, 101, 69, 120, 116, 48, 95, 105, 100, 49, 54, 1, 5, 0, 0, 0, 255, 255, 255, 255, 1, 0, 0, 0, 1, 0, 30, 83, 112, 114, 105, 116, 101, 69, 102, 102, 101, 99, 116, 69, 120, 116, 84, 101, 120, 116, 117, 114, 101, 46, 83, 97, 109, 112, 108, 101, 114, 8, 0, 0, 0, 10, 0, 
0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 12, 83, 97, 109, 112, 108, 101, 114, 95, 105, 100, 49, 55, 1, 5, 0, 0, 0, 255, 255, 255, 255, 1, 0, 0, 0, 1, 0, 9, 78, 111, 83, 97, 109, 112, 
108, 101, 114, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 9, 78, 111, 83, 97, 109, 112, 108, 101, 114, 1, 5, 0, 0, 0, 255, 255, 255, 255, 1, 0, 0, 0, 1, 0, 1, 
0, 0, 0, 0, 0, 7, 71, 108, 111, 98, 97, 108, 115, 20, 0, 0, 0, 1, 0, 0, 0, 0, 2, 0, 0, 0, 13, 0, 0, 0, 3, 0, 0, 0, 1, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 16, 0, 0, 0, 1, 1, 0, 28, 83, 112, 114, 105, 116, 101, 69, 102, 102, 101, 
99, 116, 69, 120, 116, 84, 101, 120, 116, 117, 114, 101, 46, 67, 111, 108, 111, 114, 0, 10, 67, 111, 108, 111, 114, 95, 105, 100, 49, 52, 0, 0, 0, 0, 16, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 
1, 1, 0, 30, 83, 112, 114, 105, 116, 101, 69, 102, 102, 101, 99, 116, 69, 120, 116, 84, 101, 120, 116, 117, 114, 101, 46, 72, 97, 115, 83, 82, 103, 98, 0, 12, 72, 97, 115, 83, 82, 103, 98, 95, 105, 100, 49, 53, 16, 0, 0, 0, 4, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 
0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 8, 80, 79, 83, 73, 84, 73, 79, 78, 0, 0, 0, 0, 0, 8, 84, 69, 88, 67, 79, 79, 82, 68, 0, 0, 0, 0, 0, 4, 0, 0, 0, 22, 83, 112, 114, 105, 116, 101, 69, 102, 102, 101, 99, 116, 69, 120, 116, 84, 101, 120, 116, 117, 114, 
101, 1, 170, 179, 52, 63, 13, 10, 197, 186, 92, 68, 41, 151, 77, 179, 151, 201, 10, 83, 104, 97, 100, 101, 114, 66, 97, 115, 101, 1, 172, 190, 61, 77, 68, 160, 70, 238, 222, 135, 17, 118, 190, 233, 199, 84, 16, 83, 104, 97, 100, 101, 114, 66, 97, 115, 101, 83, 116, 114, 101, 97, 109, 1, 
163, 165, 191, 129, 133, 242, 163, 216, 153, 114, 41, 63, 128, 100, 48, 211, 12, 67, 111, 108, 111, 114, 85, 116, 105, 108, 105, 116, 121, 1, 124, 200, 88, 161, 33, 56, 76, 239, 97, 45, 238, 84, 91, 130, 62, 69, 0, 2, 0, 0, 0, 0, 1, 0, 0, 0, 1, 106, 211, 219, 250, 44, 140, 251, 
134, 80, 248, 252, 114, 186, 169, 104, 216, 0, 114, 8, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 8, 80, 79, 83, 73, 84, 73, 79, 78, 1, 0, 0, 0, 0, 9, 84, 69, 88, 67, 79, 79, 82, 68, 48, 0, 1, 0, 0, 0, 9, 78, 111, 83, 97, 109, 112, 108, 101, 114, 4, 
0, 0, 0, 0, 56, 8, 0, 0, 3, 2, 35, 7, 0, 0, 1, 0, 7, 0, 8, 0, 69, 0, 0, 0, 0, 0, 0, 0, 17, 0, 2, 0, 1, 0, 0, 0, 11, 0, 6, 0, 1, 0, 0, 0, 71, 76, 83, 76, 46, 115, 116, 100, 46, 52, 53, 48, 0, 0, 0, 0, 14, 0, 3, 0, 
0, 0, 0, 0, 1, 0, 0, 0, 15, 0, 9, 0, 0, 0, 0, 0, 4, 0, 0, 0, 109, 97, 105, 110, 0, 0, 0, 0, 15, 0, 0, 0, 21, 0, 0, 0, 52, 0, 0, 0, 58, 0, 0, 0, 3, 0, 3, 0, 2, 0, 0, 0, 194, 1, 0, 0, 5, 0, 4, 0, 4, 0, 0, 0, 
109, 97, 105, 110, 0, 0, 0, 0, 5, 0, 5, 0, 9, 0, 0, 0, 86, 83, 95, 73, 78, 80, 85, 84, 0, 0, 0, 0, 6, 0, 7, 0, 9, 0, 0, 0, 0, 0, 0, 0, 80, 111, 115, 105, 116, 105, 111, 110, 95, 105, 100, 49, 57, 0, 0, 0, 6, 0, 7, 0, 9, 0, 0, 0, 
1, 0, 0, 0, 84, 101, 120, 67, 111, 111, 114, 100, 95, 105, 100, 49, 56, 0, 0, 0, 5, 0, 5, 0, 11, 0, 0, 0, 95, 48, 105, 110, 112, 117, 116, 95, 48, 0, 0, 0, 5, 0, 5, 0, 15, 0, 0, 0, 97, 95, 84, 69, 88, 67, 79, 79, 82, 68, 48, 0, 5, 0, 5, 0, 
21, 0, 0, 0, 97, 95, 80, 79, 83, 73, 84, 73, 79, 78, 48, 0, 5, 0, 5, 0, 25, 0, 0, 0, 86, 83, 95, 83, 84, 82, 69, 65, 77, 83, 0, 0, 6, 0, 7, 0, 25, 0, 0, 0, 0, 0, 0, 0, 80, 111, 115, 105, 116, 105, 111, 110, 95, 105, 100, 49, 57, 0, 0, 0, 
6, 0, 7, 0, 25, 0, 0, 0, 1, 0, 0, 0, 84, 101, 120, 67, 111, 111, 114, 100, 95, 105, 100, 49, 56, 0, 0, 0, 6, 0, 8, 0, 25, 0, 0, 0, 2, 0, 0, 0, 83, 104, 97, 100, 105, 110, 103, 80, 111, 115, 105, 116, 105, 111, 110, 95, 105, 100, 48, 0, 5, 0, 4, 0, 
27, 0, 0, 0, 115, 116, 114, 101, 97, 109, 115, 0, 5, 0, 5, 0, 38, 0, 0, 0, 86, 83, 95, 79, 85, 84, 80, 85, 84, 0, 0, 0, 6, 0, 8, 0, 38, 0, 0, 0, 0, 0, 0, 0, 83, 104, 97, 100, 105, 110, 103, 80, 111, 115, 105, 116, 105, 111, 110, 95, 105, 100, 48, 0, 
6, 0, 7, 0, 38, 0, 0, 0, 1, 0, 0, 0, 84, 101, 120, 67, 111, 111, 114, 100, 95, 105, 100, 49, 56, 0, 0, 0, 5, 0, 5, 0, 40, 0, 0, 0, 95, 48, 111, 117, 116, 112, 117, 116, 95, 48, 0, 0, 5, 0, 6, 0, 50, 0, 0, 0, 103, 108, 95, 80, 101, 114, 86, 101, 
114, 116, 101, 120, 0, 0, 0, 0, 6, 0, 6, 0, 50, 0, 0, 0, 0, 0, 0, 0, 103, 108, 95, 80, 111, 115, 105, 116, 105, 111, 110, 0, 6, 0, 7, 0, 50, 0, 0, 0, 1, 0, 0, 0, 103, 108, 95, 80, 111, 105, 110, 116, 83, 105, 122, 101, 0, 0, 0, 0, 6, 0, 7, 0, 
50, 0, 0, 0, 2, 0, 0, 0, 103, 108, 95, 67, 108, 105, 112, 68, 105, 115, 116, 97, 110, 99, 101, 0, 6, 0, 7, 0, 50, 0, 0, 0, 3, 0, 0, 0, 103, 108, 95, 67, 117, 108, 108, 68, 105, 115, 116, 97, 110, 99, 101, 0, 5, 0, 3, 0, 52, 0, 0, 0, 0, 0, 0, 0, 
5, 0, 5, 0, 58, 0, 0, 0, 118, 95, 84, 69, 88, 67, 79, 79, 82, 68, 48, 0, 5, 0, 5, 0, 68, 0, 0, 0, 78, 111, 83, 97, 109, 112, 108, 101, 114, 0, 0, 0, 71, 0, 4, 0, 15, 0, 0, 0, 30, 0, 0, 0, 1, 0, 0, 0, 71, 0, 4, 0, 21, 0, 0, 0, 
30, 0, 0, 0, 0, 0, 0, 0, 72, 0, 5, 0, 50, 0, 0, 0, 0, 0, 0, 0, 11, 0, 0, 0, 0, 0, 0, 0, 72, 0, 5, 0, 50, 0, 0, 0, 1, 0, 0, 0, 11, 0, 0, 0, 1, 0, 0, 0, 72, 0, 5, 0, 50, 0, 0, 0, 2, 0, 0, 0, 11, 0, 0, 0, 
3, 0, 0, 0, 72, 0, 5, 0, 50, 0, 0, 0, 3, 0, 0, 0, 11, 0, 0, 0, 4, 0, 0, 0, 71, 0, 3, 0, 50, 0, 0, 0, 2, 0, 0, 0, 71, 0, 4, 0, 58, 0, 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 71, 0, 4, 0, 68, 0, 0, 0, 34, 0, 0, 0, 
0, 0, 0, 0, 71, 0, 4, 0, 68, 0, 0, 0, 33, 0, 0, 0, 4, 0, 0, 0, 19, 0, 2, 0, 2, 0, 0, 0, 33, 0, 3, 0, 3, 0, 0, 0, 2, 0, 0, 0, 22, 0, 3, 0, 6, 0, 0, 0, 32, 0, 0, 0, 23, 0, 4, 0, 7, 0, 0, 0, 6, 0, 0, 0, 
4, 0, 0, 0, 23, 0, 4, 0, 8, 0, 0, 0, 6, 0, 0, 0, 2, 0, 0, 0, 30, 0, 4, 0, 9, 0, 0, 0, 7, 0, 0, 0, 8, 0, 0, 0, 32, 0, 4, 0, 10, 0, 0, 0, 7, 0, 0, 0, 9, 0, 0, 0, 21, 0, 4, 0, 12, 0, 0, 0, 32, 0, 0, 0, 
1, 0, 0, 0, 43, 0, 4, 0, 12, 0, 0, 0, 13, 0, 0, 0, 1, 0, 0, 0, 32, 0, 4, 0, 14, 0, 0, 0, 1, 0, 0, 0, 8, 0, 0, 0, 59, 0, 4, 0, 14, 0, 0, 0, 15, 0, 0, 0, 1, 0, 0, 0, 32, 0, 4, 0, 17, 0, 0, 0, 7, 0, 0, 0, 
8, 0, 0, 0, 43, 0, 4, 0, 12, 0, 0, 0, 19, 0, 0, 0, 0, 0, 0, 0, 32, 0, 4, 0, 20, 0, 0, 0, 1, 0, 0, 0, 7, 0, 0, 0, 59, 0, 4, 0, 20, 0, 0, 0, 21, 0, 0, 0, 1, 0, 0, 0, 32, 0, 4, 0, 23, 0, 0, 0, 7, 0, 0, 0, 
7, 0, 0, 0, 30, 0, 5, 0, 25, 0, 0, 0, 7, 0, 0, 0, 8, 0, 0, 0, 7, 0, 0, 0, 32, 0, 4, 0, 26, 0, 0, 0, 7, 0, 0, 0, 25, 0, 0, 0, 43, 0, 4, 0, 12, 0, 0, 0, 34, 0, 0, 0, 2, 0, 0, 0, 30, 0, 4, 0, 38, 0, 0, 0, 
7, 0, 0, 0, 8, 0, 0, 0, 32, 0, 4, 0, 39, 0, 0, 0, 7, 0, 0, 0, 38, 0, 0, 0, 21, 0, 4, 0, 47, 0, 0, 0, 32, 0, 0, 0, 0, 0, 0, 0, 43, 0, 4, 0, 47, 0, 0, 0, 48, 0, 0, 0, 1, 0, 0, 0, 28, 0, 4, 0, 49, 0, 0, 0, 
6, 0, 0, 0, 48, 0, 0, 0, 30, 0, 6, 0, 50, 0, 0, 0, 7, 0, 0, 0, 6, 0, 0, 0, 49, 0, 0, 0, 49, 0, 0, 0, 32, 0, 4, 0, 51, 0, 0, 0, 3, 0, 0, 0, 50, 0, 0, 0, 59, 0, 4, 0, 51, 0, 0, 0, 52, 0, 0, 0, 3, 0, 0, 0, 
32, 0, 4, 0, 55, 0, 0, 0, 3, 0, 0, 0, 7, 0, 0, 0, 32, 0, 4, 0, 57, 0, 0, 0, 3, 0, 0, 0, 8, 0, 0, 0, 59, 0, 4, 0, 57, 0, 0, 0, 58, 0, 0, 0, 3, 0, 0, 0, 32, 0, 4, 0, 61, 0, 0, 0, 3, 0, 0, 0, 6, 0, 0, 0, 
26, 0, 2, 0, 66, 0, 0, 0, 32, 0, 4, 0, 67, 0, 0, 0, 0, 0, 0, 0, 66, 0, 0, 0, 59, 0, 4, 0, 67, 0, 0, 0, 68, 0, 0, 0, 0, 0, 0, 0, 54, 0, 5, 0, 2, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 248, 0, 2, 0, 
5, 0, 0, 0, 59, 0, 4, 0, 10, 0, 0, 0, 11, 0, 0, 0, 7, 0, 0, 0, 59, 0, 4, 0, 26, 0, 0, 0, 27, 0, 0, 0, 7, 0, 0, 0, 59, 0, 4, 0, 39, 0, 0, 0, 40, 0, 0, 0, 7, 0, 0, 0, 61, 0, 4, 0, 8, 0, 0, 0, 16, 0, 0, 0, 
15, 0, 0, 0, 65, 0, 5, 0, 17, 0, 0, 0, 18, 0, 0, 0, 11, 0, 0, 0, 13, 0, 0, 0, 62, 0, 3, 0, 18, 0, 0, 0, 16, 0, 0, 0, 61, 0, 4, 0, 7, 0, 0, 0, 22, 0, 0, 0, 21, 0, 0, 0, 65, 0, 5, 0, 23, 0, 0, 0, 24, 0, 0, 0, 
11, 0, 0, 0, 19, 0, 0, 0, 62, 0, 3, 0, 24, 0, 0, 0, 22, 0, 0, 0, 65, 0, 5, 0, 23, 0, 0, 0, 28, 0, 0, 0, 11, 0, 0, 0, 19, 0, 0, 0, 61, 0, 4, 0, 7, 0, 0, 0, 29, 0, 0, 0, 28, 0, 0, 0, 65, 0, 5, 0, 23, 0, 0, 0, 
30, 0, 0, 0, 27, 0, 0, 0, 19, 0, 0, 0, 62, 0, 3, 0, 30, 0, 0, 0, 29, 0, 0, 0, 65, 0, 5, 0, 17, 0, 0, 0, 31, 0, 0, 0, 11, 0, 0, 0, 13, 0, 0, 0, 61, 0, 4, 0, 8, 0, 0, 0, 32, 0, 0, 0, 31, 0, 0, 0, 65, 0, 5, 0, 
17, 0, 0, 0, 33, 0, 0, 0, 27, 0, 0, 0, 13, 0, 0, 0, 62, 0, 3, 0, 33, 0, 0, 0, 32, 0, 0, 0, 65, 0, 5, 0, 23, 0, 0, 0, 35, 0, 0, 0, 27, 0, 0, 0, 19, 0, 0, 0, 61, 0, 4, 0, 7, 0, 0, 0, 36, 0, 0, 0, 35, 0, 0, 0, 
65, 0, 5, 0, 23, 0, 0, 0, 37, 0, 0, 0, 27, 0, 0, 0, 34, 0, 0, 0, 62, 0, 3, 0, 37, 0, 0, 0, 36, 0, 0, 0, 65, 0, 5, 0, 23, 0, 0, 0, 41, 0, 0, 0, 27, 0, 0, 0, 34, 0, 0, 0, 61, 0, 4, 0, 7, 0, 0, 0, 42, 0, 0, 0, 
41, 0, 0, 0, 65, 0, 5, 0, 23, 0, 0, 0, 43, 0, 0, 0, 40, 0, 0, 0, 19, 0, 0, 0, 62, 0, 3, 0, 43, 0, 0, 0, 42, 0, 0, 0, 65, 0, 5, 0, 17, 0, 0, 0, 44, 0, 0, 0, 27, 0, 0, 0, 13, 0, 0, 0, 61, 0, 4, 0, 8, 0, 0, 0, 
45, 0, 0, 0, 44, 0, 0, 0, 65, 0, 5, 0, 17, 0, 0, 0, 46, 0, 0, 0, 40, 0, 0, 0, 13, 0, 0, 0, 62, 0, 3, 0, 46, 0, 0, 0, 45, 0, 0, 0, 65, 0, 5, 0, 23, 0, 0, 0, 53, 0, 0, 0, 40, 0, 0, 0, 19, 0, 0, 0, 61, 0, 4, 0, 
7, 0, 0, 0, 54, 0, 0, 0, 53, 0, 0, 0, 65, 0, 5, 0, 55, 0, 0, 0, 56, 0, 0, 0, 52, 0, 0, 0, 19, 0, 0, 0, 62, 0, 3, 0, 56, 0, 0, 0, 54, 0, 0, 0, 65, 0, 5, 0, 17, 0, 0, 0, 59, 0, 0, 0, 40, 0, 0, 0, 13, 0, 0, 0, 
61, 0, 4, 0, 8, 0, 0, 0, 60, 0, 0, 0, 59, 0, 0, 0, 62, 0, 3, 0, 58, 0, 0, 0, 60, 0, 0, 0, 65, 0, 6, 0, 61, 0, 0, 0, 62, 0, 0, 0, 52, 0, 0, 0, 19, 0, 0, 0, 48, 0, 0, 0, 61, 0, 4, 0, 6, 0, 0, 0, 63, 0, 0, 0, 
62, 0, 0, 0, 127, 0, 4, 0, 6, 0, 0, 0, 64, 0, 0, 0, 63, 0, 0, 0, 65, 0, 6, 0, 61, 0, 0, 0, 65, 0, 0, 0, 52, 0, 0, 0, 19, 0, 0, 0, 48, 0, 0, 0, 62, 0, 3, 0, 65, 0, 0, 0, 64, 0, 0, 0, 253, 0, 1, 0, 56, 0, 1, 0, 
0, 5, 0, 0, 0, 1, 202, 85, 61, 80, 241, 173, 214, 235, 204, 64, 199, 227, 71, 202, 220, 13, 0, 221, 12, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 7, 71, 108, 111, 98, 97, 108, 115, 1, 0, 0, 0, 48, 83, 112, 114, 105, 116, 101, 69, 102, 102, 101, 99, 116, 69, 120, 
116, 84, 101, 120, 116, 117, 114, 101, 46, 88, 101, 110, 107, 111, 73, 110, 116, 101, 114, 110, 97, 108, 95, 84, 101, 120, 116, 117, 114, 101, 69, 120, 116, 48, 2, 0, 0, 0, 30, 83, 112, 114, 105, 116, 101, 69, 102, 102, 101, 99, 116, 69, 120, 116, 84, 101, 120, 116, 117, 114, 101, 46, 83, 97, 
109, 112, 108, 101, 114, 3, 0, 0, 0, 9, 78, 111, 83, 97, 109, 112, 108, 101, 114, 4, 0, 0, 0, 0, 92, 12, 0, 0, 3, 2, 35, 7, 0, 0, 1, 0, 7, 0, 8, 0, 119, 0, 0, 0, 0, 0, 0, 0, 17, 0, 2, 0, 1, 0, 0, 0, 11, 0, 6, 0, 1, 0, 0, 0, 
71, 76, 83, 76, 46, 115, 116, 100, 46, 52, 53, 48, 0, 0, 0, 0, 14, 0, 3, 0, 0, 0, 0, 0, 1, 0, 0, 0, 15, 0, 8, 0, 4, 0, 0, 0, 4, 0, 0, 0, 109, 97, 105, 110, 0, 0, 0, 0, 92, 0, 0, 0, 96, 0, 0, 0, 115, 0, 0, 0, 16, 0, 3, 0, 
4, 0, 0, 0, 7, 0, 0, 0, 3, 0, 3, 0, 2, 0, 0, 0, 194, 1, 0, 0, 5, 0, 4, 0, 4, 0, 0, 0, 109, 97, 105, 110, 0, 0, 0, 0, 5, 0, 7, 0, 11, 0, 0, 0, 84, 111, 76, 105, 110, 101, 97, 114, 95, 105, 100, 51, 40, 118, 102, 52, 59, 0, 0, 0, 
5, 0, 4, 0, 10, 0, 0, 0, 115, 82, 71, 66, 97, 0, 0, 0, 5, 0, 5, 0, 14, 0, 0, 0, 80, 83, 95, 83, 84, 82, 69, 65, 77, 83, 0, 0, 6, 0, 7, 0, 14, 0, 0, 0, 0, 0, 0, 0, 84, 101, 120, 67, 111, 111, 114, 100, 95, 105, 100, 49, 56, 0, 0, 0, 
6, 0, 7, 0, 14, 0, 0, 0, 1, 0, 0, 0, 67, 111, 108, 111, 114, 84, 97, 114, 103, 101, 116, 95, 105, 100, 50, 0, 5, 0, 12, 0, 18, 0, 0, 0, 83, 104, 97, 100, 105, 110, 103, 95, 105, 100, 50, 40, 115, 116, 114, 117, 99, 116, 45, 80, 83, 95, 83, 84, 82, 69, 65, 77, 
83, 45, 118, 102, 50, 45, 118, 102, 52, 49, 59, 0, 5, 0, 4, 0, 17, 0, 0, 0, 115, 116, 114, 101, 97, 109, 115, 0, 5, 0, 4, 0, 22, 0, 0, 0, 115, 82, 71, 66, 0, 0, 0, 0, 5, 0, 6, 0, 49, 0, 0, 0, 116, 101, 120, 116, 117, 114, 101, 67, 111, 108, 111, 114, 
0, 0, 0, 0, 5, 0, 10, 0, 52, 0, 0, 0, 88, 101, 110, 107, 111, 73, 110, 116, 101, 114, 110, 97, 108, 95, 84, 101, 120, 116, 117, 114, 101, 69, 120, 116, 48, 95, 105, 100, 49, 54, 0, 0, 5, 0, 6, 0, 56, 0, 0, 0, 83, 97, 109, 112, 108, 101, 114, 95, 105, 100, 49, 55, 
0, 0, 0, 0, 5, 0, 4, 0, 66, 0, 0, 0, 71, 108, 111, 98, 97, 108, 115, 0, 6, 0, 6, 0, 66, 0, 0, 0, 0, 0, 0, 0, 67, 111, 108, 111, 114, 95, 105, 100, 49, 52, 0, 0, 6, 0, 7, 0, 66, 0, 0, 0, 1, 0, 0, 0, 72, 97, 115, 83, 82, 103, 98, 95, 
105, 100, 49, 53, 0, 0, 0, 0, 5, 0, 3, 0, 68, 0, 0, 0, 0, 0, 0, 0, 5, 0, 4, 0, 78, 0, 0, 0, 112, 97, 114, 97, 109, 0, 0, 0, 5, 0, 5, 0, 88, 0, 0, 0, 80, 83, 95, 73, 78, 80, 85, 84, 0, 0, 0, 0, 6, 0, 8, 0, 88, 0, 0, 0, 
0, 0, 0, 0, 83, 104, 97, 100, 105, 110, 103, 80, 111, 115, 105, 116, 105, 111, 110, 95, 105, 100, 48, 0, 6, 0, 7, 0, 88, 0, 0, 0, 1, 0, 0, 0, 84, 101, 120, 67, 111, 111, 114, 100, 95, 105, 100, 49, 56, 0, 0, 0, 5, 0, 5, 0, 90, 0, 0, 0, 95, 48, 105, 110, 
112, 117, 116, 95, 48, 0, 0, 0, 5, 0, 5, 0, 92, 0, 0, 0, 118, 95, 84, 69, 88, 67, 79, 79, 82, 68, 48, 0, 5, 0, 6, 0, 96, 0, 0, 0, 103, 108, 95, 70, 114, 97, 103, 67, 111, 111, 114, 100, 0, 0, 0, 0, 5, 0, 4, 0, 99, 0, 0, 0, 115, 116, 114, 101, 
97, 109, 115, 0, 5, 0, 4, 0, 103, 0, 0, 0, 112, 97, 114, 97, 109, 0, 0, 0, 5, 0, 5, 0, 108, 0, 0, 0, 80, 83, 95, 79, 85, 84, 80, 85, 84, 0, 0, 0, 6, 0, 7, 0, 108, 0, 0, 0, 0, 0, 0, 0, 67, 111, 108, 111, 114, 84, 97, 114, 103, 101, 116, 95, 
105, 100, 50, 0, 5, 0, 5, 0, 110, 0, 0, 0, 95, 48, 111, 117, 116, 112, 117, 116, 95, 48, 0, 0, 5, 0, 10, 0, 115, 0, 0, 0, 111, 117, 116, 95, 103, 108, 95, 102, 114, 97, 103, 100, 97, 116, 97, 95, 67, 111, 108, 111, 114, 84, 97, 114, 103, 101, 116, 95, 105, 100, 50, 0, 
5, 0, 5, 0, 118, 0, 0, 0, 78, 111, 83, 97, 109, 112, 108, 101, 114, 0, 0, 0, 71, 0, 4, 0, 52, 0, 0, 0, 34, 0, 0, 0, 0, 0, 0, 0, 71, 0, 4, 0, 52, 0, 0, 0, 33, 0, 0, 0, 2, 0, 0, 0, 71, 0, 4, 0, 56, 0, 0, 0, 34, 0, 0, 0, 
0, 0, 0, 0, 71, 0, 4, 0, 56, 0, 0, 0, 33, 0, 0, 0, 3, 0, 0, 0, 72, 0, 5, 0, 66, 0, 0, 0, 0, 0, 0, 0, 35, 0, 0, 0, 0, 0, 0, 0, 72, 0, 5, 0, 66, 0, 0, 0, 1, 0, 0, 0, 35, 0, 0, 0, 16, 0, 0, 0, 71, 0, 3, 0, 
66, 0, 0, 0, 2, 0, 0, 0, 71, 0, 4, 0, 68, 0, 0, 0, 34, 0, 0, 0, 0, 0, 0, 0, 71, 0, 4, 0, 68, 0, 0, 0, 33, 0, 0, 0, 1, 0, 0, 0, 71, 0, 4, 0, 92, 0, 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 71, 0, 4, 0, 96, 0, 0, 0, 
11, 0, 0, 0, 15, 0, 0, 0, 71, 0, 4, 0, 115, 0, 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 71, 0, 4, 0, 118, 0, 0, 0, 34, 0, 0, 0, 0, 0, 0, 0, 71, 0, 4, 0, 118, 0, 0, 0, 33, 0, 0, 0, 4, 0, 0, 0, 19, 0, 2, 0, 2, 0, 0, 0, 
33, 0, 3, 0, 3, 0, 0, 0, 2, 0, 0, 0, 22, 0, 3, 0, 6, 0, 0, 0, 32, 0, 0, 0, 23, 0, 4, 0, 7, 0, 0, 0, 6, 0, 0, 0, 4, 0, 0, 0, 32, 0, 4, 0, 8, 0, 0, 0, 7, 0, 0, 0, 7, 0, 0, 0, 33, 0, 4, 0, 9, 0, 0, 0, 
7, 0, 0, 0, 8, 0, 0, 0, 23, 0, 4, 0, 13, 0, 0, 0, 6, 0, 0, 0, 2, 0, 0, 0, 30, 0, 4, 0, 14, 0, 0, 0, 13, 0, 0, 0, 7, 0, 0, 0, 32, 0, 4, 0, 15, 0, 0, 0, 7, 0, 0, 0, 14, 0, 0, 0, 33, 0, 4, 0, 16, 0, 0, 0, 
7, 0, 0, 0, 15, 0, 0, 0, 23, 0, 4, 0, 20, 0, 0, 0, 6, 0, 0, 0, 3, 0, 0, 0, 32, 0, 4, 0, 21, 0, 0, 0, 7, 0, 0, 0, 20, 0, 0, 0, 43, 0, 4, 0, 6, 0, 0, 0, 28, 0, 0, 0, 18, 81, 156, 62, 43, 0, 4, 0, 6, 0, 0, 0, 
30, 0, 0, 0, 196, 162, 46, 63, 43, 0, 4, 0, 6, 0, 0, 0, 34, 0, 0, 0, 194, 44, 77, 60, 21, 0, 4, 0, 38, 0, 0, 0, 32, 0, 0, 0, 0, 0, 0, 0, 43, 0, 4, 0, 38, 0, 0, 0, 39, 0, 0, 0, 3, 0, 0, 0, 32, 0, 4, 0, 40, 0, 0, 0, 
7, 0, 0, 0, 6, 0, 0, 0, 25, 0, 9, 0, 50, 0, 0, 0, 6, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 32, 0, 4, 0, 51, 0, 0, 0, 0, 0, 0, 0, 50, 0, 0, 0, 59, 0, 4, 0, 
51, 0, 0, 0, 52, 0, 0, 0, 0, 0, 0, 0, 26, 0, 2, 0, 54, 0, 0, 0, 32, 0, 4, 0, 55, 0, 0, 0, 0, 0, 0, 0, 54, 0, 0, 0, 59, 0, 4, 0, 55, 0, 0, 0, 56, 0, 0, 0, 0, 0, 0, 0, 27, 0, 3, 0, 58, 0, 0, 0, 50, 0, 0, 0, 
21, 0, 4, 0, 60, 0, 0, 0, 32, 0, 0, 0, 1, 0, 0, 0, 43, 0, 4, 0, 60, 0, 0, 0, 61, 0, 0, 0, 0, 0, 0, 0, 32, 0, 4, 0, 62, 0, 0, 0, 7, 0, 0, 0, 13, 0, 0, 0, 30, 0, 4, 0, 66, 0, 0, 0, 7, 0, 0, 0, 38, 0, 0, 0, 
32, 0, 4, 0, 67, 0, 0, 0, 2, 0, 0, 0, 66, 0, 0, 0, 59, 0, 4, 0, 67, 0, 0, 0, 68, 0, 0, 0, 2, 0, 0, 0, 43, 0, 4, 0, 60, 0, 0, 0, 69, 0, 0, 0, 1, 0, 0, 0, 32, 0, 4, 0, 70, 0, 0, 0, 2, 0, 0, 0, 38, 0, 0, 0, 
20, 0, 2, 0, 73, 0, 0, 0, 43, 0, 4, 0, 38, 0, 0, 0, 74, 0, 0, 0, 0, 0, 0, 0, 32, 0, 4, 0, 82, 0, 0, 0, 2, 0, 0, 0, 7, 0, 0, 0, 30, 0, 4, 0, 88, 0, 0, 0, 7, 0, 0, 0, 13, 0, 0, 0, 32, 0, 4, 0, 89, 0, 0, 0, 
7, 0, 0, 0, 88, 0, 0, 0, 32, 0, 4, 0, 91, 0, 0, 0, 1, 0, 0, 0, 13, 0, 0, 0, 59, 0, 4, 0, 91, 0, 0, 0, 92, 0, 0, 0, 1, 0, 0, 0, 32, 0, 4, 0, 95, 0, 0, 0, 1, 0, 0, 0, 7, 0, 0, 0, 59, 0, 4, 0, 95, 0, 0, 0, 
96, 0, 0, 0, 1, 0, 0, 0, 30, 0, 3, 0, 108, 0, 0, 0, 7, 0, 0, 0, 32, 0, 4, 0, 109, 0, 0, 0, 7, 0, 0, 0, 108, 0, 0, 0, 32, 0, 4, 0, 114, 0, 0, 0, 3, 0, 0, 0, 7, 0, 0, 0, 59, 0, 4, 0, 114, 0, 0, 0, 115, 0, 0, 0, 
3, 0, 0, 0, 59, 0, 4, 0, 55, 0, 0, 0, 118, 0, 0, 0, 0, 0, 0, 0, 54, 0, 5, 0, 2, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 248, 0, 2, 0, 5, 0, 0, 0, 59, 0, 4, 0, 89, 0, 0, 0, 90, 0, 0, 0, 7, 0, 0, 0, 
59, 0, 4, 0, 15, 0, 0, 0, 99, 0, 0, 0, 7, 0, 0, 0, 59, 0, 4, 0, 15, 0, 0, 0, 103, 0, 0, 0, 7, 0, 0, 0, 59, 0, 4, 0, 109, 0, 0, 0, 110, 0, 0, 0, 7, 0, 0, 0, 61, 0, 4, 0, 13, 0, 0, 0, 93, 0, 0, 0, 92, 0, 0, 0, 
65, 0, 5, 0, 62, 0, 0, 0, 94, 0, 0, 0, 90, 0, 0, 0, 69, 0, 0, 0, 62, 0, 3, 0, 94, 0, 0, 0, 93, 0, 0, 0, 61, 0, 4, 0, 7, 0, 0, 0, 97, 0, 0, 0, 96, 0, 0, 0, 65, 0, 5, 0, 8, 0, 0, 0, 98, 0, 0, 0, 90, 0, 0, 0, 
61, 0, 0, 0, 62, 0, 3, 0, 98, 0, 0, 0, 97, 0, 0, 0, 65, 0, 5, 0, 62, 0, 0, 0, 100, 0, 0, 0, 90, 0, 0, 0, 69, 0, 0, 0, 61, 0, 4, 0, 13, 0, 0, 0, 101, 0, 0, 0, 100, 0, 0, 0, 65, 0, 5, 0, 62, 0, 0, 0, 102, 0, 0, 0, 
99, 0, 0, 0, 61, 0, 0, 0, 62, 0, 3, 0, 102, 0, 0, 0, 101, 0, 0, 0, 61, 0, 4, 0, 14, 0, 0, 0, 104, 0, 0, 0, 99, 0, 0, 0, 62, 0, 3, 0, 103, 0, 0, 0, 104, 0, 0, 0, 57, 0, 5, 0, 7, 0, 0, 0, 105, 0, 0, 0, 18, 0, 0, 0, 
103, 0, 0, 0, 61, 0, 4, 0, 14, 0, 0, 0, 106, 0, 0, 0, 103, 0, 0, 0, 62, 0, 3, 0, 99, 0, 0, 0, 106, 0, 0, 0, 65, 0, 5, 0, 8, 0, 0, 0, 107, 0, 0, 0, 99, 0, 0, 0, 69, 0, 0, 0, 62, 0, 3, 0, 107, 0, 0, 0, 105, 0, 0, 0, 
65, 0, 5, 0, 8, 0, 0, 0, 111, 0, 0, 0, 99, 0, 0, 0, 69, 0, 0, 0, 61, 0, 4, 0, 7, 0, 0, 0, 112, 0, 0, 0, 111, 0, 0, 0, 65, 0, 5, 0, 8, 0, 0, 0, 113, 0, 0, 0, 110, 0, 0, 0, 61, 0, 0, 0, 62, 0, 3, 0, 113, 0, 0, 0, 
112, 0, 0, 0, 65, 0, 5, 0, 8, 0, 0, 0, 116, 0, 0, 0, 110, 0, 0, 0, 61, 0, 0, 0, 61, 0, 4, 0, 7, 0, 0, 0, 117, 0, 0, 0, 116, 0, 0, 0, 62, 0, 3, 0, 115, 0, 0, 0, 117, 0, 0, 0, 253, 0, 1, 0, 56, 0, 1, 0, 54, 0, 5, 0, 
7, 0, 0, 0, 11, 0, 0, 0, 0, 0, 0, 0, 9, 0, 0, 0, 55, 0, 3, 0, 8, 0, 0, 0, 10, 0, 0, 0, 248, 0, 2, 0, 12, 0, 0, 0, 59, 0, 4, 0, 21, 0, 0, 0, 22, 0, 0, 0, 7, 0, 0, 0, 61, 0, 4, 0, 7, 0, 0, 0, 23, 0, 0, 0, 
10, 0, 0, 0, 79, 0, 8, 0, 20, 0, 0, 0, 24, 0, 0, 0, 23, 0, 0, 0, 23, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 2, 0, 0, 0, 62, 0, 3, 0, 22, 0, 0, 0, 24, 0, 0, 0, 61, 0, 4, 0, 20, 0, 0, 0, 25, 0, 0, 0, 22, 0, 0, 0, 
61, 0, 4, 0, 20, 0, 0, 0, 26, 0, 0, 0, 22, 0, 0, 0, 61, 0, 4, 0, 20, 0, 0, 0, 27, 0, 0, 0, 22, 0, 0, 0, 142, 0, 5, 0, 20, 0, 0, 0, 29, 0, 0, 0, 27, 0, 0, 0, 28, 0, 0, 0, 80, 0, 6, 0, 20, 0, 0, 0, 31, 0, 0, 0, 
30, 0, 0, 0, 30, 0, 0, 0, 30, 0, 0, 0, 129, 0, 5, 0, 20, 0, 0, 0, 32, 0, 0, 0, 29, 0, 0, 0, 31, 0, 0, 0, 133, 0, 5, 0, 20, 0, 0, 0, 33, 0, 0, 0, 26, 0, 0, 0, 32, 0, 0, 0, 80, 0, 6, 0, 20, 0, 0, 0, 35, 0, 0, 0, 
34, 0, 0, 0, 34, 0, 0, 0, 34, 0, 0, 0, 129, 0, 5, 0, 20, 0, 0, 0, 36, 0, 0, 0, 33, 0, 0, 0, 35, 0, 0, 0, 133, 0, 5, 0, 20, 0, 0, 0, 37, 0, 0, 0, 25, 0, 0, 0, 36, 0, 0, 0, 65, 0, 5, 0, 40, 0, 0, 0, 41, 0, 0, 0, 
10, 0, 0, 0, 39, 0, 0, 0, 61, 0, 4, 0, 6, 0, 0, 0, 42, 0, 0, 0, 41, 0, 0, 0, 81, 0, 5, 0, 6, 0, 0, 0, 43, 0, 0, 0, 37, 0, 0, 0, 0, 0, 0, 0, 81, 0, 5, 0, 6, 0, 0, 0, 44, 0, 0, 0, 37, 0, 0, 0, 1, 0, 0, 0, 
81, 0, 5, 0, 6, 0, 0, 0, 45, 0, 0, 0, 37, 0, 0, 0, 2, 0, 0, 0, 80, 0, 7, 0, 7, 0, 0, 0, 46, 0, 0, 0, 43, 0, 0, 0, 44, 0, 0, 0, 45, 0, 0, 0, 42, 0, 0, 0, 254, 0, 2, 0, 46, 0, 0, 0, 56, 0, 1, 0, 54, 0, 5, 0, 
7, 0, 0, 0, 18, 0, 0, 0, 0, 0, 0, 0, 16, 0, 0, 0, 55, 0, 3, 0, 15, 0, 0, 0, 17, 0, 0, 0, 248, 0, 2, 0, 19, 0, 0, 0, 59, 0, 4, 0, 8, 0, 0, 0, 49, 0, 0, 0, 7, 0, 0, 0, 59, 0, 4, 0, 8, 0, 0, 0, 78, 0, 0, 0, 
7, 0, 0, 0, 61, 0, 4, 0, 50, 0, 0, 0, 53, 0, 0, 0, 52, 0, 0, 0, 61, 0, 4, 0, 54, 0, 0, 0, 57, 0, 0, 0, 56, 0, 0, 0, 86, 0, 5, 0, 58, 0, 0, 0, 59, 0, 0, 0, 53, 0, 0, 0, 57, 0, 0, 0, 65, 0, 5, 0, 62, 0, 0, 0, 
63, 0, 0, 0, 17, 0, 0, 0, 61, 0, 0, 0, 61, 0, 4, 0, 13, 0, 0, 0, 64, 0, 0, 0, 63, 0, 0, 0, 87, 0, 5, 0, 7, 0, 0, 0, 65, 0, 0, 0, 59, 0, 0, 0, 64, 0, 0, 0, 62, 0, 3, 0, 49, 0, 0, 0, 65, 0, 0, 0, 65, 0, 5, 0, 
70, 0, 0, 0, 71, 0, 0, 0, 68, 0, 0, 0, 69, 0, 0, 0, 61, 0, 4, 0, 38, 0, 0, 0, 72, 0, 0, 0, 71, 0, 0, 0, 171, 0, 5, 0, 73, 0, 0, 0, 75, 0, 0, 0, 72, 0, 0, 0, 74, 0, 0, 0, 247, 0, 3, 0, 77, 0, 0, 0, 0, 0, 0, 0, 
250, 0, 4, 0, 75, 0, 0, 0, 76, 0, 0, 0, 77, 0, 0, 0, 248, 0, 2, 0, 76, 0, 0, 0, 61, 0, 4, 0, 7, 0, 0, 0, 79, 0, 0, 0, 49, 0, 0, 0, 62, 0, 3, 0, 78, 0, 0, 0, 79, 0, 0, 0, 57, 0, 5, 0, 7, 0, 0, 0, 80, 0, 0, 0, 
11, 0, 0, 0, 78, 0, 0, 0, 62, 0, 3, 0, 49, 0, 0, 0, 80, 0, 0, 0, 249, 0, 2, 0, 77, 0, 0, 0, 248, 0, 2, 0, 77, 0, 0, 0, 61, 0, 4, 0, 7, 0, 0, 0, 81, 0, 0, 0, 49, 0, 0, 0, 65, 0, 5, 0, 82, 0, 0, 0, 83, 0, 0, 0, 
68, 0, 0, 0, 61, 0, 0, 0, 61, 0, 4, 0, 7, 0, 0, 0, 84, 0, 0, 0, 83, 0, 0, 0, 133, 0, 5, 0, 7, 0, 0, 0, 85, 0, 0, 0, 81, 0, 0, 0, 84, 0, 0, 0, 254, 0, 2, 0, 85, 0, 0, 0, 56, 0, 1, 0, 
        };
    }
}
#endif
