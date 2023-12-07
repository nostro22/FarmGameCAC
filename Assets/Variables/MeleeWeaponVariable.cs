using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MeleeWeaponVariable : ScriptableObject {
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    [SerializeField] private string name;
    [SerializeField] private float hitDuration;
    [SerializeField] private float coolDown;
    [SerializeField] private Vector2 colliderScale;
    [SerializeField] private Sprite icon;
    [SerializeField] private int price;
    [SerializeField] private float damage;

    public string Name {
        get { return name; }
        set { name = value; }
    }
    public float Damage {
        get { return damage; }
         set { damage = value; }
    }
    public Vector2 ColliderScale {
        get { return colliderScale; }
        set { colliderScale = value; }
    }
    public float HitDuration {
        get { return hitDuration; }
        set { hitDuration = value; }
    }
    public float CoolDown {
        get { return coolDown; }
        set { coolDown = value; }
    }

    public Sprite Icon {
        get { return icon; }
        set { icon = value; }
    }

    public int Price {
        get { return price; }
        set { price = value; }
    }

    public void ChangeValues(MeleeWeaponVariable other) {
        this.Name = other.Name;
        this.Damage = other.Damage;
        this.ColliderScale = other.ColliderScale;
        this.HitDuration = other.HitDuration;
        this.CoolDown = other.CoolDown;
        this.Icon = other.Icon;
        this.Price = other.Price;
    }
}
