using ClassLibrary1;

namespace TestProject1
{
    [TestClass]
    public class Test1
    {
        #region Konstruktor Tests

        [TestMethod]
        public void Konstruktor_DanePoprawne()
        {
            var phone = new Phone("Hubert", "123456789");

            Assert.AreEqual("Hubert", phone.Owner);
            Assert.AreEqual("123456789", phone.PhoneNumber);
            Assert.AreEqual(0, phone.Count);
        }

        [TestMethod]
        public void Konstructor_WlascicielEmpty()
        {
            Assert.ThorwsException<ArgumentException>(() =>
            new Phone("", "123456789"));
        }

        [TestMethod]
        public void Konstruktor_WlascicielNull()
        {
            Assert.ThrowException<ArgumentException>(() =>
            new Phone(null, "123456789"));
        }

        [TestMethod]
        public void Konstruktor_PhoneNull()
        {
            Assert.ThrowException<ArgumentException>(() =>
            new Phone("Hubert", null));
        }

        [TestMethod]
        public void Konstruktor_PhoneEmpty()
        {
            Assert.ThrowException<ArgumentException>(() =>
            new Phone("Hubert", ""));
        }

        [TestMethod]
        public void Konstruktor_PhoneTooShort()
        {
            Assert.ThrowException<ArgumentException>(() =>
            new Phone("Hubert", "123"));
        }

        [TestMethod]
        public void Konstruktor_PhoneTooLong()
        {
            Assert.ThrowException<ArgumentException>(() =>
            new Phone("Hubert", "1234567890"));
        }

        [TestMethod]
        public void Konstruktor_PhoneContainsLetters()
        {
            Assert.ThrowException<ArgumentException>(() =>
            new Phone("Hubert", "12345ABCD"));
        }

        #endregion

        #region AddContact Tests

        [TestMethod]
        public void AddContact_NewContact()
        {
            var phone = new Phone("Hubert", "123456789");

            var result = phone.AddContact("Molenda", "987654321");

            Assert.IsTrue(result);
            Assert.AreEqual(1, phone.Count);
        }

        [TestMethod]
        public void AddContact_DuplicateContact()
        {
            var phone = new Phone("Hubert", "123456789");

            phone.AddContact("Molenda", "987654321");
            var result = phone.AddContact("Molenda", "111111111");

            Assert.IsFalse(result);
            Assert.AreEqual(1, phone.Count);
        }

        [TestMethod]
        public void AddContact_WhenPhoneBookFull()
        {
            var phone = new Phone("Hubert", "123456789");

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
            var phone = new Phone("Hubert", "123456789");
            phone.AddContact("Molenda", "987654321");

            var result = phone.Call("Molenda");

            Assert.AreEqual("Dzwonię do 987654321 (Molenda) ...", result);

        }

        [TestMethod]
        public void Call_NonExistingContact()
        {
            var phone = new Phone("Hubert", "123456789");

            Assert.ThrowsException<InvalidOperationException>(() =>
            phone.Call("Unknown");
        }

        #endregion
    }
}
