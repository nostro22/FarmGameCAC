using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemVariable : ScriptableObject {
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    [SerializeField]  private int cantity;
    [SerializeField] private string name;
    [SerializeField] private Sprite icon;
    [SerializeField] private int price;

    public int Cantity {
        get { return cantity; }
        set { cantity = value; }
    }

    public string Name {
        get { return name; }
        set { name = value; }
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
