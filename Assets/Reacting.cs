using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reacting : MonoBehaviour {

    private void OnEnable()
    {
        Wandering behavior = GetComponent<Wandering>();
        behavior.setAlive(true);
    }

    void hideEnemy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    public void React()
    {
        Wandering behavior = GetComponent<Wandering>();
        if (behavior != null)
        {
            behavior.setAlive(false);
        }
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        Invoke("hideEnemy", 2.0f);

        yield return new WaitForSeconds(1.5f);       
    }
}
