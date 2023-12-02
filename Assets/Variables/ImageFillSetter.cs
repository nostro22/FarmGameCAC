using UnityEngine.UI;
using UnityEngine;

public class ImageFillSetter : MonoBehaviour
{
    [Tooltip("Value to use as the current ")]
    public FloatReference Variable;

    [Tooltip("Min value that Variable to have no fill on Image.")]
    public FloatReference Min;

    [Tooltip("Max value that Variable can be to fill Image.")]
    //public FloatReference Max;
    public FloatVariable Max; //Usar la variable de PlantHealth, que contiene la vida máxima total de las plantas de vida, es decir, la vida total del jugador.

    [Tooltip("Image to set the fill amount on.")]
    public Image Image;

    private void Update() {
        Image.fillAmount = Mathf.Clamp01(
            Mathf.InverseLerp(Min, Max.Value, Variable));
    }
}
