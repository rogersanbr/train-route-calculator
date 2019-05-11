using System;

namespace TrainRoute.Domain
{
    public static class ComparisonOperations
    {
        public enum ComparisonType
        {
            EqualTo,
            LessThan,
            LessOrEqualThan,
            GreaterThan,
            GreaterOrEqualThan,
        }

        public static Func<int, int, bool> EqualTo = (a, b) => a == b;
        public static Func<int, int, bool> LessThan = (a, b) => a < b;
        public static Func<int, int, bool> LessOrEqualThan = (a, b) => a <= b;
        public static Func<int, int, bool> GreaterThan = (a, b) => a > b;
        public static Func<int, int, bool> GreaterOrEqualThan = (a, b) => a >= b;

        public static Func<int, int, bool> FindOperation(ComparisonOperations.ComparisonType type)
        {
            switch (type)
            {
                case ComparisonType.EqualTo: return EqualTo;
                case ComparisonType.LessThan: return LessThan;
                case ComparisonType.LessOrEqualThan: return LessOrEqualThan;
                case ComparisonType.GreaterThan: return GreaterThan;
                case ComparisonType.GreaterOrEqualThan: return GreaterOrEqualThan;
                default: return EqualTo;
            }
        }
    }
}