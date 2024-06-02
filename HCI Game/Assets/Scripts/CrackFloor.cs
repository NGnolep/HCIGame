using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CrackFloor : MonoBehaviour
{
    private Animator anima;
    private void Awake()
    {
        anima = GetComponent<Animator>();   
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anima.enabled = true;
            anima.Play("crack");
            StartCoroutine(delayCrackAnimation());

        }
    }

    IEnumerator delayCrackAnimation()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}


