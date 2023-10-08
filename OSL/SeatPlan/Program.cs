var listA = new List<int>{
    1,2,3,4,5,6,7,8,9,23,24,25,26,27
};
var listB = new List<int>{
    11,22,33,44,55,66,77,88,99
};

var listACount = listA.Count;
var listBCount = listB.Count;

List<(List<int>, List<int>)> plans = new();

var colBenchList = new List<int> { 2, 3, 3, 3, 4 };

var skip = 0;
foreach (var colBench in colBenchList)
{
    var bsA = listA.Skip(skip).Take(colBench).ToList();
    var bsB = listB.Skip(skip).Take(colBench).ToList();

    skip += colBench;

    if (listACount < skip && listBCount > skip)
    {
        if (bsA == null)
        {
            bsA = new List<int>();
        }

        var bsAEmptyCount = colBench - bsA.Count;
        //skip += bsAEmptyCount;
        bsA.AddRange(listB.Skip(skip).Take(bsAEmptyCount).ToList());
        skip += bsAEmptyCount;
    }
    else
    {
        if (bsA == null)
        {
            bsA = new List<int>();
        }

        var bsAEmptyCount = colBench - bsA.Count;
        for (int i = 0; i < bsAEmptyCount; i++)
        {
            bsA.Add(0);
        }
    }

    if (listBCount < skip && listACount > skip)
    {
        if (bsB == null)
        {
            bsB = new List<int>();
        }

        var bsBEmtyCount = colBench - bsB.Count;
        bsB.AddRange(listA.Skip(skip).Take(bsBEmtyCount).ToList());
        skip += bsBEmtyCount;
    }
    else
    {
        if (bsB == null)
        {
            bsB = new List<int>();
        }

        var bsBEmptyCount = colBench - bsB.Count;
        for (int i = 0; i < bsBEmptyCount; i++)
        {
            bsB.Add(0);
        }
    }

    plans.Add((bsA, bsB));
}

Console.ReadKey();