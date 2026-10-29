namespace LibraryHelper
{
  public static class Helper
  {
    public static int Add(int a, int b)
    {
      return a + b;
    }

    public static bool IsPrime(int number)
    {
      if (number <= 1) return false;
      if (number == 2 || number == 3 || number == 5 || number == 7) return true;
      if (number % 2 == 0 || number % 3 == 0 || number % 5 == 0 || number % 7 == 0) return false;
      for (int divisor  = 11; divisor * divisor <= number; divisor += 2)
      {
        if (number % divisor == 0) return false;
      }

      return true;
    }
  }
}
