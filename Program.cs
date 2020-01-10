﻿using System;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Threading;

namespace Lab17_Async_Await
{
    class Program
    {
        static Uri uri = new Uri("<https://www.google.com>");
        static Stopwatch s = new Stopwatch();
        static void Main(string[] args)
        {
            // Main method here
            // Setup : Create our data file
            // CSV = Comma Separated Values
            File.WriteAllText("data.csv", "id,name,age");
            File.AppendAllText("data.csv", "\\n1,Bob,21");
            File.AppendAllText("data.csv", "\\n2,Tina,23");
            File.AppendAllText("data.csv", "\\n3,Paul,24");
        }
        static void ReadDataSync()
        {
            var output = File.ReadAllText("data.csv");
            Thread.Sleep(5000);
            Console.WriteLine("\\nSync\\n");
            Console.WriteLine(output);
        }

        async static void ReadDataAsync()
        {
            var output = await File.ReadAllTextAsync("data.csv");
            Console.WriteLine("\\nASync\\n");
            Console.WriteLine(output);
        }

        static void GetWebPageSync()
        {
            // get page

            var webclient = new WebClient { Proxy = null };
            webclient.DownloadFile(uri, @"c:\\webpage\\page01.html");
            Console.WriteLine($"Sync Web page has downloaded at time {s.ElapsedMilliseconds}");


        }
        async static void GetWebPageAsync()
        {
            var webclient = new WebClient { Proxy = null };
            var webpage = await webclient.DownloadStringTaskAsync(uri);
            // start chrome and run it locally
            Console.WriteLine($"Web page has downloaded at time {s.ElapsedMilliseconds}");
            ///Console.WriteLine(webpage);
        }
    }
}
