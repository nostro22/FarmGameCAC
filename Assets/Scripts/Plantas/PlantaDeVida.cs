using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantaDeVida : MonoBehaviour
{
    [SerializeField] private PlantaCiclo plantaCiclo; //Consigo el script de ciclo de esta instancia.
    [SerializeField] private PlantaPoder plantaPoder;
    public FloatVariable HP;
    private int etapa;

    // Start is called before the first frame update
    void Start()
    {
        etapa = plantaCiclo.etapa;
    }

    // Update is called once per frame
    public void vida()
    {
        etapa = plantaCiclo.etapa;
        if (etapa <= 3) {
            HP.ApplyChange(+plantaPoder.poderActual); //Actualiza el valor de la vida de la planta segun el nivel de poder.
            Debug.Log("Tiene una vida de " + HP.Value + ".");
        }
    }
}
