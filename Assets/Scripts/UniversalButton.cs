using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UniversalButton : MonoBehaviour
{

  /* Button objects + settings */

  //Objects
  //Base -> Whatever base object set in place
  //Press -> Actual pressing object
  //  Make sure there is a collider attatched to this object
  //Collider -> duplicate press object and remove every mesh so that just the collider is there
  //  Add rigidbody (Schematic - true, Gravity - false)
  //AudioSource -> button press sound

  // OnPressed -> empty
  // OnRelease -> Collider object + working function
  // 
  // Start is called before the first frame update
  public GameObject button;
  public UnityEvent onPress;
  public UnityEvent onRelease;
  GameObject presser;
  AudioSource sound;
  bool isPressed;

  Vector3 currPos;

  void Start()
  {
    sound = GetComponent<AudioSource>();
    isPressed = false;
    currPos = transform.position;
        Debug.Log(currPos);

  }

  private void OnTriggerEnter(Collider other)
  {
    if (!isPressed)
    {
      button.transform.localPosition = new Vector3(0, currPos.y - 0.001f, 0 );
      presser = other.gameObject;
      onPress.Invoke();
      sound.Play();
      isPressed = true;
    }

  }

  private void OnTriggerExit(Collider other)

  {
    if (other.gameObject == presser)
    {
      button.transform.localPosition = new Vector3(0, currPos.y + 0.10f, 0
);
      onRelease.Invoke();
      isPressed = false;
    }

  }

  //Add functionality for button here
  //Ex. public void SomeFucntion();
  // set function directly on inspector
  // 



   public void SpawnObject()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        sphere.transform.localPosition = new Vector3(0, 1, 1);
        sphere.AddComponent<Rigidbody>();

    }
    
}
