﻿using System;

namespace SmartSaver.Domain.Services.SavingMethodSuggestion
{
    public struct DateCounter
    {
        /// <summary>
        /// shows how many days left until goal
        /// </summary>
        public static int DaysLeft(DateTime goalEndDate)
        {
            return (int)Math.Ceiling(goalEndDate.Subtract(DateTime.Now).TotalDays);
        }

        /// <summary>
        /// a dynamic number which represents how many days have passed since account started to save
        /// </summary>
        public static decimal DaysPassed(DateTime goalStartDate)
        {
            return (decimal)DateTime.Now.Subtract(goalStartDate).TotalDays;
        }

        /// <summary>
        /// a static number to represent a goal time in days
        /// </summary>
        public static decimal GoalTimeInDays(DateTime goalStartDate, DateTime goalEndDate)
        {
            return (decimal)Math.Ceiling(goalEndDate.Subtract(goalStartDate).TotalDays);
        }

        /// <summary>
        /// returns remaining days until the end of a month
        /// </summary>
        public static int DaysUntilMonthEnd(DateTime goalStartDate, DateTime goalEndDate)
        {
            if (DateTime.Now.Year == goalEndDate.Year && DateTime.Now.Month == goalEndDate.Month)
            {
                return goalEndDate.Day;
            }

            else if (DateTime.Now.Year == goalStartDate.Year && DateTime.Now.Month == goalStartDate.Month)
            {
                return DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) - goalStartDate.Day + 1;
            }

            else
            {
                return DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            }
        }

        /// <summary>
        /// a dynamic number which represents how many months have passed since account started to save
        /// </summary>
        public static decimal MonthsPassed(DateTime goalStartDate)
        {
            return (DateTime.Now.Month - goalStartDate.Month) + 12 * (DateTime.Now.Year - goalStartDate.Year) + 1;
        }
    }
}