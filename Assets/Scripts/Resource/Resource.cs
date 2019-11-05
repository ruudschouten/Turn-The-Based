using UnityEngine;
using UnityEngine.Events;


public class Resource : MonoBehaviour
{
    public string Name;
    [SerializeField] private int amount;
    [SerializeField] private int initialAmount;

    [SerializeField] private UnityEvent onValueChanged;

    public int Amount => amount;
    public UnityEvent OnValueChanged => onValueChanged;

    private void Awake()
    {
        amount = initialAmount;
    }

    public void ChangeAmount(int amount)
    {
        this.amount += amount;
        onValueChanged.Invoke();
    }

    public bool CanAfford(int cost)
    {
        return amount >= cost;
    }

    public bool Purchase(int cost)
    {
        if (!CanAfford(cost)) return false;
        ChangeAmount(-cost);
        return true;
    }
}