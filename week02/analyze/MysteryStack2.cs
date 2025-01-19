public static class MysteryStack2 {
    private static bool IsFloat(string text) {
        return float.TryParse(text, out _);//checks to see if the text can be turned into a float, returns true or false depending on if TryParse worked
    }

    public static float Run(string text) {
        var stack = new Stack<float>();
        foreach (var item in text.Split(' ')) {//iterates through the text looking only at the items and ignoring any spaces.
            if (item == "+" || item == "-" || item == "*" || item == "/") {//if the item is +, -, *, or / this will run
                if (stack.Count < 2) //if the stack count less than 2 it will throw an exception "invalid case 1"
                    throw new ApplicationException("Invalid Case 1!");

                var op2 = stack.Pop();// removes the most recently added item  and assigns it to op2 
                var op1 = stack.Pop();// removes the second most recently additem and assigns it to op1
                float res;
                if (item == "+") {//if the item is a "+" this will add the op1 and op2 values together
                    res = op1 + op2;
                }
                else if (item == "-") { // if the item is "-" it will subtract op2 from op1
                    res = op1 - op2;
                }
                else if (item == "*") { // if the item is "*" it will multiply the two values
                    res = op1 * op2;
                }
                else {//If the value is none of the above this will start
                    if (op2 == 0)// if op2 = 0 then the "Invalid Case 2" error will throw
                        throw new ApplicationException("Invalid Case 2!");

                    res = op1 / op2;// if op2 is not 0 then this will op1,op2
                }

                stack.Push(res); //Adds whatever the res is to the end of our stack.
            }
            else if (IsFloat(item)) {//Uses IsFloat to see if the item can be a float number
                stack.Push(float.Parse(item));//adds the item to the end of the stack after changing it to a float number
            }
            else if (item == "") {//if the item is nothing, nothing  happens
            }
            else {// any other instance throws an exception "invalid Case 3"
                throw new ApplicationException("Invalid Case 3!");
            }
        }

        if (stack.Count != 1)//checks the stack count and if it is not equal to 1 "invalid Case 4" exception is thrown
            throw new ApplicationException("Invalid Case 4!");

        return stack.Pop();//removes and returns the number of the stack
    }
}

// program uses the most recent addition to the stack to determine if it is retaining the number for the stack or using the numbers to do the appropriate arithmatic
// string text = "5 3 7 + *"
// result= 50
// string text = "6 2 + 5 3 - / " 
//result = 4