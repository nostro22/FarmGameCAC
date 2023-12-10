using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

public class Cronometre : MonoBehaviour {
    private float tiempoRestante;
    public StringVariable tiempoUI;
    public StringVariable tiempoCiclo;
    public StringReference actualCicle;
    public bool esDeDia;
    public UnityEvent StartDay;
    public UnityEvent StartNight;
    public int cantidadDeDias;
    public int cantidadDeNoches;

    [SerializeField] private EnemySpawner enemySpawner;
    
    // Start is called before the first frame update
    void Start() {
        cantidadDeDias = cantidadDeNoches = 0;
        tiempoRestante = float.Parse(tiempoCiclo.Value);
        //Debug.Log(tiempoRestante);
        StartDay.Invoke();
        Debug.Log("Invoque día.");
    }

    public void TimeJump() {
        StartNight.Invoke();
        cantidadDeNoches++;
        esDeDia = false;
        tiempoRestante = 0;
    }

    // Update is called once per frame
    void Update() {
        if (esDeDia) {
            tiempoRestante = (float)tiempoRestante - Time.deltaTime;
            tiempoUI.Value = tiempoRestante.ToString();

            if (tiempoRestante <= 0) {
                StartNight.Invoke();
                cantidadDeNoches++;
                esDeDia = false;
            }
        }

        if (!esDeDia && enemySpawner!=null && enemySpawner.cantidadRestante == 0) {
            tiempoRestante = 0;
            StartDay.Invoke();
            cantidadDeDias++;
            esDeDia = true;
        }
    }
}
