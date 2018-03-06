using Assets.Scripts.Battle;
using UnityEngine;

namespace Assets.Scripts.Unit {
    public class Trait : MonoBehaviour {
        public string Name;
        public string Description;

        #region Toggles
        public bool AllowDiagonal;
        public bool DisallowStraight;
        #endregion
        #region AfterHit
        public int HealthOnHit;
        public int MagicOnHit;
        #endregion
        #region AfterKill
        public int HealthOnKill;
        public int MagicOnKill;
        #endregion
        #region Additions
        //Movement related
        public int MoveAddition;
        public float JumpAddition;
        //Attack related
        public int RangeAddition;
        public int AttackCostAddition;
        public float DamageModifierAddition;
        public int AreaOfEffectSizeAddition;
        //Base Stats
        public int HealthAddition;
        public int MagicAddition;
        public int StrengthAddition;
        public int DefenseAddition;
        public int IntelligenceAddition;
        public int ResistanceAddition;
        public int PrecisionAddition;
        public int AgilityAddition;
        //Elemental Resists
        public int FireAttunementAddition;
        public int IceAttunementAddition;
        public int WindAttunementAddition;
        #endregion
        #region Multipliers
        //Movement related
        public float MoveMultiplier;
        public float JumpMultiplier;
        //Attack related
        public float RangeMultiplier;
        public float AttackCostMultiplier;
        public float DamageModifierMultiplier;
        public float AreaOfEffectSizeMultiplier;
        public Element ElementOverride;
        //Base Stats
        public float HealthMultiplier;
        public float MagicMultiplier;
        public float StrengthMultiplier;
        public float DefenseMultiplier;
        public float IntelligenceMultiplier;
        public float ResistanceMultiplier;
        public float PrecisionMultiplier;
        public float AgilityMultiplier;
        //Elemental Resists
        public float FireAttunementMultiplier;
        public float IceAttunementMultiplier;
        public float WindAttunementMultiplier;
        #endregion
    }
}
