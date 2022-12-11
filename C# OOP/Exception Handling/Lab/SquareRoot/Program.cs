﻿using System;

namespace SquareRoot
{
    public class Program
    {
        static void Main(string[] args)
        {
			try
			{
				var num = int.Parse(Console.ReadLine());
				if (num < 0) throw new ArgumentException("Invalid number.");
				Console.WriteLine(Math.Sqrt(num));
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				Console.WriteLine("Goodbye.");
			}
        }
    }
}
