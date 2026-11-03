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
      Assert.Equal(expected, result);
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

    [Fact]
    public void Test_Value_Start_With_And_End_With_and_Contain_and_HaveLength()
    {
      const string actual = "ABCDEFGHI";
      actual.Should().StartWith("AB").And.EndWith("HI").And.Contain("EF").And.HaveLength(9);
    }

    [Fact]
    public void Test_List_only_contain_and_HaveCount()
    {
      IEnumerable<int> numbers = new[] { 1, 2, 3 };
      numbers.Should().OnlyContain(n => n > 0);
      numbers.Should().HaveCount(3, "because we thought we put four items in the collection");
    }

    private sealed record Person(string Name, int Age);

    [Fact]
    public void Valeurs_et_objets_peuvent_etre_verifies()
    {
      object? value = "hello";
      value.Should().NotBeNull();
      value.Should().BeOfType<string>();
      value.Should().BeAssignableTo<object>();
      value.Should().Be("hello");
      value.Should().NotBe("goodbye");
      var actual = new Person("Alice", 30);
      var expected = new Person("Alice", 30);
      actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Booleens_peuvent_etre_verifies()
    {
      true.Should().BeTrue();
      false.Should().BeFalse();
    }

    [Fact]
    public void Nombres_peuvent_etre_verifies()
    {
      var value = 10;
      value.Should().BeGreaterThan(5);
      value.Should().BeLessThan(20);
      value.Should().BeGreaterThanOrEqualTo(10);
      value.Should().BeLessThanOrEqualTo(10);
      value.Should().BePositive();
      (-3).Should().BeNegative();
      value.Should().BeInRange(1, 15);
    }

    [Fact]
    public void Chaines_peuvent_etre_verifiees()
    {
      var name = "Alice";
      name.Should().NotBeNullOrEmpty();
      name.Should().NotBeEmpty();
      name.Should().HaveLength(5);
      name.Should().Contain("lic");
      name.Should().NotContain("bob");
      name.Should().StartWith("Al");
      name.Should().EndWith("ce");
      name.Should().MatchRegex("^[A-Z][a-z]+$");
      name.Should().NotBeUpperCased();
    }

    [Fact]
    public void Chaines_peuvent_etre_verifiees_par_casse()
    {
      "ALICE".Should().BeUpperCased();
      "alice".Should().BeLowerCased();
    }

    [Fact]
    public void Collections_peuvent_etre_verifiees()
    {
      var numbers = new[] { 1, 2, 3 };

      numbers.Should().NotBeEmpty();
      numbers.Should().HaveCount(3);
      numbers.Should().Contain(2);
      numbers.Should().ContainSingle(n => n == 2);
      numbers.Should().OnlyContain(n => n > 0);
      numbers.Should().BeInAscendingOrder();

      var descending = new[] { 3, 2, 1 };
      descending.Should().BeInDescendingOrder();
    }

    [Fact]
    public void Exceptions_peuvent_etre_verifiees()
    {
      Action act = () => throw new InvalidOperationException("Opération invalide");
      act.Should().Throw<InvalidOperationException>().WithMessage("Opération invalide");
      Action safeAct = () => { };
      safeAct.Should().NotThrow();
    }

    [Fact]
    public async Task Exceptions_asynchrones_peuvent_etre_verifiees()
    {
      Func<Task> act = async () =>
      {
        await Task.Yield();
        throw new InvalidOperationException("Erreur asynchrone");
      };

      await act.Should().ThrowAsync<InvalidOperationException>().WithMessage("Erreur asynchrone");
      Func<Task> safeAct = () => Task.CompletedTask;
      await safeAct.Should().NotThrowAsync();
    }

    [Fact]
    public void Dates_et_durees_peuvent_etre_verifiees()
    {
      var date = new DateTime(2025, 4, 15);
      date.Should().BeAfter(new DateTime(2025, 4, 14));
      date.Should().BeBefore(new DateTime(2025, 4, 16));
      date.Should().HaveDay(15);
      date.Should().HaveMonth(4);
      date.Should().HaveYear(2025);
      var actual = DateTime.UtcNow;
      actual.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(2));
    }

    [Fact]
    public async Task Etat_dune_tache_peut_etre_verifie()
    {
      Task completedTask = Task.CompletedTask;

      await completedTask;
      completedTask.IsCompletedSuccessfully.Should().BeTrue();

      Task canceledTask = Task.FromCanceled(new CancellationToken(canceled: true));

      canceledTask.IsCanceled.Should().BeTrue();

      Task faultedTask = Task.FromException(new InvalidOperationException("Erreur"));

      faultedTask.IsFaulted.Should().BeTrue();
    }

    [Fact]
    public async Task Une_operation_asynchrone_retourne_le_resultat_attendu()
    {
      Func<Task<int>> operation = async () =>
      {
        await Task.Yield();
        return 42;
      };

      var result = await operation();
      result.Should().Be(42);
    }

    [Fact]
    public async Task Une_operation_asynchrone_leve_une_exception()
    {
      Func<Task> operation = () => Task.FromException(new InvalidOperationException("Erreur"));

      await operation.Should().ThrowAsync<InvalidOperationException>().WithMessage("Erreur");
    }
  }
}
