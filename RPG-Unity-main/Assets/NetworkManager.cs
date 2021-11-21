using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NetworkManager : MonoBehaviour
{
    [SerializeField] private string versionName = "0.1";
    [SerializeField] private GameObject usrNamePanel;
    [SerializeField] private GameObject joinGamePanel;

    [SerializeField] private InputField nameInput;
    [SerializeField] private InputField joinInput;
    [SerializeField] private InputField createInput;

    [SerializeField] private GameObject nameButton;
    [SerializeField] private GameObject joinButton;
    [SerializeField] private GameObject createButton;


    // Start is called before the first frame update
    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(versionName);
    }
    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connected");
    }
    void Start()
    {
        joinGamePanel.SetActive(false);
        usrNamePanel.SetActive(true);
        nameButton.SetActive(false);
    }
    public void ChangeUserNameInput()
    {
        if (nameInput.text.Length >= 3)
        {
            nameButton.SetActive(true);
        }
        else
        {
            nameButton.SetActive(false);
        }
    }

  
 
     public void SetUserName()
    {
        usrNamePanel.SetActive(false);
        joinGamePanel.SetActive(true);
        PhotonNetwork.playerName = nameInput.text;
    }

    public void CreateGame()
    {
        PhotonNetwork.CreateRoom(createInput.text, new RoomOptions() {maxPlayers=2 }, null);
    }

    public void JoinGame()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.maxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom(joinInput.text, roomOptions, TypedLobby.Default);

    }
}
