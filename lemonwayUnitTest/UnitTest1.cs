using System;
using Xunit;

namespace lemonwayUnitTest
{

    public class UnitTest1
    {
        private const string testXml1 = "<TRANS><HPAY><ID>103</ID><STATUS>3</STATUS><EXTRA><IS3DS>0</IS3DS><AUTH>031183</AUTH></EXTRA><INT_MSG/><MLABEL>501767XXXXXX6700</MLABEL><MTOKEN>project01</MTOKEN></HPAY></TRANS>";
        private const string reslJson1 = "{\"TRANS\":{\"HPAY\":{\"ID\":\"103\",\"STATUS\":\"3\",\"EXTRA\":{\"IS3DS\":\"0\",\"AUTH\":\"031183\"},\"INT_MSG\":null,\"MLABEL\":\"501767XXXXXX6700\",\"MTOKEN\":\"project01\"}}}";
        [Theory]
        [InlineData("", "")]
        [InlineData("test", "Bad Xml format")]
        [InlineData(testXml1, reslJson1)]
        public void TestXmlToJsonParser(string xmlvalue, string jsonvalue)
        {
            string result = lemonwayTools.StaticHelper.XmlToJsonParser(xmlvalue);
            Assert.Equal(result, jsonvalue);
        }

        [Theory]
        [InlineData(0, -1)]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 3)]
        [InlineData(5, 5)]
        [InlineData(6, 8)]
        [InlineData(100, 3.54224848179262E+20)]
        [InlineData(-101, -1)]
        [InlineData(1000, -1)]
        public void TestFibonacciValue(int value, double resultTh)
        {
            double result = lemonwayTools.StaticHelper.FibonacciValue(value);
            Assert.Equal(result, resultTh);
        }
    }
}
