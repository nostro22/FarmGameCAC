using UnityEngine;

public abstract class PlantaHPBase : MonoBehaviour {

    private bool dead;

    public bool Dead { get => dead; set => dead = value; }
    public abstract float  ObtenrVidaActual();
    public abstract float  ObtenrVidaMaxima();

}
