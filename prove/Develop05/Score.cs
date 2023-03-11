// Score.cs
using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    class Score
    {
        private int _score;

        public int GetScore()
        {
            return _score;
        }

        public void AddPoints(int points)
        {
            _score += points;
        }
    }
}