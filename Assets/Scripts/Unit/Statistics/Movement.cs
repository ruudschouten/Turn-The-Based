using System;
using UnityEngine;

namespace Unit.Statistics
{
    [Serializable]
    public class Movement
    {
        [SerializeField] private int move;
        [SerializeField] private int jump;

        public int Move
        {
            get => move;
            set => move = value;
        }

        public int Jump
        {
            get => jump;
            set => jump = value;
        }
    }
}