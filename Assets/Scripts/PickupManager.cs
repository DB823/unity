using UnityEngine;
using UnityEngine.Rendering;

public class PickupManager : MonoBehaviour
{
    [SerializeField] private GameObject ePanel;
    void OnTriggerStay(Collider other)
    {
        float distance = Vector3.Distance(transform.position, other.gameObject.transform.position);
        float maxDistance = 10.0f;
        bool isNear = distance <= maxDistance;
        if (isNear) ePanel.gameObject.SetActive(true);
        else ePanel.gameObject.SetActive(false);
        if (other.gameObject.CompareTag("EnergyPickup") && isNear && Input.GetKeyDown(KeyCode.E))
        {
            other.gameObject.SetActive(false);
            AddEnergy();
            Debug.Log(gameObject.GetComponent<EnergyManager>().totalEnergy);
            Destroy(other.gameObject);
            ePanel.gameObject.SetActive(false);
        }
    }

    void AddEnergy()
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
