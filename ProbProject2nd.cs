using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace probProject2
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

                Array.Sort(data);
                int n = data.Length;

                double Percentile(double p)
                {
                    double pos = (p / 100.0) * (n - 1);
                    int lower = (int)pos;
                    double fraction = pos - lower;

                    if (lower + 1 < n)
                        return data[lower] + fraction * (data[lower + 1] - data[lower]);
                    else
                        return data[lower];
                }

                double q1 = Percentile(25);
                double q3 = Percentile(75);
                double iqr = q3 - q1;

                double lowerBound = q1 - 1.5 * iqr;
                double upperBound = q3 + 1.5 * iqr;

                Console.WriteLine("Outliers:");

                foreach (int x in data)
                {
                    if (x < lowerBound || x > upperBound)
                    {
                        Console.WriteLine(x + " is an outlier");
                    }
                }
            }
        }
    }
    