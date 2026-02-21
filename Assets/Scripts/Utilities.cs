using System.Linq;

public static class Utilities
{
    public static EYao ToYao(this string yao) => yao switch
    {
        "Lão Dương" => EYao.Yang,
        "Lão Âm" => EYao.Ying,
        "Thiếu Dương" => EYao.Yang,
        "Thiếu Âm" => EYao.Ying,
        _ => EYao.None
    };

    public static EYao ToBianYao(this string yao) => yao switch
    {
        "Lão Dương" => EYao.Ying,
        "Lão Âm" => EYao.Yang,
        "Thiếu Dương" => EYao.Yang,
        "Thiếu Âm" => EYao.Ying,
        _ => EYao.None
    };

    public static EYao ToCuoYao(this EYao yao) => yao switch
    {
        EYao.Yang => EYao.Ying,
        EYao.Ying => EYao.Yang,
        _ => EYao.None
    };

    public static EYao[] ToYaos(this (string Yao1, string Yao2, string Yao3, string Yao4, string Yao5, string Yao6) yaoTuple) => new[]
    {
        yaoTuple.Yao1.ToYao(),
        yaoTuple.Yao2.ToYao(),
        yaoTuple.Yao3.ToYao(),
        yaoTuple.Yao4.ToYao(),
        yaoTuple.Yao5.ToYao(),
        yaoTuple.Yao6.ToYao()
    };

    public static EYao[] ToBianYaos(this (string Yao1, string Yao2, string Yao3, string Yao4, string Yao5, string Yao6) yaoTuple) => new[]
    {
        yaoTuple.Yao1.ToBianYao(),
        yaoTuple.Yao2.ToBianYao(),
        yaoTuple.Yao3.ToBianYao(),
        yaoTuple.Yao4.ToBianYao(),
        yaoTuple.Yao5.ToBianYao(),
        yaoTuple.Yao6.ToBianYao()
    };

    public static EYao[] ToCuoYaos(this EYao[] benYaos) => benYaos.Select(x => x.ToCuoYao()).ToArray();

    public static bool IsLao(this string yao) => yao is "Lão Dương" or "Lão Âm";

    public static bool HasLao(params string[] yaos) => yaos.Any(x => x.IsLao());

    public static EGong ToGong(this (EYao Xia, EYao Zhong, EYao Shang) yaoTuple) => yaoTuple switch
    {
        (EYao.Yang, EYao.Yang, EYao.Yang) => EGong.Quian,
        (EYao.Yang, EYao.Yang, EYao.Ying) => EGong.Dui,
        (EYao.Yang, EYao.Ying, EYao.Yang) => EGong.Li,
        (EYao.Ying, EYao.Yang, EYao.Yang) => EGong.Xun,
        (EYao.Yang, EYao.Ying, EYao.Ying) => EGong.Zhen,
        (EYao.Ying, EYao.Yang, EYao.Ying) => EGong.Kan,
        (EYao.Ying, EYao.Ying, EYao.Yang) => EGong.Gen,
        (EYao.Ying, EYao.Ying, EYao.Ying) => EGong.Kun,
        _ => EGong.None
    };

    public static int ToGua(this (EGong Xia, EGong Shang) gongTuple) => gongTuple switch
    {
        (EGong.Quian, EGong.Quian) => 1,
        (EGong.Kun, EGong.Kun) => 2,
        (EGong.Zhen, EGong.Kan) => 3,
        (EGong.Kan, EGong.Gen) => 4,
        (EGong.Quian, EGong.Kan) => 5,
        (EGong.Kan, EGong.Quian) => 6,
        (EGong.Kan, EGong.Kun) => 7,
        (EGong.Kun, EGong.Kan) => 8,
        (EGong.Quian, EGong.Xun) => 9,
        (EGong.Dui, EGong.Quian) => 10,
        (EGong.Quian, EGong.Kun) => 11,
        (EGong.Kun, EGong.Quian) => 12,
        (EGong.Li, EGong.Quian) => 13,
        (EGong.Quian, EGong.Li) => 14,
        (EGong.Gen, EGong.Kun) => 15,
        (EGong.Kun, EGong.Zhen) => 16,
        (EGong.Zhen, EGong.Dui) => 17,
        (EGong.Xun, EGong.Gen) => 18,
        (EGong.Dui, EGong.Kun) => 19,
        (EGong.Kun, EGong.Xun) => 20,
        (EGong.Zhen, EGong.Li) => 21,
        (EGong.Li, EGong.Gen) => 22,
        (EGong.Kun, EGong.Gen) => 23,
        (EGong.Zhen, EGong.Kun) => 24,
        (EGong.Zhen, EGong.Quian) => 25,
        (EGong.Quian, EGong.Gen) => 26,
        (EGong.Zhen, EGong.Gen) => 27,
        (EGong.Xun, EGong.Dui) => 28,
        (EGong.Kan, EGong.Kan) => 29,
        (EGong.Li, EGong.Li) => 30,
        (EGong.Gen, EGong.Dui) => 31,
        (EGong.Xun, EGong.Zhen) => 32,
        (EGong.Gen, EGong.Quian) => 33,
        (EGong.Quian, EGong.Zhen) => 34,
        (EGong.Kun, EGong.Li) => 35,
        (EGong.Li, EGong.Kun) => 36,
        (EGong.Li, EGong.Xun) => 37,
        (EGong.Dui, EGong.Li) => 38,
        (EGong.Gen, EGong.Kan) => 39,
        (EGong.Kan, EGong.Zhen) => 40,
        (EGong.Dui, EGong.Gen) => 41,
        (EGong.Zhen, EGong.Xun) => 42,
        (EGong.Quian, EGong.Dui) => 43,
        (EGong.Xun, EGong.Quian) => 44,
        (EGong.Kun, EGong.Dui) => 45,
        (EGong.Xun, EGong.Kun) => 46,
        (EGong.Kan, EGong.Dui) => 47,
        (EGong.Xun, EGong.Kan) => 48,
        (EGong.Li, EGong.Dui) => 49,
        (EGong.Xun, EGong.Li) => 50,
        (EGong.Zhen, EGong.Zhen) => 51,
        (EGong.Gen, EGong.Gen) => 52,
        (EGong.Gen, EGong.Xun) => 53,
        (EGong.Dui, EGong.Zhen) => 54,
        (EGong.Li, EGong.Zhen) => 55,
        (EGong.Gen, EGong.Li) => 56,
        (EGong.Xun, EGong.Xun) => 57,
        (EGong.Dui, EGong.Dui) => 58,
        (EGong.Kan, EGong.Xun) => 59,
        (EGong.Dui, EGong.Kan) => 60,
        (EGong.Dui, EGong.Xun) => 61,
        (EGong.Gen, EGong.Zhen) => 62,
        (EGong.Li, EGong.Kan) => 63,
        (EGong.Kan, EGong.Li) => 64,
        _ => 0
    };

    public static int ToGua(this EYao[] yaos) => ((yaos[0], yaos[1], yaos[2]).ToGong(), (yaos[3], yaos[4], yaos[5]).ToGong()).ToGua();
}
