using System;
using System.Collections.Generic;

namespace Tools.Library.Analyzers.DateTime.Implementations
{
    internal class AdjustableDateTimeComparator : IComparer<System.DateTime>
    {
        private readonly System.DateTime _targetDateTime;

        private readonly bool _ignoreYear;
        private readonly bool _ignoreMonth;
        private readonly bool _ignoreDay;

        private readonly byte _yearWeight = 10;
        private readonly byte _monthWeight = 9;
        private readonly byte _dayWeight = 8;
        private readonly byte _hourWeight = 7;
        private readonly byte _minuteWeight = 6;
        private readonly byte _secondsWeight = 5;
        
        public AdjustableDateTimeComparator(System.DateTime targetDateTime)
        {
            _targetDateTime = targetDateTime;
        }

        public AdjustableDateTimeComparator(System.DateTime targetDateTime,
            bool ignoreYear = false, bool ignoreMonth = false, bool ignoreDay = false) : this(targetDateTime)
        {
            _ignoreYear = ignoreYear;
            _ignoreMonth = ignoreMonth;
            _ignoreDay = ignoreDay;
        }

        public int Compare(System.DateTime x, System.DateTime y)
        {
            byte scoreX = byte.MaxValue;
            byte scoreY = byte.MaxValue;
            
            changeScoreForValues(x.Hour, _targetDateTime.Hour, ref scoreX, _hourWeight);
            changeScoreForValues(x.Minute, _targetDateTime.Minute, ref scoreX, _minuteWeight);
            changeScoreForValues(x.Second, _targetDateTime.Second, ref scoreX, _secondsWeight);
            
            changeScoreForValues(y.Hour, _targetDateTime.Hour, ref scoreY, _hourWeight);
            changeScoreForValues(y.Minute, _targetDateTime.Minute, ref scoreY, _minuteWeight);
            changeScoreForValues(y.Second, _targetDateTime.Second, ref scoreY, _secondsWeight);

            if (!_ignoreYear)
            {
                changeScoreForValues(x.Year, _targetDateTime.Year, ref scoreX, _yearWeight);
                changeScoreForValues(y.Year, _targetDateTime.Year, ref scoreY, _yearWeight);
            }

            if (!_ignoreMonth)
            {
                changeScoreForValues(x.Month, _targetDateTime.Month, ref scoreX, _monthWeight);
                changeScoreForValues(y.Month, _targetDateTime.Month, ref scoreY, _monthWeight);
            }

            if (!_ignoreDay)
            {
                changeScoreForValues(x.Day, _targetDateTime.Day, ref scoreX, _dayWeight);
                changeScoreForValues(y.Day, _targetDateTime.Day, ref scoreY, _dayWeight);
            }

            if (scoreX > scoreY) return -1;
            if (scoreY > scoreX) return 1;

            return 0;
        }
        
        private void changeScoreForValues(int checkValueA, int targetValueB, ref byte score, byte weight)
        {
            if (checkValueA != targetValueB)
                score -= weight;
        }
    }
}