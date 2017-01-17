using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Check the clampZIn and clampZOut if it's correct when you make a 3D game. this Code was done for a 2D game
* when you want a zoom just add a zoom button Insert it 
*/
public class MoveCamera : MonoBehaviour
{
    private PlayerController playerController;

    public float clampXLeft = -3f;
    public float clampXRight = 3f;
    public float clampYDown = -3f;
    public float clampYUp = 3f;
    public float clampZIn = -3f;
    public float clampZOut = -10f;

    void Start()
    {
        playerController = GameObject.FindWithTag(MyConst.Player).GetComponent<PlayerController>();
    }

    public Vector3 Move_Camera()
    {
        transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime, Input.GetAxisRaw("Mouse Y") * Time.deltaTime, /*Insert Zoom here*/0f);
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, playerController.transform.position.x + clampXLeft, playerController.transform.position.x + clampXRight),
            Mathf.Clamp(transform.position.y, playerController.transform.position.y + clampYDown, playerController.transform.position.y + clampYUp),
            Mathf.Clamp(transform.position.z, playerController.transform.position.z + clampZIn, playerController.transform.position.z + clampZOut));
        //maybe you have to change clampZIn with clampZOut i made it in 2D
        return transform.position;
    }
}
