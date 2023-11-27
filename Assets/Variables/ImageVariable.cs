using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class ImageVariable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    public Sprite Value;

    public void SetValue(Sprite value) {
        Value = value;
    }
    public Sprite GetValue(Sprite value) {
        return Value;
    }

    public void SetValue(ImageVariable value) {
        Value = value.Value;
    }

}
