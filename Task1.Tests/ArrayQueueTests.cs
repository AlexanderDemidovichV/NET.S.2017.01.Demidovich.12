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
        private ArrayQueue<string> queue;

        [SetUp]
        protected void SetUp()
        {
            queue = new ArrayQueue<string>(10);
            queue.Enqueue("HybridTheory");
            queue.Enqueue("Meteora");
            queue.Enqueue("MinutesToMidnight");
            queue.Enqueue("AThousandSuns");
            queue.Enqueue("HybridTheory");
            queue.Enqueue("LivingThings");
            queue.Enqueue("TheHuntingParty");
        }

        [Test]
        public void QueueEnumerator()
        {
            using (var enumerator = queue.GetEnumerator())
            {
                enumerator.MoveNext();
                Assert.AreEqual("HybridTheory", enumerator.Current);
                enumerator.MoveNext();
                Assert.AreEqual("Meteora", enumerator.Current);
            }
        }

        [Test]
        public void QueueDequeue()
        {
            Assert.AreEqual("HybridTheory", queue.Dequeue());
            Assert.AreEqual("Meteora", queue.Dequeue());
            Assert.AreEqual("MinutesToMidnight", queue.Dequeue());
        }

        [Test]
        public void QueueContains()
        {
            Assert.IsTrue(queue.Contains("AThousandSuns"));
            Assert.IsTrue(queue.Contains("TheHuntingParty"));
        }

        [Test]
        public void QueuePeek()
        {
            Assert.IsTrue(queue.Contains("AThousandSuns"));
            Assert.IsTrue(queue.Contains("TheHuntingParty"));
        }

    }
}
