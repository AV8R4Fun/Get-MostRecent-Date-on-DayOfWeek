### README
# Get-MostRecent-Date-on-DayOfWeek

.NET C# utility/helper function: Computes a new date that is on a given day of the week, relative to a reference date.
---
Copyright (c) 2011-2020  Rich Giordano / Global Software Society

### GPL-3.0-or-later

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see (https://www.gnu.org/licenses/).
---

This .NET Win console project is a demo container, part of the much broader
GssUtilsLib library, a collection of various .NET utility functions for C#.
This contains only one of the GssUtilsLib classes, namely, DateUtils, and only
contains this subset of the class to demonstrate its functionality.
It was originally written in 2002 using Microsoft .NET v2, then two years later
upgraded to v3.5

The function takes as primary arguments a reference date and a day of week.

_Example 1:_

Reference date = April 20, 2011.  This date happened to fall on a Wednesday.
E.g., the operator wishes to find the most recent date, relative to that
reference date, that falls on a Thursday.

The DateTime variable 'd' contains the date 4/20/2011. Here is the method call:
```
  DateTime x;
  x = DateUtils.GetMostRecentDateOnDayOfWeek(d, System.DayOfWeek.Thursday);
```
Returns the date 4/14/2011, which falls on a Thursday.

The method also accepts an integer for the day of week:<br />
  a value from 0 through 6 representing Sunday through Saturday, respectively.

What if the operator wishes to find the most recent date that falls on a
Wednesday.  Which Wednesday?  The reference date itself is a Wednesday.  Should
it include that same reference date, or skip back to the prior Wednesday?
The answer is The operator has a choice; There is an optional boolean parameter
 'matchingDOWReturnsRefDate' that handles this. It defaults to false.
```
  int w = 4;  // in place of System.DayOfWeek.Wednesday
  x = DateUtils.GetMostRecentDateOnDayOfWeek(d, w, true);  // returns 4/20/2011
  x = DateUtils.GetMostRecentDateOnDayOfWeek(d, w, false); // returns 4/13/2011
  x = DateUtils.GetMostRecentDateOnDayOfWeek(d, w);        // returns 4/13/2011
```
Even though this project name includes "Get Most Recent...", other functions
are included to get the Next Future date on a given day of the week. The method
call and concept is similar.

_Example 2, using the same reference date variable 'd' and value above:_
```
  int tue = 2; 
  x = DateUtils.GetNextFutureDateOnDayOfWeek(d, tue);  // returns 4/26/2011
```
Finally, there is another function form that allows getting either the Most
Recent or the Next Future date by specifying an integer parameter to indicate
which direction: a -1 for Most Recent or a 1 for Next Future.  In this form,
the boolean 'matchingDOWReturnsRefDate' parameter is required and the
'dayOfWeek' parameter allows only an integer.

_Example 3, using the same reference date variable 'd' and value above:_
```
  int dir = 1;  // Next Future date
  int fri = (int)System.DayOfWeek.Friday;
  x = DateUtils.GetAdjacentWeekDateOnDayOfWeek(d, fri, dir, false);
   // returns 4/22/2011
```
---
