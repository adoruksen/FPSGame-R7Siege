using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    int selectedWeapon = 0;
    void Start()
    {
        WeaponActivator();
    }

    void Update()
    {
        SelectWeapon();
    }
    void WeaponActivator()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i==selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }

    void SelectWeapon() {
        int previousSelectedWeapon = selectedWeapon;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = transform.childCount - 1;
            }
            else
            {
                selectedWeapon--;
            }

        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }
        }
        if (previousSelectedWeapon != selectedWeapon)
        {
            WeaponActivator();
        }
    }
}
