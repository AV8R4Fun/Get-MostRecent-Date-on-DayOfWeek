// DateUtils.cs

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

namespace UtilsLib
{
    class DateUtils
    {
        /// <summary>
        /// Computes a new date that is on a given day of the week, on or prior to a reference date.
        /// </summary>
        /// <param name="refDate">reference date</param>
        /// <param name="dayOfWeek">Sunday=0, Monday=1, ..., Saturday=6</param>
        /// <param name="matchingDOWReturnsRefDate">if the reference date's day of week matches dayOfWeek param, passing in true returns refDate, else returns the prior week's day of week</param>
        /// <returns>a new date on the given day of week</returns>
        public static DateTime GetMostRecentDateOnDayOfWeek(DateTime refDate, int dayOfWeek,
                                                            bool matchingDOWReturnsRefDate)
        {
            if (dayOfWeek < 0 || dayOfWeek > 6)
                throw new Exception("Invalid dayOfWeek parameter value passed to function DateUtils::GetMostRecentDateOnDayOfWeek()");

            DateTime retDate;
            int iRefDOW,
                iReqDOW;
            iRefDOW = (int)refDate.DayOfWeek;  // will be 0~6 (= Sun~Sat)
            iReqDOW = dayOfWeek;               // ditto
            retDate = refDate;
            if (iReqDOW != iRefDOW)
            {
                if (iRefDOW < iReqDOW)
                    iRefDOW += 7;
                retDate = retDate.AddDays(-(iRefDOW - iReqDOW));
            }
            else
            {
                if (!matchingDOWReturnsRefDate)
                    retDate = retDate.AddDays(-7);
            }
            return retDate;
        }

        /// <summary>
        /// Computes a new date that is on a given day of the week, prior to a reference date.
        /// </summary>
        /// <param name="refDate">reference date</param>
        /// <param name="dayOfWeek">Sunday=0, Monday=1, ..., Saturday=6</param>
        /// <remarks>if the reference date's day of week matches dayOfWeek param, returns the prior week's day of week.</remarks>
        /// <returns>a new date on the given day of week</returns>
        public static DateTime GetMostRecentDateOnDayOfWeek(DateTime refDate, int dayOfWeek)
        {
            // In this overload, the absence of an explicit matchingDOWReturnsRefDate param defaults to FALSE,
            //  i.e., if the Day Of Week of the passed refDate matches the passed dayOfWeek param, then
            //  the date returned excludes refDate and is the previous DOW (last week's)
            return GetMostRecentDateOnDayOfWeek(refDate, dayOfWeek, false);
        }

        /// <summary>
        /// Computes a new date that is on a given day of the week, on or prior to a reference date.
        /// </summary>
        /// <param name="refDate">reference date</param>
        /// <param name="dayOfWeek">enum</param>
        /// <param name="matchingDOWReturnsRefDate">if the reference date's day of week matches dayOfWeek param, passing in true returns refDate, else returns the prior week's day of week</param>
        /// <returns>a new date on the given day of week</returns>
        public static DateTime GetMostRecentDateOnDayOfWeek(DateTime refDate, System.DayOfWeek dayOfWeek,
                                                            bool matchingDOWReturnsRefDate)
        {
            int iReqDOW;
            iReqDOW = (int)dayOfWeek;  // will be 0~6 (= Sun~Sat)
            return GetMostRecentDateOnDayOfWeek(refDate, iReqDOW, matchingDOWReturnsRefDate);
        }

        /// <summary>
        /// Computes a new date that is on a given day of the week, prior to a reference date.
        /// </summary>
        /// <param name="refDate">reference date</param>
        /// <param name="dayOfWeek">enum</param>
        /// <remarks>if the reference date's day of week matches dayOfWeek param, returns the prior week's day of week.</remarks>
        /// <returns>a new date on the given day of week</returns>
        public static DateTime GetMostRecentDateOnDayOfWeek(DateTime refDate, System.DayOfWeek dayOfWeek)
        {
            // In this overload, the absence of an explicit matchingDOWReturnsRefDate param defaults to FALSE,
            //  i.e., if the Day Of Week of the passed refDate matches the passed dayOfWeek param, then
            //  the date returned excludes refDate and is the previous DOW (last week's)
            return GetMostRecentDateOnDayOfWeek(refDate, dayOfWeek, false);
        }


        /// <summary>
        /// Computes a new date that is on a given day of the week, on or after a reference date.
        /// </summary>
        /// <param name="refDate">reference date</param>
        /// <param name="dayOfWeek">Sunday=0, Monday=1, ..., Saturday=6</param>
        /// <param name="matchingDOWReturnsRefDate">if the reference date's day of week matches dayOfWeek param, passing in true returns refDate, else returns the following week's day of week</param>
        /// <returns>a new date on the given day of week</returns>
        public static DateTime GetNextFutureDateOnDayOfWeek(DateTime refDate, int dayOfWeek,
                                                            bool matchingDOWReturnsRefDate)
        {
            if (dayOfWeek < 0 || dayOfWeek > 6)
                throw new Exception("Invalid dayOfWeek parameter value passed to function DateUtils::GetNextFutureDateOnDayOfWeek()");
            DateTime retDate;
            int iRefDOW,
                iReqDOW;
            iRefDOW = (int)refDate.DayOfWeek;  // will be 0~6 (= Sun~Sat)
            iReqDOW = dayOfWeek;               // ditto
            retDate = refDate;
            if (iReqDOW != iRefDOW)
            {
                if (iReqDOW < iRefDOW)
                    iReqDOW += 7;
                retDate = retDate.AddDays((iReqDOW - iRefDOW));
            }
            else
            {
                if (!matchingDOWReturnsRefDate)
                    retDate = retDate.AddDays(7);
            }
            return retDate;
        }

