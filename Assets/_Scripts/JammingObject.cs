using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JammingObject : MonoBehaviour
{
    public void StopJam()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerShooter>().StopJamming();
        Destroy(gameObject);
    }
}
