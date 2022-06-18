using System;

namespace Aurora.Math
{
    public class Bytes
    {
        public enum MathBase
        {
            Binary = 2,
            Decimal = 10
        }

        public enum UnitFactor
        {
            Byte = 0,
            Kilo = 1,
            Mega = 2,
            Giga = 3,
            Tera = 4,
            Peta = 5,
            Exa = 6,
            Zetta = 7,
            Yotta = 8
        }

        private static Unit[] m_Units = new Unit[]
                                        {
                                            new Unit(UnitFactor.Byte, MathBase.Decimal, "Byte", "Byte"),
                                            new Unit(UnitFactor.Kilo, MathBase.Decimal, "kB", "Kilobyte"),
                                            new Unit(UnitFactor.Kilo, MathBase.Binary, "KiB", "Kibibyte"),
                                            new Unit(UnitFactor.Mega, MathBase.Decimal, "MB", "Megabyte"),
                                            new Unit(UnitFactor.Mega, MathBase.Binary, "MiB", "Mebibyte"),
                                            new Unit(UnitFactor.Giga, MathBase.Decimal, "GB", "Gigabyte"),
                                            new Unit(UnitFactor.Giga, MathBase.Binary, "GiB", "Gibibyte"),
                                            new Unit(UnitFactor.Tera, MathBase.Decimal, "TB", "Terabyte"),
                                            new Unit(UnitFactor.Tera, MathBase.Binary, "TiB", "Tebibyte"),
                                            new Unit(UnitFactor.Peta, MathBase.Decimal, "PB", "Petabyte"),
                                            new Unit(UnitFactor.Peta, MathBase.Binary, "PiB", "Pebibyte"),
                                            new Unit(UnitFactor.Exa, MathBase.Decimal, "EB", "Exabyte"),
                                            new Unit(UnitFactor.Exa, MathBase.Binary, "EiB", "Exbibyte"),
                                            new Unit(UnitFactor.Zetta, MathBase.Decimal, "ZB", "Zettabyte"),
                                            new Unit(UnitFactor.Zetta, MathBase.Binary, "ZiB", "Zetbibyte"),
                                            new Unit(UnitFactor.Yotta, MathBase.Decimal, "YB", "Yottabyte"),
                                            new Unit(UnitFactor.Yotta, MathBase.Binary, "YiB", "Yotbibyte")
                                        };

        public static Unit[] Units
        {
            get { return m_Units; }
            set { m_Units = value; }
        }

        public static String GetUnitShortName(UnitFactor unit, MathBase mathbase)
        {
            Unit foundunit = GetUnit(unit, mathbase);
            if (foundunit != null)
                return (foundunit.ShortName);
            else
                return ("");
        }

        public static String GetUnitLongName(UnitFactor unit, MathBase mathbase)
        {
            Unit foundunit = GetUnit(unit, mathbase);
            if (foundunit != null)
                return (foundunit.LongName);
            else
                return ("");
        }

        public static String GetUnitFormat(UnitFactor unit, MathBase mathbase)
        {
            Unit foundunit = GetUnit(unit, mathbase);
            if (foundunit != null)
                return (foundunit.Format);
            else
                return ("#,#");
        }

        public static Unit GetUnit(UnitFactor unit, MathBase mathbase)
        {
            foreach (Unit ActUnit in m_Units)
            {
                if (ActUnit.Factor == unit && ActUnit.Base == mathbase)
                    return (ActUnit);
            }
            return (null);
        }

        public class Unit
        {
            public MathBase Base;
            public UnitFactor Factor;
            public String Format;
            public String LongName;
            public String ShortName;

            public Unit(UnitFactor _Factor, MathBase _Base, String _Shortname, String _Longname)
            {
                Factor = _Factor;
                Base = _Base;
                ShortName = _Shortname;
                LongName = _Longname;
                Format = "N" + (int) Factor;
            }

            private Int64 Power
            {
                get { return ((int) Factor*(Base == MathBase.Binary ? 10 : 3)); }
            }

            public override string ToString()
            {
                return (ShortName);
            }

            public double ComputeBytesFractioned(Int64 ByteValue)
            {
                return (ByteValue/System.Math.Pow((int) Base, Power));
            }

            public Int64 ComputeBytes(Int64 ByteValue)
            {
                return (Convert.ToInt64(ByteValue/System.Math.Pow((int) Base, Power)));
            }

            public String ComputeBytesAndFormat(Int64 ByteValue)
            {
                return (ComputeBytesFractioned(ByteValue).ToString(Format));
            }
        }
    }
}
