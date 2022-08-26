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

    private void Start()
    {
       int counterRnd = Random.Range(3, 13);
       int ScreenRnd = Random.Range(0, ScreenEnvironmentsStartingPoints.Count);
        
    }
    void Update()
    {
        counter += Time.deltaTime;

        if (counter > 15 + rnd)
            spawned = false;

        this.transform.position = DefualtPos.transform.position;
        
        if (spawned) 
        {
            return;
        }

        

        if ( counter > rnd)
        {
            //spawn cheetha
            this.transform.position = ScreenEnvironmentsStartingPoints[ScreenRnd].transform.position;
            spawned = true;

            string trigger = "Screen" + (ScreenRnd + 1);
            print(trigger);
            MyAnimator.SetTrigger(trigger);
        }
       
    }
}
