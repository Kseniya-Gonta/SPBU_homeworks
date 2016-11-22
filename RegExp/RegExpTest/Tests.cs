using System;
using NUnit.Framework;
using RegExp;

namespace RegExpTest
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var emailValidator = new EmailValidator();
            var phoneValidator = new PhoneValidator();
            var postIndexPalidator = new PostIndexValidator();


            Assert.IsTrue(emailValidator.CheckValidness("a@b.cc"));
            Assert.IsTrue(emailValidator.CheckValidness("yuri.gubanov@mail.ru"));
            Assert.IsTrue(emailValidator.CheckValidness("my@domain.info"));
            Assert.IsTrue(emailValidator.CheckValidness("_.1@mail.com"));
            Assert.IsTrue(emailValidator.CheckValidness("yurik@hermitage.museum"));

            Assert.IsFalse(emailValidator.CheckValidness("a@b.c"));
            Assert.IsFalse(emailValidator.CheckValidness("a..b@mail.ru"));
            Assert.IsFalse(emailValidator.CheckValidness(".a@mail.ru"));
            Assert.IsFalse(emailValidator.CheckValidness("yo@domain.domain"));
            Assert.IsFalse(emailValidator.CheckValidness("1@mail.ru"));

            Assert.IsTrue(postIndexPalidator.CheckValidness("192168"));
            Assert.IsFalse(postIndexPalidator.CheckValidness("192168789"));

            Assert.IsTrue(phoneValidator.CheckValidness("+7(981)-835-16-88"));
            Assert.IsTrue(phoneValidator.CheckValidness("89818351688"));
        }
    }
}