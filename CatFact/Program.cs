namespace CatFact
{
    #region Usings

    using CatFact.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    #endregion Usings
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var helper = new CatFactHelper();
                helper.GetSomeFactsAboutCat();
                helper.GetSomeFactsAboutCat();
                helper.GetSomeFactsAboutCat();
                helper.GetSomeFactsAboutCat();
                helper.GetSomeFactsAboutCat();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("It's all over!");
            Console.ReadLine();
        }
    }
}
