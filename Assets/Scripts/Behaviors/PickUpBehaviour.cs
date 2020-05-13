using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBehaviour : MonoBehaviour
{
    public int quantity = 1;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            bool used = false;
            PlayerBehavior player = other.gameObject.GetComponent<PlayerBehavior>();
            switch(gameObject.tag)
            {
                case ("PickUpHp"):
                    used = player.AddHp(quantity);
                    break;
                case ("PickUpAmmo"):
                    used = player.AddAmmo(quantity);
                    break;
            }

            gameObject.SetActive(!used);
        }
    }
}
