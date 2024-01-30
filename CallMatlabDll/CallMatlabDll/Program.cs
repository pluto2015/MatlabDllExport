
// See https://aka.ms/new-console-template for more information

using ExportDllSample;
using MathWorks.MATLAB.NET.Arrays;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
Console.WriteLine("Hello, World!");

//声明两个列数量相同的二维数组，列数都是1，行数是100.并用随机数填充
var xArray = new int[100, 1];
var yArray = new int[100, 1];
var random = new Random();
for (int i = 0; i < 100; i++)
{
    xArray[i, 0] = random.Next(10,100);
    yArray[i, 0] = random.Next(10, 100);
}

Console.WriteLine("生成的X坐标");
Console.WriteLine(Array2String(xArray));
Console.WriteLine("生成的Y坐标");
Console.WriteLine(Array2String(yArray));

var showPlot = new ShowPlot();
//传给matlab的数据都要使用MWArray及其子类。数值型的强制转换到MWNumericArray即可.
//其它更多类型请查阅matlab官网文档：https://ww2.mathworks.cn/help/dotnetbuilder/MWArrayAPI/html/N_MathWorks_MATLAB_NET_Arrays.htm
//下方函数的第一个参数是返回结果的个数，数值不能超过返回参数的最大个数。
var arrays = showPlot.ExportDllSample(2, (MWNumericArray)xArray, (MWNumericArray)yArray);
//这里我们把xArray和yArray作为结果直接返回了，
var xArray1 = (int[,])(arrays[0].ToArray());
var yArray1 = (int[,])(arrays[1].ToArray());
Console.WriteLine("返回的X坐标");
Console.WriteLine(Array2String(xArray1));
Console.WriteLine("返回的Y坐标");
Console.WriteLine(Array2String(yArray1));

Console.ReadKey();

string Array2String<T>(T[,] array)
{
    var rows = new List<string>();
    for (int i = 0;i < array.GetLength(0);i++)
    {
        var cols = new List<T>();
        for (int j = 0;j < array.GetLength(1);j++)
        {
            cols.Add(array[i,j]);
        }

        rows.Add(string.Join(" ", cols));
    }

    return string.Join(Environment.NewLine, rows);
}