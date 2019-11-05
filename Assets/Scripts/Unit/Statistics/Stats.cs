using System;
using UnityEngine;

namespace Unit.Statistics
{
    [Serializable]
    public class Stats
    {
        [SerializeField] private Resources resources = new Resources();
        [SerializeField] private Movement movement = new Movement();
        [SerializeField] private Combat combat = new Combat();
        [SerializeField] private Attributes attributes = new Attributes();
        [SerializeField] private Attunement attunement = new Attunement();

        public Resources Resources => resources;
        public Movement Movement => movement;
        public Combat Combat => combat;
        public Attributes Attributes
        {
            get => attributes;
            set => attributes = value;
        }

        public Attunement Attunement => attunement;
    }
}