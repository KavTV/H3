using CustomReflection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PrivateMethods.UnitTests
{
    [TestFixture]
    internal class DeliveryManagerTests : EmplyeeTests
    {
        public override object CreateEmployee(string name)
        {
            Assembly assembly = Assembly.LoadFrom("PrivateMethods.dll");

            MyCustomReflection myCustomReflection = new MyCustomReflection(assembly);

            Type[] classTypes = myCustomReflection.GetClasses("PrivateMethods");

            Type selectedClass = myCustomReflection.GetClass("DeliveryManager", classTypes);

            //We are looking for a constructor with thease types
            Type[] constParamTypes = new Type[] { typeof(string) };

            ConstructorInfo foundConstructor = myCustomReflection.GetConstructor(selectedClass, constParamTypes);

            return foundConstructor.Invoke(new object[] { name });
        }


        [TestCase("jens", "I'm Delivery Manager jens ")]
        [TestCase("hans", "I'm Delivery Manager hans ")]
        [TestCase("måge sddsd", "I'm Delivery Manager måge sddsd ")]
        [TestCase("", "I'm Delivery Manager  ")]
        public void PrintInfo_multipleTries_ReturnsString(string name, string expected)
        {
            //Arrange
            object emp = CreateEmployee(name);

            MyCustomReflection reflection = new MyCustomReflection(Assembly.LoadFrom("PrivateMethods.dll"));

            MethodInfo classMethods = reflection.GetMethod("PrintInfo", emp.GetType());

            //Act
            object methodResult = classMethods.Invoke(emp, null);

            //Assert
            Assert.AreEqual(expected, methodResult);
        }
    }
}
