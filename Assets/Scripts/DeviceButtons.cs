using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceButtons : MonoBehaviour
{
    public PdaMove pdaMove;
    public XRayCharacter XRayCharacter;
    public XRayVision XRayVision;
    public PlayerMovement playerMovement;
    public PlayerSelection playerSelection;

    public Animator inAnim;
    public GameObject pdaOn;
    public GameObject pdaOff;

    public GameObject screen1;
    public GameObject screen2;
    public GameObject screenBlack;
    public GameObject suspectText;
    public GameObject pda;

    public GameObject arrestBtn;
    public GameObject releaseBtn;

    public GameObject policeman;

    public GameObject winParticle;
    public GameObject failParticle;
    public Transform particlePos;
    public Transform particlePos2;

    void Start()
    {
        pdaOn.SetActive(true);
        pdaOff.SetActive(false);
    }
    public void In()
    {
        inAnim.SetBool("in", true);
        inAnim.SetBool("out", false);
        pdaOn.SetActive(false);
        pdaOff.SetActive(true);
        StartCoroutine(XrayOnWait());
    }

    public void Out()
    {
        Camera.main.transform.position = pdaMove.originalCamPos.position;
        inAnim.SetBool("out", true);
        inAnim.SetBool("in", false);
        pdaOn.SetActive(true);
        pdaOff.SetActive(false);
        StartCoroutine(XrayOffWait());
    }

    public void Arrest()
    {
        policeman.SetActive(true);
        StartCoroutine(PickUpTruckWait());
    }

    public void Release()
    {
        playerMovement.trafficStop = false;
        StartCoroutine(RespawnNew());
    }

    public IEnumerator XrayOnWait()
    {
        screenBlack.SetActive(true);
        screen1.SetActive(false);
        screen2.SetActive(false);
        arrestBtn.SetActive(false);
        releaseBtn.SetActive(false);
        suspectText.SetActive(false);
        yield return new WaitForSeconds(1f);
        XRayCharacter.xRayOn = true;
        XRayVision.xRayOn = true;

        screenBlack.SetActive(false);

    }

    public IEnumerator XrayOffWait()
    {
        XRayCharacter.xRayOn = false;
        XRayVision.xRayOn = false;
        screenBlack.SetActive(true);
        yield return new WaitForSeconds(1f);
        screen1.SetActive(true);
        screen2.SetActive(true);
        arrestBtn.SetActive(true);
        releaseBtn.SetActive(true);
        suspectText.SetActive(true);

        screenBlack.SetActive(false);
    }

    public IEnumerator RespawnNew()
    {
        yield return new WaitForSeconds(10f);
        playerSelection.RandomCharacterSpawn();
        policeman.SetActive(false);
    }

    public IEnumerator PickUpTruckWait()
    {
        yield return new WaitForSeconds(3f);
        playerMovement.PickUpTruck();
        //Instantiate(winParticle, particlePos.position, Quaternion.identity);
        Instantiate(failParticle, particlePos2.position, Quaternion.Euler(-90, 0, 0));

        yield return new WaitForSeconds(0.5f);
        playerMovement.trafficStop = false;
        yield return new WaitForSeconds(10f);
        playerSelection.RandomCharacterSpawn();
        policeman.SetActive(false);
        playerMovement.trafficBarrier.SetActive(true);
        playerMovement.resetRotationTruck();
    }
}
