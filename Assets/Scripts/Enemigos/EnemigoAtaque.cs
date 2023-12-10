using System.Collections;
using UnityEngine;

public class EnemigoAtaque : MonoBehaviour {
    [SerializeField] private VelocidadAtaque _velocidad;
    [SerializeField] private Animator _animator;
    WaitForSeconds delay;

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.TryGetComponent<PlantaHP>(out var _planta)) {
            delay = new WaitForSeconds(_velocidad.velocidad);

            if (_planta != null) {
                StartCoroutine(AnimacionAtaque(_planta, _animator, delay));
            }
        }
    }

    IEnumerator AnimacionAtaque(PlantaHP _planta, Animator _animator, WaitForSeconds _delay) {
        while (_planta.HP > 0) {
            _animator.SetBool("hasAttacking", true);
            yield return _delay;
            _animator.SetBool("hasAttacking", false);
            yield return 1;
        }
    }

    private void OnDisable() {
        this.StopAllCoroutines();
    }
}