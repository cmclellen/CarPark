using CarPark.RateCalculators;
using CarPark.Utilities;
using System;
using System.Globalization;
using System.IO;

namespace CarPark
{
    public class UICoordinator
    {
        private readonly IRateCalculator RateCalculator =
            new EarlyBirdRateCalculator(
                new NightRateCalculator(
                    new WeekendRateCalculator(
                        new StandardRateCalculator())));

        public UICoordinator(TextReader reader, TextWriter writer)
        {
            Guard.NotNull(() => writer, writer);
            Guard.NotNull(() => reader, reader);
            Writer = writer;
            Reader = reader;
        }

        private TextReader Reader { get; set; }
        private TextWriter Writer { get; set; }
        private readonly string ExpectedDateFormat = "dd/MM/yyyy HH:mm";

        public void Run()
        {
            while (true)
            {
                Writer.WriteLine($"All times must be in the format {ExpectedDateFormat}");
                Writer.WriteLine("Type exit to end the program");

                var startDateTime = CaptureDateTime("Time entered: ");
                if (!startDateTime.HasValue) break;
                var endDateTime = CaptureDateTime("Time exited: ");
                if (!endDateTime.HasValue) break;

                var response = RateCalculator.Calculate(new CalculateRequest(startDateTime.Value, endDateTime.Value));

                Writer.WriteLine($"Rate Name: {response.RateName}");
                Writer.WriteLine($"Price: ${response.Price:n2}");

                Writer.WriteLine();
            }
        }

        private DateTime? CaptureDateTime(string label)
        {
            while (true)
            {
                Writer.Write(label);
                var text = Reader.ReadLine();
                if (MustExist(text)) return default(DateTime?);
                DateTime dateTime;
                if (!DateTime.TryParseExact(text, ExpectedDateFormat, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out dateTime))
                {
                    Writer.WriteLine($"Invalid format for date. Expected the format {ExpectedDateFormat}.");
                    continue;
                }
                return dateTime;
            }
        }

        private bool MustExist(string text)
        {
            return string.Equals(text, "exit", System.StringComparison.OrdinalIgnoreCase);
        }
    }
}