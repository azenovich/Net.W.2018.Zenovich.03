﻿using NET.W._2018.Zenovich._03.API;
using System;

namespace NET.W._2018.Zenovich._03.Model
{
    /// <summary>
    /// Is base class for calculation gcd and time span.
    /// </summary>
    public abstract class TimerGcd : IGcd
    {
        protected ITimer _timer;

        public TimerGcd()
        {
            _timer = new Timer();
        }

        public TimerGcd(ITimer timer)
        {
            _timer = timer ?? throw new ArgumentNullException(nameof(timer));
        }

        public TimeSpan CompletionTime
        {
            get
            {
                return _timer.GetTimeSpan();
            }
        }

        /// <summary>
        /// Implementations binary gcd algorithm for several parameters.
        /// </summary>
        /// <param name="numbers">The number array will be used in gcd calculation.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="numbers"/> is equal null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Count of <paramref name="numbers"/> should be more than 2.
        /// </exception>
        public int CalculateGcd(params int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            if (numbers.Length < 2)
            {
                throw new ArgumentException("Count of numbers should be more than 2");
            }

            int result;

            _timer.Start();
            try
            {
                result = ModelNumbersGcd(numbers);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _timer.Stop();
            }

            return result;
        }

        protected virtual int ModelNumbersGcd(int[] numbers)
        {
            int length = numbers.Length, result = 0;

            result = CalculateGcd(numbers[0], numbers[1]);

            if (length == 2)
            {
                return result;
            }

            for (int i = 2; i < length; i++)
            {
                result = CalculateGcd(numbers[i], result);
            }

            return result;
        }

        protected abstract int CalculateGcd(int left, int right);
    }
}
