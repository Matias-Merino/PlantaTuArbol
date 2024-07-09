using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

public class PlayerItem : MonoBehaviour
{
    public TMP_Text playerName;

    public GameObject leftArrowButton;
    public GameObject rightArrowButton;

    

    public void SetPlayerInfo(Player _player)
    {
        playerName.text = _player.NickName;
    }

    public void ApplyLocalChanges()
    {

        leftArrowButton.SetActive(true);
        rightArrowButton.SetActive(true);
    }
}
