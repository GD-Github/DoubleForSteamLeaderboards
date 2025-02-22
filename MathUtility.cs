using System;
using UnityEngine;

public static class MathUtility
{

    public static int ConvertDoubleToInt(double value)
    {
        if (value < 1000000000)
        {
            return (int)value;
        }
        string binaryValue = "01";
        string displayedValue = Math.Round(value).ToString("0.00000E000", System.Globalization.CultureInfo.InvariantCulture);
        string beforeDecimal = "";
        char c = 'a';
        int index = 0;
        while (c != 'E')
        {
            c = displayedValue[index];
            if (char.IsDigit(c)) beforeDecimal += c;
            index++;
        }
        int beforeDec = int.Parse(beforeDecimal);
        int afterDec = int.Parse(displayedValue.Substring(index));
        binaryValue += ConvertIntToBits(afterDec, 10) + ConvertIntToBits(beforeDec, 20);
        return Convert.ToInt32(binaryValue, 2);
    }

    public static double ConvertIntToDouble(int value)
    {
        // represents the score. First bit is not used
        // Second bit defines if we are above 1,000,000,000 (1 for true)
        // If we are under, the value is just what it is
        // Otherwise the 10 next bits represent the EXX value
        // the 20 last bits represents the "decimals" 
        string bits = ConvertIntToBits(value);
        if (bits[1] == '0') return value;
        string beforeDecimal = bits.Substring(2, 10);
        string afterDecimal = bits.Substring(12, 20);
        int afterDec = Convert.ToInt32(beforeDecimal, 2);
        int beforeDec = Convert.ToInt32(afterDecimal, 2);
        double result = beforeDec * 1.0 / (Math.Pow(10, beforeDec.ToString().Length - 1));
        result = result * Math.Pow(10, afterDec);
        return result;
    }
    public static string ConvertIntToStringScore(int value)
    {
        if (value < 1000000000)
        {
            return value.ToString("N0", System.Globalization.CultureInfo.InvariantCulture);
        }
        double doubleValue = ConvertIntToDouble(value);
        return Math.Round(doubleValue).ToString("0.#####E0", System.Globalization.CultureInfo.InvariantCulture);
    }
    private static string ConvertIntToBits(int value, int length = 32)
    {

        string result = Convert.ToString(value, 2);
        if (result.Length > length)
        {
            Debug.Log("ERROR: " + value + "  convnerts to " + result + "which is longer than expected length of " + length);
        }
        while (result.Length != length)
        {
            result = "0" + result;
        }
        return result;
    }
}
