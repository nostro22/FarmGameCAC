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
    [SerializeField] private Cronometre cronometre;

    private void Start() {
        if (ResetHP) { //Inicia el valor de la salud del jugador y el valor total de la salud de las plantas de vida en 0.
            startingPlantaHP.SetValue(StartingHP.Value);
            HP.SetValue(StartingHP.Value);
        }
    }

    private void Update()
    {
        if (cronometre.cantidadDeDias != 1 && cronometre.cantidadDeNoches != 0 && HP.Value == 0) {
            DeathEvent?.Invoke();
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
    }
}
