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




        static void exo1()
        {

            /*int targetXmin = 20;
            int targetXmax = 30;
            int targetYmin = -10;
            int targetYmax = -5;*/
            int targetXmin = 117;
            int targetXmax = 164;
            int targetYmin = -140;
            int targetYmax = -89;

            bool CanReachTarget(int startX, int startY, out int highY)
            {
                highY = 0;
                int positionX = 0;
                int positionY = 0;
                while (true)
                {
                    if (positionY < targetYmin || positionX > targetXmax)
                    {
                        return false;
                    }

                    positionX += startX;
                    positionY += startY;
                    highY = Math.Max(highY, positionY);

                    if (positionX >= targetXmin && positionX <= targetXmax && positionY >= targetYmin &&
                        positionY <= targetYmax)
                    {
                        return true;
                    }

                    if (startX > 0)
                    {
                        startX--;
                    }

                    startY--;

                }

            }


            int startXmin = 6;
            int startXmax = targetXmax + 1;

            int startYmin = 0;
            int startYMax = 2000;

            int highY = 0;
            for (int i = startXmin; i <= startXmax; i++)
            {
                for (int j = startYmin; j <= startYMax; j++)
                {
                    if (CanReachTarget(i, j, out var m))
                    {
                        highY = Math.Max(highY, m);
                    }
                }
            }


            Console.WriteLine(highY);


        }



            static void exo2() {

                /*int targetXmin = 20;
                          int targetXmax = 30;
                          int targetYmin = -10;
                          int targetYmax = -5;*/
                int targetXmin = 117;
                int targetXmax = 164;
                int targetYmin = -140;
                int targetYmax = -89;

                bool CanReachTarget(int startX, int startY, out int highY)
                {
                    highY = 0;
                    int positionX = 0;
                    int positionY = 0;
                    while (true)
                    {
                        if (positionY < targetYmin || positionX > targetXmax)
                        {
                            return false;
                        }

                        positionX += startX;
                        positionY += startY;
                        highY = Math.Max(highY, positionY);

                        if (positionX >= targetXmin && positionX <= targetXmax && positionY >= targetYmin &&
                            positionY <= targetYmax)
                        {
                            return true;
                        }

                        if (startX > 0)
                        {
                            startX--;
                        }

                        startY--;

                    }

                }


                int startXmin = 6;
                int startXmax = targetXmax + 1;

                int startYmin = targetYmin - 1;
                int startYMax = 2000;

                int count = 0;
                for (int i = startXmin; i <= startXmax; i++)
                {
                    for (int j = startYmin; j <= startYMax; j++)
                    {
                        if (CanReachTarget(i, j, out _))
                        {
                            count++;
                        }
                    }
                }


                Console.WriteLine(count);

            }

            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
                exo2();
            }
    }
}