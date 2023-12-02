using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantaOro : MonoBehaviour
{
    [SerializeField] private PlantaCiclo plantaCiclo; //Consigo el script de ciclo de esta instancia.
    [SerializeField] private int oroTotal;
    private int etapa;
    private int oroADevolver;
    private int[] divisores;
    public bool dead;

    [SerializeField] private FloatVariable oro;

    void Awake()
    {
        dead = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        divisores = new int[4];
        divisores[0] = oroTotal;
        divisores[1] = 4;
        divisores[2] = 2;
        divisores[3] = 1;
        Debug.Log("ORO");
    }

    // Update is called once per frame
    void Update()
    {
        if (dead) { //Si la planta muere, devuelve el oro correspondiente según su nivel. ¿Ver de vincular con un scriptable object de oro?
            etapa = plantaCiclo.etapa; //Guardo la etapa del script de ciclo.

            oroADevolver = oroTotal / divisores[etapa];

            if (oroADevolver == 1) {
                Debug.Log("Devolver semilla.");
            } else {
                Debug.Log("Devolver " + oroADevolver + " monedas de oro.");
                oro.ApplyChange(oroADevolver);
            }

            Destroy(gameObject);
        }
    }
}
