using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CrackFloor : MonoBehaviour
{
    private Animator anima;
    AudioManager audioManager;
    private void Awake()
    {
        anima = GetComponent<Animator>();  
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>(); 
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anima.enabled = true;
            anima.Play("crack");
            audioManager.PlaySFX(audioManager.GroundCrack);
            StartCoroutine(delayCrackAnimation());

        }
    }

    IEnumerator delayCrackAnimation()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}


