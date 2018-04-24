using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodinGameTest
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void a()
        {
        }
    }

    [TestClass]
    public class BatmanTest
    {
        [TestMethod]
        public void Move_Jump1UR_PosNeg()
        {
            int x = 0;
            int y = 0;
            string actual;
            string expected = "1 -1";

            actual = new Batman(x, y).Move(1, Direction.UR);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Move_Jump1DR_PosPos()
        {
            int x = 0;
            int y = 0;
            string actual;
            string expected = "1 1";

            actual = new Batman(x, y).Move(1, Direction.DR);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Move_Jump1DL_NegPos()
        {
            int x = 0;
            int y = 0;
            string actual;
            string expected = "-1 1";

            actual = new Batman(x, y).Move(1, Direction.UR);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Move_Jump1UL_NegNeg()
        {
            int x = 0;
            int y = 0;
            string actual;
            string expected = "-1 -1";

            actual = new Batman(x, y).Move(1, Direction.UR);

            Assert.AreEqual(expected, actual);
        }
    }
}
