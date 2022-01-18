using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerSelection playerSelection;
    public DeviceButtons deviceButtons;
    public PlayerMovement playerMovement;
    public XRayCharacter xRayCharacter;
    public XRayVision xRayVision;

    public GameObject startBtn;

    public bool gameStart = false;
    // Start is called before the first frame update
    void Start()
    {
        deviceButtons.pda.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        gameStart = true;
        playerMovement.trafficStop = false;
        deviceButtons.pda.SetActive(true);
        playerSelection.SuspectSpawn();
        startBtn.SetActive(false);
    }

    public void SuspectButton()
    {
        gameStart = true;
        playerSelection.SuspectSpawn();
    }

    public void CivilianButton()
    {
        gameStart = true;
        playerSelection.CivilianSpawn();
    }
}
