﻿using System;

namespace TestableApplication
{
    public class FileNameGenerator
    {
        public string Generate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd") + ".txt";
        }
    }
}