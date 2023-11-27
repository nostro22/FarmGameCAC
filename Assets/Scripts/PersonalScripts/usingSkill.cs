using System.Collections;
using UnityEngine;

public class usingSkill : MonoBehaviour {
    [SerializeField] private string tagToPool;
    [SerializeField] private Transform instanciatePlace;
    [SerializeField] private float activeHitDuration;
    [SerializeField] private float cooldown;
    private bool canUse;

    // Start is called before the first frame update
    void Start() {
        canUse = true;
    }

    private IEnumerator CooldownCoroutine() {
        yield return new WaitForSeconds(cooldown);
        canUse = true;
    }


    IEnumerator SkillStart() {
        GameObject pooledPrefab = ObjectPooler.SharedInstance.GetPooledObject(tagToPool);
        if (pooledPrefab != null && canUse) {
            pooledPrefab.transform.SetPositionAndRotation(instanciatePlace.position, transform.parent.rotation);
            canUse = false;
            pooledPrefab.SetActive(true);
            yield return null;
            StartCoroutine(CooldownCoroutine());
            yield return new WaitForSeconds(activeHitDuration);
            pooledPrefab.SetActive(false);
        }
    }

    public void skillStart() {
        StartCoroutine(SkillStart());
    }

}
