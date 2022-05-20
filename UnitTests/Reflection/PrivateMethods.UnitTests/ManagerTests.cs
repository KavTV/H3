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
    internal class ManagerTests : EmplyeeTests
    {
        public override object CreateEmployee(string name)
        {
            Assembly assembly = Assembly.LoadFrom("PrivateMethods.dll");

            MyCustomReflection myCustomReflection = new MyCustomReflection(assembly);

            Type[] classTypes = myCustomReflection.GetClasses("PrivateMethods");

            Type selectedClass = myCustomReflection.GetClass("Manager", classTypes);

            //We are looking for a constructor with thease types
            Type[] constParamTypes = new Type[] { typeof(string) };

            ConstructorInfo foundConstructor = myCustomReflection.GetConstructor(selectedClass, constParamTypes);

            return foundConstructor.Invoke(new object[] { name });
        }

        [TestCase("jens", "I'm Manager jens . I'm  really nice")]
        [TestCase("hans", "I'm Manager hans . I'm  really nice")]
        [TestCase("Bob", "I'm Manager Bob . I'm  serious badass")]
        [TestCase("måge sddsd", "I'm Manager måge sddsd . I'm  really nice")]
        public void PrintInfo_NoProblem_ReturnsString(string name, string expected)
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

        [TestCase("")]
        public void PrintInfo_WrongNames_ReturnsString(string name)
        {

            object emp = CreateEmployee(name);

            MyCustomReflection reflection = new MyCustomReflection(Assembly.LoadFrom("PrivateMethods.dll"));

            MethodInfo classMethods = reflection.GetMethod("PrintInfo", emp.GetType());

            //If method gets throwed, everything is okay
            Assert.Throws<System.Reflection.TargetInvocationException>(() => { classMethods.Invoke(emp, null); });
        }
    }
}
