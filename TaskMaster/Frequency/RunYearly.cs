﻿/*
Copyright 2017 James Craig
Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
    http://www.apache.org/licenses/LICENSE-2.0
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using BigBook;
using System;
using TaskMaster.Interfaces;

namespace TaskMaster.Frequency
{
    /// <summary>
    /// Runs a task yearly
    /// </summary>
    /// <seealso cref="IFrequency"/>
    public class RunYearly : IFrequency
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RunYearly"/> class.
        /// </summary>
        /// <param name="dayOfYear">The day of year.</param>
        public RunYearly(int dayOfYear)
        {
            DayOfYear = dayOfYear;
        }

        /// <summary>
        /// Gets the day of month.
        /// </summary>
        /// <value>The day of month.</value>
        public int DayOfYear { get; private set; }

        /// <summary>
        /// Determines whether this instance can run based on the specified last run.
        /// </summary>
        /// <param name="lastRun">The last run.</param>
        /// <param name="currentTime">The current time.</param>
        /// <returns>True if it can, false otherwise</returns>
        public bool CanRun(DateTime lastRun, DateTime currentTime)
        {
            var RunAfterDate = currentTime.BeginningOf(TimeFrame.Year).AddDays(DayOfYear - 1);
            return lastRun < RunAfterDate && currentTime >= RunAfterDate;
        }
    }
}