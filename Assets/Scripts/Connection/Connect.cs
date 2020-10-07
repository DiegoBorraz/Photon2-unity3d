using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;


public class Connect : MonoBehaviourPunCallbacks {
    [SerializeField]
    private GameObject painelL, painelS;
    [SerializeField]
    private InputField nomeJogador, nomeSala;
    [SerializeField]
    private Text txtNick;

    [SerializeField]
    private GameObject[] jogador;
    [SerializeField]
    private int id;


    // Start is called before the first frame update
    void Start() {

    }

   

    public void login() {
        PhotonNetwork.NickName = nomeJogador.text;
        PhotonNetwork.ConnectUsingSettings();
        painelL.SetActive(false);
        painelS.SetActive(true);
    }

    public void criaSala() {
        PhotonNetwork.JoinOrCreateRoom(nomeSala.text, new RoomOptions(), TypedLobby.Default);
    }


    public override void OnConnectedToMaster(){
        Debug.Log("Connectado");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby() {
        Debug.Log("Lobby!!!");
    }

    public override void OnDisconnected(DisconnectCause cause){
        Debug.Log("Conexão Perdida");
    }

    public override void OnJoinRandomFailed(short returnCode, string message) {
        Debug.Log("Não entrou em nenhuma sala");
    }

    public override void OnJoinedRoom() {
        Debug.Log("Entrou em uma sala");
        print(PhotonNetwork.CurrentRoom.Name);
        print(PhotonNetwork.CurrentRoom.PlayerCount);
        print(PhotonNetwork.NickName);
        txtNick.text = PhotonNetwork.NickName;

        painelS.SetActive(false);
        PhotonNetwork.Instantiate(jogador[id].name, new Vector3(Random.Range(1, 2),2, Random.Range(3, 6)), Quaternion.identity, 0); 
        
    }

    public void setId(int id) {
        this.id = id;
    }

}
