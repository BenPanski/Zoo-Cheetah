using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheetaSpawn : MonoBehaviour
{
    [SerializeField] public List<GameObject> ScreenEnvironmentsStartingPoints;
    [SerializeField] public Animator MyAnimator;
    [SerializeField] public GameObject DefualtPos;

    private float counter;
    private int rnd = 9;
    private int ScreenRnd = 1;
    private bool spawned = false;

    int counterRnd;
    
    private void Start()
    {
        NewCheetha();
    }
    public void NewCheetha() // sets the counterRnd and ScreenRnd to new random values
    {
        counterRnd = Random.Range(3, 13);
        ScreenRnd = Random.Range(0, ScreenEnvironmentsStartingPoints.Count);

    }

    void Update()
    {
        counter += Time.deltaTime;

        if (counter > 15 + counterRnd) // if the counter is bigger then 15 +  
        {
            print("Cheetha wasnt found and is spawned again");
            spawned = false;
            this.transform.position = DefualtPos.transform.position;
            NewCheetha();
        }
          
        if (spawned) 
        {
            return;
        }

        if ( counter > rnd)
        {
            this.transform.SetParent(null); 
            this.transform.position = ScreenEnvironmentsStartingPoints[ScreenRnd].transform.position;
            this.transform.parent = ScreenEnvironmentsStartingPoints[ScreenRnd].transform;
            print("screen: "+ ScreenRnd);
            spawned = true;

            string trigger = "Screen" + (ScreenRnd + 1);
            print("trigger is "+trigger);
            MyAnimator.SetTrigger(trigger);
        }
       
    }
}
