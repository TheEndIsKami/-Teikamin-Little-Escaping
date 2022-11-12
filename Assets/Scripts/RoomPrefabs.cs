using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPrefabs : MonoBehaviour
{
    public static RoomPrefabs instance;
    public GameObject roomPlan;
    public GameObject roomU, roomL, roomR, roomD, roomRD, roomLD, roomUL, roomUR, roomUD, roomLR, roomLDR, roomURD, roomULD, roomLUR, roomUDLR;

    private void Awake()
    {
        instance = this;
    }
}
