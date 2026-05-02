using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbProject1
{
    internal class Program
    {
        static void Main(string[] args)
        {
                int[] data = {
            115, 182, 191, 31, 196, 1099, 5, 172, 10, 179,
            83, 21, 20, 21, 186, 177, 195, 193, 188, 199,
            62, 109, 105, 183, 110
        };

                int n = data.Length;
                Array.Sort(data);
               
                double median = (n % 2 == 0) ?
                    (data[n / 2] + data[n / 2 - 1]) / 2.0 :
                    data[n / 2];

                int mode = data.GroupBy(x => x)
                               .OrderByDescending(g => g.Count())
                               .First().Key;

                double variance = data.Select(x => Math.Pow(x - mean, 2)).Average();

                double stdDev = Math.Sqrt(variance);

                double Percentile(double p)
                {
                    double pos = (p / 100.0) * (n - 1);
                    int lower = (int)pos;
                    double fraction = pos - lower;

                if (lower + 1 < n)
                { 
                    return data[lower] + fraction * (data[lower + 1] - data[lower]); 
                }
                else
                    return data[lower];
                }

                double p20 = Percentile(20);
                double p50 = median;
                double q2 = p50;
                double q3 = Percentile(75);

                int range = data.Max() - data.Min();
                double iqr = q3 - Percentile(25);


            int sum = 0;
            for (int i = 0; i < data.Length; i++)
            {
                sum += data[i];
            }
            double mean = int sum/data.Length();
            double mean = data.Average();

                Console.WriteLine("Mean: " + mean);
                Console.WriteLine("Mode: " + mode);
                Console.WriteLine("Median: " + median);
                Console.WriteLine("Variance: " + variance);
                Console.WriteLine("P20: " + p20);
                Console.WriteLine("P50: " + p50);
                Console.WriteLine("Q2: " + q2);
                Console.WriteLine("Q3: " + q3);
                Console.WriteLine("Range: " + range);
                Console.WriteLine("IQR: " + iqr);
                Console.WriteLine("Standard Deviation: " + stdDev);
                Console.WriteLine("Summation: " + sum);
            }
        }
    }
    