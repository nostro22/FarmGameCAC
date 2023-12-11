using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantaCiclo : MonoBehaviour
{
    public int etapa;

    // Start is called before the first frame update
    void Start()
    {
        etapa = 0; //Inicia con la etapa 0, sería la semilla.
    }

    public void dia() {
        if (etapa <= 4) { //De momento sólo hay 4 etapas.
            etapa++; //Suma una etapa al inicio del día.
        }
    }

    public void noche() { //De momento avisa que es de noche, tal vez no sirva de nada.
    }
}
