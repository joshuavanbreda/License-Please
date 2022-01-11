using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerSelection playerSelection;

    public bool gameStart = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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
