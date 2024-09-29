namespace DebugExample
{
    // Stack overflow is not just one of the best websites there is for a coder,
    // it is also a concept in programming
    // 1) Read about the concept, then try this code out.
    // 2) Test to run this code with a debugger. What do you see?
    // 3) Try to understand what recursion does and why this gives an error.
    // 4) Check the call stack in the debugger.
    // 5) Once you understand you can just conclude that the code in this file is pointless.
    //    There is nothing more to be done here. However...
    // 6) Somewhere else (in another file) in this code, there is another recursion hidden.
    //      This is wrong and gives an ugly call stack, even tough it does work. Find it.
    //      Fix it.

    public class StackOverFlow
    {
        public static int AStupidMethod(int value)
        {
            int someVariable = AnotherStupidMethod(value);
            return someVariable;
        }
        private static int AnotherStupidMethod(int value)
        {
            int someVariable = AStupidMethod(value*value);
            return someVariable;
        }
    }
}
