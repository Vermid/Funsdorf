using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash_Charge_Blink : MonoBehaviour {

    private Vector3 mousVector;
    private MoveCamera cam;
    private bool dash = true;
    private PlayerController playerController;
    public float clampXLeft = -3f;
    public float clampXRight = 3f;
    public float clampYDown = -3f;
    public float clampYUp = 3f;
    public float clampZIn = -3f;
    public float clampZOut = -10f;
    // Use this for initialization
    void Start () {
        cam = GetComponentInChildren<MoveCamera>();//  GameObject.FindWithTag("MainCamera").GetComponent<MoveCamera>();
        playerController = GetComponent<PlayerController>();
    }



    public void Dash( Vector3 mousVector)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(
    Mathf.Clamp(transform.position.x, playerController.transform.position.x + clampXLeft, playerController.transform.position.x + clampXRight),
    Mathf.Clamp(transform.position.y, playerController.transform.position.y + clampYDown, playerController.transform.position.y + clampYUp),
    Mathf.Clamp(transform.position.z, playerController.transform.position.z + clampZIn, playerController.transform.position.z + clampZOut));

        mousePos.z = 0;

        mousVector.z = 0;
        if (dash)
        {
            transform.position = mousePos;
            dash = !dash;
            Invoke(MyConst.Cooldown, 5);
        }
    }
     
    void Cooldown()
    {
        dash = !dash;
    }

}
