﻿namespace LiveChartMeParser.Models.Exceptions;

public class CustomException : Exception
{
    protected CustomException(string message)
        : base(message)
    {
    }
}