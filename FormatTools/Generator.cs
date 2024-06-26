using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanXiang.FormatTools
{
    internal class Generator
    {
        /// <summary>
        /// 十六进制字符串转十进制数
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        internal static decimal ConvertHexToNumber(string hex) {
            decimal number;
            var parts = hex.Split('.');
            string integerPart = long.Parse(parts[0].Replace("0x",""),NumberStyles.HexNumber).ToString("000");
            double fractionPart = 0;
            if(parts.Length > 1) {
                string decimalHexPart = parts[1];
                for(int i = 0;i < decimalHexPart.Length;i++) {
                    int digit = int.Parse(decimalHexPart[i].ToString(),NumberStyles.HexNumber);
                    fractionPart += digit / Math.Pow(16,i + 1);
                }
            }
            number = decimal.Parse(integerPart + fractionPart.ToString());
            return number;
        }
    }
}