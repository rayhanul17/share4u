var listA = Enumerable.Range(1, 20).ToList();
var listB = Enumerable.Range(101, 20).ToList();

var colBenchList = new List<int> { 2, 3, 4, 3, 4, 5, 5 };
var row = colBenchList.Count();
var studentPerBench = 3;
List<List<List<int>>> plans = new List<List<List<int>>>();

var skipl1 = 0;
var skipl2 = 0;
for (int i = 0; i < row; i++)
{
    var sPlans = new List<List<int>>();
    for(int j = 0; j < studentPerBench; j++)
    {
        var sPlan = new List<int>();
        if(j % 2 == 0)
        {
            sPlan = listA.Skip(skipl1).Take(colBenchList[i]).ToList();
            skipl1 += colBenchList[i];
        }
        else
        {
            sPlan = listB.Skip(skipl2).Take(colBenchList[i]).ToList();
            skipl2 += colBenchList[i];
        }

        sPlans.Add(sPlan);
    }
    plans.Add(sPlans);
}

Console.ReadKey(true);