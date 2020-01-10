// Program.cs

/*
Copyright (c) 2011-2020  Rich Giordano / Global Software Society

GPL-3.0-or-later

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Text;

using GssUtilsLib;

namespace GetMostRecentDateOnDayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            Test_GetMostRecentDateOnDayOfWeek();
        }

        public static void Test_GetMostRecentDateOnDayOfWeek()
        {
            string fmt = "Test {0}: {1:M/d/yyyy} falls on a {2}. Most recent {3} is {4:M/d/yyyy}.\n";
            DateTime x;
            DateTime d;
            int test;
            Console.WriteLine("Test GetMostRecentDateOnDayOfWeek()\n{0=Sun, 1=Mon, 2=Tue, 3=Wed, 4=Thu, 5=Fri, 6=Sat}\n");

            test = 1;
            d = DateTime.Parse("4/20/2011");
            x = DateUtils.GetMostRecentDateOnDayOfWeek(d, System.DayOfWeek.Thursday); // 4/20/11 = known Wed.
            Console.WriteLine(string.Format(fmt, test, d, d.DayOfWeek, "Thu", x));

            test = 2;
            d = DateTime.Parse("9/12/2011");
            x = DateUtils.GetMostRecentDateOnDayOfWeek(d, 5);  // 5 = Friday
            Console.WriteLine(string.Format(fmt, test, d, d.DayOfWeek, "Fri", x));

            test = 3;
            d = DateTime.Parse("4/20/2011");
            x = DateUtils.GetMostRecentDateOnDayOfWeek(d, System.DayOfWeek.Wednesday);
            Console.WriteLine(string.Format(fmt, test, d, d.DayOfWeek, "Wed", x));

            test = 4;
            d = DateTime.Parse("4/20/2011");
            x = DateUtils.GetMostRecentDateOnDayOfWeek(d, System.DayOfWeek.Wednesday, true);
            Console.WriteLine(string.Format(fmt, test, d, d.DayOfWeek, "Wed", x));

            Console.WriteLine("\nTest GetNextFutureDateOnDayOfWeek()\n{0=Sun, 1=Mon, ..., 6=Sat}\n");
            fmt = "Test {0}: {1:M/d/yyyy} falls on a {2}. Next future {3} is {4:M/d/yyy}.\n";

            test = 5;
            d = DateTime.Parse("4/20/2011");
            x = DateUtils.GetNextFutureDateOnDayOfWeek(d, 2);  // 2 = Tue.
            Console.WriteLine(string.Format(fmt, test, d, d.DayOfWeek, "Tue", x));

            test = 6;
            d = DateTime.Now;
            x = DateUtils.GetNextFutureDateOnDayOfWeek(d, 1, false);  // 1 = Mon.
            Console.WriteLine(string.Format(fmt, test, d, d.DayOfWeek, "Mon", x));

            test = 7;
            d = DateTime.Parse("4/22/2011");
            x = DateUtils.GetNextFutureDateOnDayOfWeek(d, System.DayOfWeek.Friday); // known Fri.
            Console.WriteLine(string.Format(fmt, test, d, d.DayOfWeek, "Fri", x));

            test = 8;
            d = DateTime.Parse("4/22/2011");
            x = DateUtils.GetNextFutureDateOnDayOfWeek(d, System.DayOfWeek.Friday, true);
            Console.WriteLine(string.Format(fmt, test, d, d.DayOfWeek, "Fri", x));

            Console.WriteLine("\nTest GetAdjacentWeekDateOnDayOfWeek()\n{0=Sun, 1=Mon, ..., 5=Fri, 6=Sat}\n");
            fmt = "Test {0}: {1:M/d/yyyy} falls on a {2}. {3} {4} is {5:M/d/yyyy}.\n";

            test = 9;
            d = DateTime.Parse("4/22/2011");
            x = DateUtils.GetAdjacentWeekDateOnDayOfWeek(d, (int)System.DayOfWeek.Friday, -1, true);
            Console.WriteLine(string.Format(fmt, test, d, d.DayOfWeek, "Prior", "Fri", x));

            test = 10;
            x = DateUtils.GetAdjacentWeekDateOnDayOfWeek(d, (int)System.DayOfWeek.Friday, +1, true);
            Console.WriteLine(string.Format(fmt, test, d, d.DayOfWeek, "Following", "Fri", x));

            test = 11;
            x = DateUtils.GetAdjacentWeekDateOnDayOfWeek(d, (int)System.DayOfWeek.Friday, -1, false);
            Console.WriteLine(string.Format(fmt, test, d, d.DayOfWeek, "Prior", "Fri", x));

            test = 12;
            x = DateUtils.GetAdjacentWeekDateOnDayOfWeek(d, (int)System.DayOfWeek.Friday, +1, false);
            Console.WriteLine(string.Format(fmt, test, d, d.DayOfWeek, "Following", "Fri", x));

            test = 13;
            d = DateTime.Parse("4/23/2011");  // 4/23/11 = known Sat.
            x = DateUtils.GetAdjacentWeekDateOnDayOfWeek(d, 1, +1, false);
            Console.WriteLine(string.Format(fmt, test, d, d.DayOfWeek, "Following", "Mon", x));

            test = 14;
            x = DateUtils.GetAdjacentWeekDateOnDayOfWeek(d, (int)System.DayOfWeek.Monday, -1, true);
            Console.WriteLine(string.Format(fmt, test, d, d.DayOfWeek, "Prior", "Mon", x));

            test = 15;
            d = DateTime.Now;
            x = DateUtils.GetAdjacentWeekDateOnDayOfWeek(d, (int)System.DayOfWeek.Sunday, +1, false);
            Console.WriteLine(string.Format(fmt, test, d, d.DayOfWeek, "Following", "Sun", x));

            Console.Write("Press ENTER ");
            Console.ReadLine();
        }

    }
}
