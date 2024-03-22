using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealtController : MonoBehaviour
{
    public int maxHealt;
    public int nowHealt;
    public float freeDamageTime;
    float counterDamageFreeTime;
    [SerializeField]
    GameObject destroyEffect;
    CanvasController canvasController;
    PlayerController playerController;
    SpriteRenderer sr;
    
    private void Awake()
    {
        playerController = Object.FindObjectOfType<PlayerController>();
        sr = GetComponent<SpriteRenderer>();
        canvasController = Object.FindObjectOfType<CanvasController>();
        
        
    }
    private void Start()
    {
        nowHealt = maxHealt;
    }
    private void Update()
    {
        counterDamageFreeTime = counterDamageFreeTime - Time.deltaTime;
        if(counterDamageFreeTime <= 0) 
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
        }

    }

    public void TakenDamage()
    {
        if(counterDamageFreeTime <= 0) 
        {
            nowHealt--;
            if (nowHealt <= 0)
            {
                nowHealt = 0;
                gameObject.SetActive(false);
                Instantiate(destroyEffect, transform.position, transform.rotation);
            }
            else
            {
                counterDamageFreeTime = freeDamageTime;  
                sr.color = new Color(sr.color.r,sr.color.g,sr.color.b,0.5f);
                playerController.repulseFNC();
            }
            canvasController.UpdateHealtSituation();
        }
        
    }
    public void enhanceFNC()
    {
        nowHealt++;
        if (nowHealt==maxHealt) 
        {
            maxHealt = nowHealt;        
        }
        canvasController.UpdateHealtSituation();
    }
}
