using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using WhyFSharp.CSharp;

namespace WhyFSharp.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {

            var test = new Model.TwoDPointF(1,2);
            var test2 = new TwoDPointC(1, 2);

            //Console.WriteLine(FoldTextToOneLineV1("kalsjdfosdaoijsdlkdsjfkl sdklfjal,sdjkflsadjflkadf,asdfasdf,dfsafd,        ,sdf", 2, ":)"));
            //Console.WriteLine(FoldTextToOneLineV2("kalsjdfosdaoijsdlkdsjfkl sdklfjal,sdjkflsadjflkadf,asdfasdf,dfsafd,        ,sdf", 2, ":)"));

            //Console.WriteLine(test);
            //Console.WriteLine(test2);
            //ComparePoints();
            //PrintAsync();

            var t = Enumerable.Empty<int>().Max(a => a, 0).ToString();

        }

        #region Working with lists
        private static string FoldTextToOneLineV1(string s, int maxLines, string foldSeperator)
        {
            List<string> lines = new List<string>();
            string[] strings = s.Split('\n', ',', ';');
            foreach (string line in strings)
            {
                string trimmedLine = line.Trim();
                if (trimmedLine.Length > 0)
                {
                    lines.Add(trimmedLine);
                    if (lines.Count >= maxLines)
                    {
                        break;
                    }
                }
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < lines.Count; i++)
            {
                sb.Append(lines[i]);
                if (i < lines.Count - 1)
                {
                    sb.Append(foldSeperator);
                }
            }

            return sb.ToString();
        }

        private static string FoldTextToOneLineV2(string multiLineString, int maxLines, string foldSeperator)
        {
            return multiLineString.Split('\n', ',', ';')
                                  .Select(line => line.Trim())
                                  .Where(trimmedLine => trimmedLine.Length > 0)
                                  .Take(maxLines)
                                  .Aggregate((first, second) => first + foldSeperator + second);
        }
        #endregion
        #region Primitive obsession - part 1
        private static void PrimitiveObsessionBasic()
        {
            string testString = "sjfjfmdf";
            var opStr = GetLongString(testString);
            if (opStr.HasValue)
            {
                Console.WriteLine("Long string: " + opStr.Get());
            }
            else
            {
                Console.WriteLine("No string there");
            }
        }

        private static Option<string> GetLongString(string str)
        {
            return Option<string>.OfObject(str)
                .Where(s => s.Length > 3)
                .Select(s => s + s);
        }
        #endregion

        #region Primitive obsession - part 2
        private static void PrimitiveObsessionLessBasic()
        {
            var c = CustomerId.Create("Na".Repeat(7) + " Batman!");
            if (c.HasValue)
            {
                DoSomethingWithCustomerId(c.Get());
            }
            else
            {
                Console.WriteLine("Invalid customer");
            }
        }



        private static void DoSomethingWithCustomerId( CustomerId c)
        {
            Console.WriteLine(c);
        }
        #endregion


        #region F# async
        private static async void PrintAsync()
        {
            CancellationTokenSource cts = new CancellationTokenSource(1000);
            try
            {
                string test = await Async.DelayPrint(5000, "Finished", cts.Token);
                Console.WriteLine(test);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("I've been cancelled!");
            }
        }
        #endregion

        private static void ComparePoints()
        {
            var pointC1 = new TwoDPointC(1, 2);
            var pointC2 = new TwoDPointC(1, 2);
            var pointC3 = new TwoDPointC(1, 3);

            Console.WriteLine(CompareObjects(pointC1, pointC1));
            Console.WriteLine(CompareObjects(pointC1, pointC2));
            Console.WriteLine(CompareObjects(pointC1, pointC3));

            var pointF1 = new Model.TwoDPointF(1, 2);
            var pointF2 = new Model.TwoDPointF(1, 2);
            var pointF3 = new Model.TwoDPointF(1, 3);

            Console.WriteLine(CompareObjects(pointF1, pointF1));
            Console.WriteLine(CompareObjects(pointF1, pointF2));
            Console.WriteLine(CompareObjects(pointF1, pointF3));
        }

        private static string CompareObjects(object first, object second)
        {
            return string.Format("{0} \n{1} \nare equal? {2}", first, second, first.Equals(second));
        }


    }
}
