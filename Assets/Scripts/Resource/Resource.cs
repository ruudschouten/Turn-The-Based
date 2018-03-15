using UnityEngine;
using UnityEngine.Events;


public class Resource : MonoBehaviour {
    public string Name;
    public int Amount;
    public int InitialAmount;

    public UnityEvent OnValueChanged;

    private void Awake() {
        Amount = InitialAmount;
    }

    public void ChangeAmount(int amount) {
        Amount += amount;
        OnValueChanged.Invoke();
    }

    public bool CanAfford(int cost) {
        return Amount >= cost;
    }
}