using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class lifeUI : MonoBehaviour {

    [SerializeField] Slider slider;
    [SerializeField] PlantaHPBase hp;
    [SerializeField] GameObject padre;
    [SerializeField] Vector3 offSet;
    private Canvas canvas;
    private RectTransform rectTransform;
    private void Awake() {
        slider.maxValue = hp.ObtenrVidaMaxima();
        canvas = GetComponent<Canvas>();
         rectTransform = slider.GetComponent<RectTransform>();
    }
    private void Update() {
        slider.value = hp.ObtenrVidaActual();
        slider.transform.SetParent(canvas.transform);
        // Posicionar el Slider sobre el enemigo
        canvas.transform.position = padre.transform.position + offSet;
        canvas.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        // Obt�n el RectTransform del Slider

        // Cambia el tama�o del RectTransform
       // rectTransform.sizeDelta = new Vector2(100, 20);

    }




}
