using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target; //Player
    [SerializeField] private float smooth;
    [SerializeField] private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        if (target is null)
            target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        var targetPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smooth * Time.deltaTime);
    }
}
