using MarsRover.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Helper
{
    public static class MovementHelper
    {
        public static List<MovementEnum> MovementParser(string movementString)
        {
            List<MovementEnum> moveList = new List<MovementEnum>();

            foreach (char move in movementString)
            {
                switch (move)
                {
                    case 'L':
                        moveList.Add(MovementEnum.Left);
                        break;
                    case 'R':
                        moveList.Add(MovementEnum.Right);
                        break;
                    case 'M':
                        moveList.Add(MovementEnum.Forward);
                        break;
                    default:
                        break;
                }
            }
            return moveList;

        }
    }
}
