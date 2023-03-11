//Score.cs:

using System;

namespace EternalQuest
{
    class Score
    {
        private int value;

        public int Value 
        { 
            get => value;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Score value cannot be negative");
                }

                this.value = value;
            }
        }

        public void Add(int _score)
        {
            if (_score < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(_score), "Points to add cannot be negative");
            }

            this.Value += _score;
        }
    }
}