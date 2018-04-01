using Assets.Scripts.Unit;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Ownable))]
public class Selectable : MonoBehaviour, IPointerClickHandler {

    private Character unit;
    
    void Awake() {
        unit = GetComponentInParent<Character>();
    }

    public void OnPointerClick(PointerEventData eventData) {
        if(unit != null) Debug.Log(string.Format("Clicked {0} - {1}", unit.Type, unit.Name));
    }
}