using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField] GameObject pickupPopup;
    [SerializeField] Image loadingImage;
    [SerializeField] Image itemImage;
    public ItemManager.ItemCode itemID;

    [Header("Dont Touch")]
    public Item itemType;

    //game feel
    float initSpeed = 1f;
    Rigidbody2D rb;
    Vector2 randomDir;
    bool isLoading;
    float loadingCount;

    private void Start()
    {
        pickupPopup.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        randomDir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        randomDir.Normalize();

        // ItemManager.instance.ReturnItemType((int)itemID, gameObject);
        itemImage.sprite = ItemManager.instance.itemSprite[(int)itemID];
    }

    private void Update()
    {
        rb.velocity = randomDir * initSpeed;
        initSpeed = Mathf.MoveTowards(initSpeed, 0f, Time.deltaTime);


        if (isLoading)
        {
            loadingCount += Time.deltaTime;
            loadingImage.fillAmount = loadingCount;
            if (loadingCount >= 1)
            {
                //picked
                ItemSlots.instance.AddItemToSlot((int)itemID);
                Destroy(gameObject);
                //full inventory
            }
        }
        else
        {
            loadingCount = 0f;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            pickupPopup.SetActive(true);
            isLoading = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            pickupPopup.SetActive(false);
            isLoading = false;
        }
    }
}
