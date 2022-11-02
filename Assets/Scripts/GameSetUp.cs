using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSetUp : MonoBehaviour
{

    private bool ShortRangeSoldierSelected = false;
    public GameObject ShortRangeSoldierButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
