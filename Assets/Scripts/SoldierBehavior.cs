using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBehavior : MonoBehaviour
{

    private int selectedLvl;
    private GameObject currentLevel;
    private GameSetUp gameSetUp;

    private Transform target;
    private float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        selectedLvl = PlayerPrefs.GetInt("Selected_Level");
        currentLevel = GameObject.Find("Level" + selectedLvl.ToString());
        gameSetUp = GameObject.Find("GameSetUpController").GetComponent<GameSetUp>();
        GetNewTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameSetUp.isStarted)
        {
            if (target)
            {
                transform.LookAt(target);
                transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }

            else
            {
                GetNewTarget();
            }
        }
    }

    private void GetNewTarget()
    {
        target = currentLevel.transform.GetChild(Random.Range(0, currentLevel.transform.childCount - 1));
    }



}
