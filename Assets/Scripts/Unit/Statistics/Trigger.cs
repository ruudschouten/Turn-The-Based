using System;
using UnityEngine;

namespace Unit.Statistics
{
    [Serializable]
    public class Trigger
    {
        [SerializeField] private int gold;
        [SerializeField] private Resources resources;
        [SerializeField] private Attributes attributes;

        public int Gold => gold;
        public Resources Resources => resources;
        public Attributes Attributes => attributes;

        public void Activate(Stats stats, TurnManager manager)
        {
            if (Math.Abs(Resources.Health) > 0)
            {
                stats.Resources.Health += Resources.Health;
                if (stats.Resources.Health > stats.Resources.MaxHealth)
                {
                    stats.Resources.Health = stats.Resources.MaxHealth;
                }
            }

            if (Math.Abs(Resources.Magic) > 0)
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

            stats.Attributes.Apply(attributes);
        }
    }
}