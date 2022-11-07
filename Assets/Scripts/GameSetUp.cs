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



    // Start is called before the first frame update
    void Start()
    {
        money = 100;
        moneyLabel.text = money.ToString();
        quantityLabel.text = "x0";

        ShowSelectedLevel();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePoint = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            if (ShortRangeSoldierSelected && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 300.0f))
                {
                    if(money >= 10 )
                    {
                        GameObject newSoldier = Instantiate(soldier, hit.point, Quaternion.identity, Army.transform);
                        myArmy.Add(newSoldier);
                        money -= 10;
                        moneyLabel.text = money.ToString();
                        quantityLabel.text = "x" + myArmy.Count.ToString();
                    }
                    

                }
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


    public void zoomIn()
    {
        if(Camera.main.transform.position.y > 5) Camera.main.transform.Translate(Vector3.forward * 2);
        else if (Camera.main.transform.position.y > 1) Camera.main.transform.Translate(Vector3.forward * 0.5f);
    }

    public void zoomOut()
    {

        if(Camera.main.transform.position.y < 5) Camera.main.transform.Translate(Vector3.back * 0.5f);
        else if (Camera.main.transform.position.y < 25) Camera.main.transform.Translate(Vector3.back  * 2);
    }

    public void goUp()
    {
        if (Camera.main.transform.position.y < 5) Camera.main.transform.Translate(Vector3.up * 0.2f);
        else Camera.main.transform.Translate(Vector3.up * 2);
    }

    public void goDown()
    {
        if (Camera.main.transform.position.y < 5) Camera.main.transform.Translate(Vector3.down * 0.2f);
        else Camera.main.transform.Translate(Vector3.down * 2);
    }

    public void goLeft()
    {
        if (Camera.main.transform.position.y < 5) Camera.main.transform.Translate(Vector3.left * 0.2f);
        else Camera.main.transform.Translate(Vector3.left * 2);
    }

    public void goRight()
    {
        if (Camera.main.transform.position.y < 5) Camera.main.transform.Translate(Vector3.right * 0.2f);
        else Camera.main.transform.Translate(Vector3.right * 2);
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
