using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three people with different priorities and remove them.
    // Expected Result: Items should come out in descending priority order.
    // Defect(s) Found: (Fill this in after running your test)
    public void TestPriorityQueue_1()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Bob", 1);
        pq.Enqueue("Sue", 5);
        pq.Enqueue("Tim", 3);

        Assert.AreEqual("Sue", pq.Dequeue());
        Assert.AreEqual("Tim", pq.Dequeue());
        Assert.AreEqual("Bob", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Add three people with the same priority.
    // Expected Result: Items should come out in the same order they were added.
    // Defect(s) Found: (Fill this in after running your test)
    public void TestPriorityQueue_2()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Bob", 3);
        pq.Enqueue("Sue", 3);
        pq.Enqueue("Tim", 3);

        Assert.AreEqual("Bob", pq.Dequeue());
        Assert.AreEqual("Sue", pq.Dequeue());
        Assert.AreEqual("Tim", pq.Dequeue());

        // Add more test cases as needed below.

    }
    [TestMethod]
    // Scenario: Attempt to dequeue from an empty priority queue.
    // Expected Result: InvalidOperationException should be thrown with the message "The queue is empty."
    // Defect(s) Found: (Fill this in after running your test)
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();

        try
        {
            pq.Dequeue();
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
                $"Unexpected exception of type {e.GetType()} caught: {e.Message}"
            );
        }
    }
}
