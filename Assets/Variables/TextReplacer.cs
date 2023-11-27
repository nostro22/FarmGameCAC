using TMPro;
using UnityEngine;

public class TextReplacer : MonoBehaviour
{
    public TextMeshProUGUI Text;

    public StringVariable Variable;

    public bool AlwaysUpdate;

    private void OnEnable() {
        Text.text = Variable.Value;
    }

    private void Update() {
        if (AlwaysUpdate) {
            Text.text = Variable.Value;
        }
    }
}
