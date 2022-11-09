using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBehavior : MonoBehaviour
{
    
    private GameSetUp gameSetUp;
    private GameObject MyArmy; 

    private Transform target;
    private float speed = 0.1f;

    private bool isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        MyArmy = GameObject.Find("MyArmy");
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

            else if(target == null)
            {
                GetNewTarget();
            }
        }
    }

    private void GetNewTarget()
    {
        if(MyArmy.transform.childCount > 0)
        {
            target = MyArmy.transform.GetChild(Random.Range(0, MyArmy.transform.childCount - 1));
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {



        if (collision.gameObject.name == "TT_RTS_Demo_Character(Clone)")
        {

            isAttacking = true;

         

        }
    }

}
