using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class WeaponImageSetter : MonoBehaviour
{
    [Tooltip("Current MeleeWeapon ")]
    public MeleeWeaponVariable MeleeWeapon;

    [Tooltip("Image to set the fill amount on.")]
    public Image Image;
    [Tooltip("Damage weapon")]
    public TextMeshProUGUI Damage;

    private void Update() {
        Image.sprite = MeleeWeapon.Icon;
        Damage.text = MeleeWeapon.Damage.ToString();
    }
}
