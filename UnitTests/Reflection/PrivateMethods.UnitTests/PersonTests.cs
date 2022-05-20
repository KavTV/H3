using CustomReflection;
using NUnit.Framework;
using System;
using System.Reflection;
using PrivateMethods;
using System.Linq;

namespace PrivateMethods.UnitTests
{
    public class PersonTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(20,"Boy", false)]
        [TestCase(60,"Boy", true)]
        [TestCase(999999,"something", true)]
        [TestCase(-1,"Boy", false)]
        public void IsOld_NotOld_ReturnsTrue(int age, string gender, bool expected)
        {
            Assembly assembly = Assembly.LoadFrom("PrivateMethods.dll");

            MyCustomReflection myCustomReflection = new MyCustomReflection(assembly);

            Type[] classTypes = myCustomReflection.GetClasses("PrivateMethods");

            Type selectedClass = myCustomReflection.GetClass("Person", classTypes);

            //We are looking for a constructor with thease types
            Type[] constParamTypes = new Type[] { typeof(int), typeof(string) };

            ConstructorInfo foundConstructor = myCustomReflection.GetConstructor(selectedClass, constParamTypes);

            object obj = foundConstructor.Invoke(new object[] { age, gender });


            MethodInfo classMethods = myCustomReflection.GetMethod("IsOld",selectedClass);

            object methodResult = classMethods.Invoke(obj, null);

            Assert.AreEqual(expected, methodResult);
        }
    }
}