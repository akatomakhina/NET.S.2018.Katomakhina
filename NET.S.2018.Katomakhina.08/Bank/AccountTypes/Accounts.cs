using System;
using BankSystem;

namespace AccountTypes
{
    public class BaseAccount : AbstractAccount
    {
        protected override bool IsValidBalance(decimal value) => value >= 0;

        protected override int CalculateBanefitPoints(decimal amount) => (int)Math.Round(amount * 0.01m + Balance * 0.01m);
    }


    public class SilverAccount : AbstractAccount
    {
        protected override bool IsValidBalance(decimal value) => value > -1000;

        protected override int CalculateBanefitPoints(decimal amount) => (int)Math.Round(amount * 0.03m + Balance * 0.03m);
    }

    public class GoldAccount : AbstractAccount
    {
        protected override bool IsValidBalance(decimal value) => value > -10000;

        protected override int CalculateBanefitPoints(decimal amount) => (int)Math.Round(amount * 0.1m + Balance * 0.1m);
    }

    public class PlatinumAccount : AbstractAccount
    {
        protected override bool IsValidBalance(decimal value) => value > -50000;

        protected override int CalculateBanefitPoints(decimal amount) => (int)Math.Round(amount * 0.5m + Balance * 0.5m);
    }
}
