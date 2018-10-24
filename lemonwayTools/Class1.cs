using Newtonsoft.Json;
using System;
using System.Xml;

namespace lemonwayTools
{
    public static class StaticHelper
    {
        public static string XmlToJsonParser(string xmlValue)
        {
            if (string.IsNullOrEmpty(xmlValue))
                return string.Empty;

            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(xmlValue);
            }
            catch (XmlException)
            {
                return "Bad Xml format";
            }
            return JsonConvert.SerializeXmlNode(doc);
        }

        public static double FibonacciValue(int n)
        {
            if (1 > n || n > 100)
                return -1;
            //return _FibonacciValueRecursive(n);
            return _FibonacciValueIterative(n);
        }
        //private static double _FibonacciValueRecursive(int n)
        //{
        //    return (n < 2) ? n : _FibonacciValueRecursive(n - 2) + _FibonacciValueRecursive(n - 1);
        //}
        private static double _FibonacciValueIterative(int len)
        {
            int number = len;
            double[] Fib = new double[number + 1];
            Fib[0] = 0;
            Fib[1] = 1;
            for (int i = 2; i <= number; i++)
            {
                Fib[i] = Fib[i - 2] + Fib[i - 1];
            }
            return Fib[number];
        }
    }
}
