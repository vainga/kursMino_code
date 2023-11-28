using Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode
{
    class matingClass
    {
        private double _MaxPercentage;

        public double CalculateCompatibility(corporationClass corporation, workerClass worker)
        {
            double compatibility = 0;
            if (corporation._Work_experience_need == true)
            {
                _MaxPercentage = 20;

                compatibility += CalculateSalaryCompatibility(corporation._Salary, worker._Salary_need, _MaxPercentage);

                compatibility += CalculateListCompatibility(corporation._Personal_qualities, worker._Personal_qualities, _MaxPercentage);

                compatibility += CalculateListCompatibility(corporation._Skills, worker._Skills, _MaxPercentage);

                compatibility += CalculateWECompatibility(corporation._Work_experience_min,corporation._Work_experience_max, worker._Work_experience, _MaxPercentage);

                return compatibility;
            }
            else
            {
                _MaxPercentage = 33;

                compatibility += CalculateSalaryCompatibility(corporation._Salary, worker._Salary_need, _MaxPercentage);

                compatibility += CalculateListCompatibility(corporation._Personal_qualities, worker._Personal_qualities, _MaxPercentage);

                compatibility += CalculateListCompatibility(corporation._Skills, worker._Skills, _MaxPercentage);

                return compatibility;
            }
        }

        private double CalculateSalaryCompatibility(double corpSalary, double workerSalaryNeed, double maxPercentage)
        {
            double difference = Math.Abs(corpSalary - workerSalaryNeed);
            double percentage = maxPercentage * (1-(difference / Math.Max(corpSalary, workerSalaryNeed))) * 100;
            return Math.Max(percentage, 0);
        }

        private double CalculateWECompatibility(double minNeedWE, double maxNeedWE, double workerWE, double maxPercentage)
        {
            if(workerWE > maxNeedWE)
            {
                return maxPercentage;
            }
            else
            {
                double range_WE = maxNeedWE - minNeedWE;
                double difference = Math.Min(Math.Abs(workerWE-minNeedWE),Math.Abs(maxNeedWE-workerWE));
                double percentage = maxPercentage * (1 - (difference / range_WE));
                return Math.Max(percentage, 0);
            }
        }

        private double CalculateListCompatibility(List<string> coprProp, List<string> workerProp, double maxPercentage)
        {
            if (coprProp == null || workerProp == null || coprProp.Count == 0 || workerProp.Count == 0)
            {
                return 0;
            }

            double commonSkillsCount = coprProp.Intersect(workerProp).Count();
            double percentage = (commonSkillsCount / maxPercentage) * 100;
            return Math.Max(percentage, 0);
        }
    }
}
