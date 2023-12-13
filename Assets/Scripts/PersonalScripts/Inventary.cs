using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Inventary : MonoBehaviour {


    [SerializeField] public List<ItemVariable> dayInventory = new List<ItemVariable>();

    private ItemVariable currentEquipedItem;
    public StringVariable currentEquipedName;
    public ImageVariable currentEquipedImage;
    public StringVariable currentEquipCantity;
    private int currentEquipedIndex;

    void Start() {
        currentEquipedItem = dayInventory.First();
            updateUI(currentEquipedItem);
    }

    public void updateUI(ItemVariable displayItem) {
        if (displayItem != null) {
            currentEquipedName.Value = displayItem.Name;
            currentEquipedImage.Value = displayItem.Icon;
            currentEquipedIndex = dayInventory.IndexOf(displayItem);
            currentEquipCantity.Value = displayItem.Quantity.ToString();
        } else {
            currentEquipedName.Value = "none";
            currentEquipedImage.Value = null;
            currentEquipedIndex = -1;
            currentEquipCantity.Value = "";
        }
    }

    //On E press
    public void nextItem() {
        print("q " +dayInventory.Count);
        if (currentEquipedIndex + 1 < dayInventory.Count) {
            currentEquipedIndex++;
            currentEquipedItem = dayInventory[currentEquipedIndex];
            updateUI(currentEquipedItem);
        } else {
            currentEquipedIndex=0;
            currentEquipedItem = dayInventory[currentEquipedIndex];
            updateUI(currentEquipedItem);

        }

    }

    //On Q press
    public void previusItem() {
        if (currentEquipedIndex - 1 >= 0) {
            currentEquipedIndex--;
            currentEquipedItem = dayInventory[currentEquipedIndex];
            updateUI(currentEquipedItem);
        } else {
            currentEquipedIndex = dayInventory.Count-1;
            print("E " +(dayInventory.Count-1));
            currentEquipedItem = dayInventory[currentEquipedIndex];
            updateUI(currentEquipedItem);
        }
    }
    public void equipItem(ItemVariable itemToEquip) {
        //int index = dayInventory.FindIndex(item => item.Name ==itemToEquip.Name);

        //if (index != -1) {
        //    currentEquipedIndex = index;
        //    currentEquipedItem = dayInventory[currentEquipedIndex];
        //    updateUI(currentEquipedItem);
        //}
        updateUI(currentEquipedItem);
    }



    public void consumeCurrentItem() {
        currentEquipedItem.Quantity--;
        updateUI(currentEquipedItem);
    }
    public void obtenerItem(ItemVariable itemObtenido) {
        itemObtenido.Quantity++;
        updateUI(currentEquipedItem);
    }
}
