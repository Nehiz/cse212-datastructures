using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities and dequeue them
    // Expected Result: Items should be dequeued in order of highest priority first
    // Defect(s) Found: 1) Loop condition excluded last item (< Count-1 instead of < Count), 2) Items were never removed from queue, 3) Used >= instead of > causing wrong FIFO behavior for equal priorities
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 3);        priorityQueue.Enqueue("B", 1);
        priorityQueue.Enqueue("C", 5);
        priorityQueue.Enqueue("D", 2);

        // Should dequeue in priority order: C(5), A(3), D(2), B(1)
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with equal priorities
    // Expected Result: When priorities are equal, should dequeue based on FIFO (first in, first out)
    // Defect(s) Found: Used >= comparison instead of > which caused LIFO behavior for equal priorities instead of FIFO
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 5);

        // With equal priorities, should maintain FIFO order
        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue
    // Expected Result: Should throw InvalidOperationException with appropriate message
    // Defect(s) Found: No defects found - exception handling works correctly
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                               e.GetType(), e.Message)
            );
        }
    }

    [TestMethod]
    // Scenario: Enqueue single item and dequeue it
    // Expected Result: Should successfully enqueue and dequeue the single item
    // Defect(s) Found: No defects found for single item operations
    public void TestPriorityQueue_SingleItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Only", 10);

        Assert.AreEqual("Only", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Mix of positive and negative priorities
    // Expected Result: Higher numerical values should have higher priority (including negatives)
    // Defect(s) Found: No defects found for negative priority handling
    public void TestPriorityQueue_NegativePriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", -5);
        priorityQueue.Enqueue("High", 10);
        priorityQueue.Enqueue("Medium", 0);
        priorityQueue.Enqueue("VeryLow", -10);

        // Should dequeue: High(10), Medium(0), Low(-5), VeryLow(-10)
        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
        Assert.AreEqual("VeryLow", priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.
}