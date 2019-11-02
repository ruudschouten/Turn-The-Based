using System;
using UnityEngine;

[Serializable]
public class ResourceCost
{
    [SerializeField] private Resource resource;
    [SerializeField] private int cost;

    public bool CanAfford()
    {
        return resource.CanAfford(cost);
    }

    public void Pay()
    {
        resource.ChangeAmount(-cost);
    }
}