        /// <summary>
        /// Computes a new date that is on a given day of the week, after a reference date.
        /// </summary>
        /// <param name="refDate">reference date</param>
        /// <param name="dayOfWeek">Sunday=0, Monday=1, ..., Saturday=6</param>
        /// <remarks>if the reference date's day of week matches dayOfWeek param, returns the following week's day of week</remark>
        /// <returns>a new date on the given day of week</returns>
        public static DateTime GetNextFutureDateOnDayOfWeek(DateTime refDate, int dayOfWeek)
        {
            // In this overload, the absence of an explicit matchingDOWReturnsRefDate param defaults to FALSE,
            //  i.e., if the Day Of Week of the passed refDate matches the passed dayOfWeek param, then
            //  the date returned excludes refDate and is the following DOW (next week's)
            return GetNextFutureDateOnDayOfWeek(refDate, dayOfWeek, false);
        }

        /// <summary>
        /// Computes a new date that is on a given day of the week, on or after a reference date.
        /// </summary>
        /// <param name="refDate">reference date</param>
        /// <param name="dayOfWeek">Sunday=0, Monday=1, ..., Saturday=6</param>
        /// <param name="matchingDOWReturnsRefDate">if the reference date's day of week matches dayOfWeek param, passing in true returns refDate, else returns the following week's day of week</param>
        /// <returns>a new date on the given day of week</returns>
        public static DateTime GetNextFutureDateOnDayOfWeek(DateTime refDate, System.DayOfWeek dayOfWeek,
                                                            bool matchingDOWReturnsRefDate)
        {
            int iReqDOW;
            iReqDOW = (int)dayOfWeek;  // will be 0~6 (= Sun~Sat)
            return GetNextFutureDateOnDayOfWeek(refDate, iReqDOW, matchingDOWReturnsRefDate);
        }

        /// <summary>
        /// Computes a new date that is on a given day of the week, after a reference date.
        /// </summary>
        /// <param name="refDate">reference date</param>
        /// <param name="dayOfWeek">enum</param>
        /// <remarks>if the reference date's day of week matches dayOfWeek param, returns the following week's day of week</remark>
        /// <returns>a new date on the given day of week</returns>
        public static DateTime GetNextFutureDateOnDayOfWeek(DateTime refDate, System.DayOfWeek dayOfWeek)
        {
            // In this overload, the absence of an explicit matchingDOWReturnsRefDate param defaults to FALSE,
            //  i.e., if the Day Of Week of the passed refDate matches the passed dayOfWeek param, then
            //  the date returned excludes refDate and is the following DOW (next week's)
            return GetNextFutureDateOnDayOfWeek(refDate, dayOfWeek, false);
        }

        /// <summary>
        /// Computes a new date that is on a given day of the week, relative to a reference date.
        /// </summary>
        /// <param name="refDate">reference date</param>
        /// <param name="dayOfWeek">Sunday=0, Monday=1, ..., Saturday=6</param>
        /// <param name="direction">-1=before (prior to) refDate or +1=after (following) refDate</param>
        /// <param name="matchingDOWReturnsRefDate">if the reference date's day of week matches dayOfWeek param, passing in true returns refDate, else returns the prior or following week's day of week</param>
        /// <returns>a new date on the given day of week</returns>
        public static DateTime GetAdjacentWeekDateOnDayOfWeek(DateTime refDate, int dayOfWeek, int direction,
                                                              bool matchingDOWReturnsRefDate)
        {
            // uses ..MostRecent.. or ..NextFuture.. methods above, whose Exceptions reference the "borrowed" method names.
            if (direction == -1)
                return GetMostRecentDateOnDayOfWeek(refDate, dayOfWeek, matchingDOWReturnsRefDate);
            else if (direction == 1)
                return GetNextFutureDateOnDayOfWeek(refDate, dayOfWeek, matchingDOWReturnsRefDate);
            else
                throw new Exception("Invalid direction parameter value passed to function DateUtils::GetAdjacentWeekDateOnDayOfWeek()");
        }

    }
}

/*  The following overload is not supported yet:
 public static DateTime GetMostRecentDateOnDayOfWeek(DateTime refDate, string dayOfWeek)
 {
    // Three string formats for a day of week would be supported, each listed Sunday thru Saturday below:
    // S M T W R F A
    // Sun Mon Tue Wed Thu Fri Sat
    // Sunday Monday Tuesday Wednesday Thursday Friday Saturday
    dayOfWeek = dayOfWeek.Trim().ToUpper();
    return DateTime.MinValue;
 }

*/
