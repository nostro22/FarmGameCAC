using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bulletBehavior : MonoBehaviour
{
    private Vector3 localPosition;
    [SerializeField] private float speed=10f;
    [SerializeField] private MeleeWeaponVariable rangeWeapongEquip;
  
    private IEnumerator MoveForward() {
        while (true) {
            transform.position += transform.right * speed * Time.deltaTime;
            yield return null;
        }

    }
    private IEnumerator LifeTime() {

        yield return new WaitForSeconds(rangeWeapongEquip.HitDuration);
        this.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) {
        print(collision.name);
            this.gameObject.SetActive(false);
        }
    }

    private void OnEnable() {
        StartCoroutine(MoveForward());
        StartCoroutine(LifeTime()); // 1.0f is the speed
        
    }

    private void OnDisable() {
        StopCoroutine(MoveForward());
        StopCoroutine(LifeTime());
        transform.localPosition = localPosition;
    }
   
}
