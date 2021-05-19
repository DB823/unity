using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class GunController : MonoBehaviour
{
    [SerializeField] private CharacterController character;

    [SerializeField] private Camera cam;

    private bool shoot;

    private float energyLoss = 3;

    private float damage = 10f;

    public GameObject projectile;

    public GameObject gun;

    public float speed = 100000000f;
    private Vector3 vector= new Vector3 (90, 0, 0);
    private GameObject instBullet;

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
        instBullet = Instantiate(projectile, gun.transform.position, cam.transform.rotation) as GameObject;
        instBullet.transform.Rotate(direction + vector);
        Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
        instBulletRigidbody.AddForce(cam.transform.forward * speed);
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity))
        {
            hit.collider.SendMessageUpwards("EnergyLoss", 2, SendMessageOptions.DontRequireReceiver);
            Destroy(instBullet);
        }
        gameObject.GetComponent<EnergyManager>().EnergyLoss(1);
        shoot = false;
    }

    private void OnTriggerExit(Collider other) // not currently working as bullets are immediately destroyed if fired at collider
    {
        if (other.gameObject.CompareTag("collider"))
        {
            Destroy(instBullet, 10f);
        }
    }
}
