using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheetaSpawn : MonoBehaviour
{
    [SerializeField] public List<GameObject> ScreenEnvironmentsStartingPoints;
    [SerializeField] public Transform DefualtPos;

    Animator myAnimator;
    private bool chIsMoving = false, spawned = false;
    private int randomScreen = 1, randomCounter = 0;
    private float counter = 0;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        NewCheetha();
    }

    void Update()
    {
        counter += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && chIsMoving)
        {
            print("got you");
        }

        if (counter > 5 + randomCounter && spawned)
        {
            // print("Cheetha wasnt found and is spawned again");
            spawned = false;
            transform.SetParent(DefualtPos, false);
            transform.position = Vector3.zero;
            NewCheetha();
            counter = 0;
        }

        if (counter > randomCounter && !spawned)
        {
            // print("spawn cheetha");
            transform.SetParent(ScreenEnvironmentsStartingPoints[randomScreen].transform, false);
            transform.rotation = Quaternion.identity;
            transform.localScale = Vector3.one;
            transform.position = Vector3.zero;

            spawned = true;

            string triggerName = "Screen" + (randomScreen + 1 /* +1 for animation naming comvention*/);
            myAnimator.SetTrigger(triggerName);
        }

    }

    public void ImMoving()
    {
        chIsMoving = true;
        print("visable");

    }

    public void ImHidden()
    {
        chIsMoving = false;
        print("hidden");
    }

    void NewCheetha() //Sets the randomCounter and randomScreen to new random values
    {
        randomCounter = Random.Range(3, 8);
        randomScreen = Random.Range(0, ScreenEnvironmentsStartingPoints.Count);
    }

}