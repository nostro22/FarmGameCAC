using TMPro;
using UnityEngine;

public class TextReplacer : MonoBehaviour
{
    public TextMeshProUGUI Text;

   [SerializeField] public BaseVariable Variable;

    public bool AlwaysUpdate;

    private void OnEnable() {

        Text.text = Variable.GetValue();
    }

    private void Update() {
        if (AlwaysUpdate) {
            Text.text = Variable.GetValue();
        }
    }
}
