using System;

[Serializable]
public class ResourceCost {
    public Resource Resource;
    public int Cost;

    public bool CanAfford() {
        return Resource.CanAfford(Cost);
    }

    public void Pay() {
        Resource.ChangeAmount(-Cost);
    }
}