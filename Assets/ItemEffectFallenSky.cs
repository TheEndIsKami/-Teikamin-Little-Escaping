using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffectFallenSky : MonoBehaviour
{
    [SerializeField] ItemEffectFallenSkyWarningCircle warningCircle;
    [SerializeField] float timeDrop;
    [SerializeField] GameObject dmgZone;
    [SerializeField] GameObject fXWhenContact;
    [SerializeField] GameObject lavarFX;
    public bool isLavar;
    public float lavarDmg;
    public float lavarTime;
    public float mainDmg = 10f;

    public float radius = 1f;

    float dmgingTime = 0.5f;
    bool isDmgingTime;

    CameraShake camera;
    bool isShaked;
    Vector3 targetPos;
    SpriteRenderer sr;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        warningCircle.timeWarn = timeDrop + 0.2f;
        camera = FindObjectOfType<CameraShake>();
    }
    private void Start()
    {
        sr.enabled = false;
        dmgZone.gameObject.SetActive(false);
        dmgZone.GetComponent<PlayerBullet>().damage = mainDmg;
        Instantiate(warningCircle, transform.position, transform.rotation);
        targetPos = transform.position;
        transform.position += new Vector3(0f, 20f, transform.position.z);
        transform.localScale = transform.localScale * radius;
    }
    private void Update()
    {
        timeDrop -= Time.deltaTime;
        if (timeDrop <= 0 && !isShaked)
        {
            sr.enabled = true;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * 50f);
        }

        if (transform.position == targetPos && !isShaked)
        {
            camera.Play(0.1f, 0.1f);
            isShaked = true;
            dmgZone.gameObject.SetActive(true);
            GameObject fx = Instantiate(fXWhenContact, transform.position, transform.rotation) as GameObject;
            Destroy(fx, 2f);
            sr.enabled = false;
            isDmgingTime = true;
            if (isLavar)
            {
                GameObject lavar = Instantiate(lavarFX, transform.position, transform.rotation) as GameObject;
                Destroy(lavar, lavarTime);
                lavar.GetComponent<ItemEffectFallenSkyLavar>().lavarDmg = lavarDmg;
                isLavar = false;
            }
        }

        if (isDmgingTime)
        {
            dmgingTime -= Time.deltaTime;
            if (dmgingTime <= 0 && dmgZone.gameObject != null) dmgZone.gameObject.SetActive(false);
        }
    }
}
