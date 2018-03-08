using UnityEngine;
using UnityEngine.Events;

namespace Resource {
    public class Resource : MonoBehaviour {
        public string Name;
        public int Amount;

        public UnityEvent OnValueChanged;

        public void ChangeAmount(int amount) {
            Amount += amount;
            OnValueChanged.Invoke();
        }
    }
}