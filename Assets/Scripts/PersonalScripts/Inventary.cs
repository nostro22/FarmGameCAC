using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Inventary : MonoBehaviour {


    [SerializeField] public List<ItemVariable> dayInventory = new List<ItemVariable>();
    [SerializeField] public List<ItemVariable> nigthInventory = new List<ItemVariable>();

    private ItemVariable currentEquipedItem;
    public StringVariable currentEquipedName;
    public ImageVariable currentEquipedImage;
    public StringVariable currentEquipCantity;
    private int currentEquipedIndex;

    void Start() {
        var firstPositiveItem = dayInventory.FirstOrDefault(item => item.Quantity > 0f);
        if (firstPositiveItem != null) {
            currentEquipedItem = firstPositiveItem;
            updateUI(currentEquipedItem);
        } 
    }

    public void updateUI(ItemVariable? displayItem) {
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

    public void nextItem() {
        print("next item");
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

    public void previusItem() {
        if (currentEquipedIndex - 1 >= 0) {
            currentEquipedIndex--;
            currentEquipedItem = dayInventory[currentEquipedIndex];
            updateUI(currentEquipedItem);
        } else {
            currentEquipedIndex = dayInventory.Count-1;
            currentEquipedItem = dayInventory[currentEquipedIndex];
            updateUI(currentEquipedItem);

        }


    }
}
