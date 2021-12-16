// See https://aka.ms/new-console-template for more information


using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace Day13
{
    class Program
    {

        private const string inputTest = @"A0016C880162017C3686B18A3D4780";
        private const string inputTest2 = @"C200B40A82";


        private const string input =
            @"A20D5CECBD6C061006E7801224AF251AEA06D2319904921880113A931A1402A9D83D43C9FFCC1E56FF29890E00C42984337BF22C502008C26982801009426937320124E602BC01192F4A74FD7B70692F4A74FD7B700403170400F7002DC00E7003C400B0023700082C601DF8C00D30038005AA0013F40044E7002D400D10030C008000574000AB958B4B8011074C0249769913893469A72200B42673F26A005567FCC13FE673004F003341006615421830200F4608E7142629294F92861A840118F1184C0129637C007C24B19AA2C96335400013B0C0198F716213180370AE39C7620043E0D4788B440232CB34D80260008645C86D16C401B85D0BA2D18025A00ACE7F275324137FD73428200ECDFBEFF2BDCDA70D5FE5339D95B3B6C98C1DA006772F9DC9025B057331BF7D8B65108018092599C669B4B201356763475D00480010E89709E090002130CA28C62300265C188034BA007CA58EA6FB4CDA12799FD8098021400F94A6F95E3ECC73A77359A4EFCB09CEF799A35280433D1BCCA666D5EFD6A5A389542A7DCCC010958D85EC0119EED04A73F69703669466A048C01E14FFEFD229ADD052466ED37BD8B4E1D10074B3FF8CF2BBE0094D56D7E38CADA0FA80123C8F75F9C764D29DA814E4693C4854C0118AD3C0A60144E364D944D02C99F4F82100607600AC8F6365C91EC6CBB3A072C404011CE8025221D2A0337158200C97001F6978A1CE4FFBE7C4A5050402E9ECEE709D3FE7296A894F4C6A75467EB8959F4C013815C00FACEF38A7297F42AD2600B7006A0200EC538D51500010B88919624CE694C0027B91951125AFF7B9B1682040253D006E8000844138F105C0010D84D1D2304B213007213900D95B73FE914CC9FCBFA9EEA81802FA0094A34CA3649F019800B48890C2382002E727DF7293C1B900A160008642B87312C0010F8DB08610080331720FC580";

        static string  HexStringToBinary(string hexString)
        {
            var lup = new Dictionary<char, string>{
                { '0', "0000"},
                { '1', "0001"},
                { '2', "0010"},
                { '3', "0011"},

                { '4', "0100"},
                { '5', "0101"},
                { '6', "0110"},
                { '7', "0111"},

                { '8', "1000"},
                { '9', "1001"},
                { 'A', "1010"},
                { 'B', "1011"},

                { 'C', "1100"},
                { 'D', "1101"},
                { 'E', "1110"},
                { 'F', "1111"}};

            var ret = string.Join("", from character in hexString
                select lup[character]);
            return ret;
        }

        static long DecodeLong(string s)
        {
            long res = 0;
            foreach (var c in s)
            {
                res <<= 1;
                if (c == '1')
                {
                    res |= 1;
                }
            }

            return res;
        }

        static string ParseHeader(string s, out int version, out int type )
        {
            version = (int)DecodeLong(s.Substring(0, 3));
            type = (int)DecodeLong(s.Substring(3, 3));
            return s.Substring(6);
        }
        static string ParseLiteral(string s, out long literal )
        {
            int index = 0;
            StringBuilder sb = new StringBuilder();
            while (s[index] == '1')
            {
                sb.Append(s.Substring(index+1, 4));
                index += 5;
            }
            sb.Append(s.Substring(index+1, 4));
            index += 5;

            literal = DecodeLong(sb.ToString());

            return s.Substring(index);
        }

        static List<long> ParseGroups(string s, out int sumOfVersions )
        {
            sumOfVersions = 0;
            var res = new List<long>();
            while (s.Length > 0)
            {
                s = ParseGroup(s, out int sub, out long value);
                sumOfVersions += sub;
                res.Add(value);
            }

            return res;
        }

        static string ParseGroup(string s, out int sumOfVersions, out long value)
        {
            s = ParseHeader(s, out int version, out int type);
            sumOfVersions = version;
            if (type == 4)
            {
                return ParseLiteral(s, out value);
            }

            List<long> grpsValues;
            var lengthType = s[0];
            s = s.Substring(1);
            if (lengthType == '0')
            {
                int len = (int) DecodeLong(s.Substring(0, 15));
                grpsValues = ParseGroups(s.Substring(15, len), out int sumVers);
                sumOfVersions += sumVers;
                s = s.Substring(15 + len);
            }
            else
            {
                int len = (int) DecodeLong(s.Substring(0, 11));
                grpsValues = new List<long>(len);
                s = s.Substring(11);
                for (int i = 0; i < len; i++)
                {
                    s = ParseGroup(s, out int sumVers, out long val);
                    grpsValues.Add(val);
                    sumOfVersions += sumVers;
                }
            }

            if (type == 0)
            {
                value = grpsValues.Sum();
            }

            else if (type == 1)
            {
                value = grpsValues.Aggregate(1L, (m, v) => m * v);
                long inter = 1;
                foreach (var l in grpsValues)
                {
                    inter *= l;
                }
                Trace.Assert( inter == value);
            }
            else if (type == 2)
            {
                value = grpsValues.Min();
            }
            else if (type == 3)
            {
                value = grpsValues.Max();
            }
            else if (type == 5)
            {
                value = grpsValues[0] > grpsValues[1] ? 1 : 0;
            }
            else if (type == 6)
            {
                value = grpsValues[0] < grpsValues[1] ? 1 : 0;
            }
            else if (type == 7)
            {
                value = grpsValues[0] == grpsValues[1] ? 1 : 0;
            }
            else
            {
                throw new ArgumentException();
            }

            if (value < 0)
            {
                throw new OverflowException();
            }

            return s;
        }



        static void exo1()
            {

                var strings = inputTest.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim())
                    .ToArray();

                var bits = HexStringToBinary(strings[0]);
                var s = ParseGroup(bits, out var res, out var _);


                Console.WriteLine(res);


            }



            static void exo2() {
                var strings = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim())
                    .ToArray();

                var bits = HexStringToBinary(strings[0]);
                var s = ParseGroup(bits, out var _, out var res);


                Console.WriteLine(res);

            }

            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
                exo2();
            }
    }
}