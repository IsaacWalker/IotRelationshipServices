using FYPDataGenerator.Gowalla;
using System;
using System.Collections.Generic;
using System.IO;
using Web.Iot.Models.Device;

namespace FYPDataGenerator
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Reading In...");

            string gowallaFileName = "Gowalla_totalCheckins.txt";
            string[] GowallaLines = File.ReadAllLines(gowallaFileName);

            string androidModelsFileName = "androidModels.csv";
            string[] AndroidModelLines = File.ReadAllLines(androidModelsFileName);

            string deviceFileName = "devices.txt";
            string scanFileName = "scans.txt";

            new GowallaConverter(AndroidModelLines).Run(GowallaLines, deviceFileName, scanFileName);

            Console.ReadLine();
        }


    }
}
