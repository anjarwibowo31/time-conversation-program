namespace TimeConversionProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            bool validInput = false;
            string inputTime = string.Empty;

            while (!validInput)
            {
                Console.WriteLine("Masukkan waktu dalam format 12 jam (hh:mm:ssAM/PM, contoh: 03:13:13PM): ");
                inputTime = Console.ReadLine();

                try
                {
                    string militaryTime = TimeConversion(inputTime);
                    Console.WriteLine("Waktu dalam format 24 jam: " + militaryTime);
                    validInput = true;
                    Console.Read();
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("Terjadi kesalahan: " + e.Message);
                }
            }
        }

        static string TimeConversion(string s)
        {
            int hours, minutes, seconds;
            string meridiemIndicator;

            if (s.Length != 10)
            {
                throw new ArgumentException("Format waktu tidak valid. Pastikan waktu dalam format hh:mm:ssAM/PM.");
            }

            try
            {
                hours = int.Parse(s.Substring(0, 2));
                minutes = int.Parse(s.Substring(3, 2));
                seconds = int.Parse(s.Substring(6, 2));
                meridiemIndicator = s.Substring(8);
            }
            catch (FormatException)
            {
                throw new ArgumentException("Format waktu tidak valid. Pastikan waktu dalam format hh:mm:ssAM/PM.");
            }

            if (hours < 1 || hours > 12 || minutes < 0 || minutes > 59 || seconds < 0 || seconds > 59)
            {
                throw new ArgumentException("Nilai waktu tidak valid. Pastikan jam dalam rentang 01-12, dan menit/detik dalam rentang 00-59.");
            }

            if (meridiemIndicator != "AM" && meridiemIndicator != "PM")
            {
                throw new ArgumentException("Format waktu tidak valid. Pastikan menggunakan AM atau PM.");
            }

            if (meridiemIndicator == "AM" && hours == 12)
            {
                hours = 0;
            }
            else if (meridiemIndicator == "PM" && hours < 12)
            {
                hours += 12;
            }

            return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        }
    }
}