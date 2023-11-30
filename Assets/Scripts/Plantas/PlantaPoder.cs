using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantaPoder : MonoBehaviour
{
    [SerializeField] private PlantaCiclo plantaCiclo; //Consigo el script de ciclo de esta instancia.
    [SerializeField] private int poderTotal;
    private int etapa;
    private int poderActual; //Determina el nivel de su poder de ataque, defensa, o de dar salud.
    private int[] divisores;

    // Start is called before the first frame update
    void Start()
    {
        divisores = new int[4];
        divisores[0] = poderTotal;
        divisores[1] = 4;
        divisores[2] = 2;
        divisores[3] = 1;

        etapa = plantaCiclo.etapa;
        poderActual = poderTotal / divisores[etapa];
        Debug.Log("No hace nada.");
    }

    // Update is called once per frame
    public void poder()
    {
        etapa = plantaCiclo.etapa; //Guardo la etapa del script de ciclo.

        poderActual = poderTotal / divisores[etapa];

        Debug.Log("Tiene un poder de " + poderActual + ".");
    }
}
