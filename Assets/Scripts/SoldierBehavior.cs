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

    private bool isAttacking;

    

    // Start is called before the first frame update
    void Start()
    {
        selectedLvl = PlayerPrefs.GetInt("Selected_Level");
        currentLevel = GameObject.Find("Level" + selectedLvl.ToString());
        gameSetUp = GameObject.Find("GameSetUpController").GetComponent<GameSetUp>();
        GetNewTarget();
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameSetUp.isStarted)
        {
            transform.GetComponent<Animator>().SetBool("isStarted", true);
            transform.LookAt(target);
            transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
            if (target && !isAttacking)
            {
                
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }

            else if(target == null && isAttacking)
            {
                isAttacking = false;
                GetNewTarget();
            }
        }
    }

    private void GetNewTarget()
    {
        if(currentLevel.transform.childCount > 0)
        {
            target = currentLevel.transform.GetChild(Random.Range(0, currentLevel.transform.childCount - 1));
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "LowPolySkeleton")
        {

            isAttacking = true;


        }
    }



}
