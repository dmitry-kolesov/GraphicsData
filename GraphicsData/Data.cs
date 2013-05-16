using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicsData
{
    class Data
    {
        private List<int> valuesX = new List<int>();
        private List<int> valuesY = new List<int>();
        private int maxInd = 0;

        public int MaxInd
        {
            get { return maxInd; }
            set { maxInd = value; }
        }

        public List<int> Y
        {
            get { return valuesY; }
        }

        public List<int> X
        {
            get { return valuesX; }
        }
    }
}
