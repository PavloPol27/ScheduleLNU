using System;
using Serilog;

public static class Extensions
{
    public static LoggerConfiguration ConfigureFromJSON(this LoggerConfiguration configure)
    {
        configure.AddJsonFile()
    }
}
