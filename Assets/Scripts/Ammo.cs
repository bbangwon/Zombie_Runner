using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmount = 10;

    public int GetAmmoAmount()
    {
        return ammoAmount;
    }

    public void ReduceCurrentAmmo()
    {
        ammoAmount--;
    }
}
