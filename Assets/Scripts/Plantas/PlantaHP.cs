using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlantaHP : MonoBehaviour
{
    [SerializeField] private float HP;

    public bool ResetHP;
    public FloatReference StartingHP;
    public UnityEvent DamageEvent;
    public UnityEvent DeathEvent;

    private float totalHP;
    
    [SerializeField] private PlantaCiclo plantaCiclo; //Consigo el script de ciclo de esta instancia.
    private int etapa;

    [SerializeField] public bool dead;

    [SerializeField] private PlantaPoder plantaPoder;

    [SerializeField] private FloatVariable playerHealth; //Salud del jugador.
    [SerializeField] private FloatVariable plantHealth; //Total de salud máxima de todas las plantas de vida.

    private void Awake() {
        dead = false;
    }

    private void Start() {
        if (ResetHP) { //Inicializa la vida de la planta y le suma el valor a la variable de vida total de las plantas de vida, y a la variable de vida del jugador.
            HP = StartingHP.Value;
            playerHealth.ApplyChange(HP);
            plantHealth.ApplyChange(HP);
            totalHP = StartingHP.Value;
        }
        
        etapa = plantaCiclo.etapa;
    }

    private void Update() {
        if (dead && HP > 0) {
            playerHealth.ApplyChange(-HP);
            plantHealth.ApplyChange(-totalHP);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        print("colisiono");
        DamageDealer damage = other.gameObject.GetComponent<DamageDealer>();
        if (damage != null) {
            HP -= damage.DamageAmount; //Daño aplicado a la propia planta.
            playerHealth.ApplyChange(-damage.DamageAmount); //Daño aplicado al jugador.
            DamageEvent.Invoke();
        }

        if (HP <= 0) {
            dead = true; //La planta muere.
            DeathEvent.Invoke();
        }
    }

    public void plantaVida()
    {
        etapa = plantaCiclo.etapa;
        if (etapa <= 3) { //Actualiza la vida de la planta y del jugador.
            HP += plantaPoder.poderActual;
            playerHealth.ApplyChange(plantaPoder.poderActual);
            plantHealth.ApplyChange(plantaPoder.poderActual);
            totalHP += plantaPoder.poderActual;
            Debug.Log("Tiene una vida de " + HP + ".");
        }
    }
}
