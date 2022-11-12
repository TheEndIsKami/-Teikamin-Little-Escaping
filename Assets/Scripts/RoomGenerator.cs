using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    [SerializeField] Transform generatorPoint;
    public float distanceX, distanceY;
    public Vector2 gatePosU, gatePosD, gatePosL, gatePosR;
    public GameObject gateHor, gateVer;
    [SerializeField] int mapSize = 10;

    List<Transform> planRoom = new List<Transform>();
    enum Direction { UP, RIGHT, LEFT, DOWN };

    private void Start()
    {
        //reset gen point
        generatorPoint.position = new Vector2(0f, 0f);
        for (int roomIndex = 1; roomIndex <= mapSize; roomIndex++)
        {
            if (roomIndex == 1)
            {
                GameObject roomPlanStart = Instantiate(RoomPrefabs.instance.roomPlan, generatorPoint.position, Quaternion.identity) as GameObject;
                roomPlanStart.GetComponent<RoomPlan>().roomID = roomIndex;
            }
            else
            {
                SpawnNextRoom();
                GameObject roomPlan = Instantiate(RoomPrefabs.instance.roomPlan, generatorPoint.position, Quaternion.identity) as GameObject;
                roomPlan.GetComponent<RoomPlan>().roomID = roomIndex;
            }
        }
    }

    private void SpawnNextRoom()
    {
        //spawn endRoom
        Direction randomDir = (Direction)Random.Range(0, 3);
        float newGenPosX = generatorPoint.position.x;
        float newGenPosY = generatorPoint.position.y;
        switch (randomDir)
        {
            case Direction.UP: newGenPosY += distanceY; break;
            case Direction.RIGHT: newGenPosX += distanceX; break;
            case Direction.LEFT: newGenPosX -= distanceX; break;
            case Direction.DOWN: newGenPosY -= distanceY; break;
            default: newGenPosY += distanceY; break;
        }
        generatorPoint.position = new Vector2(newGenPosX, newGenPosY);
        while (Physics2D.OverlapCircle(generatorPoint.position, 0.5f))
        {
            generatorPoint.position = new Vector2(newGenPosX, newGenPosY + distanceY);
        }
    }
}

