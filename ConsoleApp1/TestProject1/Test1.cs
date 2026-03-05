using ClassLibrary;

namespace TestProject1
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void Konstruktor_DanePoprawne()
        {
            string owner = "John Doe";
            string phoneNumber = "123456789";

            Phone phone = new(owner, phoneNumber);

            Assert.AreEqual(owner, phone.Owner);
            Assert.AreEqual(phoneNumber, phone.PhoneNumber);
        }

       
    }
}
