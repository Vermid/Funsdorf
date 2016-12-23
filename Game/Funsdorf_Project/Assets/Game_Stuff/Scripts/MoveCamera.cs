using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Checkt the Box Collider x and y to set addforce up down left right
*/
public class MoveCamera : MonoBehaviour
{

    private bool up = false;
    private BoxCollider2D bc2d;
    private Vector2 boxSize;
    void Start()
    {
        bc2d = GameObject.FindGameObjectWithTag("PlayerCameraCollider").GetComponent<BoxCollider2D>();
        boxSize = bc2d.bounds.size;
        Debug.Log(bc2d);
    }


    void OnTriggerEnter2d(Collider2D other)
    {
        if (other.gameObject.tag == "MainCamera")
            ;
    }



    public void Move_Camera()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Debug.Log(boxSize.x);


        //mousePos = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.transform.position.y - transform.position.y));
        //targetRotation = Quaternion.LookRotation(mousePos - new Vector3(transform.position.x, 0, transform.position.z));
        //transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
        //cam.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 2);

        //Down
        //if (mousePos.x < (gameObject.transform.position.x + 2) && mousePos.x > (gameObject.transform.position.x - 2) && mousePos.y < gameObject.transform.position.y)
        //{
        //    if (cam.transform.position.y < (gameObject.transform.position.y + 3))
        //        cam.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 2);
        //}
        ////Up
        //else if (mousePos.x < (gameObject.transform.position.x + 2) && mousePos.x > (gameObject.transform.position.x - 2) && mousePos.y > gameObject.transform.position.y)
        //{
        //    Debug.Log("TURE"); if (cam.transform.position.y > (gameObject.transform.position.y + 3))
        //        cam.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 2);
        //}
        //Left
        //else if (mousePos.y < (gameObject.transform.position.y + 2) && mousePos.y > (gameObject.transform.position.y - 2) && mousePos.x < gameObject.transform.position.x)
        //    cam.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 2);
        //Right
        //else if (mousePos.y < (gameObject.transform.position.y + 2) && mousePos.y > (gameObject.transform.position.y - 2) && mousePos.x > gameObject.transform.position.x)
        //    cam.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 2);


        //    cam.GetComponent<Rigidbody2D>().AddForce(Vector2. * 2);

        //Down
        //if (mousePos.x < (gameObject.transform.position.x + 2) && mousePos.x > (gameObject.transform.position.x - 2) && mousePos.y < gameObject.transform.position.y)
        //    cam.transform.position = new Vector3(gameObject.transform.position.x , (gameObject.transform.position.y - camDistance), -10);
        ////Up
        //else if (mousePos.x < (gameObject.transform.position.x + 2) && mousePos.x > (gameObject.transform.position.x - 2) && mousePos.y > gameObject.transform.position.y)
        //    cam.transform.position = new Vector3(gameObject.transform.position.x , (gameObject.transform.position.y + camDistance), -10);
        ////Left
        //else if (mousePos.y < (gameObject.transform.position.y + 2) && mousePos.y > (gameObject.transform.position.y - 2) && mousePos.x < gameObject.transform.position.x)
        //    cam.transform.position = new Vector3((gameObject.transform.position.x - camDistance), gameObject.transform.position.y, -10);
        ////Right
        //else if (mousePos.y < (gameObject.transform.position.y + 2) && mousePos.y > (gameObject.transform.position.y - 2) && mousePos.x > gameObject.transform.position.x)
        //    cam.transform.position = new Vector3((gameObject.transform.position.x + camDistance), gameObject.transform.position.y , -10);

        ////Cross
        ////RightUp
        //else if (mousePos.x > (gameObject.transform.position.x + 2) && mousePos.y > (gameObject.transform.position.y + 2))
        //cam.transform.position = new Vector3((gameObject.transform.position.x + camDistance), (gameObject.transform.position.y + camDistance), -10);

        ////RightUp
        //else if (mousePos.x > (gameObject.transform.position.x + 2) && mousePos.y > (gameObject.transform.position.y + 2))
        //    cam.transform.position = new Vector3((gameObject.transform.position.x + camDistance), (gameObject.transform.position.y + camDistance), -10);
        ////RightDown
        //else if (mousePos.x > (gameObject.transform.position.x + 2) && mousePos.y < (gameObject.transform.position.y - 2))
        //    cam.transform.position = new Vector3((gameObject.transform.position.x + camDistance), (gameObject.transform.position.y - camDistance), -10);
        ////LeftUp
        //else if (mousePos.x < (gameObject.transform.position.x - 2) && mousePos.y > (gameObject.transform.position.y + 2))
        //    cam.transform.position = new Vector3((gameObject.transform.position.x - camDistance), (gameObject.transform.position.y + camDistance), -10);
        ////LeftDown
        //else if (mousePos.x < (gameObject.transform.position.x - 2) && mousePos.y < (gameObject.transform.position.y - 2))
        //    cam.transform.position = new Vector3((gameObject.transform.position.x - camDistance), (gameObject.transform.position.y - camDistance), -10);

        //else
        //    cam.transform.position = startMCam.po;
    }
}
