using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreationGun : MonoBehaviour
{
    public GameObject firePoint;

    public GameObject Fire;
    public GameObject Water;
    public GameObject Earth;
    public ParticleSystem Air;

    private GameObject selectedProjectile;

    public float fireRate = 0.25f;
    public float projectileSpeed = 20f;
    public float projectileLife = 5f;

    public void Start()
    {
        selectedProjectile = Fire;
        StartCoroutine(Shoot());
    }

    private void Update()
    {
        HandleInput();
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Shoot());
        }
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedProjectile = Fire;
            Debug.Log("Fire Selected");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedProjectile = Water;
            Debug.Log("Water Selected");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedProjectile = Earth;
            Debug.Log("Earth Selected");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Air.Play(); // Different handling for Air as it's a ParticleSystem
            Debug.Log("Air Selected");
        }
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0)) // Left mouse click to shoot
            {
                ShootProjectile(selectedProjectile);
                Debug.Log("Shooting");  
            }
            yield return new WaitForSeconds(fireRate);
        }
    }

    private void ShootProjectile(GameObject projectile)
    {
        if (projectile != null)
        {
            GameObject proj = Instantiate(projectile, firePoint.transform.position, Quaternion.identity);
            Rigidbody rb = proj.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.velocity = transform.forward * projectileSpeed;
            }
            Destroy(proj, projectileLife);
        }
    }
}
