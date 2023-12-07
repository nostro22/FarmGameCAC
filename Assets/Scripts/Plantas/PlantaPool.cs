using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantaPool : MonoBehaviour
{
    public readonly static HashSet<PlantaPool> pool = new HashSet<PlantaPool>();
    
    private void OnEnable()
    {
        PlantaPool.pool.Add(this);
    }

    private void OnDisable()
    {
        PlantaPool.pool.Remove(this);
    }

    public static PlantaPool PlantaMasCercana(Vector3 pos)
    {
        PlantaPool result = null;
        float distancia = float.PositiveInfinity;
        var planta = PlantaPool.pool.GetEnumerator();

        while(planta.MoveNext()) {
            float d = (planta.Current.transform.position - pos).sqrMagnitude;

            if (d < distancia) {
                result = planta.Current;
                distancia = d;
            }
        }

        return result;
    }
}
