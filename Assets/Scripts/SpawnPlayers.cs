using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public Health healthScript; // Reference to the Health script on the player

    public float minX;
    public float minY;
    public float maxY;
    public float maxX;

    private void Start()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        Vector2 rand = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        // Spawn on the server
        PhotonNetwork.Instantiate(playerPrefab.name, rand, Quaternion.identity);
    }

    public void RespawnPlayer()
    {
        healthScript.currentHealth = healthScript.maxHealth; // Reset the player's health
        SpawnPlayer(); // Respawn the player
    }
}
