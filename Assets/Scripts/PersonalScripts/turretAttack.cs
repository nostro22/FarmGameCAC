using System.Collections;
using UnityEngine;
using UnityEngine.Animations;
using static UnityEngine.GraphicsBuffer;

public class turretAttack : MonoBehaviour {
    [SerializeField] private string tagToPool;
    [SerializeField] private Transform instanciatePlace;
    [SerializeField] private float activeHitDuration;
    [SerializeField] private float cooldown;
    private bool canUse;

    // Start is called before the first frame update
    void Start() {
        canUse = true;
    }
    private void Update() {
        if (EnemyPool.pool.Count > 0) {
            var posicionEnemigo = EnemyPool.EnemigoMasCercano(transform.position);
            Vector3 direction = (posicionEnemigo.transform.position - instanciatePlace.position).normalized;
            instanciatePlace.rotation = Quaternion.LookRotation(posicionEnemigo.transform.position);
        }
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
        }
    }

    public void skillStart() {
        StartCoroutine(SkillStart());
    }

}
