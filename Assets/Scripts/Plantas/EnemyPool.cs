using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour {
    public readonly static HashSet<EnemyPool> pool = new HashSet<EnemyPool>();

    private void OnEnable() {
        EnemyPool.pool.Add(this);
    }

    private void OnDisable() {
        EnemyPool.pool.Remove(this);
    }

    public static EnemyPool EnemigoMasCercano(Vector3 pos) {
        EnemyPool result = null;
        float distancia = float.PositiveInfinity;
        var enemy = EnemyPool.pool.GetEnumerator();

        while (enemy.MoveNext()) {
            float d = (enemy.Current.transform.position - pos).sqrMagnitude;

            if (d < distancia) {
                result = enemy.Current;
                distancia = d;
            }
        }

        return result;
    }
}
