var listA = Enumerable.Range(1, 2).ToList();
var listB = Enumerable.Range(101, 20).ToList();

listA.Reverse();
listB.Reverse();

var stackA = new Stack<int>(listA);
var stackB = new Stack<int>(listB);

var colBenchList = new List<int> { 2, 3, 4, 3, 4 };
var row = colBenchList.Count();
int[][,] jaggedArray = new int[row][,];

int spb = 0;

Console.Write("Student Per Brench: ");
int.TryParse(Console.ReadLine(), out spb);

Console.Write("Zigzag type: ");
string zigzag = Console.ReadLine();

bool isZigzag = string.IsNullOrWhiteSpace(zigzag) ? false : zigzag == "0" ? false : true;
bool toggle = false;
int studentPerBrench = spb;


for (int i = 0; i < jaggedArray.GetLength(0); i++)
{
    jaggedArray[i] = new int[colBenchList[i], studentPerBrench];
    
    for (int j = 0; j < colBenchList[i]; j++)
    {
        for (int k = 0; k < studentPerBrench; k++)
        {
            if (isZigzag)
            {
                if ((i + j + k) % 2 == 0)
                    stackA.TryPop(out jaggedArray[i][j, k]);
                else
                    stackB.TryPop(out jaggedArray[i][j, k]);
            }
            else
            {
                if (k % 2 == 0)
                    stackA.TryPop(out jaggedArray[i][j, k]);
                else
                    stackB.TryPop(out jaggedArray[i][j, k]);
            }
            
        }        
    } 
}

/*          if (k % 2 == 0)
                stackA.TryPop(out jaggedArray[i][j, k]);
            else
               stackB.TryPop(out jaggedArray[i][j, k]);
//Hard:1
            if ((i + j + k) % 2 == 0)
                stackA.TryPop(out jaggedArray[i][j, k]);                
            else
                stackB.TryPop(out jaggedArray[i][j, k]); 
//Hard:2 
*/
for (int i = 0; i < jaggedArray.GetLength(0); i++)
{
    Console.WriteLine($"Column {i + 1}");
    for (int j = 0; j < jaggedArray[i].GetLength(0); j++)
    {
        for (int k = 0; k < jaggedArray[i].GetLength(1); k++)
            Console.Write($"[{i}][{j},{k}] = {jaggedArray[i][j, k]}\t");
        Console.WriteLine();
    }
    Console.WriteLine();
}

