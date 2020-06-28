using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class HackMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Text cons;
    public InputField input;
    public Canvas terminal;
    public Canvas gui;
    public PlayerBehavior player;
    private string[] commands = { "hack", "upgrade", "cls", "exit",};
    private string[] hackCommands = { "cls", "exit", "port", "hack" };
    private string[] upgradeCommands = {"cls", "exit", "saldo", "list", "attack", "speed", "ammo", "hp" };
    private string prompt = "/";
    private int option;
    private int flag = 0;
    private Parser pars;
    private Parser hackpars;
    private Parser uppars;
    private string memo;
    private string[] inp;
    public static HackPoint hcp;

    public void Start()
    {

    }

    public void Writter()
    {
        pars = new Parser(prompt, commands);
        hackpars = new Parser(prompt, hackCommands);
        uppars = new Parser(prompt, upgradeCommands);
        string[] tmp = cons.text.Split('\n');
        if (tmp.Length > 20)
        {
            cons.text = "";
        }
        inp = input.text.Split(' ');
        switch (flag)
        {
            case 0:
                 option = pars.validOption(inp[0]);
                MainMenu(option, ref flag);
                break;
            case 1:
                 option = hackpars.validOption(inp[0]);
                HackMen(option, ref flag);
                break;
            case 2:
                option = uppars.validOption(inp[0]);
                UpMen(option, ref flag);
                break;
        }

    }

    private void MainMenu(int option, ref int flag)
    {
        switch (option)
        {
            case 0:
                flag = 1;
                memo = cons.text;
                cons.text = "";
                cons.text = "HackTools";
                break;
            case 1:
                flag = 2;
                memo = cons.text;
                cons.text = "";
                cons.text = "Upgrade Systems";
                break;
            case 2:
                cons.text = "";
                break;
            case 3:
                terminal.enabled = false;
                gui.enabled = true;
                Time.timeScale = 1f;
                break;
            default:
                cons.text += "\ncomands: ";
                foreach (string x in commands)
                {
                    cons.text += "\n/" + x;
                }
                break;
        }
        input.text = "";
    }

    private void HackMen(int option, ref int flag)
    {
        switch (option)
        {
            case 0:
                cons.text = "";
                break;
            case 1:
                flag = 0;
                cons.text = memo;
                break;
            case 2:
                if(inp.Length == 1)
                {
                    cons.text += "Range pls";
                }
                if(inp.Length == 2)
                {
                    bool f = false;
                    for(int i = 1; i<=System.Convert.ToInt32(inp[1]);i++)
                    {
                        if (hcp.port == i)
                        {
                            cons.text += "+\nOpen Port: " + i;
                            f = true;
                            break;
                        }
                    }
                    if (!f)
                    {
                        cons.text += "\nAll ports lock in this range";
                    }
                   
                }
                break;

            case 3:
                if(inp.Length == 2)
                {
                    cons.text += hcp.PasswordBreak(System.Convert.ToInt32(inp[1]));
                    cons.text += "\nYou earned: " + hcp.password.Length * 3 + " $";
                    player.money += hcp.password.Length * 3;
                }
                else
                {
                    cons.text += "\n Port pls";
                }

                break;
            default:
                cons.text += "\ncomands: ";
                foreach (string x in hackCommands)
                {
                    cons.text += "\n/" + x;
                }
                break;
        }
        input.text = "";
    }

    private void UpMen(int option, ref int flag)
    {
        switch (option)
        {
            case 0:
                cons.text = "";
                break;
            case 1:
                flag = 0;
                cons.text = memo;
                break;
            case 2:
                cons.text += "\n"+player.money.ToString() + "$";
                break;
            case 3:
                cons.text += "\n1.Attack: " + player.weapon.damage + "+1 Cost: " + 100 * player.weapon.damage;
                cons.text += "\n2.Speed: " + player.speed + "+1 Cost: " + 100 * player.speed;
                cons.text += "\n3.Ammo: " + player.maxamo + "+5 Cost: " + 100 * player.maxamo / 5;
                cons.text += "\n4.HP: " + player.maxhp + "+5 Cost: " + 100 * player.maxhp / 5;
                break;
            case 4:
                  if(player.money - 100 * player.weapon.damage >= 0)
                {
                    player.money -= 100 * player.weapon.damage;
                    player.weapon.damage++;
                    cons.text += "\nAttack Dmg upgraded";
                }
                  else
                    cons.text += "Not enough money";
                break;
            case 5:
                if (player.money - 100 * player.speed >= 0)
                {
                    player.money -= System.Convert.ToInt32(player.speed * 100);
                    player.speed++;
                    cons.text += "\nSpeed upgraded";
                }
                cons.text += "Not enough money";
                break;
            case 6:
                if (player.money - 100 * player.maxamo >= 0)
                {
                    player.money -= 100 * player.maxamo;
                    player.maxamo += 5;
                    cons.text += "\nMax ammo upgraded";
                }
                else
                    cons.text += "Not enough money";
                break;
            case 7:
                if (player.money - 100 * player.maxhp >= 0)
                {
                    player.money -= 100 * player.maxhp;
                    player.maxhp += 5;
                    cons.text += "\nHP upgraded";
                }
                else
                    cons.text += "Not enough money";
                break;
            default:
                cons.text += "\ncomands: ";
                foreach (string x in upgradeCommands)
                {
                    cons.text += "\n/" + x;
                }
                break;
        }
        input.text = "";
    }
}
