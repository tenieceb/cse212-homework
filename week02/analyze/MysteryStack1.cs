public static class MysteryStack1 {
    public static string Run(string text) {
        var stack = new Stack<char>();//a new stack where the letters of the text will be placed
        foreach (var letter in text)//separates each letter of the word/text and pushes them to the stack
            stack.Push(letter);

        var result = "";
        while (stack.Count > 0)//checks the stack count to be sure there's something in the stack as it goes through the stack, when the stack is empty it will end the while loop
            result += stack.Pop();//adds a letter to the result starting at the end and removes them from the stack.

        return result;//returns the string of the result.
    }
}

// Purpose of MysteryStack1.Run is to reverse the input text.

// string text = "racecar"
// result = "racecar"
// stressed = "desserts"
// a nut for a jar of tuna = "anut fo raj a rof tun a"
