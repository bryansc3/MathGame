string? numberOperation = "";
bool resultEnter = true;
char anotherOperation;
string[] numberList = { "1", "2", "3", "4" };

string operationResult = "";
List<string> operationList = new List<string>();

do
{
  while (resultEnter)
  {
    Console.Clear();
    Console.WriteLine("What operation you need know the result (Select a number): ");
    Console.WriteLine("1. Sum            ---> a + b");
    Console.WriteLine("2. Subtract       ---> a - b");
    Console.WriteLine("3. Multiplication ---> a * b");
    Console.WriteLine("4. Division       ---> a / b");
    Console.Write("Enter a number operation: ");

    numberOperation = Console.ReadLine();

    resultEnter = !numberList.Contains(numberOperation);
  }

  switch (numberOperation)
  {
    case "1":
      float[] sum = enterValues();
      operationResult = $"{sum[0]} + {sum[1]} = {sum[0] + sum[1]}";
      Console.WriteLine(operationResult);
      break;

    case "2":
      float[] subtract = enterValues();
      operationResult = $"{subtract[0]} - {subtract[1]} = {subtract[0] - subtract[1]}";
      Console.WriteLine(operationResult);
      break;

    case "3":
      float[] mult = enterValues();
      operationResult = $"{mult[0]} * {mult[1]} = {mult[0] * mult[1]}";
      Console.WriteLine(operationResult);
      break;

    case "4":
      float[] div = new float[2];
      bool divInteger = true;

      Console.WriteLine("Considered that \'a\' is between 0-100");

      while (divInteger)
      {
        div = enterValues();
        while (div[1] == 0 | div[0] > 100 | 0 > div[0])
        {
          if (div[1] == 0)
            Console.WriteLine("In a division \"b\" cannot be zero (a / b), please digit again \'a\' and \'b\'");

          if (div[0] > 100 | 0 > div[0])
            Console.WriteLine("Considered that \'a\' is between 0-100, please digit again \'a\' and \'b\'");

          div = enterValues();
        }

        divInteger = div[0] % div[1] != 0;

        if (divInteger)
          Console.WriteLine("I can divide only integers division!");
      }

      operationResult = $"{div[0]} / {div[1]} = {div[0] / div[1]}";
      Console.WriteLine(operationResult);
      break;
  }

  operationList.Add(operationResult);

  Console.Write("Do you want to perform another operation? Type 'y' -> Yes / any other key for Exit");
  anotherOperation = Console.ReadKey().KeyChar;
  resultEnter = Char.ToLower(anotherOperation) == 'y';

} while (resultEnter);

Console.Write("\nPress any key for end game");
Console.ReadKey();

Console.Clear();
Console.WriteLine("Your history for this game sesion:");
foreach (string operation in operationList)
{
  Console.WriteLine(operation);
}

static float[] enterValues()
{
  bool validNumber = true;
  float[] numbersList = new float[2];
  string? num1;
  string? num2;

  while (validNumber)
  {
    Console.Write("Enter a = ");
    num1 = Console.ReadLine();

    Console.Write("Enter b = ");
    num2 = Console.ReadLine();

    validNumber = !float.TryParse(num1, out numbersList[0]) | !float.TryParse(num2, out numbersList[1]);

    if (validNumber)
      Console.WriteLine("Wrong type for operation!");
  }
  return numbersList;
}