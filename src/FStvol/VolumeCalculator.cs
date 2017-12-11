using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvol.Data;

namespace FStvol
{
    public class VolumeCalculator
    {

        public static double CalculateVolume(Tree tree, Regression regression)
        {
            return CalculateVolume(tree.DBH, regression.CoefficientA, regression.CoefficientB, regression.CoefficientC, regression.RegressModel);
        }

        public static double CalculateVolume(double dbh, double coef1, double coef2, double coef3, string currModel)
        {
            switch (currModel)
            {
                case RegressModel.LINEAR:
                    return coef1 + coef2 * dbh;
                case RegressModel.QUADRATIC:
                    return coef1 + coef2 * dbh + coef3 * dbh * dbh;
                case RegressModel.LOG:
                    return coef1 + coef2 * Math.Log(dbh);
                case RegressModel.POWER:
                    return coef1 * Math.Pow(dbh, coef2);
                default:
                    return 0.0;
            }
        }
    }
}
