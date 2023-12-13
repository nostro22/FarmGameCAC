using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemVariable : ScriptableObject {
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    [SerializeField] private int quantity;
    [SerializeField] private string myName;
    [SerializeField] private Sprite icon;
    [SerializeField] private int price;

    public int Quantity {
        get { return quantity; }
        set { quantity = value; }
    }

    public string Name {
        get { return myName; }
        set { myName = value; }
    }

    public Sprite Icon {
        get { return icon; }
        set { icon = value; }
    }

    public int Price {
        get { return price; }
        set { price = value; }
    }
}
