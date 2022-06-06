using GameOfLife.Scripts.Model;
using NUnit.Framework;

namespace ModelTest
{
    [TestFixture]
    public class ParallelThreadPoolRulesetTests
    {
        private IRuleset rules;
        
        [SetUp]
        public void SetUp()
        {
            rules = new ParallelThreadPoolRuleset();
        }

        [Test]
        public void StillFigures()
        {
            var a = new int[,]
            {
                { 0, 0, 0, 0 },
                { 0, 1, 1, 0 },
                { 0, 1, 1, 0 },
                { 0, 0, 0, 0 }
            };
            var b = new int[,]
            {
                { 0, 0, 0, 0 },
                { 0, 1, 1, 0 },
                { 0, 1, 1, 0 },
                { 0, 0, 0, 0 }
            };
            rules.Eval(ref a);
            Assert.AreEqual(a, b);
            
            var a2 = new int[,]
            {
                { 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 1, 0, 0 },
                { 0, 1, 0, 0, 1, 0 },
                { 0, 0, 1, 1, 0, 0 },
                { 0, 0, 0, 0, 0, 0 }
            };
            var b2 = new int[,]
            {
                { 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 1, 0, 0 },
                { 0, 1, 0, 0, 1, 0 },
                { 0, 0, 1, 1, 0, 0 },
                { 0, 0, 0, 0, 0, 0 }
            };
            rules.Eval(ref a2);
            Assert.AreEqual(a2, b2);
            
            var a3 = new int[,]
            {
                { 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 1, 0, 0 },
                { 0, 1, 0, 0, 1, 0 },
                { 0, 0, 1, 0, 1, 0 },
                { 0, 0, 0, 1, 0, 0 },
                { 0, 0, 0, 0, 0, 0 }
            };
            var b3 = new int[,]
            {
                { 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 1, 0, 0 },
                { 0, 1, 0, 0, 1, 0 },
                { 0, 0, 1, 0, 1, 0 },
                { 0, 0, 0, 1, 0, 0 },
                { 0, 0, 0, 0, 0, 0 }
            };
            rules.Eval(ref a3);
            Assert.AreEqual(a3, b3);
        }

        [Test]
        public void Oscillators()
        {
            var a = new int[,]
            {
                { 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0 },
                { 0, 0, 1, 0, 0 },
                { 0, 0, 1, 0, 0 },
                { 0, 0, 0, 0, 0 }
            };
            var b = new int[,]
            {
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 1, 1, 1, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 }
            };
            rules.Eval(ref a);
            Assert.AreEqual(a, b);
            
            var a2 = new int[,]
            {
                { 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 1, 1, 0 },
                { 0, 1, 1, 1, 0, 0 },
                { 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0 }
            };
            var b2 = new int[,]
            {
                { 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 1, 0, 0 },
                { 0, 1, 0, 0, 1, 0 },
                { 0, 1, 0, 0, 1, 0 },
                { 0, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0 }
            };
            rules.Eval(ref a2);
            Assert.AreEqual(a2, b2);
        }

    }
}