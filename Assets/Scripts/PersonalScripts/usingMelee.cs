using System.Collections;
using UnityEngine;

public class usingMelee : MonoBehaviour {
    [SerializeField] private Transform instanciatePlace;
    [SerializeField] private MeleeWeaponVariable equipWeapon;
    public GameObject meleeCollider;
    private BoxCollider2D boxCollider2D;
    private bool canUse;

    // Start is called before the first frame update
    void Start() {
        boxCollider2D = meleeCollider.GetComponent<BoxCollider2D>();
        boxCollider2D.size = equipWeapon.ColliderScale;
        canUse = true;
    }

    private IEnumerator CooldownCoroutine() {
        yield return new WaitForSeconds(equipWeapon.CoolDown);
        canUse = true;
    }

    public void setUpdateColliderSize() {
        boxCollider2D.size = equipWeapon.ColliderScale;
    }
    IEnumerator MeleeStart() {
        if (canUse) {
            meleeCollider.transform.SetPositionAndRotation(instanciatePlace.position, transform.parent.rotation);
            canUse = false;
            meleeCollider.SetActive(true);
            yield return null;
            StartCoroutine(CooldownCoroutine());
            yield return new WaitForSeconds(equipWeapon.HitDuration);
            meleeCollider.SetActive(false);
        }
    }

  

    public void meleeStart() {
        StartCoroutine(MeleeStart());
    }

}
