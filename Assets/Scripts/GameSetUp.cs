using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSetUp : MonoBehaviour
{
    private bool ShortRangeSoldierSelected = false;
    public GameObject ShortRangeSoldierButton;

    public GameObject soldier;
    private List<GameObject> myArmy = new List<GameObject>();

    private float dist;
    private Vector3 v3;

    public TextMeshProUGUI moneyLabel;
    private int money;

    public TextMeshProUGUI quantityLabel;

    private int selectedLvl = 0;
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;

    public GameObject ARcamera;
    public GameObject ARtarget;

    public GameObject Army;
    public GameObject Battlefield;

    public GameObject SetUpUI;
    public GameObject StartBattleButton;

    public GameObject mapCenter;

    private float minFOV = 5f;
    private float maxFOV = 90f;
    private float sensitivity = 10f;
    private float FOV;

    public float horizontalSpeed = 10;
    public float verticalSpeed = 10;

    private string hitName;
    public bool isStarted;


    // Start is called before the first frame update
    void Start()
    {
        money = 100;
        moneyLabel.text = money.ToString();
        quantityLabel.text = "x0";
        isStarted = false;
        ShowSelectedLevel();
    }

    // Update is called once per frame
    void Update()
    {

        FOV = Camera.main.fieldOfView;
        FOV += (Input.GetAxis("Mouse ScrollWheel") * sensitivity) * -1;
        FOV = Mathf.Clamp(FOV, minFOV, maxFOV);
        Camera.main.fieldOfView = FOV;

        Vector3 mousePoint = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 300.0f))
            {

                hitName = hit.transform.name;

                if (ShortRangeSoldierSelected && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() && money >= 10)
                {
                    
                    GameObject newSoldier = Instantiate(soldier, hit.point, Quaternion.identity, Army.transform);
                    newSoldier.transform.LookAt(mapCenter.transform);
                    newSoldier.transform.eulerAngles = new Vector3(0f, newSoldier.transform.eulerAngles.y, 0f);
                    myArmy.Add(newSoldier);
                    money -= 10;
                    moneyLabel.text = money.ToString();
                    quantityLabel.text = "x" + myArmy.Count.ToString();
                }


            }
        }

           
        

        if (Input.GetMouseButton(0))
        {

            
            if (!ShortRangeSoldierSelected && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() && hitName != "TT_RTS_Demo_Character(Clone)")
            {
                float horizontalOffset = horizontalSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
                float verticalOffset = verticalSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime;

                Camera.main.transform.Translate(-horizontalOffset, -verticalOffset, 0);
            }
            
        }

    }

    public void ToggleShortRangeSoldierSelection()
    {
        ShortRangeSoldierSelected = !ShortRangeSoldierSelected;
        if (ShortRangeSoldierSelected)
        {
            ShortRangeSoldierButton.transform.localScale = new Vector3(1.2f, 1.2f,1.2f);
            ShortRangeSoldierButton.GetComponent<Image>().color = Color.cyan;
        }

        else
        {
            ShortRangeSoldierButton.transform.localScale = new Vector3(1f, 1f, 1f);
            ShortRangeSoldierButton.GetComponent<Image>().color = Color.gray;
        }

    }


    private void ShowSelectedLevel()
    {
        selectedLvl = PlayerPrefs.GetInt("Selected_Level");

        if (selectedLvl == 1)
        {
            level1.SetActive(true);
        }
        else if (selectedLvl == 2)
        {
            level2.SetActive(true);
        }
        else if (selectedLvl == 3)
        {
            level3.SetActive(true);
        }
        else Debug.Log("No level selected");
    }

    public void Ready()
    {
        ARcamera.SetActive(true);
        ARtarget.SetActive(true);
        SetUpUI.SetActive(false);
        StartBattleButton.SetActive(true);
        level1.transform.SetParent(ARtarget.transform);
        Army.transform.SetParent(ARtarget.transform);
        Battlefield.transform.SetParent(ARtarget.transform);
    }
    public void StartBattle()
    {
        Debug.Log("Start battle");
        isStarted = true;
    }

    public void deleteLast()
    {
        if(myArmy.Count >= 1)
        {
            GameObject SoldierToDelete = myArmy[myArmy.Count - 1];
            myArmy.RemoveAt(myArmy.Count - 1);
            Destroy(SoldierToDelete);
            money += 10;
            moneyLabel.text = money.ToString();
            quantityLabel.text = "x" + myArmy.Count.ToString();

        }
        
    }

}
