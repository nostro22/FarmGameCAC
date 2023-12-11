using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OroInventario : MonoBehaviour
{
    [SerializeField] private FloatVariable oro;

    void Awake() {
        oro.SetValue(200); //Reinicia el oro al abrir el juego.
    }
}
