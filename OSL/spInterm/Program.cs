var listA = Enumerable.Range(1, 20).ToList();
var listB = Enumerable.Range(101, 20).ToList();

var listACount = listA.Count();
var listBCount = listB.Count();

var colBenchList = new List<int> { 2, 3, 4, 3, 4, 5, 5 };
var row = colBenchList.Count();
var studentPerBench = 3;
List<List<List<int>>> plans = new List<List<List<int>>>();

var isSeatSame = false;
var skipl1 = 0;
var skipl2 = 0;
for (int i = 0; i < row; i++)
{
    var sPlans = new List<List<int>>();
    for(int j = 0; j < studentPerBench; j++)
    {
        var sPlan = new List<int>();
        var sPlanEmptyCount = 0;
        if (j % 2 == 0)
        {
            sPlan = listA.Skip(skipl1).Take(colBenchList[i]).ToList();
            skipl1 += colBenchList[i];
        }
        else
        {
            sPlan = listB.Skip(skipl2).Take(colBenchList[i]).ToList();
            skipl2 += colBenchList[i];
        }

        if(listACount < skipl1 && listBCount > skipl2 && isSeatSame)
        {
            sPlanEmptyCount = colBenchList[i] - sPlan.Count;
            sPlan.AddRange(listB.Skip(skipl2).Take(sPlanEmptyCount).ToList());
            skipl2 += sPlanEmptyCount;
        }

        if(listBCount < skipl2 && listACount > skipl1 && isSeatSame)
        {
            sPlanEmptyCount = colBenchList[i] - sPlan.Count;
            sPlan.AddRange(listA.Skip(skipl1).Take(sPlanEmptyCount).ToList());
            skipl1 += sPlanEmptyCount;
        }

        sPlanEmptyCount = colBenchList[i] - sPlan.Count;
        for (int z = 0; z < sPlanEmptyCount; z++)
            sPlan.Add(0);

        sPlans.Add(sPlan);
    }
    plans.Add(sPlans);
}

Console.ReadKey(true);