using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealParticleCaller : MonoBehaviour
{
   
   public void HealParticle() {
        //Instantiate(objetoAInstanciar, lugarAInstanciar.position, lugarAInstanciar.rotation);        
        GameObject healParticle = ObjectPooler.SharedInstance.GetPooledObject("Watering");
        if (healParticle != null) {
            healParticle.transform.SetPositionAndRotation(transform.position, transform.rotation);
            healParticle.SetActive(true);
        }
    }
}
