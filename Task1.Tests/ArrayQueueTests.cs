using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task1.Tests
{
    [TestFixture]
    public class ArrayQueueTests
    {
        [Test]
        public void QueueDequeue()
        {
            ArrayQueue<string> queue = new ArrayQueue<string>(10);
            queue.Enqueue("HybridTheory");
            queue.Enqueue("Meteora");
            queue.Enqueue("MinutesToMidnight");
            queue.Enqueue("AThousandSuns");
            queue.Enqueue("HybridTheory");
            queue.Enqueue("LivingThings");
            queue.Enqueue("TheHuntingParty");
            Assert.AreEqual("HybridTheory", queue.Dequeue());
            Assert.AreEqual("Meteora", queue.Dequeue());
            Assert.AreEqual("MinutesToMidnight", queue.Dequeue());
        }

        [Test]
        public void QueueContains()
        {
            ArrayQueue<string> queue = new ArrayQueue<string>(10);
            queue.Enqueue("HybridTheory");
            queue.Enqueue("Meteora");
            queue.Enqueue("MinutesToMidnight");
            queue.Enqueue("AThousandSuns");
            queue.Enqueue("HybridTheory");
            queue.Enqueue("LivingThings");
            queue.Enqueue("TheHuntingParty");
            Assert.IsTrue(queue.Contains("AThousandSuns"));
            Assert.IsTrue(queue.Contains("TheHuntingParty"));
        }

        [Test]
        public void QueueEnumerator()
        {
            ArrayQueue<string> queue = new ArrayQueue<string>(10);
            queue.Enqueue("HybridTheory");
            queue.Enqueue("Meteora");
            queue.Enqueue("MinutesToMidnight");
            queue.Enqueue("AThousandSuns");
            queue.Enqueue("HybridTheory");
            queue.Enqueue("LivingThings");
            queue.Enqueue("TheHuntingParty");
            using (var enumerator = queue.GetEnumerator())
            {
                enumerator.MoveNext();
                Assert.AreEqual("HybridTheory", enumerator.Current);
                enumerator.MoveNext();
                Assert.AreEqual("Meteora", enumerator.Current);
            }
        }
    }
}
