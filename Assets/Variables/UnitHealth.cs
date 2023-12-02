using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitHealth : MonoBehaviour
{
    public FloatVariable HP;
    public FloatVariable startingPlantaHP;

    public bool ResetHP;
    [SerializeField] private FloatReference StartingHP;
    public UnityEvent DamageEvent;
    public UnityEvent DeathEvent;

    private void Start() {
        if (ResetHP) { //Inicia el valor de la salud del jugador y el valor total de la salud de las plantas de vida en 0.
            startingPlantaHP.SetValue(StartingHP.Value);
            HP.SetValue(StartingHP.Value);
        }
    }

    //Tengo entendido que lo unico que debería recibir daño son las plantas, así que probablemente haya que sacar esto.
    //Si entendí mal, habría que ver que pasa si el jugador pierde más vida que las plantas. Podría ser un problema ya que comparten la vida.
    //Igual de momento sirve bien para testear el daño.
    private void OnTriggerEnter2D(Collider2D other) {
        print("colisiono");
        DamageDealer damage = other.gameObject.GetComponent<DamageDealer>();
        if (damage != null) {
            HP.ApplyChange(-damage.DamageAmount);
            DamageEvent.Invoke();
        }

        if (HP.Value <= 0.0f) {
            DeathEvent.Invoke();
        }
    }
}
