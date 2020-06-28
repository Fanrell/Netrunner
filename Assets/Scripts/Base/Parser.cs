using UnityEngine;

class Parser
{
    private char prompt;
    private string[] commandList;
    public Parser(string prompt, string[] commandList)
    {
        this.prompt = prompt[0];
        this.commandList = commandList;
    }

    public bool validCommand(string command)
    {
        bool isValid = false;
        if (command != ""&&command[0] == prompt) isValid = true;
        return isValid;
    }

    public int validOption(string command)
    {
        if (validCommand(command))
            {
            int i = 0;
            foreach (string x in commandList)
            {
                if (x.ToLower() == command.Split(prompt)[1].ToLower()) break;
                i++;
            }
            return i;
        }
        return -1;
    }
}
