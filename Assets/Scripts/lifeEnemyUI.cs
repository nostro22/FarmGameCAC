using UnityEngine;
using UnityEngine.UI;

public class lifeEnemyUI : MonoBehaviour {

    [SerializeField] Slider slider;
    [SerializeField] Enemy hp;
    [SerializeField] GameObject padre;
    [SerializeField] Vector3 offSet;
    private Canvas canvas;
    private RectTransform rectTransform;
    private void Awake() {
        slider.maxValue = hp.MaxHP;
        canvas = GetComponent<Canvas>();
         rectTransform = slider.GetComponent<RectTransform>();
    }
    private void Update() {
        slider.value = hp.health;
        slider.transform.SetParent(canvas.transform);
        // Posicionar el Slider sobre el enemigo
        canvas.transform.position = padre.transform.position + offSet;
        canvas.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        // Obtén el RectTransform del Slider

        // Cambia el tamaño del RectTransform
       // rectTransform.sizeDelta = new Vector2(100, 20);

    }




}
