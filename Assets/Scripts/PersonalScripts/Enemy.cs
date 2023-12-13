using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour , IDamageable
{
    [SerializeField] public float MaxHP = 100;
    [SerializeField] BoxCollider2D Collider2D;
    [SerializeField] UnityEvent deathEvent;
    private DamageDealer myDamageDealer;
    private void Awake() {
        myDamageDealer = GetComponent<DamageDealer>();
    }
    public float health { get; set; }

    private void OnEnable() {
        myDamageDealer.Dead = false;
        health = MaxHP;
    }


    public void Damage(float damageAmount) {
       this.health -= damageAmount;
        Hurtparticle();
        if (this.health <= 0) {
            myDamageDealer.Dead=true;
            deathEvent?.Invoke();
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
