using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSetUp : MonoBehaviour
{

    private bool ShortRangeSoldierSelected = false;
    public GameObject ShortRangeSoldierButton;

    public GameObject soldier;

    private float dist;
    private Vector3 v3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePoint = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            if (ShortRangeSoldierSelected)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 300.0f))
                {
                    GameObject newSoldier = Instantiate(soldier, hit.point, Quaternion.identity);
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
        if(Camera.main.transform.position.y > 50) Camera.main.transform.Translate(Vector3.forward * 50);
        else if (Camera.main.transform.position.y > 10) Camera.main.transform.Translate(Vector3.forward * 10);
    }

    public void zoomOut()
    {

        if(Camera.main.transform.position.y < 50) Camera.main.transform.Translate(Vector3.back * 10);
        else if (Camera.main.transform.position.y < 250) Camera.main.transform.Translate(Vector3.back  * 50);
    }

    public void goUp()
    {
        if (Camera.main.transform.position.y < 50) Camera.main.transform.Translate(Vector3.up * 10);
        else Camera.main.transform.Translate(Vector3.up * 50);
    }

    public void goDown()
    {
        if (Camera.main.transform.position.y < 50) Camera.main.transform.Translate(Vector3.down * 10);
        else Camera.main.transform.Translate(Vector3.down * 50);
    }

    public void goLeft()
    {
        if (Camera.main.transform.position.y < 50) Camera.main.transform.Translate(Vector3.left * 10);
        else Camera.main.transform.Translate(Vector3.left * 50);
    }

    public void goRight()
    {
        if (Camera.main.transform.position.y < 50) Camera.main.transform.Translate(Vector3.right * 10);
        else Camera.main.transform.Translate(Vector3.right * 50);
    }


}
