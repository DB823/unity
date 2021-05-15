﻿using UnityEngine;

public class PickupManager : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag ("EnergyPickup"))
        {
            other.gameObject.SetActive (false);
            AddEnergy();
            Debug.Log(gameObject.GetComponent<EnergyManager>().totalEnergy);
            Destroy(GameObject.Find("Pickup"));

        }
    }

    void AddEnergy() // not correctly adding health
    {
        if (!gameObject.GetComponent<EnergyManager>().dead)
        {
            if (gameObject.GetComponent<EnergyManager>().totalEnergy < 125f)
            {
                gameObject.GetComponent<EnergyManager>().totalEnergy += 25f;
            }
            else if (gameObject.GetComponent<EnergyManager>().totalEnergy <= 150f &&
                     gameObject.GetComponent<EnergyManager>().totalEnergy >= 125f)
            {
                gameObject.GetComponent<EnergyManager>().totalEnergy = 150f;
            }
        }
    }

}
