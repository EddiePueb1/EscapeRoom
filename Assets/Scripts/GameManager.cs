using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] blastDoors;
    public float speed = 10f;
    public bool test = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void RaiseDoors()
    {
        for (int i = 0; i < blastDoors.Length; i++)
        {
            while(blastDoors[i].transform.position.y < 4)
            {
                blastDoors[i].transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (test)
        {
            RaiseDoors();
            test = false;
        }
    }
}
