using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using System.Linq;

public class TileManager : MonoBehaviour
{
    [SerializeField] private Tilemap highlightMap = null; //Tilemap donde se ubicarán las tiles resaltadas.
    [SerializeField] private TileBase highlightTile = null; //La tile resaltada.
    [SerializeField] private GameObject jugador = null; //El jugador.
    [SerializeField] private GameObject _planta = null; //La planta a instanciar.

    private Vector3Int posicionAnterior = new Vector3Int(); //Para guardar la posición anterior del jugador.
    Vector3 posicionAnteriorFloat = new Vector3();

    private static bool esDeDia; //Para señalar si es de día o no.

    private SpriteRenderer _spriteRenderer;
    private int layerMask;
    private float distanciaRaycast;
    private float puntoMedio;
    /*private int direccionX;
    private int direccionY;*/
    
    // Start is called before the first frame update
    void Start()
    {
        layerMask = LayerMask.GetMask("Planta"); //Tomo el Layer donde se instanciarán los prefabs.
        distanciaRaycast = 0.25f; //Distancia entre el jugador y el objetivo del raycast.
        puntoMedio = 0.5f; //La mitad de una celda de la grilla, para centrar los prefabs.
    }

    // Update is called once per frame
    void Update()
    {
        Vector3Int posicionActual = Vector3Int.FloorToInt(jugador.transform.position); //Guarda la posición actual del jugador y la redondea para abajo, así coincide con una celda de la grilla.

        if (esDeDia) {
            if (!posicionActual.Equals(posicionAnterior)) { //Si el jugador se mueve a otra celda de la grilla...
                highlightMap.SetTile(posicionAnterior, null); //Se borra la tile resaltada de la posición anterior.
                highlightMap.SetTile(posicionActual, highlightTile); //Se dibuja una celda resaltada en la posición actual.
                posicionAnterior = posicionActual; //Se actualiza la posición anterior.
            }

            if (Input.GetKeyDown(KeyCode.F)) { //Cultivar.
                //Según lo seleccionado en el inventario, esto debería realizar diferentes acciones (por ej.: el tipo de semilla a plantar).
                //Si ya hay algo plantado, deberías tener la opción de "sacrificar" la planta. Supongo que habría que ver si hay algo plantado en esa posición, primero. ¿Pero cómo? USAR EL RAYCAST.
                Vector3 gridCellCenter = new Vector3(posicionActual.x + puntoMedio, posicionActual.y, 0); //Posición del jugador pero en una celda de la grilla, centrada para evitar el offset de la planta.
                Vector2 posicionActual2d = new Vector2(gridCellCenter.x, gridCellCenter.y); //Pasar la posición a 2d para el raycast.
                RaycastHit2D hit = Physics2D.Raycast(posicionActual2d, Vector2.up, distanciaRaycast, layerMask);
                if (hit.collider == null) { //Si el raycast no encuentra nada en el layer "Planta"...
                    _planta.GetComponent<SpriteRenderer>().sortingOrder = -(int)gridCellCenter.y;
                    Instantiate(_planta, gridCellCenter, Quaternion.identity); //Instanciar planta.
                }
            }
            if (Input.GetKeyDown(KeyCode.G)) { //Sacrificar.
                Vector3 gridCellCenter = new Vector3(posicionActual.x + puntoMedio, posicionActual.y, 0); //Posición del jugador pero en una celda de la grilla, centrada para evitar el offset de la planta.
                Vector2 posicionActual2d = new Vector2(gridCellCenter.x, gridCellCenter.y); //Pasar la posición a 2d para el raycast.
                RaycastHit2D hit = Physics2D.Raycast(posicionActual2d, Vector2.up, distanciaRaycast, layerMask);
                if (hit.collider != null) { //Si el raycast encuentra algo en el layer "Planta"...
                    GameObject plantaASacrificar = hit.transform.gameObject;
                    plantaASacrificar.GetComponent<PlantaHP>().dead = true;
                }
            }
            posicionAnteriorFloat = jugador.transform.position; //Se actualiza la posición anterior.
        } else {
            highlightMap.SetTile(posicionAnterior, null); //Se borra la tile resaltada de la posición anterior, pero de noche.
        }
    }

    public void dia() {
        esDeDia = true;
    }

    public void noche() {
        esDeDia = false;
    }
}
