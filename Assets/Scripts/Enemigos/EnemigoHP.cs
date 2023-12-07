using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemigoHP : MonoBehaviour
{
    [SerializeField] private FloatReference StartingHP;
    private float HP;

    [SerializeField] private FloatVariable enemigosHP;

    [SerializeField] public bool dead;
    public UnityEvent EnemyDeathEvent;

    private void Awake()
    {
        dead = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        HP = StartingHP.Value;
        enemigosHP.ApplyChange(HP);
        HP = StartingHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0) {
            EnemyDeathEvent.Invoke();
            dead = true;
        }
    }
}
