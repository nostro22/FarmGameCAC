using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemSellStand : MonoBehaviour
{
    [SerializeField] private ItemVariable Item;
    [SerializeField] private FloatVariable GoldBag;
    [SerializeField] private UnityEvent OnBuyingState;
    [SerializeField] private UnityEvent OnNormalState;

    private bool canBuy = false;


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")){
        canBuy = true;
            OnBuyingState.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")){
            print("Colisione player comprar habilitado");
            OnNormalState.Invoke();
            canBuy = false;
        }
    }
    public void buy() {
        if (canBuy && Item.Price < GoldBag.Value ) { 
        print("Ibuy");
            GoldBag.Value-=Item.Price;
            Item.Quantity++;
        }
    }

}

