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
        public int MaxHealth;
        public int MaxMagic;
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

        public string PrintResources() {
            return string.Format("HP:\t\t\t{0}/{1}\nMP:\t\t\t{2}/{3}",
                Health, MaxHealth, Magic, MaxMagic);
        }
        
        public string PrintBaseStats() {
            return string.Format("STR:\t\t\t{0}\nDEF:\t\t\t{1}\nINT:\t\t\t{2}\n" +
                          "RES:\t\t\t{3}\nPRC:\t\t\t{4}\nAGI:\t\t\t{5}",
                Strength, Defense, Intelligence, Resistance, Precision, Agility);
        }
    }
}