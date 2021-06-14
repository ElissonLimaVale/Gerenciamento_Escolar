using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGIEscolar.Utils
{
    public static class Utils
    {
        public static List<SelectListItem> ToSelectList<T>(this List<T> lista, Func<T, String> getKey, Func<T, String> getValue, string selectValue, string noSelection = "Selecione ua opção", bool search = false)
        {
            var items = new List<SelectListItem>();
            if (search)
                items.Add(new SelectListItem { Selected = true, Value = string.Empty, Text = String.Format(" {0} ", noSelection) });
            foreach (var item in lista)
            {
                items.Add(new SelectListItem {
                    Value = getValue(item), 
                    Text = getKey(item),
                    Selected = selectValue.Equals(getValue(item))
                });
            }
            return items.OrderBy(x => x.Text).ToList();
        }
    }
}
