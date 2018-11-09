using ALM_Inlamning1.UnitTestData;
using System;
using Xunit;

namespace xUnitTestBank
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1, 2000, "6500")]
        public void Deposit_CompareString(int number, int amount, string expected) //Verifiera r�tt summa efter ins�ttning
        {
            TransactionData generateTransaction = new TransactionData();

            var stringResult = generateTransaction.DepositMoney(number, amount);
            
            Assert.Equal(expected, stringResult);
        }


        [Theory]
        [InlineData(1, 2000, "2500")]
        [InlineData(1, 4600, "wrongAnswer")] //Finns bara 4500 p� kontot
        public void Withdraw_CompareString(int number, int amount, string expected) //Verifiera r�tt summa efter uttag
        {
            //Arrange
            TransactionData generateTransaction = new TransactionData();

            var stringResult = generateTransaction.WithdrawAmount(number, amount);

            //Assert
            Assert.Equal(expected, stringResult);
        }

        [Theory]
        [InlineData("Godk�nt", 1, 2000)]
        [InlineData("Godk�nt", 1, 4500)]
        [InlineData("Nekad" ,1, 4502)]
        public void Confirm_ReturnString(string expect, int number, int amount) //Verifiera f�r stort uttag
        {
            TransactionData confirmTransacion = new TransactionData();

            var compareExpectedValue = confirmTransacion.Verify(number,amount);

            Assert.Equal(expect, compareExpectedValue);
        }
    }
}
