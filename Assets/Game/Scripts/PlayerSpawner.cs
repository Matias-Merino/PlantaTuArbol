using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject[] playerPrefabs;   
    public Transform[] spawnPoints;      

    private void Start()
    {
<<<<<<< HEAD
        int playerAvatarIndex = (int)PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"];

        Transform spawnPoint = spawnPoints[playerAvatarIndex];

        GameObject playerToSpawn = playerPrefabs[playerAvatarIndex];
        PhotonNetwork.Instantiate(playerToSpawn.name, spawnPoint.position, spawnPoint.rotation);
=======
        Transform spawnPoint1 = spawnPoints[0];
        Transform spawnPoint2 = spawnPoints[1];
        GameObject playerToSpawn = playerPrefabs[(int)PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]];
        PhotonNetwork.Instantiate(playerToSpawn.name, spawnPoint1.position, Quaternion.identity);
        

>>>>>>> parent of c70c8da (Score y cambios en gamemanager)
    }
}
