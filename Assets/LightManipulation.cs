using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightManipulation : MonoBehaviour
{
    [SerializeField] Light2D light;
    [SerializeField] private Color nigthColor;
    [SerializeField] private Color dayColor;

    void Awake() {
        light.color = dayColor;
    }
    IEnumerator NigthCorrutine() {
        while (true) {
            light.color = Color.Lerp(nigthColor, dayColor, 2 * Time.deltaTime);
            yield return null;
        }
    }
    IEnumerator DayCorrutine() {
        while (true) {
            light.color = Color.Lerp(dayColor, nigthColor, 2 * Time.deltaTime);
            yield return null;
        }
    }
    public void nigthConfiguration() {
        StopAllCoroutines();
        StartCoroutine(NigthCorrutine());
    }
    public void dayConfiguration() {
        StopAllCoroutines();
        StartCoroutine(DayCorrutine());
    }
}
