using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    [SerializeField] private float speed;
    private float step;
    private Vector2 target;
    private float variacion;

    // Start is called before the first frame update
    void Start()
    {
        variacion = Random.Range(0.5f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        var posicionPlanta = PlantaPool.PlantaMasCercana(transform.position);
        target = new Vector2(posicionPlanta.transform.position.x, posicionPlanta.transform.position.y);
        step = speed * Time.deltaTime * variacion;

        transform.position = Vector2.MoveTowards(transform.position, target, step);
    }
}
