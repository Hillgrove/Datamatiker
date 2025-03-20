using System;
using System.Linq;
using System.Reflection;

namespace ReflectionExample
{
    public class Tester
    {
        public void Run()
        {
            RunTest("Test of normal invocation:", TestNormal);
            RunTest("Test of invocation by reflection:", TestReflection);
        }

        private void RunTest(string desc, Action testMethod)
        {
            Console.WriteLine(desc);
            testMethod();
            Console.WriteLine();
            Console.WriteLine();
        }

        /// <summary>
        /// Simple test of BankAccount, using normal method invocation.
        /// </summary>
        private void TestNormal()
        {
            BankAccount acc = new BankAccount("Per");
            Console.WriteLine(acc);

            acc.Deposit(2545.60);
            Console.WriteLine(acc);

            bool tryWithdraw = acc.Withdraw(4500);
            Console.WriteLine($"{acc}  (withdraw successul: {tryWithdraw})");

            tryWithdraw = acc.Withdraw(1780);
            Console.WriteLine($"{acc}  (withdraw successul: {tryWithdraw})");
        }

        /// <summary>
        /// Test of BankAccount, using constructor and method invocation
        /// by reflection. Your starting point is the "self" reference,
        /// which refers to the application itself, seen as an assembly.
        /// </summary>
        private void TestReflection()
        {
            Assembly self = Assembly.GetExecutingAssembly();
            var selfTypes = self.GetTypes();

            // ===============================================

            Type bankType = null;
            ConstructorInfo constructor = null;

            foreach (Type type in selfTypes)
            {
                constructor = type.GetConstructor(new Type[] { typeof(string) });
                if (constructor != null)
                {
                    bankType = type;
                    break;
                }
            }

            //BankAccount acc = new BankAccount("Per");
            //Console.WriteLine(acc);
            var reflectionAccount = constructor.Invoke(new object[] { "Pers Reflective Method" });
            Console.WriteLine(reflectionAccount);

            // ===============================================

            MethodInfo reflectionDeposit = null;

            foreach (MethodInfo method in bankType.GetMethods())
            {
                if (method.ReturnType == typeof(void) &&
                    method.GetParameters().All(p => p.ParameterType == typeof(double)))
                {
                    reflectionDeposit = method;
                    break;
                }
            }

            //acc.Deposit(2545.60);
            //Console.WriteLine(acc);
            reflectionDeposit.Invoke(reflectionAccount, new object[] { 2545.60 });
            Console.WriteLine(reflectionAccount);

            // ===============================================

            MethodInfo reflectionWithDraw = null;

            foreach (MethodInfo method in bankType.GetMethods())
            {
                if (method.ReturnType == typeof(bool) &&
                    method.GetParameters().All(p => p.ParameterType == typeof(double)))
                {
                    reflectionWithDraw = method;
                    break;
                }
            }

            //bool tryWithdraw = acc.Withdraw(4500);
            //Console.WriteLine($"{acc}  (withdraw successul: {tryWithdraw})");
            bool tryReflectionWithdraw = (bool)reflectionWithDraw.Invoke(reflectionAccount, new object[] { 4500 });
            Console.WriteLine($"{reflectionAccount}  (withdraw successul: {tryReflectionWithdraw})");


            //tryWithdraw = acc.Withdraw(1780);
            //Console.WriteLine($"{acc}  (withdraw successul: {tryWithdraw})");
            tryReflectionWithdraw = (bool)reflectionWithDraw.Invoke(reflectionAccount, new object[] { 1780 });
            Console.WriteLine($"{reflectionAccount}  (withdraw successul: {tryReflectionWithdraw})");
        }
    }
}