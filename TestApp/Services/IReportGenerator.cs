﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Services
{
    public interface IReportGenerator
    {
        void GenerateReport(string filePath);
    }
}
