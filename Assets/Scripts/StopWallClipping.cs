using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWallClipping : MonoBehaviour
{
    //Gameobjects that need to be toggled by the script
    public GameObject messagePanel;
    public GameObject text;
    public GameObject room;

    //Fields that control overlay fading
    [SerializeField] LayerMask collisionLayer;
    [SerializeField] float fadeSpeed;
    [SerializeField] float sphereCheckSize = .15f;

    private Material cameraFadeMat;
    private bool isCameraFaded = false;


    private void Awake()
    {
        //Gets the camera overlay material
        cameraFadeMat = messagePanel.GetComponent<Renderer>().material;
    }

    private void Update()
    {
        //If the player's head is colliding with an object out its layer
        if(Physics.CheckSphere(transform.position, sphereCheckSize, collisionLayer, QueryTriggerInteraction.Ignore))
        {
            //Turn on the camera overlay
            CameraFade(1f);

            //Start a delay and then fade out the scene
            StartCoroutine(Delay(0.5f, false));
        }
        //Otherwise
        else
        {   
            //If the camera is no currently faded return
            if (!isCameraFaded)
            {
                return;
            }

            //If the camera is currently faded out
            //Fade the scene back in
            FadeIn();

            //Start a delay and then turn off the camera overlay
            StartCoroutine(Delay(0.5f, true));
        }
    }

    
    //Starts a delay before fading the scene in or out
    IEnumerator Delay(float delay, bool fadeIn)
    {
        //Delays
        yield return new WaitForSeconds(delay);

        //Either fades the scene in or out
        if (fadeIn)
        {
            CameraFade(0f);
        }
        else
        {
            FadeOut();
        }
    }


    //Fades the scene back in
    private void FadeIn()
    {
        //Disables warning text
        text.SetActive(false);

        //Enables the clock canvas
        room.GetComponentInChildren<Canvas>().enabled = true;

        //Gets all meshrenderers in the scene and enables them
        MeshRenderer[] meshes = room.GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < meshes.Length; i++)
        {
            meshes[i].enabled = true;
        }
    }


    //Fades the scene out
    private void FadeOut()
    {
        //Enables warning text
        text.SetActive(true);

        //Disables clock canvas
        room.GetComponentInChildren<Canvas>().enabled = false;

        //Gets all meshrenderers in the scene and disables them
        MeshRenderer[] meshes = room.GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < meshes.Length; i++)
        {
            meshes[i].enabled = false;
        }

        //Sets the camera to faded
        isCameraFaded = true;
    }


    //Fades the camera overlay to the given alpha value
    public void CameraFade(float targetAlpha)
    {
        //Lerp the camera fade value towards the target alpha
        var fadeValue = Mathf.MoveTowards(cameraFadeMat.GetFloat("_AlphaValue"), targetAlpha, Time.deltaTime * fadeSpeed);
        cameraFadeMat.SetFloat("_AlphaValue", fadeValue);

        //If fades value is 0 camera is not faded
        if(fadeValue <= 0.01f)
        {
            isCameraFaded = false;
        }
    }
}
