using ALM_Inlamning1.UnitTestData;
using System;
using Xunit;

namespace xUnitTestBank
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1, 2000)]
        public void Deposit_ReturnTrue(int number, int amount) //Verifiera rätt summa efter insättning
        {
            TransactionData generateTransaction = new TransactionData();

            var booleanResult = generateTransaction.DepositMoney(number, amount);

            Assert.True(booleanResult);
        }


        [Theory]
        [InlineData(1, 2000)]
        public void Withdraw_ReturnTrue(int number, int amount) //Verifiera rätt summa efter uttag
        {
            //Arrange
            TransactionData generateTransaction = new TransactionData();

            var booleanResult = generateTransaction.WithdrawAmount(number, amount);

            //Assert
            Assert.True(booleanResult);
        }

        [Theory]
        [InlineData("Godkänt", 1, 2000)]
        [InlineData("Godkänt", 1, 4500)]
        [InlineData("Nekad" ,1, 4502)]
        public void Confirm_ReturnString(string expect, int number, int amount) //Verifiera för stort uttag
        {
            TransactionData confirmTransacion = new TransactionData();

            var compareExpectedValue = confirmTransacion.Verify(number,amount);

            Assert.Equal(expect, compareExpectedValue);
        }
    }
}
