using System;
using System.Collections;

namespace Common
{
    public static class ArrayEdit
    {
        public static string[] ArraySortWithExceptDuplication(String[] strArray)
        {
            string[] ret = null;

            try
            {
                Array.Sort(strArray);

                ArrayList arrayList = new ArrayList(strArray.Length);

                foreach (string i in strArray)
                {
                    if (!arrayList.Contains(i) && i != null)
                    {
                        arrayList.Add(i);
                    }
                }

                ret = (string[])arrayList.ToArray(typeof(string));

                return ret;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
