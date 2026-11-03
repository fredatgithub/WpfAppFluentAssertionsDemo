using FluentAssertions;
using LibraryHelper;

namespace TestProjectXunitDemo
{
  public class UnitTestPrimes
  {
    [Fact]
    public void Test_Is_Prime_2()
    {
      const int source = 2;
      const bool expected = true;
      bool result = Helper.IsPrime(source);
      result.Should().Be(expected);
    }

    [Fact]
    public void Test_Is_Prime_3()
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
    [InlineData(19, true)]
    public void Test_Is_Prime(int source, bool expected)
    {
      bool result = Helper.IsPrime(source);
      result.Should().Be(expected);
    }
  }
}
