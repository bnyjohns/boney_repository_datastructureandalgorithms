using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.DynamicProgramming
{
    class WeightedJobScheduling
    {
        private List<Job> GetJobs()
        {
            return new List<Job>
            {
                new Job{ StartTime = 1, EndTime = 2, Profit = 50},
                new Job{ StartTime = 3, EndTime = 5, Profit = 20},
                new Job{ StartTime = 6, EndTime = 19, Profit = 100},
                new Job{ StartTime = 2, EndTime = 100, Profit = 200}
            };
        }

        private List<Job> Sort(List<Job> input)
        {
            return input.OrderBy(j => j.EndTime).ToList();
        }

        private int GetLatestNonConflictJob(Job[] jobs, int i)
        {
            for (int j = i - 1; j >= 0; j--)
            {
                if (jobs[j].EndTime <= jobs[i].StartTime)
                    return j;
            }
            return -1;
        }

        public void GetJobsScheduled()
        {
            var jobs = Sort(GetJobs()).ToArray();
            int[] profit = new int[jobs.Length];
            bool[] includedJobIndexes = new bool[jobs.Length];
            profit[0] = jobs[0].Profit;
            includedJobIndexes[0] = true;

            for (int i = 1; i < jobs.Length; i++)
            {
                var includedProfit = jobs[i].Profit;
                var latestNonConflictJobIndex = GetLatestNonConflictJob(jobs, i);
                if (latestNonConflictJobIndex != -1)
                {
                    includedProfit += profit[latestNonConflictJobIndex];
                }

                if (includedProfit > profit[i - 1])
                {
                    includedJobIndexes[i] = true;
                    if (latestNonConflictJobIndex == -1)
                    {
                        int j = i - 1;
                        while (j >= 0)
                        {
                            includedJobIndexes[j] = false;
                            j--;
                        }
                    }
                    else
                    {
                        if (i - latestNonConflictJobIndex != 1)
                        {
                            for (int k = 0; k < latestNonConflictJobIndex; k++)
                            {
                                includedJobIndexes[k] = false;
                            }
                            for (int k = latestNonConflictJobIndex + 1; k < i; k++)
                            {
                                includedJobIndexes[k] = false;
                            }
                        }
                    }
                    profit[i] = includedProfit;
                }
                else
                {
                    profit[i] = profit[i - 1];
                }

            }

            var result = profit[jobs.Length - 1];

        }

        public class Job
        {
            public int StartTime { get; set; }
            public int EndTime { get; set; }
            public int Profit { get; set; }
        }
    }
}
