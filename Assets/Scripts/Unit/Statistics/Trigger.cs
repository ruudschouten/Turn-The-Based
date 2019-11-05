using System;
using Turn;
using UI;
using UnityEngine;

namespace Unit.Statistics
{
    [Serializable]
    public class Trigger
    {
        [SerializeField] private int gold;
        [SerializeField] private Resources resources;
        [SerializeField] private Attributes attributes;

        public void Activate(Stats stats, TurnManager manager, DamageUI ui)
        {
            if (gold != 0)
            {
                manager.CurrentPlayer.Gold.ChangeAmount(gold);
            }
            
            stats.Resources.Apply(resources, ui);
            stats.Attributes.Apply(attributes);
        }
    }
}