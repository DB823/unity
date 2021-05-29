using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public static int activeWeapon;

    [SerializeField] public GameObject gun1;
    [SerializeField] public GameObject gun2;

    // Start is called before the first frame update
    void Start()
    {
        activeWeapon = 0;
        gun1.SetActive(false);
        gun2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        WeaponSelection();
    }

    private void ActivateWeapon()
    {
        if (activeWeapon == 0)
        {
            gun1.SetActive(true);
            gun2.SetActive(false);
        }
        else if (activeWeapon == 1)
        {
            gun1.SetActive(false);
            gun2.SetActive(true);

        }
    }

    private void WeaponSelection()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            activeWeapon = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            activeWeapon = 1;
        }
        ActivateWeapon();
    }
}
