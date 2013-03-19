using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Procad.DataAccess.DataAnnotations.Attributes;
using System.Runtime.Serialization;
using Procad.DataAccess.Infrastructure;
using System.Reflection;

namespace Procad.DataAccessTests
{
    public class UserEntityTest
    {
        [DataMemberAttribute()]
        [DataBaseColumnMap("Id")]
        public int ID { get; set; }

        [DataMemberAttribute()]
        [DataBaseColumnMap("Name")]
        [DataBaseColumnMap("UserName")]
        public string Name { get; set; }

        [DataMemberAttribute()]
        [DataBaseColumnMap("BirthDay")]
        public DateTime BirthDay { get; set; }

        [DataMemberAttribute()]
        [DataBaseColumnMap()]
        [DataBaseColumnMapPrefix("account")]
        public AccountEntityTest Account { get; set; }
    }

    public class AccountEntityTest
    {
        [DataMemberAttribute()]
        [DataBaseColumnMap("Id")]
        public int ID { get; set; }

        [DataMemberAttribute()]
        [DataBaseColumnMap("Name")]
        public string Name { get; set; }

        [DataMemberAttribute()]
        [DataBaseColumnMap("CreationDate")]
        public DateTime CreationDate { get; set; }
    }
    

    [TestFixture]
    public class CustomAttributesMemoizerTests
    {
        [Test]
        public void GetMemoAttributes_PassingUserEntityTestAndIdPropertyAndColumnMapAttribute_ReturnsStringArrayThatContainsAnElementId()
        {
            // Arrange
            var expected = new string[] { "Id" };

            var type = typeof(UserEntityTest);
            PropertyInfo[] props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty);
            var property = props.Where(p => p.Name.CompareTo("ID") == 0).SingleOrDefault();

            // Act
            var result = CustomAttributesMemoizer<DataBaseColumnMapAttribute>.GetAttributesValues(type, property);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetMemoAttributes_PassingUserEntityTestAndIdPropertyAndColumnMapPrefixAttribute_ReturnsNull()
        {
            // Arrange
            var type = typeof(UserEntityTest);
            PropertyInfo[] props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty);
            var property = props.Where(p => p.Name.CompareTo("ID") == 0).SingleOrDefault();

            // Act
            var result = CustomAttributesMemoizer<DataBaseColumnMapPrefixAttribute>.GetAttributesValues(type, property);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetMemoAttributes_PassingUserEntityTestAndAccountPropertyAndColumnMapAttribute_ReturnsNull()
        {
            // Arrange
            var type = typeof(UserEntityTest);
            PropertyInfo[] props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty);
            var property = props.Where(p => p.Name.CompareTo("Account") == 0).SingleOrDefault();

            // Act
            var result = CustomAttributesMemoizer<DataBaseColumnMapAttribute>.GetAttributesValues(type, property);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetMemoAttributes_PassingUserEntityTestAndAccountPropertyAndColumnMapPrefixAttribute_ReturnsStringArrayThatContainsAnElementAccount()
        {
            // Arrange
            var expected = new string[] { "account" };

            var type = typeof(UserEntityTest);
            PropertyInfo[] props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty);
            var property = props.Where(p => p.Name.CompareTo("Account") == 0).SingleOrDefault();

            // Act
            var result = CustomAttributesMemoizer<DataBaseColumnMapPrefixAttribute>.GetAttributesValues(type, property);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetMemoAttributes_PassingUserEntityTestAndPropertyNullAndColumnMapPrefixAttribute_ThrowsArgumentNullException()
        {
            // Arrange
            var type = typeof(UserEntityTest);

            // Act
            CustomAttributesMemoizer<DataBaseColumnMapPrefixAttribute>.GetAttributesValues(type, null);
        }

        [Test]
        public void GetMemoAttributes_PassingUserEntityTestAndNamePropertyAndColumnMapAttribute_ReturnsStringArrayThatContainsNameAndUserName()
        {
            // Arrange
            var expected = new string[] { "Name", "UserName" };

            var type = typeof(UserEntityTest);
            PropertyInfo[] props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty);
            var property = props.Where(p => p.Name.CompareTo("Name") == 0).SingleOrDefault();

            // Act
            var result = CustomAttributesMemoizer<DataBaseColumnMapAttribute>.GetAttributesValues(type, property);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}