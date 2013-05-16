using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GraphicsData
{
    class IOFile
    {
        public int Read(string filename, Data data)
        {
            FileInfo fi1 = new FileInfo(filename);
            if (fi1.Exists)
            {
                try
                {
                    StreamReader sr = fi1.OpenText();
                    int i = 0;
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        int val1 = (int)Convert.ToInt32(line.Split(' ')[0]);
                        int val2 = (int)Convert.ToInt32(line.Split(' ')[1]);
                        data.X.Add(val1);
                        data.Y.Add(val2);
                        if (val2 > data.Y[data.MaxInd])
                            data.MaxInd = i;
                        i++;
                    }
                    sr.Close();
                }
                catch (Exception ex)
                {
                    return 2;
                }
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
