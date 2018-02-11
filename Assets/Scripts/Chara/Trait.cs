﻿using UnityEngine;

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
        public int HealthAddition;
        public int SpecialAddition;
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
        //Misc
        public int GoldAddition;
        #endregion
        #region Multipliers
        //Movement related
        public float MoveMultiplier;
        public float JumpMultiplier;
        //Base Stats
        public float HealthMultiplier;
        public float SpecialMultiplier;
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
        //Misc
        public float GoldMultiplier;
        #endregion
    }
}
