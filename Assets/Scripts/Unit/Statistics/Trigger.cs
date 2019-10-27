using System;
using UnityEngine;

namespace Unit.Statistics
{
    [Serializable]
    public class Trigger
    {
        [SerializeField] private int gold;
        [SerializeField] private Resources resources;

        public int Gold => gold;
        public Resources Resources => resources;

        public void Activate(Stats stats, TurnManager manager)
        {
            if (Resources.Health != 0)
            {
                stats.Resources.Health += Resources.Health;
                if (stats.Resources.Health > stats.Resources.MaxHealth)
                {
                    stats.Resources.Health = stats.Resources.MaxHealth;
                }
            }

            if (Resources.Magic != 0)
            {
                stats.Resources.Magic += Resources.Magic;
                if (stats.Resources.Magic > stats.Resources.MaxMagic)
                {
                    stats.Resources.Magic = stats.Resources.MaxMagic;
                }
            }

            if (Gold != 0)
            {
                manager.CurrentPlayer.Gold.ChangeAmount(Gold);
            }
        }
    }
}