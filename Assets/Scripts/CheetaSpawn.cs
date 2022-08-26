using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheetaSpawn : MonoBehaviour
{
    [SerializeField] public List<GameObject> ScreenEnvironmentsStartingPoints;
    [SerializeField] public Animator MyAnimator;
    [SerializeField] public GameObject DefualtPos;

    private float counter;
    private int ScreenRnd = 1;
    private bool spawned = false;
    private bool ChIsMoving = false;

    int counterRnd;
    
    private void Start()
    {
        NewCheetha();
    }

    public void ImMoving()
    {
        ChIsMoving = true;
        print("visable");

    }
    public void ImHidden()
    {
        ChIsMoving = false;
        print("hidden");
    }
    public void NewCheetha() // sets the counterRnd and ScreenRnd to new random values
    {
        counterRnd = Random.Range(3, 8);
        ScreenRnd = Random.Range(0, ScreenEnvironmentsStartingPoints.Count);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ChIsMoving)
        {
            print("got you");
        }

        counter += Time.deltaTime;

        if (counter > 5 + counterRnd)  
        {
           // print("Cheetha wasnt found and is spawned again");
            spawned = false;
            this.transform.position = DefualtPos.transform.position;
            NewCheetha();
            counter = 0;
        }
          
        if (spawned) 
        {
            return;
        }

        if ( counter > counterRnd)
        {
           // print("spawn cheetha");
            this.transform.SetParent(null);
            this.transform.position = Vector3.zero;
            this.transform.parent = ScreenEnvironmentsStartingPoints[ScreenRnd].transform;
            //print("screen: "+ ScreenRnd);
            spawned = true;

            string trigger = "Screen" + (ScreenRnd+1);
           // print("trigger is "+trigger);
            MyAnimator.SetTrigger(trigger);
        }
       
    }
}
