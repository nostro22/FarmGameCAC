using System.Collections;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.PlayerLoop;
using static UnityEngine.GraphicsBuffer;

public class turretAttack : MonoBehaviour {
    [SerializeField] private string tagToPool;
    [SerializeField] private Transform instanciatePlace;
    [SerializeField] private float activeHitDuration;
    [SerializeField] private float cooldown;
    //[SerializeField] private Transform target;
    private bool canUse=true;

    void Update() {
        if (canUse) {
            skillStart();
        }
    }

    private IEnumerator CooldownCoroutine() {
        yield return new WaitForSeconds(cooldown);
        canUse = true;
    }


    IEnumerator SkillStartCorrutine() {
           
        if (EnemyPool.pool.Count > 0) {
            print("Entre Enemigo");
            var posicionEnemigo = EnemyPool.EnemigoMasCercano(transform.position);
            GameObject pooledPrefab = ObjectPooler.SharedInstance.GetPooledObject(tagToPool);
            Vector3 direction = (posicionEnemigo.transform.position - instanciatePlace.position);
            float angle =  Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
            Quaternion quaternionFinalDirection = Quaternion.AngleAxis(angle,Vector3.forward);

            if (pooledPrefab != null) {
                pooledPrefab.transform.SetPositionAndRotation(instanciatePlace.position, quaternionFinalDirection);
                
                canUse = false;
                print("Entre bala");
                    pooledPrefab.SetActive(true);
                    yield return null;
                    StartCoroutine(CooldownCoroutine());
                }
          }
    }

    public void skillStart() {
        StartCoroutine(SkillStartCorrutine());
    }

}
