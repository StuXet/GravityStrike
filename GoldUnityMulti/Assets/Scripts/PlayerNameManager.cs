using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerNameManager : MonoBehaviour
{
    [SerializeField] TMP_InputField usernameInput;

    private void Start()
    {
        if (PlayerPrefs.HasKey("UserName"))
        {
            usernameInput.text = PlayerPrefs.GetString("UserName");
            PhotonNetwork.NickName = PlayerPrefs.GetString("UserName");
        }
        else
        {
            usernameInput.text = "Player" + Random.Range(0, 1000).ToString("0000");
            OnUsernameInputValuerChange();
        }
    }

    public void OnUsernameInputValuerChange()
    {
        PhotonNetwork.NickName = usernameInput.text;
        PlayerPrefs.SetString("UserName", usernameInput.text);
    }
}