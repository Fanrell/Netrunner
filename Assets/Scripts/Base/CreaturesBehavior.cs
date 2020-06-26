using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaturesBehavior : MonoBehaviour
{
    public int maxhp; //maksymalna ilość zdrowia
    public int currhp;//obecna ilość zdrowia
    public float speed;//szybkość poruszania się
    public int maxamo;//maksymalne ammo
    public int curramo;//obecne ammo
    public float slowTime;



    // Start is called before the first frame update
    protected virtual void Init()
    {
        currhp = maxhp;
        curramo = maxamo;
    }


    public virtual void TakeDamaged(int dmg, string type)
    {
        if (type == "damageble")
        {
            currhp -= dmg;
            Debug.Log("HP: " + currhp);
            if (currhp <= 0)
            {
                gameObject.SetActive(false);
                if (gameObject.tag == "Enemy")
                {
                    ChaosBehaviour.dmgIncreas();
                    ChaosBehaviour.hpIncreas();
                    Debug.Log(ChaosBehaviour.HpBoost);
                }
            }
        }
        if (type == "slow")
        {
            speed -= dmg;
            slowTime = Time.time + 5f;
        }
    }

    public virtual bool AddHp (int quantity)
    {
        bool used = false;
        if (quantity + currhp <= maxhp)
        {
            currhp += quantity;
            used = true;
        }

        else if (currhp < maxhp)
        {
            currhp = maxhp;
            used = true;
        }
        return used;
    }

    public virtual bool AddAmmo(int quantity)
    {
        bool used = false;
        if (quantity + curramo <= maxamo)
        {
            curramo += quantity;
            used = true;
        }

        else if (curramo < maxamo)
        {
            curramo = maxamo;
            used = true;
        }
        return used;
    }
}
