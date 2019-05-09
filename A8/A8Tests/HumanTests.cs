using Microsoft.VisualStudio.TestTools.UnitTesting;
using A8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A8.Tests
{
    [TestClass()]
    public class HumanTests
    {
        Human human1 = new Human("Ali", "Hoseini", DateTime.Today, 180);
        Human female1 = new Human("zahra", "zahrayi", DateTime.Today, 160);
        Human human2 = new Human("Ali", "masoudi", DateTime.Today, 170);
        Human human3 = new Human("Alireza", "ahmadi", DateTime.Today, 180);

        [TestMethod()]
        public void HumanTest()
        {
            Human human00 = new Human("Ali", "Hoseini", DateTime.Today, 180);
            Assert.AreEqual(human00, human1);

            Human human01 = new Human("Ali", "Hoseini", DateTime.Now, 180);
            Assert.AreNotEqual(human01, human1);

        }

        [TestMethod()]
        public void EqualsTest()
        {
            Human human02 = new Human("Ali", "akbari", DateTime.Today, 150);
            bool actual= human02.Equals(human2);
            bool expected = false;
            Assert.AreEqual(expected, actual);
            Human human03 = new Human("Ali", "masoudi", DateTime.Today, 170);
            actual = human03.Equals(human2);
            expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            Human human01 = new Human("Alireza", "ahmadi", DateTime.Today, 190);
            Assert.AreNotEqual(human01.GetHashCode(), human3.GetHashCode());

            Human human02 = new Human("Alireza", "ahmadi", DateTime.Today, 180);
            Assert.AreEqual(human02.GetHashCode(), human3.GetHashCode());

            Human human03 = new Human("Alireza", "ahmad", DateTime.Today, 180);
            Assert.AreNotEqual(human03.GetHashCode(), human3.GetHashCode());

            Human human04 = new Human("Alirezai", "ahmad", DateTime.Today, 180);
            Assert.AreNotEqual(human03.GetHashCode(), human3.GetHashCode());

        }

        [TestMethod]
        public void PlusOperatorTest()
        {
            Human child = human1 + female1;
            Human expchild = new Human("ChildFirstName", "ChildLastName", DateTime.Today, 30);
            Assert.AreEqual(expchild, child);
        }

        [TestMethod]
        public void OtherOperatorTest()
        {
            Assert.AreEqual(false, human1 > human2);
            Assert.AreEqual(false, human1 < human2);
            Assert.AreEqual(true, human1 == human2);
            Assert.AreEqual(true, human1 >= human2);
            Assert.AreEqual(true, human1 <= human2);
            Assert.AreEqual(false, human1 != human2);
        }

    }
}