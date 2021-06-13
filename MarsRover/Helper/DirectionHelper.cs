using MarsRover.Direction;
using MarsRover.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Helper
{
    public static class DirectionHelper
    {

        public static ICardinalDirection GetDirection(CardinalDirectionEnum cardinalDirection)
        {
            switch (cardinalDirection)
            {
                case CardinalDirectionEnum.North:
                    return new North();
                case CardinalDirectionEnum.East:
                    return new East();
                case CardinalDirectionEnum.South:
                    return new South();
                case CardinalDirectionEnum.West:
                    return new West();
                default:
                    throw new Exception();
            }
        }

        public static CardinalDirectionEnum CardinalDirectionParser(string directionString)
        {
            switch (directionString)
            {
                case "N":
                    return CardinalDirectionEnum.North;
                case "E":
                    return CardinalDirectionEnum.East;
                case "S":
                    return CardinalDirectionEnum.South;
                case "W":
                    return CardinalDirectionEnum.West;
                default:
                    throw new Exception();
            }
        }
    }
}
