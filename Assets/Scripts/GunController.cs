using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class GunController : MonoBehaviour
{
    [SerializeField] private CharacterController character;

    [SerializeField] private Camera cam;

    private bool shoot;

    private float energyLoss = 3;

    private float damage = 10f;

    void Update()
    {
        shoot = Input.GetKeyDown(KeyCode.Mouse0);
        if (shoot && gameObject.GetComponent<EnergyManager>().totalEnergy > 0f)
        {
            Fire();
        }
    }

    void Fire()
    {
        Vector3 direction = transform.forward;
        RaycastHit hit = default;
        Vector3 localOffset = transform.position + (transform.up * 2);
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity))
        {
            hit.collider.SendMessageUpwards("EnergyLoss", 2, SendMessageOptions.DontRequireReceiver);

        }
        gameObject.GetComponent<EnergyManager>().EnergyLoss(1);
        shoot = false;
    }
}
