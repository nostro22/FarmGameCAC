using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantaAnimacion : MonoBehaviour
{
    [SerializeField] private Animator plantaAnimator; //Consigo el animator de esta instancia.
    [SerializeField] private PlantaCiclo plantaCiclo; //Consigo el script de ciclo de esta instancia.
    private int etapa;

    public void dia() //Si el script Cronometre dice que es de día...
    {
        etapa = plantaCiclo.etapa; //Guardo la etapa del script de ciclo.

        switch (etapa){
            case 1:
                plantaAnimator.SetBool("Etapa 1", true); //Activo la transición entre animaciones.
                //Debug.Log("animacion: 1");
                break;
            case 2:
                plantaAnimator.SetBool("Etapa 2", true);
                //Debug.Log("animacion: 2");
                break;
            case 3:
                plantaAnimator.SetBool("Etapa 3", true);
                //Debug.Log("animacion: 3");
                break;
            default:
                //Debug.Log("animacion: default");
                break;
        }
    }
}
