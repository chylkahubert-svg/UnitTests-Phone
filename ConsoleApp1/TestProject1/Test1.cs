using ClassLibrary1;

namespace TestProject1
{
    [TestClass]
    public sealed class Test1
    {
        #region Konstruktor Tests

        [TestMethod]
        public void Konstruktor_DanePoprawne()
        {
            string owner = "John Doe";
            string phoneNumber = "123456789";

            Phone phone = new(owner, phoneNumber);

            Assert.AreEqual(owner, phone.Owner);
            Assert.AreEqual(phoneNumber, phone.PhoneNumber);
            Assert.AreEqual(0, phone.Count);
        }

        [TestMethod]
        public void Konstructor_WlascicielEmpty()
        {
            Assert.ThorwsException<ArgumentException>(() =>
            new Phone("", phoneNumber));
        }

        [TestMethod]
        public void Konstruktor_WlascicielNull()
        {
            Assert.ThrowException<ArgumentException>(() =>
            new Phone(null, phoneNumber));
        }

        [TestMethod]
        public void Konstruktor_PhoneNull()
        {
            Assert.ThrowException<ArgumentException>(() =>
            new Phone(owner, null));
        }

        [TestMethod]
        public void Konstruktor_PhoneEmpty()
        {
            Assert.ThrowException<ArgumentException>(() =>
            new Phone(owner, ""));
        }

        #endregion

        #region AddContact Tests

        [TestMethod]
        public void AddContact_NewContact()
        {
            Phone phone = new(owner, phoneNumber);

            var result = phone.AddContact("Molenda", "987654321");

            Assert.IsTrue(result);
            Assert.AreEqual(1, phone.Count);
        }

        [TestMethod]
        public void AddContact_DuplicateContact()
        {
            Phone phone = new(owner, phoneNumber);

            phone.AddContact("Molenda", "987654321");
            var result = phone.AddContact("Molenda", "111111111");

            Assert.IsFalse(result);
            Assert.AreEqual(1, phone.Count);
        }

        [TestMethod]
        public void AddContact_WhenPhoneBookFull()
        {
            Phone phone = new(owner, phoneNumber);

            for (int i = 0; i < phone.PhoneBookCapacity; i++)
            {
                phone.AddContact($"Contact{i}", "111111111");
            }

            Assert.ThrowsException<InvalidOperationException>(() =>
            phone.AddContact("Overflow", "222222222"));
        }

        #endregion

        #region Call Tests

        [TestMethod]
        public void Call_ExistingContact()
        {
            Phone phone = new(owner, phoneNumber);
            phone.AddContact("Molenda", "987654321");

            var result = phone.Call("Molenda");

            Assert.AreEqual("Dzwonię do 987654321 (Molenda) ...", result);

        }

        [TestMethod]
        public void Call_NonExistingContact()
        {
            Phone phone = new(owner, phoneNumber);

            Assert.ThrowsException<InvalidOperationException>(() =>
            phone.Call("Unknown");
        }

        #endregion
    }
}
