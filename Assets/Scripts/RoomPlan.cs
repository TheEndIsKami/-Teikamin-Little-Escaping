using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPlan : MonoBehaviour
{
    RoomGenerator rg;
    float distanceY, distanceX;
    Vector2 gatePosU, gatePosD, gatePosL, gatePosR;
    GameObject gateVer, gateHor;

    public int roomID;
    private void Awake()
    {
        rg = FindObjectOfType<RoomGenerator>();
        distanceX = rg.distanceX;
        distanceY = rg.distanceY;
        gatePosU = rg.gatePosU;
        gatePosD = rg.gatePosD;
        gatePosL = rg.gatePosL;
        gatePosR = rg.gatePosR;
        gateVer = rg.gateVer;
        gateHor = rg.gateHor;
    }
    void Start()
    {
        //check room neighbor and spawn room
        bool isUp = false, isDown = false, isLeft = false, isRight = false;
        Vector2 checkUp = new Vector2(transform.position.x, transform.position.y + distanceY);
        Vector2 checkDown = new Vector2(transform.position.x, transform.position.y - distanceY);
        Vector2 checkLeft = new Vector2(transform.position.x - distanceX, transform.position.y);
        Vector2 checkRight = new Vector2(transform.position.x + distanceX, transform.position.y);
        if (Physics2D.OverlapCircle(checkUp, 0.5f)) isUp = true;
        if (Physics2D.OverlapCircle(checkDown, 0.5f)) isDown = true;
        if (Physics2D.OverlapCircle(checkLeft, 0.5f)) isLeft = true;
        if (Physics2D.OverlapCircle(checkRight, 0.5f)) isRight = true;

        //spawn room
        if (isUp && !isDown && !isLeft && !isRight)
        {
            Instantiate(RoomPrefabs.instance.roomU, transform.position, Quaternion.identity);
        }
        else if (!isUp && isDown && !isLeft && !isRight)
        {
            Instantiate(RoomPrefabs.instance.roomD, transform.position, Quaternion.identity);
        }
        else if (!isUp && !isDown && isLeft && !isRight)
        {
            Instantiate(RoomPrefabs.instance.roomL, transform.position, Quaternion.identity);
        }
        else if (!isUp && !isDown && !isLeft && isRight)
        {
            Instantiate(RoomPrefabs.instance.roomR, transform.position, Quaternion.identity);
        }
        else if (isUp && isDown && !isLeft && !isRight)
        {
            Instantiate(RoomPrefabs.instance.roomUD, transform.position, Quaternion.identity);
        }
        else if (isUp && !isDown && isLeft && !isRight)
        {
            Instantiate(RoomPrefabs.instance.roomUL, transform.position, Quaternion.identity);
        }
        else if (isUp && !isDown && !isLeft && isRight)
        {
            Instantiate(RoomPrefabs.instance.roomUR, transform.position, Quaternion.identity);
        }
        else if (!isUp && isDown && isLeft && !isRight)
        {
            Instantiate(RoomPrefabs.instance.roomLD, transform.position, Quaternion.identity);
        }
        else if (!isUp && isDown && !isLeft && isRight)
        {
            Instantiate(RoomPrefabs.instance.roomRD, transform.position, Quaternion.identity);
        }
        else if (!isUp && !isDown && isLeft && isRight)
        {
            Instantiate(RoomPrefabs.instance.roomLR, transform.position, Quaternion.identity);
        }
        else if (isUp && isDown && isLeft && !isRight)
        {
            Instantiate(RoomPrefabs.instance.roomULD, transform.position, Quaternion.identity);
        }
        else if (isUp && isDown && !isLeft && isRight)
        {
            Instantiate(RoomPrefabs.instance.roomURD, transform.position, Quaternion.identity);
        }
        else if (isUp && !isDown && isLeft && isRight)
        {
            Instantiate(RoomPrefabs.instance.roomLUR, transform.position, Quaternion.identity);
        }
        else if (!isUp && isDown && isLeft && isRight)
        {
            Instantiate(RoomPrefabs.instance.roomLDR, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(RoomPrefabs.instance.roomUDLR, transform.position, Quaternion.identity);
        }

        //spawn gate
        if (isUp)
        {
            Vector2 gatePos = new Vector2(transform.position.x + gatePosU.x, transform.position.y + gatePosU.y);
            Instantiate(gateHor, gatePos, Quaternion.identity);
        }
        if (isDown)
        {
            Vector2 gatePos = new Vector2(transform.position.x + gatePosD.x, transform.position.y + gatePosD.y);
            Instantiate(gateHor, gatePos, Quaternion.identity);
        }
        if (isRight)
        {
            Vector2 gatePos = new Vector2(transform.position.x + gatePosR.x, transform.position.y + gatePosR.y);
            Instantiate(gateVer, gatePos, Quaternion.identity);
        }
        if (isLeft)
        {
            Vector2 gatePos = new Vector2(transform.position.x + gatePosL.x, transform.position.y + gatePosL.y);
            Instantiate(gateVer, gatePos, Quaternion.identity);
        }
    }

    private void LateUpdate()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
