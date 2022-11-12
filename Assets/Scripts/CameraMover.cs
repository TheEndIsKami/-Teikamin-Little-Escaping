using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] float speed = 4f;
    Vector3 camPos, newPos;
    PlayerController player;
    private void Start()
    {
        player = PlayerController.instance;
    }
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.tag == "RoomLogical")
    //    {
    //        camPos = other.GetComponentInParent<RoomPlan>().transform.position;
    //        newPos = new Vector3(camPos.x, camPos.y, Camera.main.transform.position.z);
    //    }
    //}
    private void Update()
    {
        //follow player
        newPos = new Vector3(player.transform.position.x, player.transform.position.y, Camera.main.transform.position.z);
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, newPos, Time.deltaTime * speed);
    }
}
