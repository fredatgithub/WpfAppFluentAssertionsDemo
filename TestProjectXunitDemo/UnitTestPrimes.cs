using LibraryHelper;
using Xunit;

namespace TestProjectXunitDemo
{
  public class UnitTestPrimes
  {
    [Fact]
    public void Test_Is_prime_2()
    {
      const int source = 2;
      const bool expected = true;
      bool result = Helper.IsPrime(source);
      Assert.Equal(expected, result);
    }
  }
}
