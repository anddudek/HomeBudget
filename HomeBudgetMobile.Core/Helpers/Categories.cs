using System;
using System.Collections.Generic;
using System.Text;

namespace HomeBudgetMobile.Helpers
{
    public class Categories
    {
        public static Category Kosmetyki = new Category("Kosmetyki", "60F25B6E-E3CB-411D-A235-429F194EB60A");

        public static Category Wplata = new Category("Wpłata", "C041805D-5CEA-4043-B349-554ABB638EA4");

        public static Category Ubrania = new Category("Ubrania", "AAA8E4DC-4CDC-4A79-9CEE-6ECE0FABEF48");

        public static Category Lunch = new Category("Lunch", "72854A02-C1EB-48FD-99A7-7347DE77B7BE");

        public static Category NieplanowaneWydatki = new Category("Nieplanowane wydatki", "C902CD38-6F34-4FF8-8F44-BC1223B9942F");

        public static Category Rozrywka = new Category("Rozrywka", "6781E6AD-71A0-4469-89B5-E529BFFB3970");

        public static Category ZakupyDoDomu = new Category("Zakupy do domu", "F08AB977-107C-4F2C-8102-F191F5CA475E");

        public static string GetCategoryName(Guid catId)
        {
            List<Category> categories = new List<Category> { Kosmetyki, Wplata, Ubrania, Lunch, NieplanowaneWydatki, Rozrywka, ZakupyDoDomu };
            foreach (var cat in categories)
            {
                if (cat.CatGuid.ToUpper().Equals(catId.ToString().ToUpper()))
                {
                    return cat.CatName;
                }
            }
            return null;
        }

        public static Guid GetCategoryGuid(string catName)
        {
            List<Category> categories = new List<Category> { Kosmetyki, Wplata, Ubrania, Lunch, NieplanowaneWydatki, Rozrywka, ZakupyDoDomu };
            foreach (var cat in categories)
            {
                if (cat.CatName.ToUpper().Equals(catName.ToString().ToUpper()))
                {
                    return new Guid(cat.CatGuid);
                }
            }
            return Guid.Empty;
        }
    }
}
