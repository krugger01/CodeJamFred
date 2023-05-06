using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _ammoCount; // Reference to the TextMeshProUGUI component for displaying ammo count
    private PlayerShooter playerShooter; // Reference to the PlayerShooter script

    void Start()
    {
        playerShooter = FindObjectOfType<PlayerShooter>(); // Find and assign the PlayerShooter component in the scene
    }

    void Update()
    {
        // Update the ammo count displayed in the TextMeshProUGUI component
        _ammoCount.SetText(playerShooter.CurrentAmmo.ToString());
    }
}
