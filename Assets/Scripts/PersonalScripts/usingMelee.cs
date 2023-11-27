using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class usingMelee : MonoBehaviour {
    [SerializeField] private Transform instanciatePlace;
    [SerializeField] private float activeHitDuration;
    [SerializeField] private float cooldown;
    [SerializeField] private Vector2 ColliderScale;
    public GameObject meleeItem;
    private BoxCollider2D boxCollider2D;
    private bool canUse;

    // Start is called before the first frame update
    void Start() {
        boxCollider2D = meleeItem.GetComponent<BoxCollider2D>();
            boxCollider2D.size = ColliderScale;
        canUse = true;
    }

    private IEnumerator CooldownCoroutine() {
        yield return new WaitForSeconds(cooldown);
        canUse = true;
    }


    IEnumerator MeleeStart() {
        if ( canUse) {
            meleeItem.transform.SetPositionAndRotation(instanciatePlace.position, transform.parent.rotation);
            canUse = false;
            meleeItem.SetActive(true);
            yield return null;
            StartCoroutine(CooldownCoroutine());
            yield return new WaitForSeconds(activeHitDuration);
            meleeItem.SetActive(false);
        }
    }

    public void meleeStart() {
        StartCoroutine(MeleeStart());
    }

}
