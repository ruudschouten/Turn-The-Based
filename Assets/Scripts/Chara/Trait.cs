using UnityEngine;

namespace Assets.Scripts.Chara {
    public class Trait : MonoBehaviour {
        public string Name;
        public string Description;

        #region Toggles
        public bool AllowDiagonal;
        public bool DisallowStraight;
        #endregion
        #region AfterHit
        public int HealthOnHit;
        public int SpecialOnHit;
        public int GoldOnHit;
        #endregion
        #region AfterKill
        public int HealthOnKill;
        public int SpecialOnKill;
        public int GoldOnKill;
        #endregion
        #region Additions
        //Movement related
        public int MoveAddition;
        public float JumpAddition;
        //Base Stats
        public int HealthPointsAddition;
        public int SpecialPointsAddition;
        public int AttackAddition;
        public int DefenseAddition;
        public int IntelligenceAddition;
        public int ResistanceAddition;
        public int HitAddition;
        public int SpeedAddition;
        //Elemental Resists
        public int FireAffinityAddition;
        public int IceAffinityAddition;
        public int WindAffinityAddition;
        //Misc
        public int GoldAddition;
        #endregion
        #region Multipliers
        //Movement related
        public float MoveMultiplier;
        public float JumpMultiplier;
        //Base Stats
        public float HealthPointsMultiplier;
        public float SpecialPointsMultiplier;
        public float AttackMultiplier;
        public float DefenseMultiplier;
        public float IntelligenceMultiplier;
        public float ResistanceMultiplier;
        public float HitMultiplier;
        public float SpeedMultiplier;
        //Elemental Resists
        public float FireAffinityMultiplier;
        public float IceAffinityMultiplier;
        public float WindAffinityMultiplier;
        //Misc
        public float GoldMultiplier;
        #endregion
    }
}
