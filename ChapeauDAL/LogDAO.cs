using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ChapeauDAL
{
    public static class LogDAO
    {
        //logs exceptions to text file
        public static void ErrorLog(Exception exp, string errorLocation)
        {
            string pathLocation = "../../../ErrorLog.txt";
            StreamWriter writer;

            if (!File.Exists(pathLocation))
            {
                //it creates new Error log file and write the exception messages to it
                writer = File.CreateText(pathLocation);
                writer.WriteLine($"{DateTime.Now}, Error occured: ({errorLocation} {exp.Message})");
            }
            else
            {
                // it writes the new error/exception message to existing log file
                writer = File.AppendText(pathLocation);
                writer.WriteLine($"{DateTime.Now}, Error occured: ({errorLocation} {exp.Message})");
            }
            writer.Close();
        }
    }
}
