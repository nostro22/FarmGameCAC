using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Enemy : MonoBehaviour , IDamageable
{
    [SerializeField] protected float MaxHP = 100;
    [SerializeField] BoxCollider2D Collider2D;
    [field:SerializeField]
    public float health { get; set; }

    private void OnEnable() {
        health = MaxHP;
    }

    public void Damage(float damageAmount) {
       this.health -= damageAmount;
        Hurtparticle();
        if (this.health <= 0) {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision) {

        DamageDealer damage = collision.gameObject.GetComponent<DamageDealer>();
        if (damage != null) {
            Damage(damage.DamageAmount.Value);
        }
    }

    void Hurtparticle() {
            //Instantiate(objetoAInstanciar, lugarAInstanciar.position, lugarAInstanciar.rotation);        
            GameObject hurtParticleEffect = ObjectPooler.SharedInstance.GetPooledObject("enemyHurtParticle");
            if (hurtParticleEffect != null) {
                hurtParticleEffect.transform.SetPositionAndRotation(transform.position, transform.rotation);
                hurtParticleEffect.SetActive(true);
            }
    }


}
