using System;
using System.Linq;
using System.Reflection;

namespace CustomReflection
{
    public class MyCustomReflection
    {
        Assembly assembly;

        public MyCustomReflection(Assembly ass)
        {
            assembly = ass;
        }

        public MethodInfo[] GetMethods(Type typ)
        {
            //Get all methods in namespace
            return typ.GetMethods(BindingFlags.NonPublic |BindingFlags.Public | BindingFlags.Instance);
        }
        public MethodInfo GetMethod(string methodName,Type typ)
        {
            foreach (var item in typ.GetMethods(BindingFlags.NonPublic | BindingFlags.Public| BindingFlags.Instance))
            {
                if (item.Name == methodName)
                {
                    return item;
                }
            }

            return null;
        }

        public Type[] GetClasses(string nameSpace)
        {
            //Get all classes
            return assembly.GetTypes().Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
        }

        public Type GetClass(string className, Type[] classes)
        {
            foreach (var clas in classes)
            {
                if (clas.Name == className)
                {
                    return clas;
                }
            }
            return null;
        }

        public ConstructorInfo GetConstructor(Type classType, Type[] paramTypes)
        {
            //Get Constructor
            var constructors = classType.GetConstructors(BindingFlags.NonPublic| BindingFlags.Public | BindingFlags.Instance);
            foreach (var constructor in constructors)
            {
                var parameters = constructor.GetParameters();

                bool paramsMatch = true;

                for (int i = 0; i < paramTypes.Length; i++)
                {
                    if (paramTypes[i] != parameters[i].ParameterType)
                    {
                        paramsMatch = false;
                    }
                }

                if (paramsMatch)
                {
                    return constructor;
                }
            }
            return null;
        }

        public ConstructorInfo GetConstructorFromClass(string nameSpace, string className, Type[] constParamTypes)
        {
            Type[] classTypes = GetClasses(nameSpace);

            Type selectedClass = GetClass(className, classTypes);

            return GetConstructor(selectedClass, constParamTypes);

        }
    }
}
