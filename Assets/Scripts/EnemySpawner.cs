using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;

    WaitForSeconds delay = new WaitForSeconds(2);
    private int cantidad;
    [SerializeField] public int cantidadRestante;

    // Start is called before the first frame update
    void Start()
    {
        cantidad = 0;
        cantidadRestante = 0;
    }

    public void Spawn()
    {
        cantidad += 10;
        cantidadRestante = cantidad;
        Debug.Log(cantidadRestante);
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        int i = 0;
        while (i < cantidad) {
            Vector3 posicionSpawn = Random.onUnitSphere;
            posicionSpawn.z = 0;
            posicionSpawn.Normalize();
            posicionSpawn.x = posicionSpawn.x * Random.Range(10, 12);
            posicionSpawn.y = posicionSpawn.y * Random.Range(4, 6);

            Instantiate(_enemy, posicionSpawn, Quaternion.identity);
            i++;
            yield return delay;
        }
    }

    public void EnemigoEliminado()
    {
        cantidadRestante--;
        Debug.Log(cantidadRestante);
    }
}