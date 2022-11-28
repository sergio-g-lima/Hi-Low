using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hi_Low
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void not_a_number()
        {
            Program.EGuess_Result response = Program.check_guess(Guid.NewGuid().ToString(), Program.maximum);

            Assert.AreEqual(Program.EGuess_Result.not_valid_number, response);
        }

        [TestMethod]
        public void lower_than_minimal()
        {
            Program.EGuess_Result response = Program.check_guess((Program.minimum - 1).ToString(), Program.maximum);

            Assert.AreEqual(Program.EGuess_Result.not_valid_number, response);
        }

        [TestMethod]
        public void higher_than_maximum()
        {
            Program.EGuess_Result response = Program.check_guess((Program.maximum + 1).ToString(), Program.maximum);

            Assert.AreEqual(Program.EGuess_Result.not_valid_number, response);
        }

        [TestMethod]
        public void higher_than_target()
        {
            Program.EGuess_Result response = Program.check_guess(Program.maximum.ToString(), Program.minimum);

            Assert.AreEqual(Program.EGuess_Result.higher, response);
        }

        [TestMethod]
        public void lower_than_target()
        {
            Program.EGuess_Result response = Program.check_guess(Program.minimum.ToString(), Program.maximum);

            Assert.AreEqual(Program.EGuess_Result.lower, response);
        }

        [TestMethod]
        public void equal_to_target()
        {
            int target = (Program.maximum + Program.minimum) / 2;
            Program.EGuess_Result response = Program.check_guess(target.ToString(), target);

            Assert.AreEqual(Program.EGuess_Result.equal, response);
        }

        [TestMethod]
        public void equal_to_target_maximum_edge()
        {
            Program.EGuess_Result response = Program.check_guess(Program.maximum.ToString(), Program.maximum);

            Assert.AreEqual(Program.EGuess_Result.equal, response);
        }

        [TestMethod]
        public void equal_to_target_minimum_edge()
        {
            Program.EGuess_Result response = Program.check_guess(Program.minimum.ToString(), Program.minimum);

            Assert.AreEqual(Program.EGuess_Result.equal, response);
        }
    }
}
