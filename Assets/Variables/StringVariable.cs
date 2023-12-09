
using UnityEngine;
[CreateAssetMenu]
public class StringVariable : BaseVariable
{
    [SerializeField]
    private string value = "";

    public string Value {
        get { return value; }
        set { this.value = value; }
    }

    public override string GetValue() {
        return this.value;
    }
}
