using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatVariable : BaseVariable{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    public float Value;

    public void SetValue(float value) {
        Value = value;
    }

    public void SetValue(FloatVariable value) {
        Value = value.Value;
    }

    public void ApplyChange(float amount) {
        Value += amount;
    }

    public void ApplyChange(FloatVariable amount) {
        Value += amount.Value;
    }

    public override string GetValue() {
       return Value.ToString();
    }
}
