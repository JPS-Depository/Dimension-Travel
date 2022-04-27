using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class Car2DController : MonoBehaviour
{
    public float speedForce = 10f;
    public float torqueForce = -200f;
    public float driftFactorSticky = 0.9f;
    public float driftFactorSlippy = 1f;
    public float maxStickyVelocity = 2.5f;
    public float minStickyVelocity = 1.5f;
    public float boostFactor = 1.5f;

    public float velocityBoostedReq = 23f;
    public bool boosted = false;
    public GameObject gameOverPanel;

    public float carHealth = 100f;
    public Button boostButton;
    public Button switchDimensionBtn;

    public int nextLevel = 0;
    private int numberItem;

    public Text timerDisplay;
    public Text nextLevelNotif;

    public float dimensionTimer = 5f;
    public float timeLeft;
    private bool velocityAccepted = false;

    private ItemsStatus itemsStatus;

    private void Start()
    {
        timeLeft = dimensionTimer;

        //itemsStatus = (ItemsStatus)FindObjectOfType(typeof(ItemsStatus));

        
    }

    private void Update()
    {
        itemsStatus = FindObjectOfType<ItemsStatus>();

        if (itemsStatus.currentLevel == 1 && (itemsStatus.items1_1 || itemsStatus.items1_2))
        {
            boostButton.gameObject.SetActive(true);

            //add switching dimension button
            if (itemsStatus.items1_1 && itemsStatus.items1_2)
            {
                switchDimensionBtn.gameObject.SetActive(true);
                nextLevelNotif.gameObject.SetActive(true);
            }
        }
        else if (itemsStatus.currentLevel == 2 && (itemsStatus.items2_1 || itemsStatus.items2_2))
        {
            boostButton.gameObject.SetActive(true);

            //add switching dimension button
            if (itemsStatus.items2_1 && itemsStatus.items2_2)
            {
                switchDimensionBtn.gameObject.SetActive(true);
                nextLevelNotif.gameObject.SetActive(true);
            }
        }
        else if (itemsStatus.currentLevel == 3 && (itemsStatus.items3_1 || itemsStatus.items3_2))
        {
            boostButton.gameObject.SetActive(true);

            //add switching dimension button
            if (itemsStatus.items3_1 && itemsStatus.items3_2)
            {
                switchDimensionBtn.gameObject.SetActive(true);
                nextLevelNotif.gameObject.SetActive(true);
            }
        }

        if (velocityAccepted)
        {
            timeLeft -= Time.deltaTime;
            timerDisplay.gameObject.SetActive(true);
            timerDisplay.text = timeLeft.ToString();
        }
        else
        {
            timeLeft = dimensionTimer;
            timerDisplay.gameObject.SetActive(false);
        }

        if(timeLeft < 0)
        {
            SceneManager.LoadScene("Map" + nextLevel);
            FindObjectOfType<ItemsStatus>().currentLevel = nextLevel;
        }
    }

    void FixedUpdate()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        float driftFactor = driftFactorSticky;
        if(RightVelocity().magnitude > maxStickyVelocity)
        {
            driftFactor = driftFactorSlippy;
        }
        
        rb.velocity = ForwardVelocity() + RightVelocity()*driftFactor;

        if (CrossPlatformInputManager.GetButton("Accelerate"))
        {
            if(boosted)
            {
                rb.AddForce(transform.up * speedForce * boostFactor);
            }
            else
            {
                rb.AddForce(transform.up * speedForce);
            }
        }

        if (CrossPlatformInputManager.GetButton("Break"))
        {
            rb.AddForce(transform.up * -speedForce/2f);
        }

        float tf = Mathf.Lerp(0, torqueForce, rb.velocity.magnitude / 2.5f);


        rb.angularVelocity = CrossPlatformInputManager.GetAxis("Horizontal") * torqueForce ;

        //Debug.Log(rb.velocity.magnitude);

        if (rb.velocity.magnitude > velocityBoostedReq)
        {
            //Debug.Log("Change to level" + level);
            //SceneManager.LoadScene("Map" + level);
            velocityAccepted = true;
        }
        else
        {
            velocityAccepted = false;
        }

        if (carHealth <= 0)
        {
            Destroy(this.gameObject);
            gameOverPanel.SetActive(true);
        }
    }

    Vector2 ForwardVelocity()
    {
        return transform.up * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.up);
    }

    Vector2 RightVelocity()
    {
        return transform.right * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.right);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            carHealth -= 10f;
        }

        if (collision.gameObject.tag == "Bullet")
        {
            carHealth -= 5f;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lava")
        {
            carHealth -= 5f;
            Debug.Log("ngidak lava");
        }

        if (collision.gameObject.tag == "Ice")
        {
            
            Debug.Log("dalan lunyu");
        }

        if (collision.gameObject.tag == "Collective")
        {
            //boostButton.gameObject.SetActive(true);
            nextLevel = collision.gameObject.GetComponent<CollectiveItem>().nextLevel;
            numberItem = collision.gameObject.GetComponent<CollectiveItem>().numberItem;

            switch (numberItem)
            {
                case 1:
                    //itemsStatus.items1_1 = true;
                    FindObjectOfType<ItemsStatus>().items1_1 = true;
                    break;
                case 2:
                    //itemsStatus.items1_2 = true;
                    FindObjectOfType<ItemsStatus>().items1_2 = true;
                    break;
                case 3:
                    //itemsStatus.items2_1 = true;
                    FindObjectOfType<ItemsStatus>().items2_1 = true;
                    break;
                case 4:
                    //itemsStatus.items2_1 = true;
                    FindObjectOfType<ItemsStatus>().items2_2 = true;
                    break;
                case 5:
                    //itemsStatus.items2_1 = true;
                    FindObjectOfType<ItemsStatus>().items3_1 = true;
                    break;
                case 6:
                    //itemsStatus.items2_1 = true;
                    FindObjectOfType<ItemsStatus>().items3_2 = true;
                    break;
            }

            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lava")
        {
            carHealth -= 0.5f;
            Debug.Log("ngidak lava");
        }
    }
}
