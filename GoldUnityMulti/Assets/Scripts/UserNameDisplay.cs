using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserNameDisplay : MonoBehaviour
{
    [SerializeField] PhotonView PlayerPV;
    [SerializeField] TMP_Text text;

    private void Start()
    {
        if (PlayerPV.IsMine)
        {
            gameObject.SetActive(false);
        }
        text.text = PlayerPV.Owner.NickName;
    }
}
