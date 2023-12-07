using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChangeEquipment : MonoBehaviour
{
    [SerializeField] private MeleeWeaponVariable WeaponSlotRef;
    [SerializeField] private MeleeWeaponVariable NewWeaponToEquip;
    public UnityEvent OnMeleeEquipmentChange;


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
        this.WeaponSlotRef.ChangeValues(this.NewWeaponToEquip); 
        OnMeleeEquipmentChange.Invoke();
        }
    }


}
