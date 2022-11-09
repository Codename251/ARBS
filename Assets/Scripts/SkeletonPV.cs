using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonPV : MonoBehaviour
{
    private int PV;
    private bool isDead;
    public bool isAttacking;

    private GameSetUp gameSetUp;

    public float attackRate = 0.2f;
    private float timeSinceLastAttack = 0;

    // Start is called before the first frame update
    void Start()
    {
        PV = 10;
        isDead = false;
        gameSetUp = GameObject.Find("GameSetUpController").GetComponent<GameSetUp>();
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            Destroy(this.gameObject);
        }

        if (isAttacking)
        {
            timeSinceLastAttack += Time.deltaTime;

            if (timeSinceLastAttack >= attackRate)
            {
                timeSinceLastAttack = 0f;
                losePV();
            }

        }
    }

    void OnCollisionEnter(Collision collision)
    {

        

        if (collision.gameObject.name == "TT_RTS_Demo_Character(Clone)")
        {

            isAttacking = true;

            transform.GetComponent<Animator>().SetBool("isAttacking", true);     


        }
    }


    private void losePV()
    {
        if (Random.Range(0.0f, 1.0f) < 0.5f && !isDead && gameSetUp.isStarted)
        {
            PV -= 1;
            if (PV == 0) isDead = true;
            print("Squelette : " + PV);
        }

    }
}
