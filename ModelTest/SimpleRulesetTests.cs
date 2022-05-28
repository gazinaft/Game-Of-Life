using System;
using GameOfLife.Scripts.Model;
using NUnit.Framework;

namespace ModelTest
{
    [TestFixture]
    public class SimpleRulesetTests
    {

        private SimpleRuleset sr;
        private int x;
        private int y;
        
        [SetUp]
        public void SetUp()
        {
            sr = new SimpleRuleset();
            x = 1;
            y = 1;
        }

        
        // the cell stays dead if it has anything but 3 neighbours
        [Test]
        public void StayDead()
        {
            // 0 neighbours
            var dead0 = new int[,]
            {
                { 0, 0, 0 },
                { 0, 0, 0 },
                { 0, 0, 0 }
            };
            Assert.AreEqual(0, sr.EvalCell(ref dead0, x, y));
            
            // 1 neighbour
            var dead1 = new int[,]
            {
                { 0, 0, 1 },
                { 0, 0, 0 },
                { 0, 0, 0 }
            };
            Assert.AreEqual(0, sr.EvalCell(ref dead1, x, y));

            // 2 neighbours
            var dead2 = new int[,]
            {
                { 0, 0, 1 },
                { 1, 0, 0 },
                { 0, 0, 0 }
            };
            Assert.AreEqual(0, sr.EvalCell(ref dead2, x, y));
            
            // 4 neighbours
            var dead4 = new int[,]
            {
                { 0, 0, 1 },
                { 1, 0, 1 },
                { 0, 1, 0 }
            };
            Assert.AreEqual(0, sr.EvalCell(ref dead4, x, y));

            // 5 neighbour
            var dead5 = new int[,]
            {
                { 0, 1, 1 },
                { 0, 0, 1 },
                { 0, 1, 1 }
            };
            Assert.AreEqual(0, sr.EvalCell(ref dead5, x, y));
        }

        // Cell is born only with 3 neighbours
        [Test]
        public void Birth()
        {
            var birth1 = new int[,]
            {
                { 0, 0, 0 },
                { 0, 0, 0 },
                { 1, 1, 1 }
            };
            Assert.AreEqual(1, sr.EvalCell(ref birth1, x, y));
            
            var birth2 = new int[,]
            {
                { 0, 1, 0 },
                { 0, 0, 0 },
                { 1, 0, 1 }
            };
            Assert.AreEqual(1, sr.EvalCell(ref birth2, x, y));
            
            var birth3 = new int[,]
            {
                { 1, 0, 0 },
                { 0, 0, 1 },
                { 0, 0, 1 }
            };
            Assert.AreEqual(1, sr.EvalCell(ref birth3, x, y));
            
            var birth4 = new int[,]
            {
                { 0, 1, 0 },
                { 1, 0, 0 },
                { 0, 1, 0 }
            };
            Assert.AreEqual(1, sr.EvalCell(ref birth4, x, y));
            
            var birth5 = new int[,]
            {
                { 1, 0, 1 },
                { 0, 0, 0 },
                { 0, 0, 1 }
            };
            Assert.AreEqual(1, sr.EvalCell(ref birth5, x, y));
        }

        // 4 or more alive neighbours
        [Test]
        public void OverpopulationDeath()
        {
            // 4
            var death4 = new int[,]
            {
                { 1, 0, 1 },
                { 0, 1, 1 },
                { 0, 0, 1 }
            };
            Assert.AreEqual(0, sr.EvalCell(ref death4, x, y));
            
            // 5
            var death5 = new int[,]
            {
                { 1, 0, 1 },
                { 0, 1, 1 },
                { 1, 0, 1 }
            };
            Assert.AreEqual(0, sr.EvalCell(ref death5, x, y));

            // 6
            var death6 = new int[,]
            {
                { 1, 1, 1 },
                { 0, 1, 1 },
                { 1, 0, 1 }
            };
            Assert.AreEqual(0, sr.EvalCell(ref death6, x, y));

            // 7
            var death7 = new int[,]
            {
                { 1, 1, 1 },
                { 1, 1, 1 },
                { 1, 0, 1 }
            };
            Assert.AreEqual(0, sr.EvalCell(ref death7, x, y));

            // 8
            var death8 = new int[,]
            {
                { 1, 1, 1 },
                { 1, 1, 1 },
                { 1, 1, 1 }
            };
            Assert.AreEqual(0, sr.EvalCell(ref death8, x, y));
        }

