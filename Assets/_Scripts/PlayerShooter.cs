using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject laserPrefab; // The prefab for the laser/bullet
    public int ammoCapacity = 3; // Maximum ammo capacity
    public float reloadTime = 5f; // Time it takes to reload ammo in seconds
    public float bulletLifetime = 5f; // Lifetime of bullet in seconds
    private int currentAmmo; // Current ammo count
    public int CurrentAmmo => currentAmmo; // Public property to access current ammo count
    private bool isReloading = false; // Flag for reloading
    private bool isJammed = false; // Flag for jammed, true then it is jammed, false then it is not
    public GameObject jammedPrefab; // The prefab for when it is jammed

    private void Start()
    {
        currentAmmo = ammoCapacity; // Set the current ammo count to the maximum capacity at the start
    }

    private void Update()
    {
        // Check for input to shoot only if not reloading, ammo available, and game is in progress
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isReloading && currentAmmo > 0 && GameManager.instance.GetGameStatus())
        {
            if (!isJammed)
            {
                isJammed = IsJamming();
                if (isJammed)
                {
                    StartJamming();
                }
            }
            if (!isJammed)
            {
                Shoot(); // Shoots a bullet
                currentAmmo--; // Reduces the current ammo count by 1
            }

            if (currentAmmo == 0)
            {
                StartCoroutine(Reload()); // Start the reload coroutine if the ammo is depleted
            }
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(laserPrefab, transform.position, Quaternion.identity); // Create a bullet/laser object
        Destroy(bullet, bulletLifetime); // Destroy the bullet after its lifetime expires
    }

    private IEnumerator Reload()
    {
        isReloading = true; // Set the reloading flag to true
        yield return new WaitForSeconds(reloadTime); // Wait for the specified reload time
        currentAmmo = ammoCapacity; // Reset the current ammo count to the maximum capacity
        isReloading = false; // Set the reloading flag to false
    }

    private bool IsJamming()
    {
        // Probability of jamming: 25%
        float jammingProbability = 0.25f;
        return Random.value < jammingProbability;
    }

    private void StartJamming()
    {
        //
        GameObject JamObject = Instantiate(jammedPrefab, transform.position, Quaternion.identity);
        JamObject.transform.parent = GameObject.Find("Canvas").transform;
        float xpos = Random.Range(0, Screen.width);
        float ypos = Random.Range(0, Screen.height);
        JamObject.transform.position = new Vector3(xpos, ypos, 0);
    }

    public void StopJamming()
    {
        isJammed = false;
    }
}

