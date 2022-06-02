using Entity;

namespace Context.FakeData;

public static class FakeData
{
    public static List<Unit> Units => new()
    {
        new Unit
        {
            Id = 1,
            FaName = "متر",
            EnName = "Meter",
            Symbol = "m",
            FromBasic = "1",
            ToBasic = "1"
        },
        new Unit
        {
            Id = 2,
            FaName = "آمپر",
            EnName = "Ampere",
            Symbol = "A",
            FromBasic = "1",
            ToBasic = "1"
        },
        new Unit
        {
            Id = 3,
            FaName = "ثانیه",
            EnName = "Second",
            Symbol = "S",
            FromBasic = "1",
            ToBasic = "1"
        },
        new Unit
        {
            Id = 4,
            FaName = "گرم",
            EnName = "Gram",
            Symbol = "g",
            FromBasic = "1",
            ToBasic = "1"
        },
        new Unit
        {
            Id = 5,
            FaName = "سلسیوس",
            EnName = "Celsius",
            Symbol = "C",
            FromBasic = "1",
            ToBasic = "1"
        },
        new Unit
        {
            Id = 6,
            ParentId = 1,
            FaName = "میلی متر",
            EnName = "Millimeter",
            Symbol = "mm",
            ToBasic = "a / 1000",
            FromBasic = "a * 1000"
        },
        new Unit
        {
            Id = 7,
            ParentId = 1,
            FaName = "کیلومتر",
            EnName = "Kilometer",
            Symbol = "Km",
            ToBasic = "a * 1000",
            FromBasic = "a / 1000"
        },
        new Unit
        {
            Id = 8,
            ParentId = 2,
            FaName = "میلی آمپر",
            EnName = "Milliampere",
            Symbol = "mA",
            ToBasic = "a / 1000",
            FromBasic = "a * 1000"
        },
        new Unit
        {
            Id = 9,
            ParentId = 3,
            FaName = "میلی ثانیه",
            EnName = "Millisecond",
            Symbol = "mS",
            ToBasic = "a / 1000",
            FromBasic = "a * 1000"
        },
        new Unit
        {
            Id = 10,
            ParentId = 3,
            FaName = "دقیقه",
            EnName = "Minute",
            Symbol = "min",
            ToBasic = "a * 60",
            FromBasic = "a / 60"
        },
        new Unit
        {
            Id = 11,
            ParentId = 3,
            FaName = "ساعت",
            EnName = "Hour",
            Symbol = "H",
            ToBasic = "a * 3600",
            FromBasic = "a / 3600"
        },
        new Unit
        {
            Id = 12,
            ParentId = 4,
            FaName = "کیلو گرم",
            EnName = "Kilogram",
            Symbol = "mg",
            ToBasic = "a * 1000",
            FromBasic = "a / 1000"
        },
        new Unit
        {
            Id = 13,
            ParentId = 4,
            FaName = "میلی گرم",
            EnName = "Milligram",
            Symbol = "mg",
            ToBasic = "a / 1000",
            FromBasic = "a * 1000"
        },
        new Unit
        {
            Id = 14,
            ParentId = 5,
            FaName = "کلوین",
            EnName = "Kelvin",
            Symbol = "K",
            ToBasic = "a - 273.15",
            FromBasic = "a + 273.15"
        },
        new Unit
        {
            Id = 15,
            ParentId = 5,
            FaName = "فارنهایت",
            EnName = "Fahrenheit",
            Symbol = "F",
            ToBasic = "(a − 32) * 5 / 9",
            FromBasic = "(a * 9 / 5) + 32"
        },
        new Unit
        {
            Id = 16,
            ParentId = 5,
            FaName = "تست ۱",
            EnName = "Test 1",
            Symbol = "T1",
            ToBasic = "((a − 32) * 5) / 9",
            FromBasic = "((a * 9) / 5) + 32"
        },
        new Unit
        {
            Id = 17,
            ParentId = 5,
            FaName = "تست ۲",
            EnName = "Test 2",
            Symbol = "T2",
            ToBasic = "((a − 32) * 5) / (9 * 7)",
            FromBasic = "((a * 9) / 5) + (32 * 2)"
        }
    };

    public static List<Dimension> Dimensions => new()
    {
        new Dimension
        {
            FaName = "طول",
            EnName = "Length",
            UnitId = 1,
            UnitFaName = "متر",
            UnitEnName = "Meter",
            UnitSymbol = "m"
        },
        new Dimension
        {
            FaName = "جریان الکتریکی",
            EnName = "Electric current",
            UnitId = 2,
            UnitFaName = "آمپر",
            UnitEnName = "Ampere",
            UnitSymbol = "A"
        },
        new Dimension
        {
            FaName = "زمان",
            EnName = "Time",
            UnitId = 3,
            UnitFaName = "ثانیه",
            UnitEnName = "Second",
            UnitSymbol = "S"
        },
        new Dimension
        {
            FaName = "جرم",
            EnName = "Mass",
            UnitId = 4,
            UnitFaName = "گرم",
            UnitEnName = "Gram",
            UnitSymbol = "g"
        },
        new Dimension
        {
            FaName = "دما",
            EnName = "Temperature",
            UnitId = 5,
            UnitFaName = "سلسیوس",
            UnitEnName = "Celsius",
            UnitSymbol = "C"
        }
    };
}