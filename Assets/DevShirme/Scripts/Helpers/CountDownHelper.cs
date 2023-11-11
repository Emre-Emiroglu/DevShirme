using UnityEngine;
using TMPro;
using System;
using DevShirme.Utils.Enums;

namespace DevShirme.Helpers
{
    public class CountDownHelper
    {
        #region Fields
        private Enums.CountDownFormatting countDownFormatting;
        private bool showMilliSeconds;
        private double countDownTime;
        private TMP_Text countDownText;
        private double countdownInternal;
        private bool countDownOver;
        #endregion

        #region Getters
        public double CountDownInternal => countdownInternal;
        private string formatTime(double time, Enums.CountDownFormatting formatting, bool includeMilliseconds)
        {
            string timeText = "";

            int intTime = (int)time;
            int days = intTime / 86400;
            int hoursTotal = intTime / 3600;
            int hoursFormatted = hoursTotal % 24;
            int minutesTotal = intTime / 60;
            int minutesFormatted = minutesTotal % 60;
            int secondsTotal = intTime;
            int secondsFormatted = intTime % 60;
            int milliseconds = (int)(time * 100);
            milliseconds = milliseconds % 100;

            if (includeMilliseconds)
            {
                if (formatting == Enums.CountDownFormatting.DaysHoursMinutesSeconds)
                {
                    timeText = string.Format("{0:00}:{1:00}:{2:00}:{3:00}:{4:00}", days, hoursFormatted, minutesFormatted, secondsFormatted, milliseconds);
                }
                else if (formatting == Enums.CountDownFormatting.HoursMinutesSeconds)
                {
                    timeText = string.Format("{0:00}:{1:00}:{2:00}:{3:00}", hoursTotal, minutesFormatted, secondsFormatted, milliseconds);
                }
                else if (formatting == Enums.CountDownFormatting.MinutesSeconds)
                {
                    timeText = string.Format("{0:00}:{1:00}:{2:00}", minutesTotal, secondsFormatted, milliseconds);
                }
                else if (formatting == Enums.CountDownFormatting.Seconds)
                {
                    timeText = string.Format("{0:00}:{1:00}", secondsTotal, milliseconds);
                }
            }
            else
            {
                if (formatting == Enums.CountDownFormatting.DaysHoursMinutesSeconds)
                {
                    timeText = string.Format("{0:00}:{1:00}:{2:00}:{3:00}", days, hoursFormatted, minutesFormatted, secondsFormatted);
                }
                else if (formatting == Enums.CountDownFormatting.HoursMinutesSeconds)
                {
                    timeText = string.Format("{0:00}:{1:00}:{2:00}", hoursTotal, minutesFormatted, secondsFormatted);
                }
                else if (formatting == Enums.CountDownFormatting.MinutesSeconds)
                {
                    timeText = string.Format("{0:00}:{1:00}", minutesTotal, secondsFormatted);
                }
                else if (formatting == Enums.CountDownFormatting.Seconds)
                {
                    timeText = string.Format("{0:00}", secondsTotal);
                }
            }

            return timeText;
        }
        #endregion

        #region Constructor
        public CountDownHelper(Enums.CountDownFormatting countDownFormatting, bool showMilliSeconds, double countDownTime, TMP_Text countDownText)
        {
            this.countDownFormatting = countDownFormatting;
            this.showMilliSeconds = showMilliSeconds;
            this.countDownTime = countDownTime;
            this.countDownText = countDownText;
            this.countdownInternal = this.countDownTime;
            this.countDownOver = false;
        }
        #endregion

        #region Executes
        public void ExternalUpdate(Action OnCountDownEnded = null)
        {
            if (countdownInternal > 0)
            {
                countdownInternal -= Time.deltaTime;
                if (countdownInternal < 0)
                {
                    countdownInternal = 0;
                    OnCountDownEnded?.Invoke();
                }
                countDownText.SetText(formatTime(countdownInternal, countDownFormatting, showMilliSeconds));
            }
            else
            {
                if (!countDownOver)
                {
                    countDownOver = true;

                    Debug.Log("Countdown has finished running...");
                }
            }
        }
        #endregion
    }
}
