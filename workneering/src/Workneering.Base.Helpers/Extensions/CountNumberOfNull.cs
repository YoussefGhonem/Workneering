namespace Workneering.Base.Helpers.Extensions
{
    public static class CountNumberOfNull
    {
        public static int CountNumberOfnull(this object original)
        {
            int count = 0;
            foreach (var property in typeof(object).GetProperties())
            {
                if (property.GetValue(original) == null)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
