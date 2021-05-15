using UnityEngine;

public class EnergyManager : MonoBehaviour
{
    private float gunEnergyLoss = 3;
    public float totalEnergy = 120f;
    private float damage = 25;
    public bool dead = false;

    public void EnergyLoss(float mode)
    {
        switch (mode)
        {
            case 1: // energy loss when firing gun
                totalEnergy -= gunEnergyLoss;
                break;
            case 2: // energy loss when hit
                if (totalEnergy <= 0.0)
                {
                    return;
                }
                totalEnergy -= damage;
                if (totalEnergy <= 0.0)
                {
                    Destroy(gameObject);
                    dead = true;
                    Debug.Log("Destroyed!");
                }
                break;

        }
    }
}
