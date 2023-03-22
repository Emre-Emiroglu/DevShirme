using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TimeHelper
{
    public const int DAY_AS_SECOND = 86400;
    static float time;

    public static double SubstractCurrent(string time, DateType dateType = DateType.Now)
    {
        DateTime timeDate = new DateTime();
        DateTime localDate = dateType == DateType.Now ? DateTime.Now : DateTime.UtcNow;

        DateTime.TryParse(time, out timeDate);

        double timeValue = TimeSpan.FromTicks(timeDate.Ticks).TotalSeconds;
        double currentVal = TimeSpan.FromTicks(localDate.Ticks).TotalSeconds;

        return (currentVal - timeValue);
    }

    public static DateTime ConvertToDateTime(string timeStr)
    {
        DateTime newDate = new DateTime();
        DateTime.TryParse(timeStr, out newDate);
        return newDate;
    }

    public static double Substract(string oldTime, string newTime)
    {
        DateTime newDate = new DateTime();
        DateTime oldDate = new DateTime();

        DateTime.TryParse(newTime, out newDate);
        DateTime.TryParse(oldTime, out oldDate);

        double old = TimeSpan.FromTicks(oldDate.Ticks).TotalSeconds;
        double now = TimeSpan.FromTicks(newDate.Ticks).TotalSeconds;

        return (now - old);
    }

    public static double Addition(string time, string addedTime)
    {
        DateTime newDate = new DateTime();
        DateTime oldDate = new DateTime();

        DateTime.TryParse(time, out newDate);
        DateTime.TryParse(addedTime, out oldDate);

        double click = TimeSpan.FromTicks(newDate.Ticks).TotalSeconds;
        double server = TimeSpan.FromTicks(oldDate.Ticks).TotalSeconds;

        return (server + click);
    }

    public static string AddTime(string clickTime, int timeStepAsSecond)
    {
        DateTime clickdate = new DateTime(0, DateTimeKind.Utc);
        string calculatedDate = "";

        DateTime.TryParse(clickTime, out clickdate);

        clickdate = clickdate.AddSeconds(timeStepAsSecond);
        calculatedDate = clickdate.ToString("yyyy/MM/dd HH:mm:ss");

        return calculatedDate;
    }
    public static string AddTime(string localTime, object nOTIFICATION_TIME_FREQ)
    {
        throw new NotImplementedException();
    }
    public static string GetLocalTimeAsString(DateType dateType = DateType.Now)
    {
        string result = "";

        DateTime now = dateType == DateType.Now ? DateTime.Now : DateTime.UtcNow;
        result = now.ToString("yyyy/MM/dd HH:mm:ss");

        return result;
    }
    public static DateTime GetLocalTime(DateType dateType = DateType.Now)
    {
        DateTime now = dateType == DateType.Now ? DateTime.Now : DateTime.UtcNow;
        return now;
    }
    public static int GetLocalTimeHour(DateType dateType = DateType.Now)
    {
        DateTime now = dateType == DateType.Now ? DateTime.Now : DateTime.UtcNow;
        return now.Hour;
    }
    public static string GetHourAsString(DateType dateType = DateType.Now)
    {
        DateTime now = dateType == DateType.Now ? DateTime.Now : DateTime.UtcNow;
        int h = now.Hour;
        string hourStr = "";

        if (h < 10)
        {
            hourStr = "0" + h;
        }
        else
        {
            hourStr = h.ToString();
        }

        return hourStr;
    }
    public static string GetHourSpaceAsString(DateType dateType = DateType.Now)
    {
        DateTime now = dateType == DateType.Now ? DateTime.Now : DateTime.UtcNow;
        int h1 = now.Hour;
        int h2 = h1 + 1;

        string hstr1 = "";
        string hstr2 = "";

        if (h1 < 10)
            hstr1 = "0" + h1;
        else
            hstr1 = h1.ToString();


        if (h2 < 10)
            hstr2 = "0" + h2;
        else
            hstr2 = h2.ToString();


        return hstr1 + "_" + hstr2;
    }
    public static void StartTimer()
    {
        time = Time.realtimeSinceStartup;
    }
    public static float StopTimer(string title = "")
    {
        float diff = Time.realtimeSinceStartup - time;
        Debug.Log(title + "TIME::" + diff);
        return diff;
    }
}

public enum DateType
{
    Now,
    UTCNow
}
