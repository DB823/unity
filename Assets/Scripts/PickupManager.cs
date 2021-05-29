using UnityEngine;

public class PickupManager : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        float distance = Vector3.Distance(transform.position, other.gameObject.transform.position);
        float maxDistance = 10.0f;
        bool isNear = distance <= maxDistance;
        if (other.gameObject.CompareTag ("EnergyPickup") && isNear && Input.GetKeyDown(KeyCode.E))
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
