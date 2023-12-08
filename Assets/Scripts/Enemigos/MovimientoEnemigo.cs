using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    [SerializeField] private float speed;
    private float step;
    private Vector2 target;
    private float variacion;
    private SpriteRenderer spriteRenderer;
    private Animator animator;


    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();    
    }
    // Start is called before the first frame update
    void Start()
    {
        variacion = Random.Range(0.5f, 1.5f);
        WalkAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlantaPool.pool.Count > 0) 
        {
            var posicionPlanta = PlantaPool.PlantaMasCercana(transform.position);
            target = new Vector2(posicionPlanta.transform.position.x, posicionPlanta.transform.position.y);
            step = speed * Time.deltaTime * variacion;

            transform.position = Vector2.MoveTowards(transform.position, target, step);
            if (posicionPlanta.transform.position.x < transform.position.x) 
            {
                spriteRenderer.flipX = true;
            } 
            else
            {
                spriteRenderer.flipX = false;
            }
        }
    }


    public void WalkAnimation()
    {
        animator.SetBool("hasAttacking", false);
    }

    public void AttackAnimation() {
        animator.SetBool("hasAttacking", true);
    }

}
