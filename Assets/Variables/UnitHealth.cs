using UnityEngine;
using UnityEngine.Events;

public class UnitHealth : MonoBehaviour {
    public FloatVariable HP;
    public bool ResetHP;
    public FloatReference StartingHP;
    [SerializeField] private bool CanBeHeal=false; 
    [SerializeField] private bool CantakePlayerDamage=false;
    public UnityEvent DamageEvent;
    public UnityEvent HealEvent;
    public UnityEvent DeathEvent;


    private void Start() {
        if (ResetHP)
            HP.SetValue(StartingHP);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // Verifica si el objeto que causó la colisión es un hijo del mismo objeto

        if ((other.transform.CompareTag("range")|| other.transform.CompareTag("melee"))&& this.CompareTag("Player")) {
            return;
        }

        DamageDealer damage = other.gameObject.GetComponent<DamageDealer>();
        if (damage != null && damage.DamageAmount>0 ) {
            if (damage.CompareTag("Player") && !CantakePlayerDamage) {
                return;
            }
            HP.ApplyChange(-damage.DamageAmount);
            DamageEvent.Invoke();
        }

        if (HP.Value <= 0.0f) {
            DeathEvent.Invoke();
        }

            Debug.Log(CanBeHeal);
        if (CanBeHeal) {

            HealDealer heal = other.gameObject.GetComponent<HealDealer>();
            if (heal != null) {
                if (HP.Value > 0.0f
                    && (HP.Value + heal.HealAmount <= StartingHP)
                    ) {
                HP.ApplyChange(heal.HealAmount);
                HealEvent.Invoke();
                }
            }
        }


    }
}
