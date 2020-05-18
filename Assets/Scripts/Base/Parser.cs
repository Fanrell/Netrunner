class Parser
{
    private char prompt;
    private string[] commandList;
    public Parser(char prompt, string[] commandList)
    {
        this.prompt = prompt;
        this.commandList = commandList;
    }

    public bool validCommand(string command)
    {
        bool isValid = false;
        if (command[0] == prompt) isValid = true;
        return isValid;
    }

    public int validOption(string command)
    {
        int i = 0;
        foreach (string x in commandList)
        {
            if (x.ToLower() == command.Split(prompt)[1].ToLower()) break;
            i++;
        }
        return i;
    }
}
