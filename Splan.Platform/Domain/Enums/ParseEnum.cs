namespace Splan.Platform.Domain.Enums
{
    public static class ParseEnum
    {
        public static string ParseIntToEnum(int id)
        {
            if (id >= 0 && id <= 5)
            {
                if (id == 0)
                {

                    return "Research";
                }
                else if (id == 1)
                {

                    return "Scholarship";
                }
                else if (id == 2)
                {

                    return "Trainee";
                }
                else if (id == 3)
                {

                    return "CLT";
                }
                else if (id == 4)
                {

                    return "PJ";
                }
            }
            return "MEI";
        }
    }
}
