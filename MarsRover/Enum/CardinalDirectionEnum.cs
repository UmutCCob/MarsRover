using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Enum
{
    public enum CardinalDirectionEnum
    {
        North,
        East,
        South,
        West
    }


    public static class CardinalDirectionEnumExtensions
    {
        public static string ToReportString(this CardinalDirectionEnum directionEnum)
        {
            switch (directionEnum)
            {
                case CardinalDirectionEnum.North:
                    return "N";
                case CardinalDirectionEnum.East:
                    return "E";
                case CardinalDirectionEnum.South:
                    return "S";
                case CardinalDirectionEnum.West:
                    return "W";
                default:
                    return string.Empty;
            }
        }
    }
}
