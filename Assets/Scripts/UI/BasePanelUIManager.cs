using System.Collections.Generic;
using Assets.Scripts.Unit;
using UnityEngine;

namespace UI {
    public class BasePanelUIManager {
        public GameObject PanelParent;
        public GameObject UnitPanel;
        
        public void ShowUnitList(List<Character> units) {
            Debug.Log("I am showing the unit lists");
        }

        public void WithdrawUnit() {
            
        }

        public void DepositUnit() {
            
        }

        public void Hide() {
            
        }
    }
}