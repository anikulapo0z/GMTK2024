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

    public float fireRate = 0.5f;
    public float projectileSpeed = 10f; 
    public float projectileLife = 5f;

    public void FixedUpdate()
    {
        StartCoroutine(Shoot());
    }

    public IEnumerator Shoot()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ShootProjectile(Fire);
                Debug.Log("Fire Selected");
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ShootProjectile(Water);
                Debug.Log("Water Selected");
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                ShootProjectile(Earth);
                Debug.Log("Earth Selected");
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                Air.Play();
                Debug.Log("Air Selected");
            }
            yield return new WaitForSeconds(fireRate);
        }
    }

    void ShootProjectile(GameObject projectile)
    {
        GameObject proj = Instantiate(projectile, firePoint.transform.position, Quaternion.identity);
        Rigidbody rb = proj.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.velocity = transform.forward * projectileSpeed; // Set the velocity
        }
        Destroy(proj, lifeTime); // Destroy the projectile after 'lifeTime' seconds
    }
}
