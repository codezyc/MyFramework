using System.Collections.Generic;

namespace CommonLibary.RegularExpressionExt
{
    /// <summary>
    /// 正则表达式常用扩展方法
    /// </summary>
    public static class RegularExpressionExt
    {
        /// <summary>
        /// Returns the input typed as a generic IEnumerable of the groups
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static IEnumerable<System.Text.RegularExpressions.Group> AsEnumerable(
            this System.Text.RegularExpressions.GroupCollection gc)
        {
            foreach (System.Text.RegularExpressions.Group g in gc)
            {
                yield return g;
            }
        }

        /// <summary>
        /// Returns the input typed as a generic IEnumerable of the matches
        /// </summary>
        /// <param name="mc"></param>
        /// <returns></returns>
        public static IEnumerable<System.Text.RegularExpressions.Match> AsEnumerable(this System.Text.RegularExpressions.MatchCollection mc)
        {
            foreach (System.Text.RegularExpressions.Match m in mc)
            {
                yield return m;
            }
        }
    }
}
