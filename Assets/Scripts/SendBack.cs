using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SendBack : MonoBehaviour
{
    private void OnTriggerEnter(Collider Player)
    {
        SceneManager.LoadScene(2);
    }
}
