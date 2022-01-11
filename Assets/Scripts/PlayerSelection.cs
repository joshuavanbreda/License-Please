using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerMovement playerMovement;

    [Header("Lists")]
    public List<GameObject> gender;
    public List<GameObject> mHairTypes;
    public List<GameObject> fHairTypes;
    public List<Material> skinColorVariant;
    public List<Material> hairColor;
    public List<Material> eyeColor;
    public List<Material> shirtColor;

    public List<GameObject> suspectItems;

    [Header("Characters")]
    public GameObject maleChar;
    public GameObject femaleChar;

    [Header("Male Hair Types")]
    public GameObject mHair1;
    public GameObject mHair2;
    public GameObject mHair3;
    public GameObject mHair4;

    [Header("Female Hair Types")]
    public GameObject fHair1;
    public GameObject fHair2;
    public GameObject fHair3;
    public GameObject fHair4;

    [Header("Original Materials")]
    public Material skin1;
    public Material skin2;
    public Material skin3;
    public Material skin4;
    public Material skin5;

    public Material hair1;
    public Material hair2;
    public Material hair3;
    public Material hair4;
    public Material hair5;

    public Material eye1;
    public Material eye2;
    public Material eye3;

    public Material shirt1;
    public Material shirt2;
    public Material shirt3;
    public Material shirt4;
    public Material shirt5;
    public Material shirt6;
    public Material shirt7;
    public Material shirt8;
    public Material shirt9;
    public Material shirt10;

    public GameObject mainPlayer;

    [Header("Suspect Set Materials")]
    GameObject suspectGender;
    public GameObject suspectShirtMale;
    GameObject suspectShirtFemale;
    int        suspectAge;
    Material suspectSkinMat;
    Material suspectHairMat;
    Material suspectEyeMat;
    Material suspectShirtMat;

    GameObject suspectHairType;
    public GameObject suspectEye1;
    public GameObject suspectEye2;

    [Header("Civilian Set Materials")]
    GameObject civilianGender;
    public GameObject civilianShirtMale;
    GameObject civilianShirtFemale;
    int        civilianAge;
    Material civilianSkinMat;
    Material civilianHairMat;
    Material civilianEyeMat;
    Material civilianShirtMat;

    GameObject civilianHairType;
    public GameObject civilianEye1;
    public GameObject civilianEye2;

    int randomGender;
    int randomAge;
    int randomSkin;
    int randomHair;
    int randomEye;
    int randomMaleHair;
    int randomFemaleHair;
    int randomShirt;

    int randomGenderCiv;
    int randomAgeCiv;
    int randomSkinCiv;
    int randomHairCiv;
    int randomEyeCiv;
    int randomMaleHairCiv;
    int randomFemaleHairCiv;
    int randomShirtCiv;

    int suspectCount;

    int initialPlayerSelect;



    // Start is called before the first frame update
    void Start()
    {
        SetCharLists();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameStart == true)
        {
            //Suspect();
            //mainPlayer.transform.GetChild(0).GetComponent<Renderer>().material = suspectSkin;
            //mainPlayer.transform.GetChild(1).GetComponent<Renderer>().material = suspectHair;
            //mainPlayer.transform.GetChild(2).GetComponent<Renderer>().material = suspectEye;
        }
    }

    public void RandomGenerateSuspect()
    {
        //MUST NOT FORGET TO UN-COMMENT AFTER BUGFIXING//
        //randomGender = Random.Range(0, 2);
        randomGender = 0;
        randomAge = Random.Range(15, 100);
        randomSkin = Random.Range(0, 5);
        randomHair = Random.Range(0, 5); //don't forget white hair ovveride for when over 60 (pos 5 in List)
        randomEye = Random.Range(0, 3);
        randomMaleHair = Random.Range(0, 4);
        randomFemaleHair = Random.Range(0, 4);
        randomShirt = Random.Range(0, 10);
    }

    public void RandomGenerateCivilian()
    {
        //MUST NOT FORGET TO UN-COMMENT AFTER BUGFIXING//
        //randomGender = Random.Range(0, 2);
        randomGenderCiv = 0;
        randomAgeCiv = Random.Range(15, 100);
        randomSkinCiv = Random.Range(0, 5);
        randomHairCiv = Random.Range(0, 5); //don't forget white hair ovveride for when over 60 (pos 5 in List)
        randomEyeCiv = Random.Range(0, 3);
        randomMaleHairCiv = Random.Range(0, 4);
        randomFemaleHairCiv = Random.Range(0, 4);
        randomShirtCiv = Random.Range(0, 10);
    }

    public void Suspect()
    {
        if (suspectCount < 1)
        {
            suspectCount = 1;
            RandomGenerateSuspect();
        }
        //suspect base selection
        suspectAge = randomAge;
        suspectSkinMat = skinColorVariant[randomSkin];
        suspectHairMat = hairColor[randomHair];
        suspectEyeMat = eyeColor[randomEye];
        suspectShirtMat = shirtColor[randomShirt];

        //suspect Gender selection
        if (randomGender == 0)
        {
            suspectGender = maleChar;
            suspectHairType = mHairTypes[randomMaleHair];
            suspectShirtMale.transform.GetComponent<Renderer>().material = suspectShirtMat;
        }
        else if (randomGender == 1)
        {
            suspectGender = femaleChar;
            suspectHairType = fHairTypes[randomFemaleHair];
            suspectShirtFemale.transform.GetComponent<Renderer>().material = suspectShirtMat;
        }
        // Set suspect material colors
        suspectGender.transform.GetComponent<Renderer>().material = suspectSkinMat;

        suspectHairType.transform.GetComponent<Renderer>().material = suspectHairMat;

        suspectEye1.transform.GetChild(0).GetComponent<Renderer>().material = suspectEyeMat;
        suspectEye2.transform.GetChild(0).GetComponent<Renderer>().material = suspectEyeMat;
    }

    public void Civilian()
    {
        RandomGenerateCivilian();

        //Age
        civilianAge = randomAgeCiv;

        //civilian material base selection
        civilianSkinMat = skinColorVariant[randomSkinCiv];
        civilianHairMat = hairColor[randomHairCiv];
        civilianEyeMat = eyeColor[randomEyeCiv];
        civilianShirtMat = shirtColor[randomShirtCiv];

        //civilian Gender selection
        if (randomGenderCiv == 0)
        {
            civilianGender = maleChar;
            civilianHairType = mHairTypes[randomMaleHairCiv];
            civilianShirtMale.transform.GetComponent<Renderer>().material = civilianShirtMat;
        }
        else if (randomGenderCiv == 1)
        {
            civilianGender = femaleChar;
            civilianHairType = fHairTypes[randomFemaleHairCiv];
            civilianShirtFemale.transform.GetComponent<Renderer>().material = civilianShirtMat;
        }
        // Set civilian colors
        civilianGender.transform.GetComponent<Renderer>().material = civilianSkinMat;

        civilianHairType.transform.GetComponent<Renderer>().material = civilianHairMat;

        civilianEye1.transform.GetChild(0).GetComponent<Renderer>().material = civilianEyeMat;
        civilianEye2.transform.GetChild(0).GetComponent<Renderer>().material = civilianEyeMat;

        // Spawn civilian
        civilianGender.SetActive(true);
        civilianEye1.SetActive(true);
        civilianEye2.SetActive(true);
    }

    public void SetCharLists()
    {
        //gender list
        gender.Add(maleChar);
        gender.Add(femaleChar);

        //other lists
        //skinColorVariant = new List<Material>(Resources.LoadAll<Material>("CharSkinColors"));
        skinColorVariant.Add(skin1);
        skinColorVariant.Add(skin2);
        skinColorVariant.Add(skin3);
        skinColorVariant.Add(skin4);
        skinColorVariant.Add(skin5);

        //hairColor = new List<Material>(Resources.LoadAll<Material>("CharHairColors"));
        hairColor.Add(hair1);
        hairColor.Add(hair2);
        hairColor.Add(hair3);
        hairColor.Add(hair4);
        hairColor.Add(hair5);

        //eyeColor = new List<Material>(Resources.LoadAll<Material>("CharEyeColors"));
        eyeColor.Add(eye1);
        eyeColor.Add(eye2);
        eyeColor.Add(eye3);

        mHairTypes.Add(mHair1);
        mHairTypes.Add(mHair2);
        mHairTypes.Add(mHair3);
        mHairTypes.Add(mHair4);

        fHairTypes.Add(fHair1);
        fHairTypes.Add(fHair2);
        fHairTypes.Add(fHair3);
        fHairTypes.Add(fHair4);

        shirtColor.Add(shirt1);
        shirtColor.Add(shirt2);
        shirtColor.Add(shirt3);
        shirtColor.Add(shirt4);
        shirtColor.Add(shirt5);
        shirtColor.Add(shirt6);
        shirtColor.Add(shirt7);
        shirtColor.Add(shirt8);
        shirtColor.Add(shirt9);
        shirtColor.Add(shirt10);
    }

    public void SuspectSpawn()
    {
        //GameObject.Instantiate(suspectHairType, GameObject.FindWithTag("Suspect").transform.position, Quaternion.identity);

        Suspect();

        mHair1.SetActive(false);
        mHair2.SetActive(false);
        mHair3.SetActive(false);
        mHair4.SetActive(false);

        //femaleChar.SetActive(false);
        maleChar.SetActive(false);

        //civilianGender.SetActive(false);
        //civilianHairType.SetActive(false);
        civilianEye1.SetActive(false);
        civilianEye2.SetActive(false);

        suspectGender.SetActive(true);
        suspectHairType.SetActive(true);
        suspectEye1.SetActive(true);
        suspectEye2.SetActive(true);
    }

    public void CivilianSpawn()
    {
        Civilian();

        mHair1.SetActive(false);
        mHair2.SetActive(false);
        mHair3.SetActive(false);
        mHair4.SetActive(false);

        //femaleChar.SetActive(false);
        maleChar.SetActive(false);

        //suspectGender.SetActive(false);
        //suspectHairType.SetActive(false);
        suspectEye1.SetActive(false);
        suspectEye2.SetActive(false);

        civilianGender.SetActive(true);
        civilianHairType.SetActive(true);
        civilianEye1.SetActive(true);
        civilianEye2.SetActive(true);
    }

    public void RandomCharacterSpawn()
    {
        initialPlayerSelect = Random.Range(1, 7);
        Debug.Log(initialPlayerSelect);

        if (initialPlayerSelect == 2)
        {
            SuspectSpawn();
            playerMovement.transform.position = playerMovement.spawnPoint.position;
            playerMovement.trafficStop = false;
        }
        if (initialPlayerSelect != 2)
        {
            CivilianSpawn();
            playerMovement.transform.position = playerMovement.spawnPoint.position;
            playerMovement.trafficStop = false;
        }
    }
}
