using NUnit.Framework;
using Moq;
using Moq.Protected;

namespace MoqService
{
    [TestFixture]
    public class MoqTest
    {
        [Test]
        public void MoqTestInterface()
        {
            Robot robot;

            // Assume that there is no implemanation of the interafce IParameters
            // Althoug you want to test the Robot class

            // TODO 
            // Create Mock for IParameters
            var mockObject = new Mock<IParameters>();

            // Assign new Robot to robot variable, and provide Mock.Object as a parameter to the constructor.
            robot = new Robot(mockObject.Object);

            // Setup a get for a name field
            mockObject.SetupGet(m => m.name).Returns("zucc");

            // Setup two gets for health field (use Sequence)
            mockObject.SetupSequence(m => m.health).Returns(100).Returns(70);


            // You can't make any changes below this line.
            // -----------------------------------------------

            Assert.AreEqual("zucc", robot.Name());
            Assert.AreEqual(100, robot.Health());
            // meanwhile takes a bullet (-30 hp)
            Assert.AreEqual(70, robot.Health());
        }

         [Test]
        public void MoqTestProtected()
        {
            Robot robot;

            // Now that you've implemented the RandomDamage class test the Robot again

            // TODO
            // create Mock for RandomDamage
            var mockObject = new Mock<RandomDamage>();

            // Assign new Robot to robot variable, and provide Mock.Object as a parameter to the constructor.
            robot = new Robot(mockObject.Object);

            // Setup proper protected function respond (use Moq.Protected)
            mockObject.Protected().Setup<int>("damageRand").Returns(7);


            // You can't make any changes below this line.
            // -----------------------------------------------

            Assert.AreEqual(7, robot.Damage());
        }
    }
}