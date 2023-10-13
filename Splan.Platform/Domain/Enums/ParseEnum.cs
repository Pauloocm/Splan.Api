namespace Splan.Platform.Domain.Enums
{
    public static class ParseEnum
    {
        public static string ParseIntToEnum(int id)
        {
            if (id >= 1 && id <= 6)
            {
                if (id == 1)
                {

                    return "Research";
                }
                else if (id == 2)
                {

                    return "Scholarship";
                }
                else if (id == 3)
                {

                    return "Trainee";
                }
                else if (id == 4)
                {

                    return "CLT";
                }
                else if (id == 5)
                {

                    return "PJ";
                }
            }
            return "MEI";
        }
    }
}
