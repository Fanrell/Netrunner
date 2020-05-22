using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class TerminalBehaviour : MonoBehaviour
{
    private Light illumine;
    private float intens = 0.5f;
    public int intensMax = 5;
 
    // Start is called before the first frame update
    void Start()
    {
        illumine = GetComponent<Light>();
    }

    private void ChangeIntense()
    { 
        illumine.range += intens * Time.deltaTime;
        if (illumine.range >= intensMax) intens = -0.5f;
        else if (illumine.range <= 0) intens = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeIntense();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Interact");
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
    }
}
