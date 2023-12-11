using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlantaHP : PlantaHPBase
{
    [SerializeField] public float HP;
    public bool ResetHP;
    public FloatReference StartingHP;
    public UnityEvent DamageEvent;
    public UnityEvent DeathEvent;
    private float totalHP;
    [SerializeField] private PlantaCiclo plantaCiclo; //Consigo el script de ciclo de esta instancia.
    private int etapa;
    [SerializeField] private PlantaPoder plantaPoder;
    [SerializeField] private FloatVariable playerHealth; //Salud del jugador.
    [SerializeField] private FloatVariable plantHealth; //Total de salud máxima de todas las plantas de vida.
    WaitForSeconds delay;

    private void Awake() {
        this.Dead = false;
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
      
        if (HP <= 0 || (Dead && HP > 0)) {
            Dead = true; //La planta muere.
            DeathEvent.Invoke();
            playerHealth.ApplyChange(-totalHP);
            plantHealth.ApplyChange(-totalHP);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damage = other.gameObject.GetComponent<DamageDealer>();
        if (other.TryGetComponent<VelocidadAtaque>(out var velocidad))
        {
            delay = new WaitForSeconds(velocidad.velocidad);
            if (damage != null) {
                StartCoroutine(RecibirDano(damage, delay));
            }
        }
        if (other.TryGetComponent<HealDealer>(out var healer)) {
            if (StartingHP.Value > HP + healer.HealAmount.Value) {
                this.HP += healer.HealAmount.Value;
            } else if(StartingHP.Value < HP + healer.HealAmount.Value)
            {
                this.HP = StartingHP.Value;
            }
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

    IEnumerator RecibirDano(DamageDealer _damage, WaitForSeconds _delay)
    {
        while (HP > 0 && !_damage.Dead) {
            HP -= _damage.DamageAmount; //Daño aplicado a la propia planta.
            //playerHealth.ApplyChange(-_damage.DamageAmount); //Daño aplicado al jugador.
            DamageEvent.Invoke();
            yield return _delay;
        }
    }
    public override float ObtenrVidaActual() {
        return HP;
    }

    public override float ObtenrVidaMaxima() {
        return StartingHP.Value;
    }
}
