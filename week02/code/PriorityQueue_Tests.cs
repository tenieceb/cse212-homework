using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue separate items at various priorities.
    // Expected Result: Regardless of the priority, the item is enqueued to the end of the line.
    // Defect(s) Found: None. Enqueued as expected.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item 1",3);
        priorityQueue.Enqueue("Item 2",4);
        priorityQueue.Enqueue("Item 3", 1);
        Console.WriteLine(priorityQueue);
        priorityQueue.Enqueue("Item 4", 5);
        Console.WriteLine(priorityQueue);

    }

    [TestMethod]
    // Scenario: The item with the highest priority is in the center of the queue.
    // Expected Result: The system will dequeue the item regardless of it's spot within the system.
    // Defect(s) Found: The item that is "dequeued" is not the item that is the highest priority due to line 27 in the main code _queue.Count -1 leaves the end of the list off.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item 1", 3);
        priorityQueue.Enqueue("Item 2", 4);
        priorityQueue.Enqueue("Item 3", 1);
        priorityQueue.Enqueue("Item 4", 5);
        var dequeuedByPriority = priorityQueue.Dequeue();
        var highestPriority = "Item 4";
        if (highestPriority != dequeuedByPriority)
        {
            Assert.Fail($"Expected: {highestPriority} but got {dequeuedByPriority}.");
        }
    }

    [TestMethod]
        // Scenario: There are two items with the same priority
        // Expected Result: The program will dequeue the first item of the highest priority
        // Defect(s) Found: The system did not remove the item from the list in order of what item was added first. 

    public void TestPriorityQueue_3()
    {


        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item 1", 3);
        priorityQueue.Enqueue("Item 2", 4);
        priorityQueue.Enqueue("Item 3", 1);
        priorityQueue.Enqueue("Item 4", 4);
        Console.WriteLine(priorityQueue);
        var dequeuedByPriorityAndPosition = priorityQueue.Dequeue();
        Console.WriteLine(dequeuedByPriorityAndPosition);
        Console.WriteLine(priorityQueue);

    }

    [TestMethod]
        // Scenario: There is no one in the queue
        // Expected Result: System will throw an error exception
        // Defect(s) Found: none

    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue(); // This should throw an exception
            Assert.Fail("Expected exception was not thrown.");
        }
        catch (InvalidOperationException)
        {
            // Test passes if exception is caught
        }
    }

}