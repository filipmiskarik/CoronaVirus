
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaVirus
{
    public readonly struct Coordinate
    {
        private readonly int stupenD;
        private readonly int minutaD;
        private readonly double sekundaD;

        private readonly int stupenS;
        private readonly int minutaS;
        private readonly double sekundaS;
        public Coordinate((int, int, double) delka, (int, int, double) sirka)
        {
            (stupenD, minutaD, sekundaD) = delka;
            (stupenS, minutaS, sekundaS) = sirka;
        }

        public static double RecountToDecimal((int, int, double) tupleUnit)
        {

            double a = tupleUnit.Item1;
            double b = tupleUnit.Item2;
            double c = tupleUnit.Item3;

            double mezi = a + b / 60;
            double finish = mezi + c / 3600;

            return finish;

        }

        public static (int, int, double) RecountToDegrees(double input)
        {
            int stupen = (int)input;
            double minuta = (input - stupen) * 60;
            double sekunda = (minuta - (int)minuta) * 60;
            return (stupen, (int)minuta, sekunda);
        }

        public static Coordinate operator +(Coordinate a, Coordinate b) =>
          new Coordinate(
              RecountToDegrees(
                RecountToDecimal((a.stupenD, a.minutaD, a.sekundaD)) + RecountToDecimal((b.stupenD, b.minutaD, b.sekundaD)))
              ,
              RecountToDegrees(
                RecountToDecimal((a.stupenS, a.minutaS, a.sekundaS)) + RecountToDecimal((b.stupenS, b.minutaS, b.sekundaS))));

        public static Coordinate operator -(Coordinate a, Coordinate b) =>
          new Coordinate(
              RecountToDegrees(
                RecountToDecimal((a.stupenD, a.minutaD, a.sekundaD)) - RecountToDecimal((b.stupenD, b.minutaD, b.sekundaD)))
              ,
              RecountToDegrees(
                RecountToDecimal((a.stupenS, a.minutaS, a.sekundaS)) - RecountToDecimal((b.stupenS, b.minutaS, b.sekundaS))));


        private static double DegToRad(double uhel)
        {
            return uhel * Math.PI / 180.0;
        }

        public double getKilometers(Coordinate toCompare)
        {


            double decimalDelkaA = RecountToDecimal((stupenD, minutaD, sekundaD));
            double decimalSirkaA = RecountToDecimal((stupenS, minutaS, sekundaS));

            double decimalDelkaB = RecountToDecimal((toCompare.stupenD, toCompare.minutaD, toCompare.sekundaD));
            double decimalSirkaB = RecountToDecimal((toCompare.stupenS, toCompare.minutaS, toCompare.sekundaS));

            double delka1 = DegToRad(decimalDelkaA);
            double sirka1 = DegToRad(decimalSirkaA);
            double delka2 = DegToRad(decimalDelkaB);
            double sirka2 = DegToRad(decimalSirkaB);

            return 6371 * Math.Acos(
                Math.Sin(sirka1) * Math.Sin(sirka2) + Math.Cos(sirka1) * Math.Cos(sirka2) * Math.Cos(delka2 - delka1)
                );
        }

        public override int GetHashCode()
        {
            //return HashCode.Combine(stupenD, minutaD, sekundaD, stupenS, minutaS, sekundaS);
            return Tuple.Create(stupenD, minutaD, sekundaD, stupenS, minutaS, sekundaS).GetHashCode();
        }

        public override string ToString()
        {
            return $"delka:[{stupenD}°,{minutaD}', {sekundaD}¨], sirka:[{stupenS}°,{minutaS}', {sekundaS}¨]";
        }

        public override bool Equals(object obj)
        {

            Coordinate coordinate = (Coordinate)obj;

            if (
                coordinate.stupenD == stupenD &&
                coordinate.minutaD == minutaD &&
                coordinate.sekundaD == sekundaD &&

                coordinate.stupenS == stupenS &&
                coordinate.minutaS == minutaS &&
                coordinate.sekundaS == sekundaS)
            {
                return true;
            }
            else return false;

        }
    };
}
