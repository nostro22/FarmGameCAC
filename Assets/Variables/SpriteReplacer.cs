using UnityEngine;
using UnityEngine.UI;

public class SpriteReplacer : MonoBehaviour {

    public Image ImageRef ;

    public ImageVariable Variable;

    public bool AlwaysUpdate;

    private void Awake() {
        ImageRef = GetComponent<Image>();
    }

    private void OnEnable() {
        if (ImageRef != null) {
            ImageRef.sprite = Variable.Value;
        }
    }

    private void Update() {
        if (AlwaysUpdate && ImageRef != null) {
            ImageRef.sprite = Variable.Value;
        }
    }
}
