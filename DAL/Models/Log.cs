using System;
using System.Globalization;

namespace DAL.Models
{
    public class Log
    {
        public int Id { get; set; }
        public DateTime LogTime { get; set; }
        public string LogInformation { get; set; }

        public Log() { }
        public Log(DateTime date, string message)
        {
            LogTime = date;
            LogInformation = message;
        }

        public override string ToString()
        {
            return $"{LogTime.ToString()}: {LogInformation}";
        }
    }
}
