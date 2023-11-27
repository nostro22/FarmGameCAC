using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehavior : MonoBehaviour
{
    private Vector3 localPosition;
    [SerializeField] private float speed=10f;
    // Start is called before the first frame update
    void Start()
    {
    }
    private IEnumerator MoveForward() {
        while (true) {
            transform.position += transform.right * speed * Time.deltaTime;
            yield return null;
        }
    }

    private void OnEnable() {
        StartCoroutine(MoveForward()); // 1.0f is the speed
        
    }

    private void OnDisable() {
        StopCoroutine(MoveForward());
        transform.localPosition = localPosition;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
