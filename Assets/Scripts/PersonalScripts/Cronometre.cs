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
    public bool ResetTiempo;
    public UnityEvent StartDay;
    public UnityEvent StartNight;
    
    // Start is called before the first frame update
    void Start() {
        tiempoRestante = float.Parse(tiempoCiclo.Value);
        //Debug.Log(tiempoRestante);
        StartDay.Invoke();
        Debug.Log("Invoque día.");
    }

    // Update is called once per frame
    void Update() {
        tiempoRestante = (float)tiempoRestante - Time.deltaTime;
        tiempoUI.Value = tiempoRestante.ToString();

        if (tiempoRestante <= 0) {
            ResetTiempo = !ResetTiempo;
            tiempoRestante = float.Parse(tiempoCiclo.Value);

            if (ResetTiempo) {
                StartNight.Invoke();
                Debug.Log("Invoque noche.");
            }
            else {
                StartDay.Invoke();
                Debug.Log("Invoque día.");
            }

            /*print("calor" + actualCicle.Value);
            if (actualCicle.Value =="Dia") {
                tiempoRestante = float.Parse(tiempoCiclo.Value);
                print("invoque noche");
                StartNigth.Invoke();
            } else {
                tiempoRestante = float.Parse(tiempoCiclo.Value);
                print("invoque dia");
                StartDay.Invoke();
            }*/
        }
    }
}

   