        // dies if 1 or less neighbours
        [Test]
        public void LonelinessDeath()
        {
            // 0 neighbours
            var dead0 = new int[,]
            {
                { 0, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, 0 }
            };
            Assert.AreEqual(0, sr.EvalCell(ref dead0, x, y));
            
            // 1 neighbour
            var dead1 = new int[,]
            {
                { 0, 0, 1 },
                { 0, 1, 0 },
                { 0, 0, 0 }
            };
            Assert.AreEqual(0, sr.EvalCell(ref dead1, x, y));

            var dead2 = new int[,]
            {
                { 0, 0, 0 },
                { 0, 1, 1 },
                { 0, 0, 0 }
            };
            Assert.AreEqual(0, sr.EvalCell(ref dead2, x, y));
            
            var dead3 = new int[,]
            {
                { 0, 0, 0 },
                { 0, 1, 0 },
                { 1, 0, 0 }
            };
            Assert.AreEqual(0, sr.EvalCell(ref dead3, x, y));
            
            var dead4 = new int[,]
            {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, 0 }
            };
            Assert.AreEqual(0, sr.EvalCell(ref dead4, x, y));
        }

        // Cell stays alive if it has 2 or 3 neighbours
        [Test]
        public void StayAlive()
        {
            var alive1 = new int[,]
            {
                { 0, 0, 0 },
                { 0, 1, 0 },
                { 1, 1, 1 }
            };
            Assert.AreEqual(1, sr.EvalCell(ref alive1, x, y));
            
            var alive2 = new int[,]
            {
                { 0, 1, 0 },
                { 0, 1, 0 },
                { 1, 0, 1 }
            };
            Assert.AreEqual(1, sr.EvalCell(ref alive2, x, y));
            
            var alive3 = new int[,]
            {
                { 1, 0, 0 },
                { 0, 1, 1 },
                { 0, 0, 1 }
            };
            Assert.AreEqual(1, sr.EvalCell(ref alive3, x, y));
            
            var alive4 = new int[,]
            {
                { 0, 1, 0 },
                { 1, 1, 0 },
                { 0, 1, 0 }
            };
            Assert.AreEqual(1, sr.EvalCell(ref alive4, x, y));
            
            var alive5 = new int[,]
            {
                { 1, 0, 1 },
                { 0, 1, 0 },
                { 0, 0, 1 }
            };
            Assert.AreEqual(1, sr.EvalCell(ref alive5, x, y));
            
            var alive6 = new int[,]
            {
                { 0, 0, 0 },
                { 0, 1, 0 },
                { 1, 0, 1 }
            };
            Assert.AreEqual(1, sr.EvalCell(ref alive6, x, y));
            
            var alive7 = new int[,]
            {
                { 0, 1, 0 },
                { 0, 1, 0 },
                { 1, 0, 0 }
            };
            Assert.AreEqual(1, sr.EvalCell(ref alive7, x, y));
            
            var alive8 = new int[,]
            {
                { 0, 0, 0 },
                { 0, 1, 1 },
                { 0, 0, 1 }
            };
            Assert.AreEqual(1, sr.EvalCell(ref alive8, x, y));
            
            var alive9 = new int[,]
            {
                { 0, 1, 0 },
                { 0, 1, 0 },
                { 0, 1, 0 }
            };
            Assert.AreEqual(1, sr.EvalCell(ref alive9, x, y));
            
            var alive10 = new int[,]
            {
                { 1, 0, 1 },
                { 0, 1, 0 },
                { 0, 0, 0 }
            };
            Assert.AreEqual(1, sr.EvalCell(ref alive10, x, y));
        }
    }
}