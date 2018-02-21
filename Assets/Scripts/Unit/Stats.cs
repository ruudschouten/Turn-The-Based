using Assets.Scripts.Battle;

namespace Assets.Scripts.Unit {
    public class Stats {
        //Movement related
        public int Move;
        public float Jump;
        //Attack related
        public int Range;
        public float Height;
        public float AttackCost;
        public float DamageModifier;
        public Element ElementOverride;
        public int AreaOfEffectSize;
        //Base Stats
        public int Health;
        public int Magic;
        public int Strength;
        public int Defense;
        public int Intelligence;
        public int Resistance;
        public int Precision;
        public int Agility;
        //Elemental Attunement
        public int FireAttunement;
        public int IceAttunement;
        public int WindAttunement;
    }
}
