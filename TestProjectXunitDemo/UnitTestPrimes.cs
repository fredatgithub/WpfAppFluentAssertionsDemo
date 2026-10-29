using LibraryHelper;
using FluentAssertions;

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

    [Fact]
    public void Test_Is_prime_3()
    {
      const int source = 3;
      const bool expected = true;
      bool result = Helper.IsPrime(source);
      result.Should().Be(expected);
    }

    [Theory]
    [InlineData(-3, false)]
    [InlineData(0, false)]
    [InlineData(1, false)]
    [InlineData(2, true)]
    [InlineData(3, true)]
    [InlineData(4, false)]
    [InlineData(5, true)]
    [InlineData(9, false)]
    [InlineData(17, true)]
    
    public void Test_Is_prime(int source, bool expected)
    {
      bool result = Helper.IsPrime(source);
      result.Should().Be(expected);
    }
  }
}
