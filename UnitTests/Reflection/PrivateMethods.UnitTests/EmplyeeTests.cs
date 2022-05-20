using CustomReflection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace PrivateMethods.UnitTests
{
    [TestFixture]
    public abstract class EmplyeeTests
    {
        public abstract object CreateEmployee(string name);

        [TestCase("eeqfew")]
        public void ContainsIllegalChars_DoesNotContain_ReturnsFalse(string name)
        {
            //Assembly assembly = Assembly.LoadFrom("PrivateMethods.dll");

            //MyCustomReflection myCustomReflection = new MyCustomReflection(assembly);

            //Type[] classTypes = myCustomReflection.GetClasses("PrivateMethods");

            //Type selectedClass = myCustomReflection.GetClass("Employee", classTypes);

            ////We are looking for a constructor with thease types
            //Type[] constParamTypes = new Type[] { typeof(string) };

            //ConstructorInfo foundConstructor = myCustomReflection.GetConstructor(selectedClass, constParamTypes);
            object emp = CreateEmployee(name);
            bool ContainsIllegalChars = (bool)emp.GetType().GetMethod("ContainsIllegalChars", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Instance)
                .Invoke(emp, null);

            //object obj = foundConstructor.Invoke(new object[] { name });


            //MethodInfo classMethods = myCustomReflection.GetMethod("IsOld", selectedClass);

            //object methodResult = classMethods.Invoke(obj, null);

            Assert.IsFalse(ContainsIllegalChars);
        }

    }
}
