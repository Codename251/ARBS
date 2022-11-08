using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonPV : MonoBehaviour
{
    private int PV;
    private bool isDead;

    private GameSetUp gameSetUp;

    // Start is called before the first frame update
    void Start()
    {
        PV = 10;
        isDead = false;
        gameSetUp = GameObject.Find("GameSetUpController").GetComponent<GameSetUp>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "TT_RTS_Demo_Character(Clone)")
        {
            if (Random.Range(0.0f, 1.0f) < 0.5f && !isDead && gameSetUp.isStarted)
            {
                PV -= 1;
                if (PV == 0) isDead = true;
                print("Squelette : " + PV);
            }


        }
    }
}
